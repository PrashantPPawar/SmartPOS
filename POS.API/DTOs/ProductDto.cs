namespace POS.API.DTOs
{
    public class ProductDto
    {
        public int? Id { get; set; }
        public string Barcode { get; set; }
        public string Department { get; set; }
        public string Section { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string Brand { get; set; }
        public string Pattern { get; set; }
        public string ArticleName { get; set; }
        public string Unit { get; set; }
        public string GSTGroup { get; set; }
        public string HSNCode { get; set; }
        public string ProductType { get; set; }
        public decimal PRP { get; set; }
        public decimal MRP { get; set; }
        public decimal WSP { get; set; }
        public decimal SSP { get; set; }
        public int Stock { get; set; }
        public int MinLevel { get; set; }
        public int MaxLevel { get; set; }
        public bool IsActive { get; set; }
    }
}
