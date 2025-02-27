namespace SupportBank
{
    class CSVReader
    {

        public static List<string> ReadFile(string filePath)
        {
            
            using StreamReader reader = new(filePath);
            string? line;
            List<string> lines = [];
            
            while ((line = reader.ReadLine()) != null)
            {
                lines.Add(line);
            }
            return lines;
            
        }
       
    }
}
