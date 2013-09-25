using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Una.PA.Servico.Models
{
    [DataContract]
    public class Usuario_Imap
    {
        [DataMember(Name="Id")]
        public int Id { get; set; }

        [DataMember(Name="Id_usuario")]
        public int Id_usuario { get; set; }

        [DataMember(Name="Id_imap")]
        public int Id_imap { get; set; }

        [DataMember(Name="Email")]
        public string Email { get; set; }

        [DataMember(Name="Password")]
        public string Password { get; set; }

        [DataMember(Name="Usuario")]
        [ForeignKey("Id_usuario")]
        public virtual Usuario Usuario { get; set; }

        [DataMember(Name="Imap")]
        [ForeignKey("Id_imap")]
        public virtual Imap Imap { get; set; }
    }
}