namespace KSC_SalesTax_API.Helpers
{
    public class RoundOff
    {
        private const double roundoff = 0.05;

        public static double RoundingOff(double value)
        {
            return (int)(value / roundoff + 0.5) * 0.05;
        }
    }
}
