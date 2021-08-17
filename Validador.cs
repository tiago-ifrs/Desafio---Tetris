using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

class Validador
{
    public static IEnumerable<ValidationResult> GValidationResults(object obj)
    {
        List<ValidationResult> validationResults = new List<ValidationResult>();
        ValidationContext context = new ValidationContext(obj, null, null);
        System.ComponentModel.DataAnnotations.Validator.TryValidateObject(obj, context, validationResults,
            true);
        return validationResults;
    }
}
