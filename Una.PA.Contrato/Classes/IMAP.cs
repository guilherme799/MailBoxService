using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Una.PA.Contrato
{
    [DataContract]
    public class IMAP
    {
        [DataMember(Name = "host", Order = 1)]
        public string host { get; set; }

        [DataMember(Name = "porta", Order = 2)]
        public int porta { get; set; }

        [DataMember(Name = "login", Order = 3)]
        public string login { get; set; }

        [DataMember(Name = "senha", Order = 4)]
        public string senha { get; set; }

        [DataMember(Name = "caixa", Order = 5)]
        public CaixaMensagem caixa { get; set; }
    }
}
