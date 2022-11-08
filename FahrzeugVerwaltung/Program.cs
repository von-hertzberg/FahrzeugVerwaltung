using FahrzeugVerwaltung.Service;
using FahrzeugVerwaltung.Shared;
using System;

namespace FahrzeugVerwaltung
{
    public class Program
    {
        private static string promptBegin = ">";

        private enum Action : int
        {
            Unknown = 0,
            Add = 1,
            Delete = 2,
            List = 3,
            Edit = 4,
            Save = 5,
            Quit = 10
        }

        private Action ChooseAction()
        {
            string formatString = @"Bitten wählen Sie die Aktion aus
{0}) Vehicle anlegen
{1}) Vehicle löschen
{2}) Alle Vehicle anzeigen
{3}) Vehicle bearbeiten
{4}) Vehicle Liste Speichern
{5}) Programm beenden";

            string chooseActionText = string.Format(formatString,
                (int)Action.Add,
                (int)Action.Delete,
                (int)Action.List,
                (int)Action.Edit,
                (int)Action.Save,
                (int)Action.Quit
            );

            System.Console.WriteLine(chooseActionText);

            try
            {
                var choice = (Action)Helpers.ReadInt(Helpers.PromptBegin, "Ungültige Eingabe");
                return choice;
            }
            catch (Exception)
            {
                return Action.Unknown;
            }
        }

        public void Run()
        {
            var vehicelService = new VehicleConsoleService();

            bool running = true;

            vehicelService.LoadFromDisk();

            while (running)
            {
                var action = ChooseAction();
                switch (action)
                {
                    case Action.Add:
                        vehicelService.Save();
                        break;
                    case Action.Delete:
                        vehicelService.Delete();
                        break;
                    case Action.List:
                        vehicelService.GetAll();
                        break;
                    case Action.Quit:
                        running = false;
                        break;
                    case Action.Edit:
                        vehicelService.Update();
                        break;
                    case Action.Save:
                        vehicelService.SaveToDisk();
                        break;
                    case Action.Unknown:
                    default:
                        Helpers.PrintWithColor("Keine gültige Aktion", ConsoleColor.Red);
                        break;
                }
            }
        }


        static void Main(string[] args)
        {
            Program program = new Program();
            program.Run();
        }
    }
}
