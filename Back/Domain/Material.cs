namespace Domain
{
    public class Material
    {
        public int Id { get; set; }
        public float Price { get; set; }
        public int MaterialTypeId { get; set; }
        public MaterialType MaterialType { get; set; }
    }
}