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
    public class UsuarioController : ApiController
    {
        private Context db = new Context();

        // GET api/Default1
        public IEnumerable<Usuario> GetUsuarios()
        {
            return db.Usuarios.AsEnumerable();
        }

        // GET api/Default1/5
        public Usuario GetUsuario(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return usuario;
        }

        // PUT api/Default1/5
        public HttpResponseMessage PutUsuario(int id, Usuario usuario)
        {
            if (ModelState.IsValid && id == usuario.Id)
            {
                db.Entry(usuario).State = EntityState.Modified;

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

        // POST api/Default1
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage AdicionarUsuario(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(usuario);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, usuario);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = usuario.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage LogarUsuario(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario = db.Usuarios.FirstOrDefault(u => u.Login.Equals(usuario.Login) && u.Senha.Equals(usuario.Senha));
                if (usuario == null)
                    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound, new Exception("Usuário ou senha inválidos.")));

                return Request.CreateResponse(HttpStatusCode.Found, usuario);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Default1/5
        public HttpResponseMessage DeleteUsuario(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Usuarios.Remove(usuario);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, usuario);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}