using OcpSample.Dto;
using System;

namespace OcpSample
{
    public class InvoiceFactory
    {
        public InvoiceCreator Create(InvoiceDto invoice, InvoiceEngine engine)
        {
            try
            {
                return (InvoiceCreator)Activator.CreateInstance(
                    Type.GetType($"OcpSample.{invoice.InvoiceTypeCode}Creator"),
                        new object[] { engine });
            }
            catch
            {
                return null;
            }
        }
    }
}
