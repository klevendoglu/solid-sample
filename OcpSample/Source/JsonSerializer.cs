using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using OcpSample.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcpSample
{
    public class JsonSerializer
    {
        public InvoiceDto GetInvoiceFromJsonString(string jsonString)
        {
            return JsonConvert.DeserializeObject<InvoiceDto>(jsonString,
                new StringEnumConverter());
        }

        public string GetJsonStringFromInvoice(InvoiceDto input)
        {
            return JsonConvert.SerializeObject(input);
        }
    }
}
