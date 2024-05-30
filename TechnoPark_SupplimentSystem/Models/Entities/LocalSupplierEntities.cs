using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechnoPark_SupplimentSystem.Models.Entities
{
    [Table("Form")]
    public class LocalSupplierEntities
    {
        [Key]
        public int? NO { get; set; }
        [Column("Supplier Company Name")]
        public string? Supplier_Company_Name { get; set; }
        [Column("Suppliers Contact Person")]
        public string? Suppliers_Contact_Person { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public string? Brand { get; set; }
        [Column("Product Category")]
        public string? Product_Category { get; set; }
        [Column("Product Details")]
        public string? Product_Details { get; set; }
        [Column("Purchased History(Type of Response)")]
        public string? Purchased_History_Type_of_Response { get; set; }
        [Column("Supplier Invoice Number")]
        public string? Supplier_Invoice_Number { get; set; }
        [Column("End User PO Number")]
        public string? End_User_PO_Number { get; set; }
        [Column("Quotation to End User")]
        public string? Quotation_to_End_User { get; set; }
        [Column("Stock Photo at Technopark Warehouse")]
        public string? Stock_Photo_at_Technopark_Warehouse { get; set; }
    }
}
