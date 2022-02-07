   ## Aufgaben zur Service und Repository
   ### Aufgabe 1) Erstellen des Basis Interfaces IRepository<TId, TModel>
   Als aller ersten soll ein Interface in dem Projekt Fahrzeugverwaltung erstellt werden. Dieses Interface soll Methoden bereitstellen die CRUD Funktionalitäten darstellen.
   Folgende Methoden sollen bereitgestellt werden.
   ```
   void Save(TModel entity);
   TModel Get(TId ident);
   IEnumerable<TModel> GetAll();
   void Update(TModel entity);
   void Delete(TModel entity);
   ```
### Aufgabe 2) Erstellen der Service und Repository Interfaces
Nun soll das **IVehicleRepository** und das **IVehicelService** Interface erstellt werden. Dabei ist es wichtig, dass das **IVehicleRepository** von **IRepository<TId, TModel>** ableitet. Das **IVehicelService** soll wiederum vom **IVehicleRepository** ableiten

Wieso ist es wichtig, dass **IVehicelService** von **IVehicleRepository** ableitet?

### Aufgabe 3) Erstellen der Implementierungen
Jetzt sollen für die beiden Interfaces jeweils Implementierung erstellt werden. Implementierung sind hier in diesem Fall Klassen, die das Interfaces ableiten. 
Die Namen der Klassen sollen wie die Interface heißen. Dabei soll das I vorne weggelassen werden.

### Aufgabe 4) Implementierungen der Methoden für den VehicleService
Sollten alle Aufgabe bis hierhin richtig sein, sollte nun eine Klasse namens Vehicleservice vorhanden sein, die die Methodes aus Aufgabe 1 hat.
Da diese Methode von dem Repository ausgeführt werden soll im VehicleService einfach eine Instanz des VehicleRepository erstellt werden. 
