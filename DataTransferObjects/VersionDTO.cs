namespace DataTransferObjects
{
    public class VersionDTO
    {
        public int VersionId { get; set; }
        public int BranchId { get; set; }
        public string Content { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }
        public string? Description { get; set; }

    }
}
