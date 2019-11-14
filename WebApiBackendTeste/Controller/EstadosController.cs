using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Routing;
using WebApiBackendTeste.Context;
using WebApiBackendTeste.Model;

namespace WebApiBackendTeste.Controller
{
    public class EstadosController : ApiController
    {
        private ContextModel db = new ContextModel();
        public EstadosController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        private readonly ContextModel _context;
        private readonly UrlHelper _urlHelper;
        public EstadosController(ContextModel context, UrlHelper urlHelper)
        {
            _context = context;
            _urlHelper = urlHelper;
        }
        // GET: api/Estados
        [Microsoft.AspNetCore.Mvc.HttpGet(Name = nameof(GetEstados))]
        public async Task<IQueryable<Estado>> GetEstados()
        {
            /*foreach (Estado estados in GetEstados())
            {

            }*/
            return db.Estados;
        }

        // GET: api/Estados/5
        [ResponseType(typeof(Estado))]
        [Microsoft.AspNetCore.Mvc.HttpGet("{id}", Name = nameof(GetEstado))]
        public async Task<IHttpActionResult> GetEstado(int id)
        {
            Estado estado = await db.Estados.FindAsync(id);
            if (estado == null)
            {
                return NotFound();
            }
            GerarLinks(estado);
            return Ok(estado);
        }

        // PUT: api/Estados/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEstado(int id, Estado estado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != estado.IdEstado)
            {
                return BadRequest();
            }

            db.Entry(estado).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoExists(id))
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

        // POST: api/Estados
        [ResponseType(typeof(Estado))]
        public async Task<IHttpActionResult> PostEstado(Estado estado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Estados.Add(estado);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = estado.IdEstado }, estado);
        }

        // DELETE: api/Estados/5
        [ResponseType(typeof(Estado))]
        public async Task<IHttpActionResult> DeleteEstado(int id)
        {
            Estado estado = await db.Estados.FindAsync(id);
            if (estado == null)
            {
                return NotFound();
            }

            db.Estados.Remove(estado);
            await db.SaveChangesAsync();

            return Ok(estado);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        private void GerarLinks(Estado estados)
        {
            estados.Links.Add(new LinkDTO("http://localhost:63811/api/Estados/" + estados.IdEstado, rel: "self", metodo: "GET"));

            estados.Links.Add(new LinkDTO("http://localhost:63811/api/Estados/" + estados.IdEstado, rel: "update-estados", metodo: "PUT"));

            estados.Links.Add(new LinkDTO("http://localhost:63811/api/Estados/" + estados.IdEstado, rel: "delete-estados", metodo: "DELETE"));

        }
        private bool EstadoExists(int id)
        {
            return db.Estados.Count(e => e.IdEstado == id) > 0;
        }
    }
}