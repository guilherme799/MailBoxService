using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Una.PA.Servico.Models
{
    [DataContract]
    public class Imap
    {
        [DataMember(Name="Id")]
        public int Id { get; set; }

        [DataMember(Name="Porta")]
        public int Porta { get; set; }

        [DataMember(Name="Host")]
        public string Host { get; set; }

        [DataMember(Name="Nome")]
        public string Nome { get; set; }

        [DataMember(Name="SSL")]
        public bool SSL { get; set; }

        [DataMember(Name="Usuario_Imap")]
        public virtual ICollection<Usuario_Imap> Usuario_Imap { get; set; }
    }
}