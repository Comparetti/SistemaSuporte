using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SuporteCore.Entity.DTO
{
    public class RegisterUserDTO
    {
        [Required(ErrorMessage = "O Campo {0} é Obrigatorio")]
        [EmailAddress(ErrorMessage = "O Campo {0}  está em formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigatorio")]
        [StringLength(20, ErrorMessage = "O Campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 3)]
        public string Password { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigatorio")]
        [StringLength(20, ErrorMessage = "O Campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 3)]
        public string Name { get; set; }

    }

    public class LoginUserDTO
    {
        [Required(ErrorMessage = "O Campo {0} é Obrigatorio")]
        [EmailAddress(ErrorMessage = "O Campo {0}  está em formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O Campo {0} é Obrigatorio")]
        [StringLength(20, ErrorMessage = "O Campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 3)]
        public string Password { get; set; }

    }
    public class AccessManager
    {
        public LoginUserDTO User { get; set; }
        public string Token { get; set; }
    }

    public class LoadingState
    {
        public RegisterUserDTO User { get; set; }
        public string Token { get; set; }
    }
}
