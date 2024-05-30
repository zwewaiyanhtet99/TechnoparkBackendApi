using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechnoPark_SupplimentSystem.Models.Entities
{
    [Table("CurrencyExchangeRate_Table")]
    public class CurrencyExchangeRateEntities
    {
        [Key]
        public int Id { get; set; }
        public decimal USD_ExchangeRate { get; set; }
        public decimal EUR_ExchangeRate { get; set; }
        public decimal JPY_ExchangeRate { get; set; }
        public decimal THB_ExchangeRate { get; set; }
        public decimal CNY_ExchangeRate { get; set; }
        public decimal SGD_ExchangeRate { get; set; }
        public decimal GBP_ExchangRate { get; set; }
        public decimal MRM_ExchangeRate { get; set; }
        public decimal KW_Exchange_Rate { get; set; }
        public decimal AUD_Exchange_Rate { get; set; }
        public decimal AED_Exchange_Rate { get; set; }
        public DateTime CreatedDate { get; set; }
        public System.Nullable<DateTime> ExchangeRateDate { get; set; }
    }
}
