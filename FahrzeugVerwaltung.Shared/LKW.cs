namespace FahrzeugVerwaltung.Shared
{
    public class LKW : Vehicle
    {
        public double Capacity { get; set; }

        public override string ToString()
        {
            return base.ToString() + string.Format(", Capacity: {0}", Capacity);
        }
    }
}
