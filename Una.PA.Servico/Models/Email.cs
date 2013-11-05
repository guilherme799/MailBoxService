using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Una.PA.Servico.Models
{
    [DataContract]
    public class Email
    {
        [DataMember]
        public string Assunto { get; set; }

        [DataMember]
        public string Remetente { get; set; }

        [DataMember]
        public string Destinatario { get; set; }

        [DataMember]
        public string Mensagem { get; set; }

        [DataMember]
        public string Data_Envio { get; set; }

        [DataMember]
        public Usuario_Imap Usuario_Imap { get; set; }
    }
}