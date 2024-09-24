namespace DataTransferObjects
{
    public class MergeDTO
    {
        public int MergeId { get; set; }
        public int SourceBranchId { get; set; }
        public int TargetBranchId { get; set; }
        public DateTime MergeAt { get; set; }
    }
}
