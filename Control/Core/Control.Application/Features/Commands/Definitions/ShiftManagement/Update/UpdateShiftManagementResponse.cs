namespace GControl.Application.Features.Commands.Definitions.ShiftManagement.Update
{
    public class UpdateShiftManagementResponse
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
        public DateTime ShiftStartDate { get; set; }
        public DateTime ShiftEndDate { get; set; } 
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
