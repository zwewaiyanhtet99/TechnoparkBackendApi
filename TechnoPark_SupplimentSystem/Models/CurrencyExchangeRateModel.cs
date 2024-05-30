namespace TechnoPark_SupplimentSystem.Models
{
    public class CurrencyExchangeRateModel
    {
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
        public string CreatedDate { get; set; }
        public string? ExchangeRateDate { get; set; }
    }

    public class DailyExchangeRateResponseModel
    {
        public int Id { get; set; }
        public decimal ExchangeRate { get; set; }
    }
}
