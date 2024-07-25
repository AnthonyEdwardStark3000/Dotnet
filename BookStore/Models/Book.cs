namespace BookStore.Models{
    public class Book{
        public int? BookId{get;set;}
        public string? Author{get;set;}
        public override string ToString(){
            return $"BookId is {BookId} and written By {Author}";
        }
    }
}