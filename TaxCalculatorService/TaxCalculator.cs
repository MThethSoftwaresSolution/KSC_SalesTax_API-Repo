using KSC_SalesTax_API.Helpers;
using KSC_SalesTax_API.Models;
using System.Linq.Expressions;

namespace KSC_SalesTax_API.TaxCalculatorService
{
    public class TaxCalculator : ITaxCalculator
    {
        public double CalculateSalesTaxes(List<SalesTax> salesTaxes)
        {
            double lSalesTaxes = 0;

            foreach (var st in salesTaxes)
            {
                switch (st.GoodTypeId)
                {
                    case 1: //
                        // if imported, add 5 percent
                        if(st.IsImported)
                        {
                            lSalesTaxes = lSalesTaxes + (st.Price/100) * 5;
                        }
                        break;
                    case 2:
                        // if imported, add 5 percent
                        if (st.IsImported)
                        {
                            lSalesTaxes = lSalesTaxes + (st.Price / 100) * 5;
                        }
                        break;
                    case 3:
                        // if imported, add 5 percent
                        if (st.IsImported)
                        {
                            lSalesTaxes = lSalesTaxes + (st.Price / 100) * 5;
                        }
                        break;
                    case 4:
                        // Normal type (NOT Food, Medical, Books)...Therefore additional calculation of 10 percent is required
                        if (st.IsImported)
                        {
                            lSalesTaxes = lSalesTaxes + (((st.Price / 100) * 5) + ((st.Price / 100) * 5));
                        }
                        else
                        {
                            lSalesTaxes = lSalesTaxes + (st.Price / 100)*10;
                        }
                        break;
                }
            }

            return lSalesTaxes;
        }

        public double CalculateTotal(List<SalesTax> salesTaxes)
        {
            double total = 0;
            //Get SalesTaxes
            double lSalesTaxes = CalculateSalesTaxes(salesTaxes);
            foreach (var st in salesTaxes)
            {
                total = total + st.Price;
            }

            total = total + lSalesTaxes;
            return total;
        }
    }
}
