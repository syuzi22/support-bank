namespace SupportBank
{
    class AmountConversion
    {
        public static int ConvertPoundToPence(string pound)
        {
            return Convert.ToInt32(Math.Round(Convert.ToDouble(pound), 2) * 100);
        }
        public static double ConvertPenceToPound(int pence)
        {
            return Convert.ToDouble(pence)/ 100.0;
        }
    }
}