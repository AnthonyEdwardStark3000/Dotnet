using System.ComponentModel.DataAnnotations;

namespace modelValidations.Models{
    public class Person{
        [Required(ErrorMessage = "{0} field is an Required field and cannot be empty!")] // Attribute Required to make the PersonName field required one 
        // {0} takes the first property name here it is PersonName
        //All the attributes are classes
        [Display(Name="Person Name")] // Display Name to be shown in {0}
        [StringLength(40,MinimumLength =3,ErrorMessage ="{0} should contain between {2} - {1} characters")]
        public string? PersonName{get;set;}
        public string? Email{get;set;}
        public string? Phone{get;set;}
        public string? Password{get;set;}
        public string? ConfirmPassword{get;set;}
        [Range(0,999.99, ErrorMessage ="{0} can contain numbers from the range {1} to {2}")]
        public double? Price{get;set;}
        public override string ToString(){
            return $"Person object - PersonName: {PersonName}\n Email: {Email}\n Phone: {Phone}\n Password: {Password}\n ConfirmPassword: {ConfirmPassword}\n Price: {Price}";
        }
    }
}
