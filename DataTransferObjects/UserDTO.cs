namespace DataTransferObjects
{
    public class UserDTO
    {
        public int UserId { get; set; }

        public string UserName { get; set; } = null!;

        public string? Email { get; set; }

        public string Password { get; set; } = null!;

        public DateTime? CreatedAt { get; set; }

        public int YearCreated { get; set; }

        public List<RepositoryDTO> Repositories { get; set; } = new List<RepositoryDTO>();
    }
}
