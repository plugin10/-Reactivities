namespace Domain
{
    public class Activity // this is the class that will be used to create the table in the database
    {
        public Guid Id { get; set; } // this is the primary key
        public string Title { get; set; } 
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string City { get; set; }
        public string Venue { get; set; }
    }
}