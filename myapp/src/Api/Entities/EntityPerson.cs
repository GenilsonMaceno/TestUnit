using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace src.Entities
{
    public class EntityPerson
    {
        [Key]
        public int Entity { get; set; }

        [Column(TypeName = "Varchar(50)")]
        public string Name { get; set; }

        [Column(TypeName = "Varchar(200)")]
        public string LastName { get; set; }
        public int Age { get; set; }
        
        [Column(TypeName = "Varchar(200)")]
        public string Email { get; set; }
    }
}