using System.Configuration;

namespace AddressBookModel
{
    public class ConfigurationReader
    {
        public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    }
}
