using OcpSample.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcpSample
{
    public abstract class InvoiceCreator
    {
        protected readonly InvoiceEngine _engine;

        public InvoiceCreator(InvoiceEngine engine)
        {
            _engine = engine;
        }

        public abstract void Create(InvoiceDto input);
    }
}
