using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using modelValidations.CustomValidators;

namespace modelValidations.Models{
    public class Person: IValidatableObject{
        [Required(ErrorMessage = "{0} field is an Required field and cannot be empty!")] // Attribute Required to make the PersonName field required one 
        // {0} takes the first property name here it is PersonName
        //All the attributes are classes
        [Display(Name="Person Name")] // Display Name to be shown in {0}
        [StringLength(40,MinimumLength =3,ErrorMessage ="{0} should contain between {2} - {1} characters")]
        [RegularExpression("^[A-Za-z .,]$",ErrorMessage="Please Enter a valid character A-Za-z .,")]
        [ValidateNever]
        public string? PersonName{get;set;}


        [EmailAddress(ErrorMessage ="{0} should be a valid Email address with characters like email@email.com")]
        [Required(ErrorMessage ="This field cannot be empty")]
        public string? Email{get;set;}


        [BindNever]
        [Phone(ErrorMessage ="Please Enter a valid {0} number")]
        public string? Phone{get;set;}


        [Required(ErrorMessage = "{0} field is an required field and cannot be empty!")]
        public string? Password{get;set;}

        [Required(ErrorMessage = "{0} field is an required field and cannot be empty!")]
        [Compare("Password",ErrorMessage ="{0} and {1} don't match")]
        [Display(Name="Re-enter Password")]
        public string? ConfirmPassword{get;set;}


        [Range(0,999.99, ErrorMessage ="{0} can contain numbers from the range {1} to {2}")]
        public double? Price{get;set;}


        // [MinimumYearValidator(1999,ErrorMessage ="Date of Birth should not exceed {0}")]
        [MinimumYearValidator(1999)]
        public DateTime? DateOfBirth{get;set;}


        public DateTime? FromDate{get;set;}
        
        public int?Age{get;set;}

        [DateRangeValidator("FromDate", ErrorMessage="From Date cannot Exceed or Equalto  To Date")]
        public DateTime? ToDate{get;set;}


        public override string ToString(){
            return $"Person object - PersonName: {PersonName}\n Email: {Email}\n Phone: {Phone}\n Password: {Password}\n ConfirmPassword: {ConfirmPassword}\n Price: {Price}";
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext){
            if(DateOfBirth.HasValue == false && Age.HasValue == false){
                yield return new ValidationResult("Either Date of Birth or Age must be supplied!", new[]{nameof(Age)});
            }
        }

    }
}
