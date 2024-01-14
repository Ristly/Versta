using System.ComponentModel.DataAnnotations;

namespace VerstaWebApp.Services.Attributes;

public class DateValidation:ValidationAttribute
{
    public override bool IsValid(object? date)
    {
        var dateTime = (DateTime)date;
        return dateTime.Date > DateTime.Now.Date;
    }
}
