using System;
using System.ComponentModel.DataAnnotations;

namespace DatingApp2.DTO
{
    public class RegisterDto
    {
        [Required] //questo controlla quando registro un utente che il parametro non sia blank 
                    //posso inserire altre annotazione ad esempre espressioni regolari
        public string Username { get; set; }

        [Required] public string KnownAs { get; set; }
        [Required] public string Gender { get; set; }
        [Required] public DateTime? DateOfBirth { get; set; } //settato a optional per 
        [Required] public string City { get; set; }
        [Required] public string Country { get; set; }


        [Required]
        [StringLength(8, MinimumLength = 4)]
        public string Password { get; set; }
    }
}
