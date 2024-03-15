using KSC_SalesTax_API.Models;

namespace KSC_SalesTax_API.Helpers
{
    public class Seed
    {
        IList<GoodType> goodTypes = new List<GoodType>();
        //Seed Good types
        public Seed()
        {
            goodTypes.Add(new GoodType() { Id = 1, Name = "Book" });
            goodTypes.Add(new GoodType() { Id = 2, Name = "Food" });
            goodTypes.Add(new GoodType() { Id = 3, Name = "Medical" });
            goodTypes.Add(new GoodType() { Id = 4, Name = "Normal" });
        }

        public List<GoodType> GetGoodTypes()
        {
            return goodTypes.ToList();
        }
    }
}
