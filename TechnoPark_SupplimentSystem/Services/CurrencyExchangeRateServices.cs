using Microsoft.EntityFrameworkCore;
using TechnoPark_SupplimentSystem.Models;
using TechnoPark_SupplimentSystem.Models.Entities;

namespace TechnoPark_SupplimentSystem.Services
{
    public class CurrencyExchangeRateServices
    {
        private EFDBContext _dbContext;

        public CurrencyExchangeRateServices(EFDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> SetupExchangeRate(CurrencyExchangeRateModel model)
        {
            try
            {
                #region DataMapping
                CurrencyExchangeRateEntities entities = new CurrencyExchangeRateEntities();
                entities.USD_ExchangeRate = model.USD_ExchangeRate;
                entities.EUR_ExchangeRate = model.EUR_ExchangeRate;
                entities.JPY_ExchangeRate = model.JPY_ExchangeRate;
                entities.THB_ExchangeRate = model.THB_ExchangeRate;
                entities.CNY_ExchangeRate = model.CNY_ExchangeRate;
                entities.SGD_ExchangeRate = model.SGD_ExchangeRate;
                entities.GBP_ExchangRate = model.GBP_ExchangRate;
                entities.MRM_ExchangeRate = model.MRM_ExchangeRate;
                entities.KW_Exchange_Rate = model.KW_Exchange_Rate;
                entities.AUD_Exchange_Rate = model.AUD_Exchange_Rate;
                entities.AED_Exchange_Rate = model.AED_Exchange_Rate;
                entities.ExchangeRateDate = Convert.ToDateTime(model.ExchangeRateDate).Date;
                entities.CreatedDate = DateTime.Now.Date;
                #endregion
                _dbContext.CurrencyExchangeRate.Add(entities);
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public bool CheckDuplicateCurrency(string currency)
        //{
        //    try
        //    {
        //        var dataResult = _dbContext.CurrencyExchangeRate.Where(x => x.Currency.ToUpper() == currency.ToUpper())
        //            .FirstOrDefault();
        //        if (dataResult != null)
        //        {
        //            return false;
        //        }
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public async Task<List<CurrencyExchangeRateModel>> GetExchangeRateList()
        {
            try
            {
                return await _dbContext.CurrencyExchangeRate.Select(x => new CurrencyExchangeRateModel()
                {
                    Id = x.Id,
                    //Currency = x.Currency,
                    USD_ExchangeRate = x.USD_ExchangeRate,
                    EUR_ExchangeRate = x.EUR_ExchangeRate,
                    JPY_ExchangeRate = x.JPY_ExchangeRate,
                    THB_ExchangeRate = x.THB_ExchangeRate,
                    CNY_ExchangeRate = x.CNY_ExchangeRate,
                    SGD_ExchangeRate = x.SGD_ExchangeRate,
                    GBP_ExchangRate = x.GBP_ExchangRate,
                    MRM_ExchangeRate = x.MRM_ExchangeRate,
                    KW_Exchange_Rate = x.KW_Exchange_Rate,
                    AUD_Exchange_Rate = x.AUD_Exchange_Rate,
                    AED_Exchange_Rate = x.AED_Exchange_Rate,
                    ExchangeRateDate = x.ExchangeRateDate.HasValue
                    ? x.ExchangeRateDate.Value.ToString("yyyy-MM-dd hh:mm tt")
                    : "<date value not avalialbe>",
                    CreatedDate = x.CreatedDate.ToString("yyyy-MM-dd hh:mm tt"),
                }).OrderByDescending(x => x.Id).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DailyExchangeRateResponseModel> GetDailyExchangeRateByCurrency(string currency,DateTime exchangeRateDate)
        {
            try
            {
                switch (currency)
                {
                    case "USD":
                        if (exchangeRateDate != default(DateTime))
                        {
                            return await _dbContext.CurrencyExchangeRate.Where(x=>x.ExchangeRateDate==exchangeRateDate)
                                .Select(x => new DailyExchangeRateResponseModel()
                            {
                                Id = x.Id,
                                ExchangeRate = x.USD_ExchangeRate
                            }).OrderByDescending(x => x.Id).FirstOrDefaultAsync();
                        }
                        return await _dbContext.CurrencyExchangeRate.Select(x => new DailyExchangeRateResponseModel()
                        {
                            Id = x.Id,
                            ExchangeRate = x.USD_ExchangeRate
                        }).OrderByDescending(x => x.Id).FirstOrDefaultAsync();

                    case "EUR":
                        if (exchangeRateDate != default(DateTime))
                        {
                            return await _dbContext.CurrencyExchangeRate.Where(x => x.ExchangeRateDate == exchangeRateDate)
                                .Select(x => new DailyExchangeRateResponseModel()
                                {
                                    Id = x.Id,
                                    ExchangeRate = x.EUR_ExchangeRate
                                }).OrderByDescending(x => x.Id).FirstOrDefaultAsync();
                        }
                        return await _dbContext.CurrencyExchangeRate.Select(x => new DailyExchangeRateResponseModel()
                        {
                            Id = x.Id,
                            ExchangeRate = x.EUR_ExchangeRate
                        }).OrderByDescending(x => x.Id).FirstOrDefaultAsync();

                    case "JPY":
                        if (exchangeRateDate != default(DateTime))
                        {
                            return await _dbContext.CurrencyExchangeRate.Where(x => x.ExchangeRateDate == exchangeRateDate)
                                .Select(x => new DailyExchangeRateResponseModel()
                                {
                                    Id = x.Id,
                                    ExchangeRate = x.JPY_ExchangeRate
                                }).OrderByDescending(x => x.Id).FirstOrDefaultAsync();
                        }
                        return await _dbContext.CurrencyExchangeRate.Select(x => new DailyExchangeRateResponseModel()
                        {
                            Id = x.Id,
                            ExchangeRate = x.JPY_ExchangeRate
                        }).OrderByDescending(x => x.Id).FirstOrDefaultAsync();

                    case "THB":
                        if (exchangeRateDate != default(DateTime))
                        {
                            return await _dbContext.CurrencyExchangeRate.Where(x => x.ExchangeRateDate == exchangeRateDate)
                                .Select(x => new DailyExchangeRateResponseModel()
                                {
                                    Id = x.Id,
                                    ExchangeRate = x.THB_ExchangeRate
                                }).OrderByDescending(x => x.Id).FirstOrDefaultAsync();
                        }
                        return await _dbContext.CurrencyExchangeRate.Select(x => new DailyExchangeRateResponseModel()
                        {
                            Id = x.Id,
                            ExchangeRate = x.THB_ExchangeRate
                        }).OrderByDescending(x => x.Id).FirstOrDefaultAsync();

                    case "CNY":
                        if (exchangeRateDate != default(DateTime))
                        {
                            return await _dbContext.CurrencyExchangeRate.Where(x => x.ExchangeRateDate == exchangeRateDate)
                                .Select(x => new DailyExchangeRateResponseModel()
                                {
                                    Id = x.Id,
                                    ExchangeRate = x.CNY_ExchangeRate
                                }).OrderByDescending(x => x.Id).FirstOrDefaultAsync();
                        }
                        return await _dbContext.CurrencyExchangeRate.Select(x => new DailyExchangeRateResponseModel()
                        {
                            Id = x.Id,
                            ExchangeRate = x.CNY_ExchangeRate
                        }).OrderByDescending(x => x.Id).FirstOrDefaultAsync();

                    case "SGD":
                        if (exchangeRateDate != default(DateTime))
                        {
                            return await _dbContext.CurrencyExchangeRate.Where(x => x.ExchangeRateDate == exchangeRateDate)
                                .Select(x => new DailyExchangeRateResponseModel()
                                {
                                    Id = x.Id,
                                    ExchangeRate = x.SGD_ExchangeRate
                                }).OrderByDescending(x => x.Id).FirstOrDefaultAsync();
                        }
                        return await _dbContext.CurrencyExchangeRate.Select(x => new DailyExchangeRateResponseModel()
                        {
                            Id = x.Id,
                            ExchangeRate = x.SGD_ExchangeRate
                        }).OrderByDescending(x => x.Id).FirstOrDefaultAsync();
                    case "GBP":
                        if (exchangeRateDate != default(DateTime))
                        {
                            return await _dbContext.CurrencyExchangeRate.Where(x => x.ExchangeRateDate == exchangeRateDate)
                                .Select(x => new DailyExchangeRateResponseModel()
                                {
                                    Id = x.Id,
                                    ExchangeRate = x.GBP_ExchangRate
                                }).OrderByDescending(x => x.Id).FirstOrDefaultAsync();
                        }
                        return await _dbContext.CurrencyExchangeRate.Select(x => new DailyExchangeRateResponseModel()
                        {
                            Id = x.Id,
                            ExchangeRate = x.GBP_ExchangRate
                        }).OrderByDescending(x => x.Id).FirstOrDefaultAsync();

                    case "MRM":
                        if (exchangeRateDate != default(DateTime))
                        {
                            return await _dbContext.CurrencyExchangeRate.Where(x => x.ExchangeRateDate == exchangeRateDate)
                                .Select(x => new DailyExchangeRateResponseModel()
                                {
                                    Id = x.Id,
                                    ExchangeRate = x.MRM_ExchangeRate
                                }).OrderByDescending(x => x.Id).FirstOrDefaultAsync();
                        }
                        return await _dbContext.CurrencyExchangeRate.Select(x => new DailyExchangeRateResponseModel()
                        {
                            Id = x.Id,
                            ExchangeRate = x.MRM_ExchangeRate
                        }).OrderByDescending(x => x.Id).FirstOrDefaultAsync();

                    case "KW":
                        if (exchangeRateDate != default(DateTime))
                        {
                            return await _dbContext.CurrencyExchangeRate.Where(x => x.ExchangeRateDate == exchangeRateDate)
                                .Select(x => new DailyExchangeRateResponseModel()
                                {
                                    Id = x.Id,
                                    ExchangeRate = x.KW_Exchange_Rate
                                }).OrderByDescending(x => x.Id).FirstOrDefaultAsync();
                        }
                        return await _dbContext.CurrencyExchangeRate.Select(x => new DailyExchangeRateResponseModel()
                        {
                            Id = x.Id,
                            ExchangeRate = x.KW_Exchange_Rate
                        }).OrderByDescending(x => x.Id).FirstOrDefaultAsync();

                    case "AUD":
                        if (exchangeRateDate != default(DateTime))
                        {
                            return await _dbContext.CurrencyExchangeRate.Where(x => x.ExchangeRateDate == exchangeRateDate)
                                .Select(x => new DailyExchangeRateResponseModel()
                                {
                                    Id = x.Id,
                                    ExchangeRate = x.AUD_Exchange_Rate
                                }).OrderByDescending(x => x.Id).FirstOrDefaultAsync();
                        }
                        return await _dbContext.CurrencyExchangeRate.Select(x => new DailyExchangeRateResponseModel()
                        {
                            Id = x.Id,
                            ExchangeRate = x.AUD_Exchange_Rate
                        }).OrderByDescending(x => x.Id).FirstOrDefaultAsync();

                    case "AED":
                        if (exchangeRateDate != default(DateTime))
                        {
                            return await _dbContext.CurrencyExchangeRate.Where(x => x.ExchangeRateDate == exchangeRateDate)
                                .Select(x => new DailyExchangeRateResponseModel()
                                {
                                    Id = x.Id,
                                    ExchangeRate = x.AED_Exchange_Rate
                                }).OrderByDescending(x => x.Id).FirstOrDefaultAsync();
                        }
                        return await _dbContext.CurrencyExchangeRate.Select(x => new DailyExchangeRateResponseModel()
                        {
                            Id = x.Id,
                            ExchangeRate = x.AED_Exchange_Rate
                        }).OrderByDescending(x => x.Id).FirstOrDefaultAsync();

                    default:
                        return new DailyExchangeRateResponseModel();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> UpdateExchangeRate(CurrencyExchangeRateModel model)
        {
            try
            {

                CurrencyExchangeRateEntities entities = new CurrencyExchangeRateEntities();
                entities = await _dbContext.CurrencyExchangeRate.AsNoTracking().Where(x => x.Id == model.Id).FirstOrDefaultAsync();
                if (entities != null)
                {
                    #region DataMapping
                    entities.USD_ExchangeRate = model.USD_ExchangeRate;
                    entities.EUR_ExchangeRate = model.EUR_ExchangeRate;
                    entities.JPY_ExchangeRate = model.JPY_ExchangeRate;
                    entities.THB_ExchangeRate = model.THB_ExchangeRate;
                    entities.CNY_ExchangeRate = model.CNY_ExchangeRate;
                    entities.SGD_ExchangeRate = model.SGD_ExchangeRate;
                    entities.GBP_ExchangRate = model.GBP_ExchangRate;
                    entities.MRM_ExchangeRate = model.MRM_ExchangeRate;
                    entities.KW_Exchange_Rate = model.KW_Exchange_Rate;
                    entities.AUD_Exchange_Rate = model.AUD_Exchange_Rate;
                    entities.AED_Exchange_Rate = model.AED_Exchange_Rate;
                    #endregion
                }
                _dbContext.CurrencyExchangeRate.Update(entities);
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> DeleteExchangeRate(int Id)
        {
            try
            {
                CurrencyExchangeRateEntities entities = new CurrencyExchangeRateEntities();
                entities = await _dbContext.CurrencyExchangeRate.AsNoTracking().Where(x => x.Id == Id).FirstOrDefaultAsync();
                if (entities != null)
                {
                    _dbContext.CurrencyExchangeRate.Remove(entities);
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
