namespace BaseProject.Domain.Entities.HR.Employment
{
    public class Appellation : B_BaseEntity
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public Guid? MainAppellationId { get; set; }
    }
}
