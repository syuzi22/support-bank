namespace SupportBank
{
    class Amount
    {
        public static int ConvertPoundToPence(string pound)
        {
            return Convert.ToInt32(Math.Round(Convert.ToDouble(pound), 2) * 100);
        }
        public static double ConvertPenceToPound(string pence)
        {
            return Convert.ToDouble(pence)/ 100.0;
        }
    }
}