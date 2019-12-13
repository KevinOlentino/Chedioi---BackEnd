using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiBackendTeste.Context;
using WebApiBackendTeste.Model;

namespace WebApiBackendTeste.Controller
{
    /// <summary>
    /// 
    /// </summary>
    public class EstadosController : ApiController
    {
        private ContextModel db = new ContextModel();        
        /// <summary>
        /// 
        /// </summary>
        public EstadosController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
      
        // GET: api/Estados
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
                
                if (estado == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK, estadosPOCO);
            }
            catch(Exception ex)
            {                
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }                     
        }

        // PUT: api/Estados/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="estado"></param>
        /// <returns></returns>
        [ResponseType(typeof(void))]
        public HttpResponseMessage PutEstado(int id, Estado estado)
        {
            
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }


            db.Entry(estado).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!EstadoExists(id))
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest,ex);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound,ex);
                }
            }

          return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="estado"></param>
        /// <returns></returns>
        // POST: api/Estados
        [ResponseType(typeof(Estado))]      
        public HttpResponseMessage PostEstado(Estado estado)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }

                db.Estados.Add(estado);
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.Created, estado);

            }catch(Exception ex)
            {               
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
          
        }
        
        // DELETE: api/Estados/5      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(Estado))]
        public HttpResponseMessage DeleteEstado(int id)
        {
            Estado estado = db.Estados.Find(id);
            if (estado == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Estados.Remove(estado);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }
      /// <summary>
      /// 
      /// </summary>
      /// <param name="disposing"></param>
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