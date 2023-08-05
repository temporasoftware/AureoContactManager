using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApp.DbModels
{
    public class Contacts
    {

        public Contacts()
        {
            this.Id = Guid.NewGuid().ToString("N");
        }


        [Key]
        [Column("Id")]
        [StringLength(32)]
        public string Id { get; set; }

        [StringLength(60, ErrorMessage = "The Name field cannot have more than 60 characters")]
        public string Name { get; set; }

        [StringLength(9, ErrorMessage = "The Contact field cannot have more than 9 characters")]
        public string Contact { get; set; }

        [StringLength(60, ErrorMessage = "The Contact field cannot have more than 60 characters")]
        [EmailAddress(ErrorMessage = "The email address is invalid.")]
        public string Email { get; set; }
        
        public bool Audit_RecordStatus { get; set; }


    }
}
