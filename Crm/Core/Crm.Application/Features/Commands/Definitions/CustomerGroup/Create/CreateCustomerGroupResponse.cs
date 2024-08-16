namespace GCrm.Application.Features.Commands.Definitions.CustomerGroup.Create
{
    public  class CreateCustomerGroupResponse
    {
        public string Id { get; set; }
        public string CustomerGroupName { get; set; }
        public string CustomerGroupType { get; set; }      
        public string Message { get; set; }
    }
}
