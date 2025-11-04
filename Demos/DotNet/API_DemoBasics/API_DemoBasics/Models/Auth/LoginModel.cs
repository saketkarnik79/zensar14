using System.ComponentModel.DataAnnotations;

namespace API_DemoBasics.Models.Auth
{
    public class LoginModel
    {
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
