namespace PlaneApplication.Models
{
    public class Plane
    {
        public int PlaneId { get; set; }
        public string PlaneName { get; set; }
        public Type PlaneType { get; set; }
        public string PlanePrice { get; set; }
        public int PlaneYear { get; set; }
        public string PlaneManifacturer { get; set; }
        public string PlaneSerialNumber { get; set; }
        public string PlaneOwner { get; set; }
        public string CreatorId { get; set; }
    }

    public enum Type
    {
        Jet,
        PistonSingle,
        PistonAgricultural
    }
}
