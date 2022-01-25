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
 
