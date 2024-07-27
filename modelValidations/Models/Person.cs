using System.ComponentModel.DataAnnotations;

namespace modelValidations.Models{
    public class Person{
        [Required(ErrorMessage = "This field is an Required field and cannot be empty!")] // Attribute Required to make the PersonName field required one
        //All the attributes are classes
        public string? PersonName{get;set;}
        public string? Email{get;set;}
        public string? Phone{get;set;}
        public string? Password{get;set;}
        public string? ConfirmPassword{get;set;}
        public double? Price{get;set;}
        public override string ToString(){
            return $"Person object - PersonName: {PersonName}\n Email: {Email}\n Phone: {Phone}\n Password: {Password}\n ConfirmPassword: {ConfirmPassword}\n Price: {Price}";
        }
    }
}
