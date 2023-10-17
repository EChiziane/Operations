namespace Application.Dtos;

public class CarLoadDto
{
    public string Costumer { get; set; }
    public string Driver { get; set; }
    public string Destiny { get; set; }
    public string Material { get; set; }
    public DateTime EndTime { get; set; }
    public float PaymentValue { get; set; }
    public string CreatedBy { get; set; }
    public string LastUpdateBy { get; set; }
}