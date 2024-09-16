
namespace Models
{
    public class EquipmentSupplierContact
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? AddressLine3 { get; set; }
        public string? AddressLine4 { get; set; }
        public string? PostCode { get; set; }
        public string? Telephone { get; set; }
        public string? Email { get; set; }



        //public EquipmentSupplierContact(int id, int supplierId, string? addressLine1, string? addressLine2, string? addressLine3, string? addressLine4, string? postCode, , string? telephone, string? email)
        //{
        //    Id = id;
        //    SupplierId = supplierId;
        //    AddressLine1 = addressLine1;
        //    AddressLine2 = addressLine2;
        //    AddressLine3 = addressLine3;
        //    AddressLine4 = addressLine4;
        //    AddressLine4 = addressLine4;
        //    AddressLine4 = addressLine4;
        //    PostCode = postCode;
        //    Telephone = telephone;
        //    Email = email;

        //}
    }
}
