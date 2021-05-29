using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcpSample.Dto
{
    public class InvoiceLineTypeDto
    {
        public decimal TaxExclusiveAmount { get; set; }
        public decimal TaxInclusiveAmount { get; set; }
        public decimal TotalTaxAmount { get; set; }
        public string Item { get; set; }
        public int Quantity { get; set; }
    }
}
