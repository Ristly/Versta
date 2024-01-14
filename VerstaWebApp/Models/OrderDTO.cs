using System.ComponentModel.DataAnnotations;
using VerstaWebApp.Services.Attributes;

namespace VerstaWebApp.Models;

public class OrderDTO
{
    public string? OrderNumber { get; set; }
    [Required]
    [DataType(DataType.Text)]
    [Display(Name="Sender's city")]
    public string SenderCity { get; set; }
    [Required]
    [DataType(DataType.Text)]
    [Display(Name = "Sender's address")]
    public string SenderAddress { get; set; }
    [Required]
    [DataType(DataType.Text)]
    [Display(Name = "Receiver's city")]
    public string ReceiverCity { get; set; }
    [Required]
    [DataType(DataType.Text)]
    [Display(Name = "Receiver's address")]
    public string ReceiverAddress { get; set; }

    [Required]
    [Range(0, double.MaxValue)]
    [Display(Name = "Weight")]
    public double Weight { get; set; }
    [Required]
    [DataType(DataType.Date)]
    [Display(Name = "Receive date")]
    [DateValidation(ErrorMessage = "Receive date can't be earlier than today.")]
    public DateTime ReceiveDate { get; set; }
}
