namespace GControl.Application.VMs.Definitions
{
    public class EmployeeLabelGroupVM
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public ICollection<EmployeeLabelGroupLabelVM> Labels { get; set; }
    }

    public class EmployeeLabelGroupLabelVM
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
