using System.ComponentModel.DataAnnotations;

namespace TravelExperts.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please enter a Username.")]
        [StringLength(255, ErrorMessage = "The Username cannot exceed 255 characters. ")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter a First Name.")]
        [StringLength(255, ErrorMessage = "The First Name cannot exceed 255 characters. ")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Please enter a Last Name.")]
        [StringLength(255, ErrorMessage = "The Last Name cannot exceed 255 characters. ")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Please enter an Email Address.")]
        [StringLength(255, ErrorMessage = "The Email cannot exceed 255 characters. ")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Please enter a valid email address. ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a Password.")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm your Password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}