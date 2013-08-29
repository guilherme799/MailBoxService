using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Koolwired.Imap;

namespace Una.PA.Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ImapConnect connection = new ImapConnect("imap.gmail.com", 993, true))
            {
                ImapCommand command = new ImapCommand(connection);
                ImapAuthenticate authentication = new ImapAuthenticate(connection, "user", "password");
                ImapMailbox mailbox;

                connection.Open();
                authentication.Login();
                mailbox = command.Select("INBOX");

                mailbox = command.Fetch(mailbox, mailbox.Exist - 20, mailbox.Exist);
                foreach (ImapMailboxMessage m in mailbox.Messages.Reverse<ImapMailboxMessage>())
                {
                    ImapMailboxMessage msg = command.FetchBodyStructure(m);
                    if (m.HasText)
                    {
                        msg = command.FetchBodyPart(m, m.Text);
                        String textBody = msg.BodyParts[m.Text].Data;
                    }
                    if (m.HasHTML)
                    {
                        msg = command.FetchBodyPart(m, m.HTML);
                        String htmlText = msg.BodyParts[m.HTML].Data;
                    }

                    Console.WriteLine("---------------------------------------");
                    Console.WriteLine(string.Format("Remetente: {0}", m.From));
                    Console.WriteLine(string.Format("Assunto: {0}", m.Subject));
                    Console.WriteLine("---------------------------------------");
                }

                authentication.Logout();
                connection.Close();
            }
            Console.Read();
        }
    }
}
