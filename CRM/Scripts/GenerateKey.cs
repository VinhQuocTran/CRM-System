
namespace CRM.Scripts
{
    class GenerateKey
    {
        public string GenerateString(string baseStr, int num)
        {
            string formattedNumber = num.ToString("D3");
            string generatedStr = $"{baseStr}{formattedNumber}";
            return generatedStr;
        }
    }
}
