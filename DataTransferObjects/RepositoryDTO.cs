namespace DataTransferObjects
{
    public class RepositoryDTO
    {
        public int RepositoryId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public string? Description { get; set; }
        public int UserId { get; set; }
        public List<BranchDTO> Branches { get; set; } = new List<BranchDTO>();
    }
}
