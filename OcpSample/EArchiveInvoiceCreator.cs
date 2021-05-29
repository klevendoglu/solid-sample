using OcpSample.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcpSample
{
    public class EArchiveInvoiceCreator : InvoiceCreator
    {
        public EArchiveInvoiceCreator(InvoiceEngine engine)
            : base(engine)
        {
        }

        public override void Create(InvoiceDto input)
        {
            _engine.TaxCalculationRate = 10m;
            _engine.ItemPrice = 5m;
            InvoiceDto invoice = InitializeSampleEArchiveInvoice();
            _engine.InvoiceSource.InsertInvoiceTypeToJson(_engine.JsonSerializer.GetJsonStringFromInvoice(invoice));
        }

        private InvoiceDto InitializeSampleEArchiveInvoice()
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
                InvoiceTypeCode = "EArchiveInvoice",
                DocumentCurrencyCode = "TRY",
                Note = new List<string> { "Note 1", "Note 2" },
            };
            var invoiceLineType = new InvoiceLineTypeDto();
            invoiceLineType.Item = "Pen";
            invoiceLineType.Quantity = 2;
            invoiceLineType.TaxExclusiveAmount = _engine.ItemPrice;
            invoiceLineType.TotalTaxAmount = Math.Round(invoiceLineType.TaxExclusiveAmount * _engine.TaxCalculationRate / 100, 2, MidpointRounding.AwayFromZero);
            invoiceLineType.TaxInclusiveAmount = Math.Round(invoiceLineType.TaxExclusiveAmount + invoiceLineType.TotalTaxAmount, 2);
            invoice.InvoiceLineTypes = new List<InvoiceLineTypeDto>() { invoiceLineType }.ToArray();
            return invoice;
        }
    }
}
