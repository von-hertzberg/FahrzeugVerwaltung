   ## Aufgaben zur Grafische Darstellung mit WPF 
   ### Aufgabe 1) Erweitern des MainWindow.xaml
Diese Aufgaben behandeln das Projekt **FahrzeugVerwaltung.UI**. Dabei soll nun das vorhandene **MainWindow.XAML** um zwei Eingabemöglichkeiten erweitert werden. 
|Name|Datentyp  |Erklärung
|--|--|--|
| Model| string  |Gibt das Model des Vehicles an
|Brand|string| Gibt die Marke des Models an

Bei der Umsetzung muss darauf geachtet werden, dass die Position des Buttons im Gridsystem nach  unten angepasst werden muss.
### Aufgabe 2) Erweitern des VehicleViewModel
In dieser Aufgabe muss das ViewModel um die beiden Eigenschaften aus Aufgabe 1 erweitert werden. Dabei soll das Binding zum Einsatz kommen, welches das ViewModel und Window verbindet 
### Aufgabe 3) Ausführen des Buttons
Der Button **"speichern"** führt beim Klicken die Methode **"save()"** aus. Diese gibt bisher eine leere **MessageBox** aus. Diese Box soll jedoch nun die im Fenster eingegebenen Werte anzeigen. 
Beispiel:
`Es wurde folgendes Fahrzeug angelegt: Typ: PKW, Marke: Mercedes Benz, Modell: A-Klasse `

### Aufgabe 4) Anzeigen der Vehicle in einer Listbox
Es sollen allen angelegten Vehicle unterhalb des Button **"speichern"** angezeigt werden, dazu soll das WPF Control **ListBox** genutzt werden. Die Quelle der Items soll eine **ObservableCollection** vom Typ Vehicle sein.
 Sobald ein Fahrzeug nun gespeichert wird, soll dieses in der Listbox angezeigt werden.
### Aufgabe 5) Anzeigen der Eigenschaften des Vehicle in der Listbox (DataTemplating)
Da in der vorigen Aufgabe nicht spezifiert wurde, was angezeigt wurde, soll nun das Vehicle wie folgt in der Listbox angezeigt werden
[Type] [Brand] [Modell] Dabei soll der Type des Fahrzeug fett gedruckt sein

### Aufgabe 6) Laden von Vehicles bei dem Start der Applikation (Dictionaries, Random)
Da beim Start der Applikation, die Liste der Vehicle leer ist, sollen nun 3-5 Vehicle (jedesmal zufällig) angelegt werden. Dabei ist die "Brand" von dem "Type" abhängig und das "Model" wiederum von der "Brand" 

### Aufgabe 7) Bearbeiten der vorhandenen Vehicle
Dem Benutzer soll es ermöglicht werden vorhandene Vehicles zu bearbeiten. Dafür sollen die Daten des aktuellen Vehicles oben angezeigt werden

### Aufgabe 8) Erstellen eines Contextmenus
Die Listbox soll nun ein Contextmenu bekommen. Dabei soll dieses Menü folgende Punkte beinhalten. 
`Neu
-Bearbeiten
-Löschen
`
Dieses Contextmenu soll bei einem Rechtsklick in der Listbox erscheinen. 
Dabei sollen alle Punkte beim Anklicken eine Messagebox mit ausgeben.

### Aufgabe 9) Löschen von Fahrzeugen
Der Menüpunkt **"löschen"** soll das ausgewählte Fahrzeug aus der Listbox entfernen.

### Aufgabe 10) Fenster zum Erstellen/Bearbeiten eines Vehicles
Es soll jetzt ein weiteres Fenster erstellt werden. Dieses Fenster soll das Anlegen und Bearbeiten der Vehicle übernehmen. 
Dabei sollen alle Eigenschaften eingebbar sein.

