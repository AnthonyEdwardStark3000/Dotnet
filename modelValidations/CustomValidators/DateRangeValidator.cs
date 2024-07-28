using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace modelValidations.CustomValidators{
    public class DateRangeValidator : ValidationAttribute
    {
        public string OtherPropertyName{get;set;}
        public DateRangeValidator(string otherPropertyName){ // Reads the value from the string part of the DateRangeValidator attribute in the person Model.
            OtherPropertyName = otherPropertyName; // Reads the value passed as string here it is "FromDate", ErrorMessage()
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value!=null){ // This is the ToDate property of the Person Model,as the DateRangeValidator was applied to that property.
                DateTime to_date = Convert.ToDateTime(value); 

                // Getting reference to the property using Reflection concept
                PropertyInfo? otherProperty = validationContext.ObjectType.GetProperty(OtherPropertyName);
                // validationContext has the informations about the Mode property, Model class and Model object 
                // ObjectInstance refers to the Model instance created by Model binding. 
                // Gets the value of FromDate from person Model.
                if(otherProperty!= null){
                DateTime from_date = Convert.ToDateTime(otherProperty.GetValue(validationContext.ObjectInstance));

                if(from_date > to_date){
                    return new ValidationResult(ErrorMessage, new string[] { OtherPropertyName, validationContext.MemberName });
                }else{
                    return ValidationResult.Success;
                }
              }
              return null;
            }
            return null;
        }

    }
}