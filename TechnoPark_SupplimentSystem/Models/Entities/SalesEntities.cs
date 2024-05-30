using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechnoPark_SupplimentSystem.Models.Entities
{
    [Table("Sales_Table")]
    public class SalesEntities
    {
        [Key]
        public int Id { get; set; }
        public string RefNo { get; set; }
        public string QuotationNoToEndUser { get; set; }
        public DateTime? POReceivedDateFromEndUser { get; set; }
        public string PONumberFromEndUser { get; set; }
        public string ProductCategory { get; set; }
        public string ProductDetails { get; set; }
        public string DeliveryOrderNoToEndUser { get; set; }
        public DateTime? DeliveryAndInvoiceDate { get; set; }
        public string InvoiceNoToEndUser { get; set; }
        public DateTime? PaymentDueDate { get; set; }
        public DateTime? PaymentReceivedDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string SupplierName { get; set; }
        public string SupplierBuyPrice_Currency { get; set; }
        public decimal SupplierBuyPrice_Amount { get; set; }
        public int SupplierBuyPrice_ExchangeRate { get; set; }
        public string SupplierBuyPrice_Note { get; set; }
        public decimal SupplierBuyingPrice { get; set; }
        public string Tax_Currency { get; set; }
        public decimal Tax_Amount { get; set; }
        public int Tax_ExchangeRate { get; set; }
        public string Tax_Note { get; set; }
        public decimal Tax { get; set; }
        public string BankCharges_Currency { get; set; }
        public decimal BankCharges_Amount { get; set; }
        public int BankCharges_ExchangeRate { get; set; }
        public string BankCharges_Note { get; set; }
        public decimal BankCharges { get; set; }
        public string LogisticsCost_Currency { get; set; }
        public decimal LogisticsCost_Amount { get; set; }
        public int LogisticsCost_ExchangeRate { get; set; }
        public string LogisticsCost_Note { get; set; }
        public decimal LogisticsCost { get; set; }
        public string LogisticsCost_Local_Currency { get; set; }
        public decimal LogisticsCost_Local_Amount { get; set; }
        public int LogisticsCost_Local_ExchangeRate { get; set; }
        public string LogisticsCost_Local_Note { get; set; }
        public decimal LogisticsCost_Local { get; set; }
        public string UnexpectedCost_Currency { get; set; }
        public decimal UnexpectedCost_Amount { get; set; }
        public int UnexpectedCost_ExchangeRate { get; set; }
        public string UnexpectedCost_Note { get; set; }
        public decimal UnexpectedCost { get; set; }
        public string LossAmountDueToExchange_Rate_Currency { get; set; }
        public decimal LossAmountDueToExchange_Rate_Amount { get; set; }
        public int LossAmountDueToExchange_Rate_ExchangeRate { get; set; }
        public string LossAmountDueToExchange_Rate_Note { get; set; }
        public decimal LossAmountDueToExchange_Rate { get; set; }
        public string MiscellaneousCost_Currency { get; set; }
        public decimal MiscellaneousCost_Amount { get; set; }
        public int MiscellaneousCost_ExchangeRate { get; set; }
        public string MiscellaneousCost_Note { get; set; }
        public decimal MiscellaneousCost { get; set; }
        public string EquipmentAndFacilityRentalFees_Currency { get; set; }
        public decimal EquipmentAndFacilityRentalFees_Amount { get; set; }
        public int EquipmentAndFacilityRentalFees_ExchangeRate { get; set; }
        public string EquipmentAndFacilityRentalFees_Note { get; set; }
        public decimal EquipmentAndFacilityRentalFees { get; set; }
        public decimal FinalSellingPrice { get; set; }
        public decimal FinalBuyingPrice { get; set; }
        public decimal ProfitAndLoss { get; set; }
        public string? CommissionPercentageGroup { get; set; }
        public string? CommissionPercentageIndividual { get; set; }
        public string? CommissionPercentageGroupFinalAmount { get; set; }
        public string? CommissionPercentageIndividualFinalAmount { get; set; }
        public string? Link { get; set; }
        public string Currency { get; set; }
        public int ExchangeRate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? SupplierBuyingPriceUpdatedDate { get; set; }
        public DateTime? TaxUpdatedDate { get; set; }
        public DateTime? BankChargeUpdatedDate { get; set; }
        public DateTime? LogisticCostUpdatedDate { get; set; }
        public DateTime? LogisticCostLocalUpdatedDate { get; set; }
        public DateTime? UnexpectedCostUpdatedDate { get; set; }
        public DateTime? LossAmountDueToExchange_RateUpdatedDate { get; set; }
        public DateTime? MiscellaneousCostUpdatedDate { get; set; }
        public DateTime? EquipmentAndFacilityFeesUpdatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? IsDeleted { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

    }
}
