using Microsoft.EntityFrameworkCore;
using TechnoPark_SupplimentSystem.Models;
using TechnoPark_SupplimentSystem.Models.Entities;

namespace TechnoPark_SupplimentSystem.Services
{
    public class GlobalSupplierServices
    {
        private EFDBContext _dbContext;

        public GlobalSupplierServices(EFDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateSupplier(GlobalSupplierModel model)
        {
            try
            {
                #region DataMapping
                GlobalSupplierEntities entities = new GlobalSupplierEntities();
                entities.Supplier_Company_Name = model.Supplier_Company_Name;
                entities.Supplier_Contact_Person = model.Supplier_Contact_Person;
                entities.Phone = model.Phone;
                entities.Email = model.Email;
                entities.Website = model.Website;
                entities.Brand = model.Brand;
                entities.Country = model.Country;
                entities.Product_Details = model.Product_Details;
                entities.Product_Category = model.Product_Category;
                entities.Purchased_History_Type_of_Response = model.Purchased_History_Type_of_Response;
                entities.Supplier_Invoice_Number = model.Supplier_Invoice_Number;
                entities.End_User_PO_Number = model.End_User_PO_Number;
                entities.Quotation_to_End_User = model.Quotation_to_End_User;
                entities.Stock_Photo_at_Technopark_Warehouse = model.Stock_Photo_at_Technopark_Warehouse;
                #endregion
                await _dbContext.GlobalSupplier.AddAsync(entities);
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<GlobalSupplierModel>> GlobalSupplierList()
        {
            try
            {
                return await _dbContext.GlobalSupplier.Select(x => new GlobalSupplierModel()
                {
                    NO = x.NO,
                    Supplier_Company_Name = x.Supplier_Company_Name,
                    Supplier_Contact_Person = x.Supplier_Contact_Person,
                    Phone = x.Phone,
                    Email = x.Email,
                    Website = x.Website,
                    Country = x.Country,
                    Product_Details = x.Product_Details,
                    Product_Category = x.Product_Category,
                    Purchased_History_Type_of_Response = x.Purchased_History_Type_of_Response,
                    Supplier_Invoice_Number = x.Supplier_Invoice_Number,
                    End_User_PO_Number = x.End_User_PO_Number,
                    Quotation_to_End_User = (DateTime)x.Quotation_to_End_User,
                    Stock_Photo_at_Technopark_Warehouse = x.Stock_Photo_at_Technopark_Warehouse,
                }).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> UpdateGlobalSupplier(GlobalSupplierModel model)
        {
            try
            {
                GlobalSupplierEntities entities = new GlobalSupplierEntities();
                entities = await _dbContext.GlobalSupplier.AsNoTracking().Where(x => x.NO == model.NO).FirstOrDefaultAsync();
                if (entities != null)
                {
                    #region DataMapping
                    entities.NO = model.NO;
                    entities.Supplier_Company_Name = model.Supplier_Company_Name;
                    entities.Supplier_Contact_Person = model.Supplier_Contact_Person;
                    entities.Phone = model.Phone;
                    entities.Email = model.Email;
                    entities.Website = model.Website;
                    entities.Country = model.Country;
                    entities.Brand = model.Brand;
                    entities.Product_Details = model.Product_Details;
                    entities.Product_Category = model.Product_Category;
                    entities.Purchased_History_Type_of_Response = model.Purchased_History_Type_of_Response;
                    entities.Supplier_Invoice_Number = model.Supplier_Invoice_Number;
                    entities.End_User_PO_Number = model.End_User_PO_Number;
                    entities.Quotation_to_End_User = model.Quotation_to_End_User;
                    entities.Stock_Photo_at_Technopark_Warehouse = model.Stock_Photo_at_Technopark_Warehouse;
                    #endregion

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

        public async Task<int> DeleteGlobalSupplier(int? No)
        {
            try
            {
                GlobalSupplierEntities entities = new GlobalSupplierEntities();
                entities = await _dbContext.GlobalSupplier.Where(x => x.NO == No).FirstOrDefaultAsync();
                if (entities != null)
                {
                    _dbContext.GlobalSupplier.Remove(entities);
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
