using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Una.PA.Servico.Models
{
    public class Context : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Imap> Imaps { get; set; }
        public DbSet<Usuario_Imap> Usuario_Imap { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.Configuration.LazyLoadingEnabled = false;
            base.OnModelCreating(modelBuilder);
        }
    }

    public class ContextInitializer : DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {
            Usuario usuario = context.Usuarios.Add(new Usuario { Nome = "Administrador do sistema", Login = "adminsitrador", Senha = "password" });
            Imap imap = context.Imaps.Add(new Imap { Nome = "Gmail", Host = "imap.gmail.com", Porta = 993, SSL = true });
            context.SaveChanges();

            context.Usuario_Imap.Add(new Usuario_Imap { Id_imap = imap.Id, Id_usuario = usuario.Id, Email = "una.pa.webmail@gmail.com", Password = "qwertyuiop0" });
            context.SaveChanges();

            base.Seed(context);
        }
    }
}