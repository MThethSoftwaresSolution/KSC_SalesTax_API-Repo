using KSC_SalesTax_API.Models;

namespace KSC_SalesTax_API.TaxCalculatorService
{
    public interface ITaxCalculator
    {
        public double CalculateSalesTaxes(List<SalesTax> salesTaxes);
        public double CalculateTotal(List<SalesTax> salesTaxes);
    }
}
