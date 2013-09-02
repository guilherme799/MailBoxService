using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Una.PA.Contrato;

namespace Una.PA.Negocio
{
    public class FabricaBuscaMensagens
    {
        public IBuscarMensagens ObterBusca(CaixaMensagem caixa)
        {
            switch (caixa)
            {
                case CaixaMensagem.Entrada:
                    return new BuscarCaixaEntrada();
                case CaixaMensagem.Saida:
                    return new BuscarCaixaSaida();
                default:
                    throw new NotSupportedException("Caixa de mensagem não encontrada");
            }
        }
    }
}
