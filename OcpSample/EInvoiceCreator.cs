using OcpSample.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcpSample
{
    public class EInvoiceCreator : InvoiceCreator
    {
        public EInvoiceCreator(InvoiceEngine engine)
            : base(engine)
        {
        }

        public override void Create(InvoiceDto input)
        {
            _engine.TaxCalculationRate = 15m;
            _engine.ItemPrice = 10m;
            InvoiceDto invoice = InitializeSampleEInvoice();
            _engine.InvoiceSource.InsertInvoiceTypeToJson(_engine.JsonSerializer.GetJsonStringFromInvoice(invoice));
        }

        private InvoiceDto InitializeSampleEInvoice()
        {
            InvoiceDto invoice = new InvoiceDto()
            {
                IssueDate = DateTime.Now,
                IssueTime = DateTime.Now,
                AccountingCustomerParty = new CustomerPartyTypeDto()
                {
                    Party = new PartyTypeDto()
                    {
                        PartyIdentification = new PartyIdentificationTypeDto()
                        {
                            Value = "11111111111"
                        },
                        PartyName = new PartyNameTypeDto()
                        {
                            Name = "Sample Customer"
                        },
                        PostalAddress = new AddressTypeDto
                        {
                            CitySubdivisionName = "CANKAYA",
                            CityName = "ANKARA",
                            Country = "TURKEY",
                        },
                        Contact = new ContactTypeDto()
                        {
                            Name = "John Doe",
                            ElectronicMail = "test@test.com",
                            Telephone = "3333333333"
                        }
                    }
                },
                AccountingSupplierParty = new SupplierPartyTypeDto()
                {
                    Party = new PartyTypeDto()
                    {
                        PartyIdentification = new PartyIdentificationTypeDto()
                        {
                            Value = "11111111111"
                        },
                        PartyName = new PartyNameTypeDto()
                        {
                            Name = "Sample Supplier"
                        },
                        PostalAddress = new AddressTypeDto
                        {
                            CitySubdivisionName = "CANKAYA",
                            CityName = "ANKARA",
                            Country = "TURKEY",
                        },
                        Contact = new ContactTypeDto()
                        {
                            Name = "John Doe",
                            ElectronicMail = "test@test.com",
                            Telephone = "3333333333"
                        }
                    }
                },
                InvoiceTypeCode = "EInvoice",
                DocumentCurrencyCode = "TRY",
                Note = new List<string> { "Note 1", "Note 2" },
            };
            var invoiceLineType = new InvoiceLineTypeDto();
            invoiceLineType.Item = "Notebook";
            invoiceLineType.Quantity = 5;
            invoiceLineType.TaxExclusiveAmount = _engine.ItemPrice;
            invoiceLineType.TotalTaxAmount = Math.Round(invoiceLineType.TaxExclusiveAmount * _engine.TaxCalculationRate / 100, 2, MidpointRounding.AwayFromZero);
            invoiceLineType.TaxInclusiveAmount = Math.Round(invoiceLineType.TaxExclusiveAmount + invoiceLineType.TotalTaxAmount, 2);
            invoice.InvoiceLineTypes = new List<InvoiceLineTypeDto>() { invoiceLineType }.ToArray();
            return invoice;
        }
    }
}
