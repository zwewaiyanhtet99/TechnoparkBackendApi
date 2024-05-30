using Microsoft.EntityFrameworkCore;
using TechnoPark_SupplimentSystem.Models.Entities;
using TechnoPark_SupplimentSystem.Models;

namespace TechnoPark_SupplimentSystem.Services
{
    public class LocalSupplierServices
    {
        private EFDBContext _dbContext;

        public LocalSupplierServices(EFDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateSupplier(LocalSupplierModel model)
        {
            try
            {
                #region DataMapping
                LocalSupplierEntities entities = new LocalSupplierEntities();
                entities.Supplier_Company_Name = model.Supplier_Company_Name;
                entities.Suppliers_Contact_Person = model.Suppliers_Contact_Person;
                entities.Phone = model.Phone;
                entities.Email = model.Email;
                entities.Website = model.Website;
                entities.Brand = model.Brand;
                entities.Product_Details = model.Product_Details;
                entities.Product_Category = model.Product_Category;
                entities.Purchased_History_Type_of_Response = model.Purchased_History_Type_of_Response;
                entities.Supplier_Invoice_Number = model.Supplier_Invoice_Number;
                entities.End_User_PO_Number = model.End_User_PO_Number;
                entities.Quotation_to_End_User = model.Quotation_to_End_User;
                entities.Stock_Photo_at_Technopark_Warehouse = model.Stock_Photo_at_Technopark_Warehouse;
                #endregion
                await _dbContext.LocalSupplier.AddAsync(entities);
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<LocalSupplierModel>> GlobalSupplierList()
        {
            try
            {
                return await _dbContext.LocalSupplier.Select(x => new LocalSupplierModel()
                {
                    NO=x.NO,
                    Supplier_Company_Name = x.Supplier_Company_Name,
                    Suppliers_Contact_Person = x.Suppliers_Contact_Person,
                    Phone = x.Phone,
                    Email = x.Email,
                    Website = x.Website,
                    Product_Details = x.Product_Details,
                    Product_Category = x.Product_Category,
                    Purchased_History_Type_of_Response = x.Purchased_History_Type_of_Response,
                    Supplier_Invoice_Number = x.Supplier_Invoice_Number,
                    End_User_PO_Number = x.End_User_PO_Number,
                    Quotation_to_End_User = x.Quotation_to_End_User,
                    Stock_Photo_at_Technopark_Warehouse = x.Stock_Photo_at_Technopark_Warehouse,
                }).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> UpdateGlobalSupplier(LocalSupplierModel model)
        {
            try
            {
                LocalSupplierEntities entities = new LocalSupplierEntities();
                entities = await _dbContext.LocalSupplier.AsNoTracking().Where(x => x.NO == model.NO).FirstOrDefaultAsync();
                if (entities != null)
                {
                    #region DataMapping
                    entities.NO = model.NO;
                    entities.Supplier_Company_Name = model.Supplier_Company_Name;
                    entities.Suppliers_Contact_Person = model.Suppliers_Contact_Person;
                    entities.Phone = model.Phone;
                    entities.Email = model.Email;
                    entities.Website = model.Website;
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
                LocalSupplierEntities entities = new LocalSupplierEntities();
                entities = await _dbContext.LocalSupplier.Where(x => x.NO == No).FirstOrDefaultAsync();
                if (entities != null)
                {
                    _dbContext.LocalSupplier.Remove(entities);
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
