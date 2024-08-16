namespace Utilities.Core.UtilityDomain.Entities
{
    public class BaseEntity
    {
        virtual public Guid Id { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedDate { get; set; }

        public string? CreatedBy { get; set; }

        virtual public DateTime? UpdatedDate { get; set; }

        virtual public string? UpdatedBy { get; set; }

        virtual public DateTime? DeletedDate { get; set; }

        virtual public string? DeletedBy { get; set; }

    }
}