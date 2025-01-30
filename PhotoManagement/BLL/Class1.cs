using BLL;
namespace BLL
{
    public class Class1
    {
        public static string GenerateShortUniqueCodeFromGuid()
        {
            string guid = Guid.NewGuid().ToString().Replace("-", "");
            return guid.Substring(0, 8); // קיצור ל-8 תווים
        }

    }
}