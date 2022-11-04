﻿using System.ComponentModel.DataAnnotations;

namespace DatingApp2.DTO
{
    public class RegisterDto
    {
        [Required] //questo controlla quando registro un utente che il parametro non sia blank //posso inserire altre annotazione ad esempre espressioni regolari
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
