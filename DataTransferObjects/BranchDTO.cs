namespace DataTransferObjects
{
    public class BranchDTO
    {
        public int BranchId { get; set; }
        public int RepositoryId { get; set; }
        public string Name { get; set; } = null!;
        public bool IsMain { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
