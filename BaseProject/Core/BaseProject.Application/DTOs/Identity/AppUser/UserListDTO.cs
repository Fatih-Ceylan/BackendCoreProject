namespace BaseProject.Application.DTOs.Identity.AppUser
{
    public class UserListDTO
    {
        public int TotalCount { get; set; }

        public List<UserDTO> AppUsers { get; set; }
    }
}