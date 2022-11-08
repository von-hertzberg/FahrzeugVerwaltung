using System;
using System.Collections.Generic;
using System.IO;
using FahrzeugVerwaltung.Shared;
using System.Text.Json;
using Newtonsoft.Json;
using System.Threading;

namespace FahrzeugVerwaltung.Service
{
    public class VehicleConsoleService
    {
        private List<Vehicle> vehicleList = new List<Vehicle>();
        private int newIdent = 0;
        private Stack<int> unusedIdents = new Stack<int>();

        /// <summary>
        /// Prompts the user to input data necessary to create a vehicle.
        /// </summary>
        /// <returns>The vehicle created form user input.</returns>
        private Vehicle PromptVehicleInput()
        {

            int type = -1;

            while (true)
            {
                type = Helpers.ReadInt(@"Welchen Typ wollen Sie anlegen
1)PKW
2)LKW
" + Helpers.PromptBegin, "Ungültiger Fahrzeugtyp");

                if (!(type == 1 || type == 2))
                {
                    Helpers.PrintError("Ungültiger Fahrzeugtyp");
                    continue;
                }
                break;
            }

            Vehicle vehicle;
            switch (type)
            {
                case 1:
                    vehicle = new PKW();
                    vehicle.VehicleType = VehicleType.PKW;
                    break;
                default:
                    vehicle = new LKW();
                    vehicle.VehicleType = VehicleType.LKW;
                    break;
            }

            Console.WriteLine("Bitten Geben sie nun die Marke ein");
            Helpers.PrintPrompt();
            vehicle.Brand = Console.ReadLine();

            Console.WriteLine("Bitten Geben sie nun das Modell ein");
            Helpers.PrintPrompt();
            vehicle.Model = Console.ReadLine();

            if (vehicle.VehicleType == VehicleType.LKW)
            {
                ((LKW)vehicle).Capacity = Helpers.ReadDouble("Bitten Geben sie nun die Kapazität ein\n" + Helpers.PromptBegin, "Ungültige Eingabe");
            }

            return vehicle;
        }

        /// <summary>
        /// Generates a unique id.
        /// </summary>
        /// <returns>A unique id.</returns>
        private int GenerateId()
        {
            if (unusedIdents.Count != 0)
            {
                return unusedIdents.Pop();
            }
            else
            {
                var newId = newIdent;
                newIdent++;
                return newId;
            }
        }

        /// <summary>
        /// Displays a loading animation for 5 seconds.
        /// </summary>
        private void LoadingAnimation()
        {
            var (cursorX, cursorY) = Console.GetCursorPosition();

            var stepCount = 50;
            Console.Write('[');
            Console.SetCursorPosition(cursorX + stepCount + 1, cursorY);
            Console.Write(']');
            Console.SetCursorPosition(cursorX, cursorY);
            for (int i = 1; i < stepCount + 1; i++)
            {
                Console.SetCursorPosition(cursorX + i, cursorY);
                Console.Write('█');
                Thread.Sleep(5 * 1000 / stepCount);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Create a new vehicle.
        /// </summary>
        public void Save()
        {
            Vehicle newVehicle = PromptVehicleInput();

            Console.WriteLine("Das Fahrzeug wird hinzugefügt");
            LoadingAnimation();

            var index = vehicleList.FindIndex(v => v.Equals(newVehicle));
            if (index == -1)
            {
                newVehicle.Id = GenerateId();

                vehicleList.Add(newVehicle);

                Helpers.PrintSuccess(string.Format("Ein {0} wurde angelegt", newVehicle.VehicleType));
            }
            else
            {
                Helpers.PrintError("Das Fahrzeug existiert bereits");
            }

        }

        /// <summary>
        /// Delete an existing vehicle.
        /// </summary>
        public void Delete()
        {
            var id = Helpers.ReadInt("Bitte Geben sie die Id des zu entfernenden Fahrzeugs ein\n" + Helpers.PromptBegin, "Ungültige Eingabe");

            var index = vehicleList.FindIndex(v => v.Id == id);
            if (index != -1)
            {
                vehicleList.RemoveAt(index);
                unusedIdents.Push(index);

                Helpers.PrintSuccess(string.Format("Das Fahrzeug mit der Id {} wurde gelöscht", id));
            }
            else
            {
                Helpers.PrintError(string.Format("Das Fahrzeug mit der Id {} existiert nicht", id));
            }
        }

        /// <summary>
        /// Edit an existing vehicle.
        /// </summary>
        public void Update()
        {
            int index = -1;
            do
            {
                var id = Helpers.ReadInt("Bitte Geben sie nun den Ident ein\n" + Helpers.PromptBegin, "Ungültige Eingabe");
                index = vehicleList.FindIndex(v => v.Id == id);
                if (index == -1)
                    Helpers.PrintError("Die eingegebene Id ist ungültig");
            } while (index == -1);

            var newVehicel = PromptVehicleInput();
            newVehicel.Id = vehicleList[index].Id;
            vehicleList[index] = newVehicel;

            Helpers.PrintSuccess("Das Fahrzeug wurde erfolgreich bearbeitet");
        }

        public void GetAll()
        {
            foreach (var vehicle in vehicleList)
            {
                Console.WriteLine(vehicle.ToString());
            }
        }

        /// <summary>
        /// Print all existing vehicles.
        /// </summary>
        public void SaveToDisk()
        {
            string fileName;
            Console.WriteLine("Geben sie den Namen der Date zum Speichern ein, leer lassen für \"vehicles.json\"");
            Helpers.PrintPrompt();
            fileName = Console.ReadLine();

            if (fileName.Length == 0)
                fileName = "vehicles.json";

            var vehicleJson = JsonConvert.SerializeObject(vehicleList);

            using (var writer = File.CreateText(Path.Join(Helpers.BaseListPath, fileName)))
            {
                writer.Write(vehicleJson);
            }

            Helpers.PrintSuccess("Fahrzeugliste wurde erfolgreich abspeichert");
        }

        /// <summary>
        /// Load a vechicle list form Disk.
        /// </summary>
        public void LoadFromDisk()
        {
            var files = Directory.GetFiles(Helpers.BaseListPath);

            Console.WriteLine("Wählen sie eine der folgenden Dateien zum Laden aus");
            for (int i = 0; i < files.Length; i++)
            {
                Console.WriteLine(i + ") " + Path.GetFileName(files[i]));
            }

            int selectedIndex;
            while (true)
            {
                selectedIndex = Helpers.ReadInt(Helpers.PromptBegin, "Ungültiger Index");
                if (selectedIndex >= files.Length || selectedIndex < 0)
                {
                    Helpers.PrintError("Ungültiger Index");
                    continue;
                }

                break;
            }

            try
            {
                LoadFromDisk(files[selectedIndex]);
                Helpers.PrintSuccess("Fahrzeugliste wurde erfolgreich geladen");
            }
            catch (Exception e)
            {
                Helpers.PrintError("Fahrzeugliste konnte nicht geladen werden");
                Helpers.PrintError(e.Message);
            }
        }

        /// <summary>
        /// Load a vechicle list from Disk.
        /// </summary>
        /// <param name="filePath">The path of the vehicle json to load.</param>
        private void LoadFromDisk(string filePath)
        {
            var json = File.ReadAllText(filePath);

            JsonConverter[] converters = { new VehicleConverter() };

            vehicleList = JsonConvert.DeserializeObject<List<Vehicle>>(json, new JsonSerializerSettings() { Converters = converters });

            foreach (var vehicle in vehicleList)
            {
                vehicle.Id = GenerateId();
            }
        }
    }
}
