using System.ComponentModel.DataAnnotations;

namespace modelValidations.CustomValidators{
    public class MinimumYearValidatorAttribute:ValidationAttribute{
        public int MaximumYear{get;set;} = 2000; // Default year in the property
        // Parameterless constructor
        public MinimumYearValidatorAttribute(){}
        // Parameterised constructor
        public MinimumYearValidatorAttribute(int maxYear){
            MaximumYear = maxYear;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            if(value!=null){
                DateTime date = (DateTime)value;
                if(date.Year>=MaximumYear){
                    // return new ValidationResult("Maximum year allowed is 2000");
                    return new ValidationResult(string.Format(ErrorMessage,MaximumYear));
                }
                else{
                    return ValidationResult.Success;
                }
            }
            return null;
        }
    }
}