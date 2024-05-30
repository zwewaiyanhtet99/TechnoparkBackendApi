using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechnoPark_SupplimentSystem.Models.Entities
{
    [Table("Category_Table")]
    public class CategoryEntities
    {
        [Key]
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}
