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
using WebApiBackendTeste.Model.POCO;


namespace WebApiBackendTeste.Controller
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("Api")]
    public class AreasDeConhecimentoController : ApiController
    {
        private ContextModel db = new ContextModel();

        /// <summary>
        /// 
        /// </summary>
        public AreasDeConhecimentoController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET: api/AreasDeConhecimento
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("AreasDeConhecimento/")]
        public HttpResponseMessage GetAreasDeConhecimento()
        {
            try
            {
                List<AreasDeConhecimentoPOCO> areasDeConhecimentoPOCOs = db.AreaDeConhecimento.Select(areasDeConhecimento => new AreasDeConhecimentoPOCO()
                {
                    IdAreaDeConhecimento = areasDeConhecimento.IdAreaDeConhecimento,
                    Descricao = areasDeConhecimento.Descricao,

                    Links = new List<LinkDTO>()
                    {
                        new LinkDTO()
                        {
                            Rel = "self",
                            Href = "http://localhost/AreasDeConhecimento/" + areasDeConhecimento.IdAreaDeConhecimento.ToString(),
                            Metodo = "GET"
                        },
                        new LinkDTO()
                        {
                            Rel = "update-areas-de-conhecimento",
                            Href = "http://localhost/AreasDeConhecimento/" + areasDeConhecimento.IdAreaDeConhecimento.ToString(),
                            Metodo = "PUT"
                        },
                        new LinkDTO()
                        {
                            Rel = "delete-areas-de-conhecimento",
                            Href = "http://localhost/AreasDeConhecimento/" + areasDeConhecimento.IdAreaDeConhecimento.ToString(),
                            Metodo = "DELETE"
                        }
                    }
                }).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, areasDeConhecimentoPOCOs);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // GET: api/AreasDeConhecimento/{id}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("AreasDeConhecimento/{id}")]
        public HttpResponseMessage GetAreaDeConhecimento(int id)
        {
            AreaDeConhecimento areaDeConhecimento = db.AreaDeConhecimento.SingleOrDefault(area => area.IdAreaDeConhecimento == id);

            try
            {
                AreasDeConhecimentoPOCO areasDeConhecimentoPOCO = new AreasDeConhecimentoPOCO()
                {
                    IdAreaDeConhecimento = areaDeConhecimento.IdAreaDeConhecimento,
                    Descricao = areaDeConhecimento.Descricao,

                    Links = new List<LinkDTO>()
                    {
                        new LinkDTO()
                        {
                            Rel = "self",
                            Href = "http://localhost/AreasDeConhecimento/" + areaDeConhecimento.IdAreaDeConhecimento.ToString(),
                            Metodo = "GET"
                        },
                        new LinkDTO()
                        {
                            Rel = "update-areas-de-conhecimento",
                            Href = "http://localhost/AreasDeConhecimento/" + areaDeConhecimento.IdAreaDeConhecimento.ToString(),
                            Metodo = "PUT"
                        },
                        new LinkDTO()
                        {
                            Rel = "delete-areas-de-conhecimento",
                            Href = "http://localhost/AreasDeConhecimento/" + areaDeConhecimento.IdAreaDeConhecimento.ToString(),
                            Metodo = "DELETE"
                        }
                    }
                };

                if (areaDeConhecimento == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK, areasDeConhecimentoPOCO);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // PUT: api/AreasDeConhecimento/5
        /// <summary>
        /// 
        /// </summary>
        [ResponseType(typeof(void))]
        [HttpPut]
        [Route("AreasDeConhecimento/{id}")]
        public HttpResponseMessage PutAreaDeConhecimento(int id, AreaDeConhecimento areaDeConhecimento)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(areaDeConhecimento).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!AreaExists(id))
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
                }
            }

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
        
        // POST: api/AreasDeConhecimento
        /// <summary>
        /// 
        /// </summary>
        /// <param name="areaDeConhecimento"></param>
        /// <returns></returns>
        [ResponseType(typeof(AreaDeConhecimento))]
        [HttpPost]
        [Route("AreasDeConhecimento/")]
        public HttpResponseMessage PostAreaDeConhecimento(AreaDeConhecimento areaDeConhecimento)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }

                db.AreaDeConhecimento.Add(areaDeConhecimento);
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.Created, areaDeConhecimento);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // DELETE: api/AreasDeConhecimento/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(AreaDeConhecimento))]
        [HttpDelete]
        [Route("AreasDeConhecimento/{id}")]
        public HttpResponseMessage DeleteAreaDeConhecimento(int id)
        {
            AreaDeConhecimento areaDeConhecimento = db.AreaDeConhecimento.Find(id);

            if (areaDeConhecimento == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.AreaDeConhecimento.Remove(areaDeConhecimento);
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

        private bool AreaExists(int id)
        {
            return db.AreaDeConhecimento.Count(e => e.IdAreaDeConhecimento == id) > 0;
        }
    }
}
