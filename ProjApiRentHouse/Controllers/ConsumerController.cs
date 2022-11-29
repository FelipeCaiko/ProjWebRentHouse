using Domain.Entities;
using Nancy.Json;
using System.Text;

namespace ProjApiRentHouse.Controllers;

public class ConsumerController
{
    private readonly string _consumerPostRealtyRent = "https://localhost:7192/api/RealtyRents";

    public async Task<bool> PostRealtyRentAsync(RealtyRent realtyRent)
    {
        using (HttpClient _realtyRentClient = new())
        {
            string jsonString = new JavaScriptSerializer().Serialize(realtyRent);
            HttpContent http = new StringContent(jsonString, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _realtyRentClient.PostAsync(_consumerPostRealtyRent + realtyRent, http);

            if (response.IsSuccessStatusCode)
                return true;
            return false;
        }
    }
}