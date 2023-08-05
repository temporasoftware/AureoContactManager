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

        [StringLength(60)]
        public string Name { get; set; }

        [StringLength(9)]
        public string Contact { get; set; }

        [StringLength(60)]
        public string Email { get; set; }
        
        public bool Audit_RecordStatus { get; set; }


    }
}
