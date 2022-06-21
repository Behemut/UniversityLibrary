using System.ComponentModel.DataAnnotations;

namespace UniversityLibrary.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        [Display(Name = "Nombres")]
        public string FirstName { get; set; }
        [Display(Name = "Apellidos")]
        public string LastName { get; set; }
        [Display(Name = "Correo electronico")]
        public string Email { get; set; }
        public string Password { get; set; }
        [Display(Name = "Rol")]
        public string Role { get; set; }
    }
}
