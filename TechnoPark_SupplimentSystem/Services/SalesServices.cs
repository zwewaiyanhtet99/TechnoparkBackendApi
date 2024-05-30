using Microsoft.EntityFrameworkCore;
using TechnoPark_SupplimentSystem.Models;
using TechnoPark_SupplimentSystem.Models.Entities;

namespace TechnoPark_SupplimentSystem.Services
{
    public class SalesServices
    {
        private EFDBContext _dbContext;

        public SalesServices(EFDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddSale(SalesModel model)
        {
            try
            {
                if (CheckRefNo(model.RefNo))
                {
                    DateTime serverTime = DateTime.Now.Date;
                    DateTime _localTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(serverTime, TimeZoneInfo.Local.Id, "Myanmar Standard Time");
                    #region Data Mapping
                    SalesEntities entities = new SalesEntities();
                    entities.RefNo = model.RefNo;
                    entities.QuotationNoToEndUser = model.QuotationNoToEndUser;
                    entities.POReceivedDateFromEndUser = model.POReceivedDateFromEndUser;
                    entities.PONumberFromEndUser = model.PONumberFromEndUser;
                    entities.ProductCategory = model.ProductCategory;
                    entities.ProductDetails = model.ProductDetails;
                    entities.DeliveryOrderNoToEndUser = model.DeliveryOrderNoToEndUser;
                    entities.DeliveryAndInvoiceDate = model.DeliveryAndInvoiceDate;
                    entities.InvoiceNoToEndUser = model.InvoiceNoToEndUser;
                    entities.PaymentDueDate = model.PaymentDueDate;
                    entities.PaymentReceivedDate = model.PaymentReceivedDate;
                    entities.TotalAmount = model.TotalAmount;
                    entities.SupplierName = model.SupplierName;

                    entities.SupplierBuyPrice_Currency = model.SupplierBuyPrice_Currency;
                    entities.SupplierBuyPrice_Amount = model.SupplierBuyPrice_Amount;
                    entities.SupplierBuyPrice_ExchangeRate = model.SupplierBuyPrice_ExchangeRate;
                    entities.SupplierBuyPrice_Note = model.SupplierBuyPrice_Note;
                    entities.SupplierBuyingPrice = model.SupplierBuyingPrice;

                    entities.Tax_Currency = model.Tax_Currency;
                    entities.Tax_Amount = model.Tax_Amount;
                    entities.Tax_ExchangeRate = model.Tax_ExchangeRate;
                    entities.Tax_Note = model.Tax_Note;
                    entities.Tax = model.Tax;

                    entities.BankCharges_Currency = model.BankCharges_Currency;
                    entities.BankCharges_Amount = model.BankCharges_Amount;
                    entities.BankCharges_ExchangeRate = model.BankCharges_ExchangeRate;
                    entities.BankCharges_Note = model.BankCharges_Note;
                    entities.BankCharges = model.BankCharges;

                    entities.LogisticsCost_Currency = model.LogisticsCost_Currency;
                    entities.LogisticsCost_Amount = model.LogisticsCost_Amount;
                    entities.LogisticsCost_ExchangeRate = model.LogisticsCost_ExchangeRate;
                    entities.LogisticsCost_Note = model.LogisticsCost_Note;
                    entities.LogisticsCost = model.LogisticsCost;

                    entities.LogisticsCost_Local_Currency = model.LogisticsCost_Local_Currency;
                    entities.LogisticsCost_Local_Amount = model.LogisticsCost_Local_Amount;
                    entities.LogisticsCost_Local_ExchangeRate = model.LogisticsCost_Local_ExchangeRate;
                    entities.LogisticsCost_Local_Note = model.LogisticsCost_Local_Note;
                    entities.LogisticsCost_Local = model.LogisticsCost_Local;

                    entities.UnexpectedCost_Currency = model.UnexpectedCost_Currency;
                    entities.UnexpectedCost_Amount = model.UnexpectedCost_Amount;
                    entities.UnexpectedCost_ExchangeRate = model.UnexpectedCost_ExchangeRate;
                    entities.UnexpectedCost_Note = model.UnexpectedCost_Note;
                    entities.UnexpectedCost = model.UnexpectedCost;

                    entities.LossAmountDueToExchange_Rate_Currency = model.LossAmountDueToExchange_Rate_Currency;
                    entities.LossAmountDueToExchange_Rate_Amount = model.LossAmountDueToExchange_Rate_Amount;
                    entities.LossAmountDueToExchange_Rate_ExchangeRate = model.LossAmountDueToExchange_Rate_ExchangeRate;
                    entities.LossAmountDueToExchange_Rate_Note = model.LossAmountDueToExchange_Rate_Note;
                    entities.LossAmountDueToExchange_Rate = model.LossAmountDueToExchange_Rate;

                    entities.MiscellaneousCost_Currency = model.MiscellaneousCost_Currency;
                    entities.MiscellaneousCost_Amount = model.MiscellaneousCost_Amount;
                    entities.MiscellaneousCost_ExchangeRate = model.MiscellaneousCost_ExchangeRate;
                    entities.MiscellaneousCost_Note = model.MiscellaneousCost_Note;
                    entities.MiscellaneousCost = model.MiscellaneousCost;

                    entities.EquipmentAndFacilityRentalFees_Currency = model.EquipmentAndFacilityRentalFees_Currency;
                    entities.EquipmentAndFacilityRentalFees_Amount = model.EquipmentAndFacilityRentalFees_Amount;
                    entities.EquipmentAndFacilityRentalFees_ExchangeRate = model.EquipmentAndFacilityRentalFees_ExchangeRate;
                    entities.EquipmentAndFacilityRentalFees_Note = model.EquipmentAndFacilityRentalFees_Note;
                    entities.EquipmentAndFacilityRentalFees = model.EquipmentAndFacilityRentalFees;

                    entities.FinalSellingPrice = model.FinalSellingPrice;
                    entities.FinalBuyingPrice = model.FinalBuyingPrice;
                    entities.ProfitAndLoss = model.ProfitAndLoss;
                    entities.CommissionPercentageGroup = model.CommissionPercentageGroup;
                    entities.CommissionPercentageIndividual = model.CommissionPercentageIndividual;
                    if (model.ProfitAndLoss > 0)
                    {
                        //calculate group commission
                        if (Convert.ToUInt32(model.CommissionPercentageGroup) > 0)
                        {
                            entities.CommissionPercentageGroupFinalAmount = CalculateCommission(Convert.ToDouble(model.ProfitAndLoss),
                                model.CommissionPercentageGroup, "0").ToString();
                        }
                        //calculate individual commission
                        else if (Convert.ToUInt32(model.CommissionPercentageIndividual) > 0)
                        {
                            entities.CommissionPercentageIndividualFinalAmount = CalculateCommission(Convert.ToDouble(model.ProfitAndLoss),
                                "0", model.CommissionPercentageIndividual).ToString();
                        }
                    }
                    entities.Link = model.Link;
                    entities.Currency = model.Currency;
                    entities.ExchangeRate = model.ExchangeRate;
                    entities.CreatedBy = model.CreatedBy;
                    //entities.CreatedDate = DateTime.Now.Date;
                    entities.CreatedDate = _localTime;
                    entities.IsDeleted = false;
                    #endregion
                    await _dbContext.AddRangeAsync(entities);
                    return await _dbContext.SaveChangesAsync();
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private decimal CalculateCommission(double ProfitAndLoss, string commissionTeam, string commissionIndividual)
        {
            try
            {
                decimal finalAmount = 0.00m;
                if (ProfitAndLoss > 0)
                {
                    if (Convert.ToInt32(commissionTeam) > 0)
                    {
                        finalAmount = Convert.ToDecimal((Convert.ToDouble(commissionTeam) / 100) * ProfitAndLoss);
                    }
                    else if (Convert.ToDouble(commissionIndividual) > 0)
                    {
                        finalAmount = Convert.ToDecimal((Convert.ToDouble(commissionIndividual) / 100) * ProfitAndLoss);
                    }
                    return finalAmount;
                }
                return finalAmount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<SalesModel>> SaleList(SaleListRequestModel model)
        {
            try
            {
                if (!string.IsNullOrEmpty(model.RefNo))
                {
                    return await _dbContext.Sales.Where(x => x.RefNo == model.RefNo && x.IsDeleted==false)
                        .Select(x => new SalesModel()
                        {
                            #region DataMapping
                            Id = x.Id,
                            RefNo = x.RefNo,
                            QuotationNoToEndUser = x.QuotationNoToEndUser,
                            POReceivedDateFromEndUser = x.POReceivedDateFromEndUser,
                            PONumberFromEndUser = x.PONumberFromEndUser,
                            ProductCategory = _dbContext.Category.Where(c => c.Id.ToString() == x.ProductCategory).
                            Select(c => c.CategoryName).FirstOrDefault(),
                            ProductDetails = x.ProductDetails,
                            DeliveryOrderNoToEndUser = x.DeliveryOrderNoToEndUser,
                            DeliveryAndInvoiceDate = x.DeliveryAndInvoiceDate,
                            InvoiceNoToEndUser = x.InvoiceNoToEndUser,
                            PaymentDueDate = x.PaymentDueDate,
                            PaymentReceivedDate = x.PaymentReceivedDate,
                            TotalAmount = x.TotalAmount,
                            SupplierName = x.SupplierName,

                            SupplierBuyPrice_Currency = x.SupplierBuyPrice_Currency,
                            SupplierBuyPrice_Amount = x.SupplierBuyPrice_Amount,
                            SupplierBuyPrice_ExchangeRate = x.SupplierBuyPrice_ExchangeRate,
                            SupplierBuyPrice_Note = x.SupplierBuyPrice_Note,
                            SupplierBuyingPrice = x.SupplierBuyingPrice,

                            Tax_Currency = x.Tax_Currency,
                            Tax_Amount = x.Tax_Amount,
                            Tax_ExchangeRate = x.Tax_ExchangeRate,
                            Tax_Note = x.Tax_Note,
                            Tax = x.Tax,

                            BankCharges_Currency = x.BankCharges_Currency,
                            BankCharges_Amount = x.BankCharges_Amount,
                            BankCharges_ExchangeRate = x.BankCharges_ExchangeRate,
                            BankCharges_Note = x.BankCharges_Note,
                            BankCharges = x.BankCharges,

                            LogisticsCost_Currency = x.LogisticsCost_Currency,
                            LogisticsCost_Amount = x.LogisticsCost_Amount,
                            LogisticsCost_ExchangeRate = x.LogisticsCost_ExchangeRate,
                            LogisticsCost_Note = x.LogisticsCost_Note,
                            LogisticsCost = x.LogisticsCost,

                            LogisticsCost_Local_Currency = x.LogisticsCost_Local_Currency,
                            LogisticsCost_Local_Amount = x.LogisticsCost_Local_Amount,
                            LogisticsCost_Local_ExchangeRate = x.LogisticsCost_Local_ExchangeRate,
                            LogisticsCost_Local_Note = x.LogisticsCost_Local_Note,
                            LogisticsCost_Local = x.LogisticsCost_Local,

                            UnexpectedCost_Currency = x.UnexpectedCost_Currency,
                            UnexpectedCost_Amount = x.UnexpectedCost_Amount,
                            UnexpectedCost_ExchangeRate = x.UnexpectedCost_ExchangeRate,
                            UnexpectedCost_Note = x.UnexpectedCost_Note,
                            UnexpectedCost = x.UnexpectedCost,

                            LossAmountDueToExchange_Rate_Currency = x.LossAmountDueToExchange_Rate_Currency,
                            LossAmountDueToExchange_Rate_Amount = x.LossAmountDueToExchange_Rate_Amount,
                            LossAmountDueToExchange_Rate_ExchangeRate = x.LossAmountDueToExchange_Rate_ExchangeRate,
                            LossAmountDueToExchange_Rate_Note = x.LossAmountDueToExchange_Rate_Note,
                            LossAmountDueToExchange_Rate = x.LossAmountDueToExchange_Rate,

                            MiscellaneousCost_Currency = x.MiscellaneousCost_Currency,
                            MiscellaneousCost_Amount = x.MiscellaneousCost_Amount,
                            MiscellaneousCost_ExchangeRate = x.MiscellaneousCost_ExchangeRate,
                            MiscellaneousCost_Note = x.MiscellaneousCost_Note,
                            MiscellaneousCost = x.MiscellaneousCost,

                            EquipmentAndFacilityRentalFees_Currency = x.EquipmentAndFacilityRentalFees_Currency,
                            EquipmentAndFacilityRentalFees_Amount = x.EquipmentAndFacilityRentalFees_Amount,
                            EquipmentAndFacilityRentalFees_ExchangeRate = x.EquipmentAndFacilityRentalFees_ExchangeRate,
                            EquipmentAndFacilityRentalFees_Note = x.EquipmentAndFacilityRentalFees_Note,
                            EquipmentAndFacilityRentalFees = x.EquipmentAndFacilityRentalFees,

                            FinalSellingPrice = x.FinalSellingPrice,
                            FinalBuyingPrice = x.FinalBuyingPrice,
                            ProfitAndLoss = x.ProfitAndLoss,
                            CommissionPercentageGroup = x.CommissionPercentageGroup,
                            CommissionPercentageIndividual = x.CommissionPercentageIndividual,
                            Link = x.Link,
                            Currency = x.Currency,
                            ExchangeRate = x.ExchangeRate,
                            CreatedBy = _dbContext.User.Where(u => u.UserID.ToString() == x.CreatedBy).
                            Select(u => u.UserName).FirstOrDefault(),
                            CreatedDate = x.CreatedDate,

                            SupplierBuyingPriceUpdatedDate = x.SupplierBuyingPriceUpdatedDate,
                            TaxUpdatedDate = x.TaxUpdatedDate,
                            BankChargeUpdatedDate = x.BankChargeUpdatedDate,
                            LogisticCostUpdatedDate = x.LogisticCostUpdatedDate,
                            LogisticCostLocalUpdatedDate = x.LogisticCostLocalUpdatedDate,
                            UnexpectedCostUpdatedDate = x.UnexpectedCostUpdatedDate,
                            LossAmountDueToExchange_RateUpdatedDate = x.LossAmountDueToExchange_RateUpdatedDate,
                            MiscellaneousCostUpdatedDate = x.MiscellaneousCostUpdatedDate,
                            EquipmentAndFacilityFeesUpdatedDate = x.EquipmentAndFacilityFeesUpdatedDate
                            #endregion
                        }).OrderByDescending(x => x.Id).ToListAsync();
                }
                else if (model.Category.ToString() != "0")
                {
                    return await _dbContext.Sales.Where(x => x.ProductCategory == model.Category.ToString()
                    && x.IsDeleted == false)
                        .Select(x => new SalesModel()
                        {
                            #region DataMapping
                            Id = x.Id,
                            RefNo = x.RefNo,
                            QuotationNoToEndUser = x.QuotationNoToEndUser,
                            POReceivedDateFromEndUser = x.POReceivedDateFromEndUser,
                            PONumberFromEndUser = x.PONumberFromEndUser,
                            ProductCategory = _dbContext.Category.Where(c => c.Id.ToString() == x.ProductCategory).
                            Select(c => c.CategoryName).FirstOrDefault(),
                            ProductDetails = x.ProductDetails,
                            DeliveryOrderNoToEndUser = x.DeliveryOrderNoToEndUser,
                            DeliveryAndInvoiceDate = x.DeliveryAndInvoiceDate,
                            InvoiceNoToEndUser = x.InvoiceNoToEndUser,
                            PaymentDueDate = x.PaymentDueDate,
                            PaymentReceivedDate = x.PaymentReceivedDate,
                            TotalAmount = x.TotalAmount,
                            SupplierName = x.SupplierName,

                            SupplierBuyPrice_Currency = x.SupplierBuyPrice_Currency,
                            SupplierBuyPrice_Amount = x.SupplierBuyPrice_Amount,
                            SupplierBuyPrice_ExchangeRate = x.SupplierBuyPrice_ExchangeRate,
                            SupplierBuyPrice_Note = x.SupplierBuyPrice_Note,
                            SupplierBuyingPrice = x.SupplierBuyingPrice,

                            Tax_Currency = x.Tax_Currency,
                            Tax_Amount = x.Tax_Amount,
                            Tax_ExchangeRate = x.Tax_ExchangeRate,
                            Tax_Note = x.Tax_Note,
                            Tax = x.Tax,

                            BankCharges_Currency = x.BankCharges_Currency,
                            BankCharges_Amount = x.BankCharges_Amount,
                            BankCharges_ExchangeRate = x.BankCharges_ExchangeRate,
                            BankCharges_Note = x.BankCharges_Note,
                            BankCharges = x.BankCharges,

                            LogisticsCost_Currency = x.LogisticsCost_Currency,
                            LogisticsCost_Amount = x.LogisticsCost_Amount,
                            LogisticsCost_ExchangeRate = x.LogisticsCost_ExchangeRate,
                            LogisticsCost_Note = x.LogisticsCost_Note,
                            LogisticsCost = x.LogisticsCost,

                            LogisticsCost_Local_Currency = x.LogisticsCost_Local_Currency,
                            LogisticsCost_Local_Amount = x.LogisticsCost_Local_Amount,
                            LogisticsCost_Local_ExchangeRate = x.LogisticsCost_Local_ExchangeRate,
                            LogisticsCost_Local_Note = x.LogisticsCost_Local_Note,
                            LogisticsCost_Local = x.LogisticsCost_Local,

                            UnexpectedCost_Currency = x.UnexpectedCost_Currency,
                            UnexpectedCost_Amount = x.UnexpectedCost_Amount,
                            UnexpectedCost_ExchangeRate = x.UnexpectedCost_ExchangeRate,
                            UnexpectedCost_Note = x.UnexpectedCost_Note,
                            UnexpectedCost = x.UnexpectedCost,

                            LossAmountDueToExchange_Rate_Currency = x.LossAmountDueToExchange_Rate_Currency,
                            LossAmountDueToExchange_Rate_Amount = x.LossAmountDueToExchange_Rate_Amount,
                            LossAmountDueToExchange_Rate_ExchangeRate = x.LossAmountDueToExchange_Rate_ExchangeRate,
                            LossAmountDueToExchange_Rate_Note = x.LossAmountDueToExchange_Rate_Note,
                            LossAmountDueToExchange_Rate = x.LossAmountDueToExchange_Rate,

                            MiscellaneousCost_Currency = x.MiscellaneousCost_Currency,
                            MiscellaneousCost_Amount = x.MiscellaneousCost_Amount,
                            MiscellaneousCost_ExchangeRate = x.MiscellaneousCost_ExchangeRate,
                            MiscellaneousCost_Note = x.MiscellaneousCost_Note,
                            MiscellaneousCost = x.MiscellaneousCost,

                            EquipmentAndFacilityRentalFees_Currency = x.EquipmentAndFacilityRentalFees_Currency,
                            EquipmentAndFacilityRentalFees_Amount = x.EquipmentAndFacilityRentalFees_Amount,
                            EquipmentAndFacilityRentalFees_ExchangeRate = x.EquipmentAndFacilityRentalFees_ExchangeRate,
                            EquipmentAndFacilityRentalFees_Note = x.EquipmentAndFacilityRentalFees_Note,
                            EquipmentAndFacilityRentalFees = x.EquipmentAndFacilityRentalFees,

                            FinalSellingPrice = x.FinalSellingPrice,
                            FinalBuyingPrice = x.FinalBuyingPrice,
                            ProfitAndLoss = x.ProfitAndLoss,
                            CommissionPercentageGroup = x.CommissionPercentageGroup,
                            CommissionPercentageIndividual = x.CommissionPercentageIndividual,
                            Link = x.Link,
                            Currency = x.Currency,
                            ExchangeRate = x.ExchangeRate,
                            CreatedBy = _dbContext.User.Where(u => u.UserID.ToString() == x.CreatedBy).
                            Select(u => u.UserName).FirstOrDefault(),
                            CreatedDate = x.CreatedDate
                            #endregion
                        }).OrderByDescending(x => x.Id).ToListAsync();
                }
                else if (!string.IsNullOrEmpty(model.FromDate.ToString())
                    && !string.IsNullOrEmpty(model.ToDate.ToString()))
                {
                    return await _dbContext.Sales.Where(x => x.CreatedDate >= model.FromDate 
                    && x.CreatedDate <= model.ToDate && x.IsDeleted == false)
                        .Select(x => new SalesModel()
                        {
                            #region DataMapping
                            Id = x.Id,
                            RefNo = x.RefNo,
                            QuotationNoToEndUser = x.QuotationNoToEndUser,
                            POReceivedDateFromEndUser = x.POReceivedDateFromEndUser,
                            PONumberFromEndUser = x.PONumberFromEndUser,
                            ProductCategory = _dbContext.Category.Where(c => c.Id.ToString() == x.ProductCategory).
                            Select(c => c.CategoryName).FirstOrDefault(),
                            ProductDetails = x.ProductDetails,
                            DeliveryOrderNoToEndUser = x.DeliveryOrderNoToEndUser,
                            DeliveryAndInvoiceDate = x.DeliveryAndInvoiceDate,
                            InvoiceNoToEndUser = x.InvoiceNoToEndUser,
                            PaymentDueDate = x.PaymentDueDate,
                            PaymentReceivedDate = x.PaymentReceivedDate,
                            TotalAmount = x.TotalAmount,
                            SupplierName = x.SupplierName,

                            SupplierBuyPrice_Currency = x.SupplierBuyPrice_Currency,
                            SupplierBuyPrice_Amount = x.SupplierBuyPrice_Amount,
                            SupplierBuyPrice_ExchangeRate = x.SupplierBuyPrice_ExchangeRate,
                            SupplierBuyPrice_Note = x.SupplierBuyPrice_Note,
                            SupplierBuyingPrice = x.SupplierBuyingPrice,

                            Tax_Currency = x.Tax_Currency,
                            Tax_Amount = x.Tax_Amount,
                            Tax_ExchangeRate = x.Tax_ExchangeRate,
                            Tax_Note = x.Tax_Note,
                            Tax = x.Tax,

                            BankCharges_Currency = x.BankCharges_Currency,
                            BankCharges_Amount = x.BankCharges_Amount,
                            BankCharges_ExchangeRate = x.BankCharges_ExchangeRate,
                            BankCharges_Note = x.BankCharges_Note,
                            BankCharges = x.BankCharges,

                            LogisticsCost_Currency = x.LogisticsCost_Currency,
                            LogisticsCost_Amount = x.LogisticsCost_Amount,
                            LogisticsCost_ExchangeRate = x.LogisticsCost_ExchangeRate,
                            LogisticsCost_Note = x.LogisticsCost_Note,
                            LogisticsCost = x.LogisticsCost,

                            LogisticsCost_Local_Currency = x.LogisticsCost_Local_Currency,
                            LogisticsCost_Local_Amount = x.LogisticsCost_Local_Amount,
                            LogisticsCost_Local_ExchangeRate = x.LogisticsCost_Local_ExchangeRate,
                            LogisticsCost_Local_Note = x.LogisticsCost_Local_Note,
                            LogisticsCost_Local = x.LogisticsCost_Local,

                            UnexpectedCost_Currency = x.UnexpectedCost_Currency,
                            UnexpectedCost_Amount = x.UnexpectedCost_Amount,
                            UnexpectedCost_ExchangeRate = x.UnexpectedCost_ExchangeRate,
                            UnexpectedCost_Note = x.UnexpectedCost_Note,
                            UnexpectedCost = x.UnexpectedCost,

                            LossAmountDueToExchange_Rate_Currency = x.LossAmountDueToExchange_Rate_Currency,
                            LossAmountDueToExchange_Rate_Amount = x.LossAmountDueToExchange_Rate_Amount,
                            LossAmountDueToExchange_Rate_ExchangeRate = x.LossAmountDueToExchange_Rate_ExchangeRate,
                            LossAmountDueToExchange_Rate_Note = x.LossAmountDueToExchange_Rate_Note,
                            LossAmountDueToExchange_Rate = x.LossAmountDueToExchange_Rate,

                            MiscellaneousCost_Currency = x.MiscellaneousCost_Currency,
                            MiscellaneousCost_Amount = x.MiscellaneousCost_Amount,
                            MiscellaneousCost_ExchangeRate = x.MiscellaneousCost_ExchangeRate,
                            MiscellaneousCost_Note = x.MiscellaneousCost_Note,
                            MiscellaneousCost = x.MiscellaneousCost,

                            EquipmentAndFacilityRentalFees_Currency = x.EquipmentAndFacilityRentalFees_Currency,
                            EquipmentAndFacilityRentalFees_Amount = x.EquipmentAndFacilityRentalFees_Amount,
                            EquipmentAndFacilityRentalFees_ExchangeRate = x.EquipmentAndFacilityRentalFees_ExchangeRate,
                            EquipmentAndFacilityRentalFees_Note = x.EquipmentAndFacilityRentalFees_Note,
                            EquipmentAndFacilityRentalFees = x.EquipmentAndFacilityRentalFees,

                            FinalSellingPrice = x.FinalSellingPrice,
                            FinalBuyingPrice = x.FinalBuyingPrice,
                            ProfitAndLoss = x.ProfitAndLoss,
                            CommissionPercentageGroup = x.CommissionPercentageGroup,
                            CommissionPercentageIndividual = x.CommissionPercentageIndividual,
                            Link = x.Link,
                            Currency = x.Currency,
                            ExchangeRate = x.ExchangeRate,
                            CreatedBy = _dbContext.User.Where(u => u.UserID.ToString() == x.CreatedBy).
                            Select(u => u.UserName).FirstOrDefault(),
                            CreatedDate = x.CreatedDate,

                            SupplierBuyingPriceUpdatedDate = x.SupplierBuyingPriceUpdatedDate,
                            TaxUpdatedDate = x.TaxUpdatedDate,
                            BankChargeUpdatedDate = x.BankChargeUpdatedDate,
                            LogisticCostUpdatedDate = x.LogisticCostUpdatedDate,
                            LogisticCostLocalUpdatedDate = x.LogisticCostLocalUpdatedDate,
                            UnexpectedCostUpdatedDate = x.UnexpectedCostUpdatedDate,
                            LossAmountDueToExchange_RateUpdatedDate = x.LossAmountDueToExchange_RateUpdatedDate,
                            MiscellaneousCostUpdatedDate = x.MiscellaneousCostUpdatedDate,
                            EquipmentAndFacilityFeesUpdatedDate = x.EquipmentAndFacilityFeesUpdatedDate
                            #endregion
                        }).OrderByDescending(x => x.Id).ToListAsync();
                }
                else
                {
                    return await _dbContext.Sales.Where(x=>x.IsDeleted==false)
                        .Select(x => new SalesModel()
                        {
                            #region DataMapping
                            Id = x.Id,
                            RefNo = x.RefNo,
                            QuotationNoToEndUser = x.QuotationNoToEndUser,
                            POReceivedDateFromEndUser = x.POReceivedDateFromEndUser,
                            PONumberFromEndUser = x.PONumberFromEndUser,
                            ProductCategory = _dbContext.Category.Where(c => c.Id.ToString() == x.ProductCategory).
                            Select(c => c.CategoryName).FirstOrDefault(),
                            ProductDetails = x.ProductDetails,
                            DeliveryOrderNoToEndUser = x.DeliveryOrderNoToEndUser,
                            DeliveryAndInvoiceDate = x.DeliveryAndInvoiceDate,
                            InvoiceNoToEndUser = x.InvoiceNoToEndUser,
                            PaymentDueDate = x.PaymentDueDate,
                            PaymentReceivedDate = x.PaymentReceivedDate,
                            TotalAmount = x.TotalAmount,
                            SupplierName = x.SupplierName,

                            SupplierBuyPrice_Currency = x.SupplierBuyPrice_Currency,
                            SupplierBuyPrice_Amount = x.SupplierBuyPrice_Amount,
                            SupplierBuyPrice_ExchangeRate = x.SupplierBuyPrice_ExchangeRate,
                            SupplierBuyPrice_Note = x.SupplierBuyPrice_Note,
                            SupplierBuyingPrice = x.SupplierBuyingPrice,

                            Tax_Currency = x.Tax_Currency,
                            Tax_Amount = x.Tax_Amount,
                            Tax_ExchangeRate = x.Tax_ExchangeRate,
                            Tax_Note = x.Tax_Note,
                            Tax = x.Tax,

                            BankCharges_Currency = x.BankCharges_Currency,
                            BankCharges_Amount = x.BankCharges_Amount,
                            BankCharges_ExchangeRate = x.BankCharges_ExchangeRate,
                            BankCharges_Note = x.BankCharges_Note,
                            BankCharges = x.BankCharges,

                            LogisticsCost_Currency = x.LogisticsCost_Currency,
                            LogisticsCost_Amount = x.LogisticsCost_Amount,
                            LogisticsCost_ExchangeRate = x.LogisticsCost_ExchangeRate,
                            LogisticsCost_Note = x.LogisticsCost_Note,
                            LogisticsCost = x.LogisticsCost,

                            LogisticsCost_Local_Currency = x.LogisticsCost_Local_Currency,
                            LogisticsCost_Local_Amount = x.LogisticsCost_Local_Amount,
                            LogisticsCost_Local_ExchangeRate = x.LogisticsCost_Local_ExchangeRate,
                            LogisticsCost_Local_Note = x.LogisticsCost_Local_Note,
                            LogisticsCost_Local = x.LogisticsCost_Local,

                            UnexpectedCost_Currency = x.UnexpectedCost_Currency,
                            UnexpectedCost_Amount = x.UnexpectedCost_Amount,
                            UnexpectedCost_ExchangeRate = x.UnexpectedCost_ExchangeRate,
                            UnexpectedCost_Note = x.UnexpectedCost_Note,
                            UnexpectedCost = x.UnexpectedCost,

                            LossAmountDueToExchange_Rate_Currency = x.LossAmountDueToExchange_Rate_Currency,
                            LossAmountDueToExchange_Rate_Amount = x.LossAmountDueToExchange_Rate_Amount,
                            LossAmountDueToExchange_Rate_ExchangeRate = x.LossAmountDueToExchange_Rate_ExchangeRate,
                            LossAmountDueToExchange_Rate_Note = x.LossAmountDueToExchange_Rate_Note,
                            LossAmountDueToExchange_Rate = x.LossAmountDueToExchange_Rate,

                            MiscellaneousCost_Currency = x.MiscellaneousCost_Currency,
                            MiscellaneousCost_Amount = x.MiscellaneousCost_Amount,
                            MiscellaneousCost_ExchangeRate = x.MiscellaneousCost_ExchangeRate,
                            MiscellaneousCost_Note = x.MiscellaneousCost_Note,
                            MiscellaneousCost = x.MiscellaneousCost,

                            EquipmentAndFacilityRentalFees_Currency = x.EquipmentAndFacilityRentalFees_Currency,
                            EquipmentAndFacilityRentalFees_Amount = x.EquipmentAndFacilityRentalFees_Amount,
                            EquipmentAndFacilityRentalFees_ExchangeRate = x.EquipmentAndFacilityRentalFees_ExchangeRate,
                            EquipmentAndFacilityRentalFees_Note = x.EquipmentAndFacilityRentalFees_Note,
                            EquipmentAndFacilityRentalFees = x.EquipmentAndFacilityRentalFees,

                            FinalSellingPrice = x.FinalSellingPrice,
                            FinalBuyingPrice = x.FinalBuyingPrice,
                            ProfitAndLoss = x.ProfitAndLoss,
                            CommissionPercentageGroup = x.CommissionPercentageGroup,
                            CommissionPercentageIndividual = x.CommissionPercentageIndividual,
                            Link = x.Link,
                            Currency = x.Currency,
                            ExchangeRate = x.ExchangeRate,
                            CreatedBy = _dbContext.User.Where(u => u.UserID.ToString() == x.CreatedBy).
                            Select(u => u.UserName).FirstOrDefault(),
                            CreatedDate = x.CreatedDate,

                            SupplierBuyingPriceUpdatedDate = x.SupplierBuyingPriceUpdatedDate,
                            TaxUpdatedDate = x.TaxUpdatedDate,
                            BankChargeUpdatedDate = x.BankChargeUpdatedDate,
                            LogisticCostUpdatedDate = x.LogisticCostUpdatedDate,
                            LogisticCostLocalUpdatedDate = x.LogisticCostLocalUpdatedDate,
                            UnexpectedCostUpdatedDate = x.UnexpectedCostUpdatedDate,
                            LossAmountDueToExchange_RateUpdatedDate = x.LossAmountDueToExchange_RateUpdatedDate,
                            MiscellaneousCostUpdatedDate = x.MiscellaneousCostUpdatedDate,
                            EquipmentAndFacilityFeesUpdatedDate = x.EquipmentAndFacilityFeesUpdatedDate
                            #endregion
                        }).OrderByDescending(x => x.Id).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckRefNo(string refNo)
        {
            try
            {
                var dataResult = _dbContext.Sales.Where(x => x.RefNo == refNo && x.IsDeleted==false).Select(x => x.RefNo).FirstOrDefault();
                if (dataResult != null)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<int> UpdateSale(SalesModel model)
        {
            try
            {
                SalesEntities entities = new SalesEntities();
                entities = await _dbContext.Sales.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
                if (entities != null)
                {
                    #region Data Mapping
                    entities.Id = model.Id;
                    entities.RefNo = model.RefNo;
                    entities.QuotationNoToEndUser = model.QuotationNoToEndUser;
                    entities.POReceivedDateFromEndUser = model.POReceivedDateFromEndUser;
                    entities.PONumberFromEndUser = model.PONumberFromEndUser;
                    entities.ProductCategory = model.ProductCategory;
                    entities.ProductDetails = model.ProductDetails;
                    entities.DeliveryOrderNoToEndUser = model.DeliveryOrderNoToEndUser;
                    entities.DeliveryAndInvoiceDate = model.DeliveryAndInvoiceDate;
                    entities.InvoiceNoToEndUser = model.InvoiceNoToEndUser;
                    entities.PaymentDueDate = model.PaymentDueDate;
                    entities.PaymentReceivedDate = model.PaymentReceivedDate;
                    entities.TotalAmount = model.TotalAmount;
                    entities.SupplierName = model.SupplierName;
                    entities.SupplierBuyPrice_Currency = model.SupplierBuyPrice_Currency;
                    entities.SupplierBuyPrice_Amount = model.SupplierBuyPrice_Amount;
                    entities.SupplierBuyPrice_ExchangeRate = model.SupplierBuyPrice_ExchangeRate;
                    entities.SupplierBuyPrice_Note = model.SupplierBuyPrice_Note;
                    entities.SupplierBuyingPrice = model.SupplierBuyingPrice;

                    entities.Tax_Currency = model.Tax_Currency;
                    entities.Tax_Amount = model.Tax_Amount;
                    entities.Tax_ExchangeRate = model.Tax_ExchangeRate;
                    entities.Tax_Note = model.Tax_Note;
                    entities.Tax = model.Tax;

                    entities.BankCharges_Currency = model.BankCharges_Currency;
                    entities.BankCharges_Amount = model.BankCharges_Amount;
                    entities.BankCharges_ExchangeRate = model.BankCharges_ExchangeRate;
                    entities.BankCharges_Note = model.BankCharges_Note;
                    entities.BankCharges = model.BankCharges;

                    entities.LogisticsCost_Currency = model.LogisticsCost_Currency;
                    entities.LogisticsCost_Amount = model.LogisticsCost_Amount;
                    entities.LogisticsCost_ExchangeRate = model.LogisticsCost_ExchangeRate;
                    entities.LogisticsCost_Note = model.LogisticsCost_Note;
                    entities.LogisticsCost = model.LogisticsCost;

                    entities.LogisticsCost_Local_Currency = model.LogisticsCost_Local_Currency;
                    entities.LogisticsCost_Local_Amount = model.LogisticsCost_Local_Amount;
                    entities.LogisticsCost_Local_ExchangeRate = model.LogisticsCost_Local_ExchangeRate;
                    entities.LogisticsCost_Local_Note = model.LogisticsCost_Local_Note;
                    entities.LogisticsCost_Local = model.LogisticsCost_Local;

                    entities.UnexpectedCost_Currency = model.UnexpectedCost_Currency;
                    entities.UnexpectedCost_Amount = model.UnexpectedCost_Amount;
                    entities.UnexpectedCost_ExchangeRate = model.UnexpectedCost_ExchangeRate;
                    entities.UnexpectedCost_Note = model.UnexpectedCost_Note;
                    entities.UnexpectedCost = model.UnexpectedCost;

                    entities.LossAmountDueToExchange_Rate_Currency = model.LossAmountDueToExchange_Rate_Currency;
                    entities.LossAmountDueToExchange_Rate_Amount = model.LossAmountDueToExchange_Rate_Amount;
                    entities.LossAmountDueToExchange_Rate_ExchangeRate = model.LossAmountDueToExchange_Rate_ExchangeRate;
                    entities.LossAmountDueToExchange_Rate_Note = model.LossAmountDueToExchange_Rate_Note;
                    entities.LossAmountDueToExchange_Rate = model.LossAmountDueToExchange_Rate;

                    entities.MiscellaneousCost_Currency = model.MiscellaneousCost_Currency;
                    entities.MiscellaneousCost_Amount = model.MiscellaneousCost_Amount;
                    entities.MiscellaneousCost_ExchangeRate = model.MiscellaneousCost_ExchangeRate;
                    entities.MiscellaneousCost_Note = model.MiscellaneousCost_Note;
                    entities.MiscellaneousCost = model.MiscellaneousCost;

                    entities.EquipmentAndFacilityRentalFees_Currency = model.EquipmentAndFacilityRentalFees_Currency;
                    entities.EquipmentAndFacilityRentalFees_Amount = model.EquipmentAndFacilityRentalFees_Amount;
                    entities.EquipmentAndFacilityRentalFees_ExchangeRate = model.EquipmentAndFacilityRentalFees_ExchangeRate;
                    entities.EquipmentAndFacilityRentalFees_Note = model.EquipmentAndFacilityRentalFees_Note;
                    entities.EquipmentAndFacilityRentalFees = model.EquipmentAndFacilityRentalFees;

                    entities.FinalSellingPrice = model.FinalSellingPrice;
                    entities.FinalBuyingPrice = model.FinalBuyingPrice;
                    entities.ProfitAndLoss = model.ProfitAndLoss;
                    entities.CommissionPercentageGroup = model.CommissionPercentageGroup;
                    entities.CommissionPercentageIndividual = model.CommissionPercentageIndividual;
                    entities.Link = model.Link;
                    entities.Currency = model.Currency;
                    entities.ExchangeRate = model.ExchangeRate;
                    entities.SupplierBuyingPriceUpdatedDate = model.SupplierBuyingPriceUpdatedDate;
                    entities.TaxUpdatedDate = model.TaxUpdatedDate;
                    entities.BankChargeUpdatedDate = model.BankChargeUpdatedDate;
                    entities.LogisticCostUpdatedDate = model.LogisticCostUpdatedDate;
                    entities.LogisticCostLocalUpdatedDate = model.LogisticCostLocalUpdatedDate;
                    entities.UnexpectedCostUpdatedDate = model.UnexpectedCostUpdatedDate;
                    entities.LossAmountDueToExchange_RateUpdatedDate = model.LossAmountDueToExchange_RateUpdatedDate;
                    entities.MiscellaneousCostUpdatedDate = model.MiscellaneousCostUpdatedDate;
                    entities.EquipmentAndFacilityFeesUpdatedDate = model.EquipmentAndFacilityFeesUpdatedDate;
                    entities.UpdatedDate = DateTime.Now.Date;
                    #endregion
                    _dbContext.Sales.Update(entities);
                    return await _dbContext.SaveChangesAsync();
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> DeleteSaleRecord(int Id, int deletedBy)
        {
            try
            {
                SalesEntities entities = new SalesEntities();
                entities = await _dbContext.Sales.FirstOrDefaultAsync(x => x.Id == Id);
                if (entities != null)
                {
                    entities.IsDeleted = true;
                    entities.DeletedDate = DateTime.Now.Date;
                    entities.DeletedBy = deletedBy;
                    _dbContext.Update(entities);
                    return await _dbContext.SaveChangesAsync();
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
