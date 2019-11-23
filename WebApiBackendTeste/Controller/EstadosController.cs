using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
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
      
        // GET: api/Estados
        public HttpResponseMessage GetEstados()
        {
            try
            {
                List<EstadosPOCO> estadosPOCOs = db.Estados.Select(estados => new EstadosPOCO()
                {
                    IdEstado = estados.IdEstado,
                    NomeEstado = estados.NomeEstado,
                    UF = estados.UF,

                    Links = new List<LinkDTO>() {
                        new LinkDTO()
                        {
                            Rel = "self",
                            Href = "http://localhost/Estados/" + estados.IdEstado.ToString(),
                            Metodo = "GET"
                        },
                         new LinkDTO()
                        {
                            Rel = "update-estados",
                            Href = "http://localhost/Estados/" + estados.IdEstado.ToString(),
                            Metodo = "PUT"
                        },
                          new LinkDTO()
                        {
                            Rel = "delete-estados",
                             Href = "http://localhost/Estados/" + estados.IdEstado.ToString(),
                            Metodo = "DELETE"
                        }
                }
                }).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, estadosPOCOs);
            }
            catch(Exception ex)
            {
               return Request.CreateErrorResponse(HttpStatusCode.BadRequest,ex);
            }           
        }        
      
        // GET: api/Estados/{id}
        public HttpResponseMessage GetEstado(int id)
        {
            Estado estado = db.Estados.SingleOrDefault(est => est.IdEstado == id);
            try
            {
                EstadosPOCO estadosPOCO = new EstadosPOCO()
                {
                    IdEstado = estado.IdEstado,
                    NomeEstado = estado.NomeEstado,
                    UF = estado.UF,

                    Links = new List<LinkDTO>() {
                        new LinkDTO()
                        {
                            Rel = "self",
                            Href = "http://localhost/Estados/" + estado.IdEstado.ToString(),
                            Metodo = "GET"
                        },
                         new LinkDTO()
                        {
                            Rel = "update-estados",
                            Href = "http://localhost/Estados/" + estado.IdEstado.ToString(),
                            Metodo = "PUT"
                        },
                          new LinkDTO()
                        {
                            Rel = "delete-estados",
                             Href = "http://localhost/Estados/" + estado.IdEstado.ToString(),
                            Metodo = "DELETE"
                         }
                     }   
                };
                return Request.CreateResponse(HttpStatusCode.OK, estadosPOCO);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }                     
        }

        // PUT: api/Estados/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEstado(int id, Estado estado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (id != estado.IdEstado)
            {
                return BadRequest();
            }

            db.Entry(estado).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
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
        public IHttpActionResult PostEstado(Estado estado)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }
            db.Estados.Add(estado);          
            db.SaveChanges();
               
         return CreatedAtRoute("DefaultApi", new { id = estado.IdEstado }, estado);           
        }
        
        // DELETE: api/Estados/5
        /*
        [ResponseType(typeof(Estado))]
        public IHttpActionResult DeleteEstado(int id)
        {
            Estado estado = db.Estados.Find(id);
            if (estado == null)
            {
                return NotFound();
            }

            db.Estados.Remove(estado);
            db.SaveChanges();

            return OK(estado);
        }
        */
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
     
        private bool EstadoExists(int id)
        {
            return db.Estados.Count(e => e.IdEstado == id) > 0;
        }
    }
}