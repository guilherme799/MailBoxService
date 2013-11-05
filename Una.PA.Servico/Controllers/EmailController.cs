using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Koolwired.Imap;
using Una.PA.Servico.Models;

namespace Una.PA.Servico.Controllers
{
    public class EmailController : ApiController
    {
        Context contexto;
        // GET api/email
        public HttpResponseMessage Get()
        {
            throw new HttpResponseException(HttpStatusCode.NotImplemented);
        }

        // GET api/email/5
        public HttpResponseMessage Get(int id, string Pasta = "INBOX", string Filtro = "Todas")
        {
            try
            {
                List<Email> emails = new List<Email>();
                contexto = new Context();
                List<Usuario_Imap> usuarios_Imaps = contexto.Usuario_Imap
                    .Include("Usuario")
                    .Include("Imap")
                    .Where(u => u.Id_usuario == id).ToList();

                usuarios_Imaps.ForEach(usuario_imap => PreencheEmails(usuario_imap, Pasta, ref emails));
                return Request.CreateResponse(HttpStatusCode.Found, emails);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }

        private void PreencheEmails(Usuario_Imap usuario_imap, string pasta, ref List<Email> emails)
        {
            Imap imap = usuario_imap.Imap;

            using (ImapConnect connection = new ImapConnect(imap.Host, imap.Porta, imap.SSL))
            {
                ImapCommand command = new ImapCommand(connection);
                ImapAuthenticate authentication = new ImapAuthenticate(connection, usuario_imap.Email, usuario_imap.Password);
                ImapMailbox mailbox;

                connection.Open();
                authentication.Login();
                mailbox = command.Select(pasta);

                mailbox = command.Fetch(mailbox);
                foreach (ImapMailboxMessage m in mailbox.Messages.Reverse<ImapMailboxMessage>())
                {
                    string destinatarios = string.Empty;
                    Email email = new Email();

                    m.To.ToList().ForEach(a => destinatarios += a.Address + "; ");
                    email.Remetente = m.From.Address;
                    email.Destinatario = destinatarios.Trim();
                    email.Assunto = m.Subject;
                    email.Data_Envio = m.Sent.ToString("dd/MM/yyyy");
                    email.Usuario_Imap = usuario_imap;

                    ImapMailboxMessage msg = command.FetchBodyStructure(m);
                    if (m.HasText)
                    {
                        msg = command.FetchBodyPart(m, m.Text);
                        email.Mensagem = msg.BodyParts[m.Text].Data;
                    }
                    if (m.HasHTML)
                    {
                        msg = command.FetchBodyPart(m, m.HTML);
                        email.Mensagem = msg.BodyParts[m.HTML].Data;
                    }

                    emails.Add(email);
                }

                authentication.Logout();
                connection.Close();
            }
        }

        // POST api/email
        public void Post([FromBody]string value)
        {
        }

        // PUT api/email/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/email/5
        public void Delete(int id)
        {
        }
    }
}
