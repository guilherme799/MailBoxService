using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Una.PA.Contrato
{
    [DataContract]
    public enum CaixaMensagem
    {
        [EnumMember(Value = "Entrada")]
        Entrada = 1,

        [EnumMember(Value = "Saida")]
        Saida = 2
    }
}
