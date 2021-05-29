using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcpSample.Dto
{
    public class PartyTypeDto
    {
        public PartyIdentificationTypeDto PartyIdentification { get; set; }

        public PartyNameTypeDto PartyName { get; set; }

        public AddressTypeDto PostalAddress { get; set; }

        public ContactTypeDto Contact { get; set; }
    }
}
