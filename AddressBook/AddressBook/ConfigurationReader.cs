using System.Configuration;

namespace AddressBookModel
{
    public static class ConfigurationReader
    {
        public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["DatabaseConnect"].ConnectionString;
    }
}
