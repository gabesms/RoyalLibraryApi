namespace RoyalLibrary.Domain.QueriesResults
{
    public class ListBookQueryResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string Authors => $"{FirstName} {LastName}";
        public string FirstName { private get; set; }
        public string LastName { private get; set; }
        public string Type { get; set; }
        public string AvailableCopies => $"{CopiesInUse}/{TotalCopies}";
        public int TotalCopies { private get; set; }
        public int CopiesInUse { private get; set; }

    }
}
