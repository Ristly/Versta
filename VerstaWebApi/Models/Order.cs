using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace VerstaWebApi.Models;

public class Order
{
    public Guid Id { get; set; }

    [JsonIgnore]
    private string? _orderNumber {  get; set; }

    [BackingField(nameof(_orderNumber))]
    public string? OrderNumber
    {
        get => _orderNumber;
        set => _orderNumber = GenerateOrderNumber(value);
    }
    public string SenderCity { get; set; }
    public string SenderAddress { get; set; }
    public string ReceiverCity { get; set; }
    public string ReceiverAddress { get; set; }
    public double Weight { get; set; }
    public DateTime ReceiveDate { get; set; }

    private string GenerateOrderNumber(string id)
    {
        var number = new StringBuilder();
        var digits = id.Where(x => char.IsDigit(x));
        number.Append(string.Concat(digits.Take(3)));
        number.Append('-');
        number.Append(string.Concat(digits.Skip(3).Take(3)));
        return number.ToString();
    }
}