using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Routing;
using WebApiBackendTeste.Context;
using WebApiBackendTeste.HateOAS;
using WebApiBackendTeste.Model;

namespace WebApiBackendTeste.Controller

{
    public class EstadosController : ApiController
    {        
        public ContextModel db = new ContextModel();

        private readonly ContextModel _context;
      //  private readonly UrlHelper _urlHelper;
      /*  public EstadosController (ContextModel context, UrlHelper urlHelper)
        {
            _context = context;
            _urlHelper = urlHelper;
        }*/
        public EstadosController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }      

        // GET: api/Estados1
        public IQueryable<Estado> GetEstados()
        {
            var Estados = GetEstados();
            foreach(var Estado in Estados) {
                var selflink = new Link
                {
                    Rel = "Self",
                    Href = Url.Route("Api Default", new
                    {
                        controller = "EstadosController",
                        id = Estado.IdEstado
                    })
                };
            }
            return db.Estados;
        }

        // GET: api/Estados1/5
        [ResponseType(typeof(Estado))]
        public IHttpActionResult GetEstados(int id)
        {
            Estado estados = db.Estados.Find(id);
            if (estados == null)
            {
                return NotFound();
            }
        //    GerarLinks(estados);
                return Ok(estados);
        }

        // PUT: api/Estados1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEstados(int id, Estado estados)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != estados.IdEstado)
            {
                return BadRequest();
            }
         //   GerarLinks(estados);

            db.Entry(estados).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Estados1
        [ResponseType(typeof(Estado))]
        public IHttpActionResult PostEstados(Estado estados)
        {            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Estados.Add(estados);            
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = estados.IdEstado }, estados);
        }

        // DELETE: api/Estados1/5
        [ResponseType(typeof(Estado))]
        public IHttpActionResult DeleteEstados(int id)
        {
            Estado estados = db.Estados.Find(id);
            if (estados == null)
            {
                return NotFound();
            }

            db.Estados.Remove(estados);
            db.SaveChanges();

            return Ok(estados);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
       /* public void GerarLinks(Estado estados)
        {
            estados.Link.Add(new Link(_urlHelper.Link(nameof(GetEstados), new { id = estados.IdEstado }), rel: "self", metodo: "GET"));

            estados.Link.Add(new Link(_urlHelper.Link(nameof(PutEstados), new { id = estados.IdEstado }), rel: "update-estados", metodo: "PUT"));

            estados.Link.Add(new Link(_urlHelper.Link(nameof(DeleteEstados), new { id = estados.IdEstado }), rel: "delete-estados", metodo: "DELETE"));

        }*/

        public abstract class UrlHelper
        {
            public abstract string Link(string routeName,
              IDictionary<string, object> routeValues);
            public abstract string Link(string routeName, object routeValues);
            public abstract string Route(string routeName,
              IDictionary<string, object> routeValues);
            public abstract string Route(string routeName, object routeValues);
        }
        private bool EstadosExists(int id)
        {
            return db.Estados.Count(e => e.IdEstado == id) > 0;
        }
    }
}