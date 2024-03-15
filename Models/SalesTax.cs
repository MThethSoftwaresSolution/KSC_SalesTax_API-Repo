namespace KSC_SalesTax_API.Models
{
    public class SalesTax
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsImported { get; set; }
        public int GoodTypeId { get; set; }
        public int Count { get; set; }
    }
}
