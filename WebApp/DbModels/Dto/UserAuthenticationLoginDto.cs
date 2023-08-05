using System.ComponentModel.DataAnnotations;

namespace WebApp.DbModels.Dto
{
    public class UserAuthenticationLoginDto
    {
        [Required(ErrorMessage = "Input your email")]
        [StringLength(60, ErrorMessage = "The Email cannot have more than 60 characters")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Input your password")]
        [StringLength(60, ErrorMessage = "The Password cannot have more than 60 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
