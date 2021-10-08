using System.ComponentModel.DataAnnotations;

namespace TravelExperts.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please enter a Username.")]
        [StringLength(255)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter a Password.")]
        [StringLength(255)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }

        public bool RememberMe { get; set; }

    }
}
