using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcpSample
{
    public class InvoiceSource
    {
        public string GetInvoiceTypeFromSource()
        {
            return File.ReadAllText("invoiceSource.json");
        }

        public void InsertInvoiceTypeToJson(string toWrite)
        {
            using (TextWriter writer = new StreamWriter("invoiceOutput.json"))
            {
                writer.WriteLine(toWrite);
                writer.Flush();
                writer.Close();
            }
        }
    }
}
