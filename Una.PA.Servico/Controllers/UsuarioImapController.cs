using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Una.PA.Servico.Models;

namespace Una.PA.Servico.Controllers
{
    public class UsuarioImapController : ApiController
    {
        private Context db = new Context();

        // GET api/UsuarioImap
        public IEnumerable<Usuario_Imap> GetUsuario_Imap()
        {
            return db.Usuario_Imap.AsEnumerable();
        }

        // GET api/UsuarioImap/5
        public Usuario_Imap GetUsuario_Imap(int id)
        {
            Usuario_Imap usuario_imap = db.Usuario_Imap.Find(id);
            if (usuario_imap == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return usuario_imap;
        }

        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Usuario_Imap> ObterImapsUsuario(int id)
        {
            return db.Usuario_Imap.Include(u => u.Imap).Where(u => u.Id_usuario == id);
        }

        // PUT api/UsuarioImap/5
        public HttpResponseMessage PutUsuario_Imap(int id, Usuario_Imap usuario_imap)
        {
            if (ModelState.IsValid && id == usuario_imap.Id)
            {
                db.Entry(usuario_imap).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/UsuarioImap
        public HttpResponseMessage PostUsuario_Imap(Usuario_Imap usuario_imap)
        {
            if (ModelState.IsValid)
            {
                db.Usuario_Imap.Add(usuario_imap);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, usuario_imap);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = usuario_imap.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/UsuarioImap/5
        public HttpResponseMessage DeleteUsuario_Imap(int id)
        {
            Usuario_Imap usuario_imap = db.Usuario_Imap.Find(id);
            if (usuario_imap == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Usuario_Imap.Remove(usuario_imap);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, usuario_imap);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}