### Aufgabe 11) Menüpunkt "Neu" mit dem Fenster verknüpfen 
Sobald der Menupunkt "Neu" gerdrückt wird, soll das Fenster VehicleWindow erscheinen. Sobald ein Vehicle in dem neuen Fenster angelegt wird, soll sich dieses Fenster schließen.
Das neue Vehicle soll in der Listbox angezeigt werden. 

### Aufgabe 12) Menüpunkt "Bearbeiten" mit dem Fenster verknüpfen 
Sobald der Menupunkt "Bearbeiten" gerdrückt wird, soll das Fenster VehicleWindow erscheinen.Sobald ein Vehicle in dem neuen Fenster bearbeitet wurde, soll sich dieses Fenster schließen.
Das geänderte Vehicle soll in der Listbox angezeigt werden. 

### Aufgabe 13) Datatemplating
Die Darstellung der Vehicles in der Liste soll nun um eine Checkbox erweitert werden. In dieser soll nur ein Haken drin wenn das Fahrzeug vom Nutzer zur Zeit ausgewählt ist.

### Aufgabe 14) Visibility 
Die Menüpunkte Bearbeiten und Löschen sollen nur angezeigt werden, sofern ein Vehicle ausgewählt werden. Anderfalls sollen die Menüpunkte ausgegraut werden.  

### Aufgabe 15) Datenvalidierung per Validationrule
Bei dem Erstellen/Bearbeiten Fenster sollen die eingegeben Daten validiert werden. Dies soll über **ValidationRules** geschehen.
Dabei gilt:
-Marke muss länger als drei Buchstaben sein und darf keine Zahlen enthalten
-Modell muss länger als drei Buchstaben sein

### Aufgabe 16) Fahrzeuginformationen - Menüpunkt
Ein weiterer Menüpunkt namens **Fahrzeuginformation** soll hinzugefügt werden. Dieser Menüpunkt soll dafür sorgen, dass Informationen für das jeweilige Fahrzeug hinterlegt werden können. 

### Aufgabe 17) Fahrzeuginformationen - Fenster
Sobald der Menüpunkt **Fahrzeuginformation** gedrückt wird, soll ein Fenster erscheinen. Dieses Fenster soll ein Eingabefeld beinhalten und ein Button mit dem Content **Speichern**.In dem Eingabefeld kann man Informationen in Textform hinterlegen. Sobald gespeichert wird soll sich das Fenster schließen.

### Aufgabe 18) Styling
In dieser Aufgabe soll das Vehicle um die Eigenschaft `In Reparatur` erweitert werden. Diese Eigenschaft drückt ob ein Fahrzeug gerade in der Reparatur ist.
Dabei soll dies dem Nutzer in der Liste angezeigt werden, indem diese Fahrzeuge einen hellroten Hintergrund haben. Fahrzeuge die nicht `In Reparatur` sind sollen hellgrün angezeigt werden 

### Aufgabe 19) Erstellen eines Loginfensters
Damit nicht jeder das Programm nutzen kann, soll nun ein Loginfenster als erstes erscheinen. Dabei soll ein user seinen Namen und Passwort eingeben können. 

### Aufgabe 20) Speichern der Anmeldedaten
Das Loginfenster soll um eine Checkbox erweitert werden, die dem User ermöglicht, dass das Programm sich die Anmeldedaten merkt.
Die Daten sollen in einem Json gepseichert werden.

### Aufgabe 21) Programm schließen
Es soll im Hauptfenster eine Button eingeführt werden, über den der User das Programm beeden kann

### Aufgabe 22) Speichern der Liste aller Fahrzeuge
Sobald das Programm über den Button aus Aufgabe 21) beendet wird, sollen alle Fahrzeuge aus der Liste gespeichert werden. Die Datei soll unter `C:/dev/Excersice02/vehicles.json` gespeichert werden. 

### Aufgabe 23) Laden der Liste. 
Bei Programmstart soll nun (falls vorhanden) die Fahrzeuge geladen werden. Sollten keine Datei vorhanden sein. Sollen die zufälligen Daten angezeigt werden.


