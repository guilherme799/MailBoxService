using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Una.PA.Contrato
{
    [DataContract]
    public class DataTransferObject
    {
        [DataMember(Name = "OcorreuErro", Order = 1)]
        public bool OcorreuErro { get; set; }

        [DataMember(Name = "MensagemRetorno", Order = 2)]
        public string MensagemRetorno { get; set; }

        [DataMember(Name = "ObjetoRetorno", Order = 3)]
        public Object ObjetoRetorno { get; set; }
    }
}
