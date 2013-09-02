using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Una.PA.Contrato
{
    [ServiceContract(Namespace="")]
    public interface IMailBoxService
    {
        [OperationContract]
        [WebInvoke(Method="POST", UriTemplate="ObterMensagens", ResponseFormat=WebMessageFormat.Json, RequestFormat=WebMessageFormat.Json, BodyStyle=WebMessageBodyStyle.Wrapped)]
        DataTransferObject ObterMensagens(IMAP[] servidores);
    }
}
