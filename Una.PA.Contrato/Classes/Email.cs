using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Una.PA.Contrato
{
    [DataContract]
    public class Email
    {
        [DataMember(Name = "destinatario", Order = 1)]
        public string destinatario { get; set; }

        [DataMember(Name = "remetente", Order = 2)]
        public string remetente { get; set; }

        [DataMember(Name = "corpo", Order = 3)]
        public string corpo { get; set; }

        [DataMember(Name = "data", Order = 4)]
        public DateTime data { get; set; }

        [DataMember(Name = "anexo", Order = 5)]
        public Arquivo anexo { get; set; }

        [DataMember(Name = "imap", Order = 6)]
        public IMAP imap { get; set; }
    }
}
