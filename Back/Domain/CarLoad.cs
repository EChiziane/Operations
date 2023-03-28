using System;

namespace Domain
{
    public class CarLoad
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public float Amount { get; set; }
        public int MaterialId { get; set; }
        public Material Material { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int DriverId { get; set; }
        public Driver Driver { get; set; }
        public int DestinationId { get; set; }
        public Destination Destination { get; set; }
    }
}