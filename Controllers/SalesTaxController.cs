using KSC_SalesTax_API.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;
using KSC_SalesTax_API.Models;
using KSC_SalesTax_API.ViewModels;
using KSC_SalesTax_API.TaxCalculatorService;

namespace KSC_SalesTax_API.Controllers
{
    public class SalesTaxController : Controller
    {
        private readonly ITaxCalculator _taxCalculator;

        public SalesTaxController(ITaxCalculator taxCalculator)
        {
            _taxCalculator = taxCalculator;
        }

        [HttpPost("printReceipt")]
        public IActionResult PostSalesTax([FromBody] List<SalesTax> salesTaxes)
        {
            List<string> counterNamePrices = new List<string>();

            try
            {
                foreach (var st in salesTaxes)
                {
                    counterNamePrices.Add($"{st.Count} {st.Name} at {st.Price}");
                }

                double lSalesTaxes = RoundOff.RoundingOff(_taxCalculator.CalculateSalesTaxes(salesTaxes));
                double lTotal = _taxCalculator.CalculateTotal(salesTaxes);
                SalesTaxViewModel salesTaxViewModel = new SalesTaxViewModel();
                salesTaxViewModel.CounterNamePrices = counterNamePrices;
                salesTaxViewModel.SalesTaxes = "Sales Taxes: "+ lSalesTaxes;
                salesTaxViewModel.Total = "Total: " + lTotal;

                return Ok(salesTaxViewModel);
            }
            catch (Exception Ex)
            {
                return BadRequest("Something bad happened " + Ex.Message);
            }
        }

    }
}
