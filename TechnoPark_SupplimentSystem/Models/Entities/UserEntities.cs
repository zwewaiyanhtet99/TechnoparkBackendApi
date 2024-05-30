using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechnoPark_SupplimentSystem.Models.Entities
{
    [Table("User_Table")]
    public class UserEntities
    {
        [Key]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserRole { get; set; }
        public string Password { get; set; }
        [DataType(DataType.DateTime)]
        public string CreatedDate { get; set; }
    }
}
