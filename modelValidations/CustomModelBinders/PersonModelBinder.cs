using Microsoft.AspNetCore.Mvc.ModelBinding;
using modelValidations.Models;

namespace modelValidations.CustomModelBinders{
    public class PersonModelBinder:IModelBinder{
        Task IModelBinder.BindModelAsync(ModelBindingContext bindingContext)
        {
            Person person = new Person(); 
            // User providing FirstName and LastName instead of PersonName as a whole name
            if (bindingContext.ValueProvider.GetValue("FirstName").Length > 0 && bindingContext.ValueProvider.GetValue("LastName").Length > 0 )
            {
                person.PersonName = bindingContext.ValueProvider.GetValue("FirstName").FirstValue;
                person.PersonName += " "+(bindingContext.ValueProvider.GetValue("LastName").FirstValue);
            }

            // Email
            if(bindingContext.ValueProvider.GetValue("Email").Length>0){
                person.Email = bindingContext.ValueProvider.GetValue("Email").FirstValue;
            }

            // Phone
            if(bindingContext.ValueProvider.GetValue("Phone").Length>0){
                person.Phone = bindingContext.ValueProvider.GetValue("Phone").FirstValue;
            }
            
            // Password
            if(bindingContext.ValueProvider.GetValue("Password").Length>0){
                person.Password = bindingContext.ValueProvider.GetValue("Password").FirstValue;
            }
            
            // ConfirmPassword
            if(bindingContext.ValueProvider.GetValue("ConfirmPassword").Length>0){
                person.ConfirmPassword = bindingContext.ValueProvider.GetValue("ConfirmPassword").FirstValue;
            }
            
            // Price
            if(bindingContext.ValueProvider.GetValue("Price").Length>0){
                person.Price = Convert.ToDouble(bindingContext.ValueProvider.GetValue("Price").FirstValue);
            }
            
            // DateOfBirth
            if(bindingContext.ValueProvider.GetValue("DateOfBirth").Length>0){
                person.DateOfBirth = Convert.ToDateTime(bindingContext.ValueProvider.GetValue("DateOfBirth").FirstValue);
            }
            
            // FromDate
            if(bindingContext.ValueProvider.GetValue("FromDate").Length>0){
                person.FromDate = Convert.ToDateTime(bindingContext.ValueProvider.GetValue("FromDate").FirstValue);
            }
            
            // Age
            if(bindingContext.ValueProvider.GetValue("Age").Length>0){
                person.Age = Convert.ToInt32(bindingContext.ValueProvider.GetValue("Age").FirstValue);
            }
            
            // ToDate
            if(bindingContext.ValueProvider.GetValue("ToDate").Length>0){
                person.ToDate = Convert.ToDateTime(bindingContext.ValueProvider.GetValue("ToDate").FirstValue);
            }

            // // Tags
            // var valueProviderTags = bindingContext.ValueProvider.GetValue("Tags");
            // if(valueProviderTags.Length>0){
            //     // person.Tags = valueProviderTags;
            // }
            bindingContext.Result = ModelBindingResult.Success(person);
            return Task.CompletedTask;
        }
    }
}