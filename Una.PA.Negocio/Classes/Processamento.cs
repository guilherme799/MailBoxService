using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Una.PA.Contrato;

namespace Una.PA.Negocio
{
    public class Processamento
    {
        public DataTransferObject ObterMensagens(IMAP[] servidores)
        {
            try
            {
                return null;
            }
            catch (Exception e)
            {
                return new DataTransferObject { OcorreuErro = true, MensagemRetorno = e.Message, ObjetoRetorno = e };
            }
        }
    }
}
