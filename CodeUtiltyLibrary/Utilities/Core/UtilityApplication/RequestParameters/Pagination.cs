namespace Utilities.Core.UtilityApplication.RequestParameters
{
    public class Pagination
    {
        public int Page { get; set; } = 0;

        public int Size { get; set; } = 5;

        public string? FilterText { get; set; }

        public bool IsDeleted { get; set; } = false;

        public bool  DoPagination{ get; set; } = true;
    }
}