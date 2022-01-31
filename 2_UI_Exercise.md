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


