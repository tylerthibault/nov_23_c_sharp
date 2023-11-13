#pragma warning disable CS8618
namespace DateValidator.Models;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public class Date
{   
    [Required]
    [DisplayName("Date")]
    [Old]
    public DateOnly ChosenDay {get; set;}
    
}

public class OldAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var TempDate = (DateOnly)value;
        var DateNow = DateOnly.FromDateTime(DateTime.Now);

        Console.WriteLine(TempDate);
        Console.WriteLine(DateNow);
        if(TempDate > DateNow)
        {
            return new ValidationResult("Date must be in the past");
        }
        else
        {
            return ValidationResult.Success;
        }
    }
}