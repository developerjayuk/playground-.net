namespace GuestBookLibrary.Models
{
    public class GuestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PartySize { get; set; }
        public string? MessageToHost { get; set; }
    }
}
