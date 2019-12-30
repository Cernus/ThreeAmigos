using System.Net.Http;

namespace ThreeAmigos.OrderFacade
{
    public interface IOrderFac
    {
        HttpResponseMessage CreateOrder(string json);

        string GetInvoices(int id);
    }
}
