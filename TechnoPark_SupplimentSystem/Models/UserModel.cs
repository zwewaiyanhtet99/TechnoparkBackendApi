namespace TechnoPark_SupplimentSystem.Models
{
    public class UserModel
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserRole { get; set; }
        public string Password { get; set; }
        public string CreatedDate { get; set; }
    }

    public class AfterLoginResponseModel
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserRole { get; set; }
    }
}
