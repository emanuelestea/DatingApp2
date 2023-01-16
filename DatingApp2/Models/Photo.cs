using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Permissions;

namespace DatingApp2.Models
{
    [Table("Photos")] //nome che avrà all'interno del db
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }

        //necessari per far si che la foto non sia null
        //in questo caso se elimino l'utente andrò  a 
        //cancellare anche le foto associate
        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }
    }
}

