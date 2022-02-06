   ## Aufgaben zur Service und Repository
   ### Aufgabe 1) Erstellen des Basis Interfaces IRepository<TId, TModel>
   Als aller ersten soll ein Interface in dem Projekt Fahrzeugverwaltung erstellt werden. Dieses Interface soll Methoden bereitstellen die CRUD Funktionalitäten darstellen
   Folgende Methoden sollen bereitgestellt werden.
   ```
   void Save(TModel entity);
   TModel Get(TId ident);
   IEnumerable<TModel> GetAll();
   void Update(TModel entity);
   void Delete(TModel entity);
   ```
