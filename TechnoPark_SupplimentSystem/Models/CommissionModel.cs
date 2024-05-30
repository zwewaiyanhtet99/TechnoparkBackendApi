namespace TechnoPark_SupplimentSystem.Models
{
    public class CommissionModel
    {
        public int Id { get; set; }
        public string CommissionPercentageIndividual { get; set; }
        public string CommissionPercentageTeam { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int CreatedUserId { get; set; }
        public int UpdatedUserId { get; set; }
    }
}
