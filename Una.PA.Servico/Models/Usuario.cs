using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Una.PA.Servico.Models
{
    [DataContract]
    public class Usuario
    {
        [DataMember(Name="Id")]
        public int Id { get; set; }

        [DataMember(Name="Nome")]
        public string Nome { get; set; }

        [DataMember(Name="Login")]
        public string Login { get; set; }

        [DataMember(Name="Senha")]
        public string Senha { get; set; }

        [DataMember(Name="Usuario_Imap")]
        public virtual ICollection<Usuario_Imap> Usuario_Imap { get; set; }
    }
}