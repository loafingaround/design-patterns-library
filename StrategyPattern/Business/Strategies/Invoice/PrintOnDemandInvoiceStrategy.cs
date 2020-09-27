using Newtonsoft.Json;
using StrategyPattern.Business.Models;
using System;
using System.Net.Http;

namespace StrategyPattern.Business.Strategies.Invoice
{
    class PrintOnDemandInvoiceStrategy : InvoiceStrategy
    {
        public override void Generate(Order order)
        {
            using (var client = new HttpClient())
            {
                var content = JsonConvert.SerializeObject(order);

                client.BaseAddress = new Uri("https://example.com");

                client.PostAsync("/print-on-demand", new StringContent(content));
            }
        }
    }
}
