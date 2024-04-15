namespace RoyalLibrary.Domain.Entities.Book
{
    public class Book
    {
        public Book(string title, string firstName, string lastName, int totalCopies, int copiesInUse, string type, string isbn, string category)
        {          
            Title = title;
            FirstName = firstName;
            LastName = lastName;
            TotalCopies = totalCopies;
            CopiesInUse = copiesInUse;
            Type = type;
            Isbn = isbn;
            Category = category;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TotalCopies { get; set; }
        public int CopiesInUse { get; set; }
        public string Type { get; set; }
        public string Isbn { get; set; }
        public string Category { get; set; }
    }
}
