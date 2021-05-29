using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcpSample.Dto
{
    public class InvoiceDto
    {
        public DateTime IssueDate { get; set; }

        public DateTime IssueTime { get; set; }

        public string InvoiceTypeCode { get; set; }

        public IList<string> Note { get; set; }

        public string DocumentCurrencyCode { get; set; }

        public SupplierPartyTypeDto AccountingSupplierParty { get; set; }

        public CustomerPartyTypeDto AccountingCustomerParty { get; set; }

        public IList<InvoiceLineTypeDto> InvoiceLineTypes { get; set; }
    }
}
