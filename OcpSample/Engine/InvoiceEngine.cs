using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcpSample
{
    public class InvoiceEngine
    {
        public InvoiceSource InvoiceSource { get; set; } = new InvoiceSource();
        public JsonSerializer JsonSerializer { get; set; } = new JsonSerializer();
        public decimal TaxCalculationRate { get; set; }
        public decimal ItemPrice { get; set; }
        public bool IsSuccesfull { get; set; }
        public void Create()
        {
            string invoiceTypeJson = InvoiceSource.GetInvoiceTypeFromSource();
            var invoice = JsonSerializer.GetInvoiceFromJsonString(invoiceTypeJson);

            Console.WriteLine($"Starting to create sample {invoice.InvoiceTypeCode} to { Directory.GetCurrentDirectory() } invoiceOutput.json");

            var factory = new InvoiceFactory();

            var rater = factory.Create(invoice, this);
            rater?.Create(invoice);

            Console.WriteLine($"{invoice.InvoiceTypeCode} creation completed.");
        }
    }
}
