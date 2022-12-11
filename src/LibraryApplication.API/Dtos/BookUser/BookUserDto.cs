namespace LibraryApplication.API.Dtos.BookUser
{
    public class BookUserDto
    {
        public int Id { get; set; }

        public string BookId { get; set; }

        public string UserId { get; set; }

        public bool ActualUser { get; set; }   
    }
}
