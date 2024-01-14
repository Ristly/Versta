namespace VerstaWebApi.Models;

public class OrderDTO
{
    public string? OrderNumber { get; set; }
    public string SenderCity { get; set; }
    public string SenderAddress { get; set; }
    public string ReceiverCity { get; set; }
    public string ReceiverAddress { get; set; }
    public double Weight { get; set; }
    public DateTime ReceiveDate { get; set; }
}
