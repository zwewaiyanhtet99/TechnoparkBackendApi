using Microsoft.EntityFrameworkCore;
using TechnoPark_SupplimentSystem.Models;
using TechnoPark_SupplimentSystem.Models.Entities;

namespace TechnoPark_SupplimentSystem.Services
{
    public class CommissionServices
    {
        private EFDBContext _dbContext;

        public CommissionServices(EFDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CommissionModel> GetCommission()
        {
            try
            {
                return await _dbContext.Commission.Select(x => new CommissionModel
                {
                    Id = x.Id,
                    CommissionPercentageIndividual = x.CommissionPercentageIndividual,
                    CommissionPercentageTeam = x.CommissionPercentageTeam,
                    CreatedDate = x.CreatedDate,
                    CreatedUserId = x.CreatedUserId,
                    UpdatedDate = x.UpdatedDate,
                    UpdatedUserId = x.UpdatedUserId
                }).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> CreateCommission(CommissionModel model)
        {
            try
            {
                CommissionEntities entities = new CommissionEntities();
                //update commission if count row is greater than or equal to 1
                if (CheckCountRows())
                {
                    #region ExchangeData
                    entities.CommissionPercentageIndividual = model.CommissionPercentageIndividual + "%";
                    entities.CommissionPercentageTeam = model.CommissionPercentageTeam + "%";
                    entities.CreatedDate = DateTime.Now.Date;
                    entities.CreatedUserId = model.CreatedUserId;
                    #endregion
                }
                else
                {
                    return await UpdateCommission(model);
                }
                await _dbContext.Commission.AddAsync(entities);
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> UpdateCommission(CommissionModel model)
        {
            try
            {
                CommissionEntities entities = new CommissionEntities();
                if (model.Id == 0)
                {
                    entities = await _dbContext.Commission.FirstOrDefaultAsync();
                    model.Id = entities.Id;
                    entities.UpdatedUserId = model.CreatedUserId;
                }
                entities = await _dbContext.Commission.FindAsync(model.Id);
                if (entities != null)
                {
                    #region ExchangeData
                    entities.CommissionPercentageIndividual = model.CommissionPercentageIndividual + "%";
                    entities.CommissionPercentageTeam = model.CommissionPercentageTeam + "%";
                    entities.UpdatedDate = DateTime.Now.Date;
                    entities.UpdatedUserId = model.UpdatedUserId;
                    #endregion
                }
                _dbContext.Commission.Update(entities);
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckCountRows()
        {
            try
            {
                var countRows = _dbContext.Commission.ToList();
                return countRows.Count > 0 ? false : true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
