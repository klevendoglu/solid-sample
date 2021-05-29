using System;

namespace OcpSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new InvoiceEngine();
            engine.Create();
        }
    }
}
