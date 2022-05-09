using QuidProGo.Models;
using System.Collections.Generic;

namespace QuidProGo.Auth.Models.ViewModels
{
    public class RegistrationViewModel
    {
        public Registration Registration { get; set; }

        public List<UserType> UserTypeOptions { get; set; }
    }
}
