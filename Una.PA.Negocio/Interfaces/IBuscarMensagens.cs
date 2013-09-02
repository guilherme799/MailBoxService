using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Una.PA.Contrato;

namespace Una.PA.Negocio
{
    public interface IBuscarMensagens
    {
        IEnumerable<Email> Buscar(IMAP imap);
    }
}
