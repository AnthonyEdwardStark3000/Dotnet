using Microsoft.AspNetCore.Mvc;

namespace BookStore.Models{
    public class Book{
        [FromQuery]
        public int? BookId{get;set;}
        [FromRoute]
        public string? Author{get;set;}
        public override string ToString(){
            return $"Book object - BookId is {BookId} and written By {Author}";
        }
    }
}