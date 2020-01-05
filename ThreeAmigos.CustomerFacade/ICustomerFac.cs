using System.Net.Http;

namespace ThreeAmigos.CustomerFacade
{
    public interface ICustomerFac
    {
        string GetCustomer(int id);
        string GetCustomerUpdate(int id);
        string GetCustomerName(int id);
        HttpResponseMessage UpdateCustomer(int id, string json);
        HttpResponseMessage CreateCustomer(string json);
        HttpResponseMessage RequestDelete(int id);
        bool HasAddressAndTel(int id);
        int Authenticate(string username, string password);
    }
}
