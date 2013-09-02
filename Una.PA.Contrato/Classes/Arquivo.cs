using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Una.PA.Contrato
{
    [DataContract]
    public class Arquivo
    {
        [DataMember(Name = "nome", Order = 1)]
        public string nome { get; set; }

        [DataMember(Name = "mime", Order = 2)]
        public string mime { get; set; }

        [DataMember(Name = "arquivo", Order = 3)]
        public byte[] arquivo { get; set; }
    }
}
