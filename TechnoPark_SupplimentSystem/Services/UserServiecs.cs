using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using TechnoPark_SupplimentSystem.Models;
using TechnoPark_SupplimentSystem.Models.Entities;

namespace TechnoPark_SupplimentSystem.Services
{
    public class UserServiecs
    {
        private EFDBContext _dbContext;

        public UserServiecs(EFDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> RegisterUser(UserModel model)
        {
            try
            {
                if (CheckUser(model.UserName))
                {
                    #region DataMapping
                    UserEntities entities = new UserEntities();
                    entities.UserName = model.UserName;
                    entities.Password = model.Password;
                    entities.UserRole = model.UserRole;
                    entities.CreatedDate = DateTime.Now.ToString();
                    #endregion
                    await _dbContext.User.AddAsync(entities);
                    return await _dbContext.SaveChangesAsync();
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckUser(string userName)
        {
            try
            {
                var checkUser = _dbContext.User.Where(x => x.UserName == userName).Select(x => x.UserName)
                    .FirstOrDefault();
                return checkUser != null ? false : true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AfterLoginResponseModel> Login(string userName, string password)
        {
            try
            {
                var dataResult = await _dbContext.User.Where(x => x.UserName == userName && x.Password == password)
                    .Select(x => new AfterLoginResponseModel()
                    {
                        UserID = x.UserID,
                        UserName = x.UserName,
                        UserRole = x.UserRole
                    }).FirstOrDefaultAsync();
                if (dataResult != null)
                {
                    return dataResult;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<UserModel>> UserList()
        {
            string filePath_1 = @"C:\New folder\Error.txt";
            try
            {
                List<UserModel> lstUser = new List<UserModel>();
                var dataResult = await _dbContext.User.Select(x => new UserModel()
                {
                    UserID = x.UserID,
                    UserName = x.UserName,
                    UserRole = x.UserRole,
                    Password = x.Password,
                    CreatedDate = x.CreatedDate.ToString()
                }).ToListAsync();
                return dataResult;
            }
            catch (Exception ex)
            {
                //using (StreamWriter writer = new StreamWriter(filePath, true))
                //{
                //    writer.WriteLine("-----------------------------------------------------------------------------");
                //    writer.WriteLine("Date : " + DateTime.Now.ToString());
                //    writer.WriteLine();

                //    while (ex != null)
                //    {
                //        writer.WriteLine(ex.GetType().FullName);
                //        writer.WriteLine("Message : " + ex.Message);
                //        writer.WriteLine("StackTrace : " + ex.StackTrace);

                //        ex = ex.InnerException;
                //    }
                //}
                throw ex;
            }
        }

        public async Task<int> UpdateUser(UserModel model)
        {
            try
            {
                var dataResult = await _dbContext.User.AsNoTracking().Where(x => x.UserID == model.UserID)
                    .FirstOrDefaultAsync();
                #region DataMapping
                UserEntities entities = new UserEntities();
                entities.UserID = dataResult.UserID;
                entities.UserName = model.UserName;
                entities.Password = model.Password;
                entities.UserRole = model.UserRole;
                entities.CreatedDate = dataResult.CreatedDate;
                #endregion
                _dbContext.Update(entities);
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> DeleteUser(int userID)
        {
            try
            {
                int isDelete = 0;
                UserEntities entities = new UserEntities();
                entities.UserID = await _dbContext.User.Where(x => x.UserID == userID).Select(x => x.UserID)
                   .FirstOrDefaultAsync();
                if (entities.UserID > 0)
                {
                    _dbContext.User.Remove(entities);
                    isDelete = await _dbContext.SaveChangesAsync();
                }
                return isDelete > 0 ? 1 : 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
