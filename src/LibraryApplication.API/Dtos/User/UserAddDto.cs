using System.ComponentModel.DataAnnotations;

namespace LibraryApplication.API.Dtos.User
{
    public class UserAddDto
    {
        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(150, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 2)]
        public string UserName { get; set; }
    }
}
