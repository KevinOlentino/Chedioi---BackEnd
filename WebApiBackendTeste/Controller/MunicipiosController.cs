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
using WebApiBackendTeste.Context;
using WebApiBackendTeste.Model;
using WebApiBackendTeste.Model.POCO;

namespace WebApiBackendTeste.Controller
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("Api")]
    public class MunicipiosController : ApiController
    {
        private ContextModel db = new ContextModel();

        // GET: api/Municipios
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Municipios/")]
        public HttpResponseMessage GetMunicipios()
        {
            try 
            {

                List<MunicipiosPOCO> municipiosPOCOs = db.Municipio.Select(Municipio => new MunicipiosPOCO() {                    
                    IdMunicipio = Municipio.IdMunicipio,
                    NomeMunicipio = Municipio.NomeMunicipio,                    
                    Estado = Municipio.Estado,

                    Links = new List<LinkDTO>()
                {
                    new LinkDTO()
                    {
                        Rel = "self",
                        Href = "http://localhost/Municipios/" + Municipio.IdMunicipio.ToString(),
                        Metodo = "GET"
                    },
                     new LinkDTO()
                    {
                        Rel = "update-Municipio",
                        Href = "http://localhost/Municipios/" + Municipio.IdMunicipio.ToString(),
                        Metodo = "PUT"
                    },
                      new LinkDTO()
                    {
                        Rel = "delete-Municipio",
                        Href = "http://localhost/Municipios/" + Municipio.IdMunicipio.ToString(),
                        Metodo = "DELETE"
                    }

                }

                }).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, municipiosPOCOs);       
            } 
            
            catch (Exception ex) 
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);            
            }
        }

        // GET: api/Municipios/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(MunicipiosModel))]
        [Route("Municipios/{id}")]
        public HttpResponseMessage GetMunicipiosModel(int id)
        {
            MunicipiosModel Municipio = db.Municipio.Find(id);
            Estado Est = db.Estados.Find(Municipio.IdEstado);
            try

            {
                MunicipiosPOCO municipiosPOCO = new MunicipiosPOCO()
                {
                    IdMunicipio = Municipio.IdMunicipio,
                    NomeMunicipio = Municipio.NomeMunicipio,                   
                    Estado = Est,                    

                    Links = new List<LinkDTO>()
                    {

                        new LinkDTO()
                        {
                        Rel = "self",
                        Href = "http://localhost/Municipios/" + Municipio.IdMunicipio.ToString(),
                        Metodo = "GET"
                        },
                        new LinkDTO()
                        {
                        Rel = "update-Municipio",
                        Href = "http://localhost/Municipios/" + Municipio.IdMunicipio.ToString(),
                        Metodo = "PUT"
                        },
                        new LinkDTO()
                        {
                        Rel = "delete-Municipio",
                        Href = "http://localhost/Municipios/" + Municipio.IdMunicipio.ToString(),
                        Metodo = "DELETE"
                        }
                    }
                };


                if (Municipio == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound );
                }

                return Request.CreateResponse(HttpStatusCode.OK, municipiosPOCO);
            }catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
 }

        // PUT: api/Municipios/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="municipiosModel"></param>
        /// <returns></returns>
        [ResponseType(typeof(void))]
        [HttpPut]
        [Route("Municipios/{id}")]
        public HttpResponseMessage PutMunicipiosModel(int id, MunicipiosModel municipiosModel)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            if (id != municipiosModel.IdMunicipio)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(municipiosModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MunicipiosModelExists(id))
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                else
                {
                    throw;
                }
            }

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        // POST: api/Municipios
        /// <summary>
        /// 
        /// </summary>
        /// <param name="municipiosModel"></param>
        /// <returns></returns>
        [ResponseType(typeof(MunicipiosModel))]
        [HttpPost]
        [Route("Municipios/")]
        public HttpResponseMessage PostMunicipiosModel(MunicipiosModel municipiosModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }

                db.Municipio.Add(municipiosModel);
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.Created, municipiosModel);
            }catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        // DELETE: api/Municipios/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(MunicipiosModel))]
        [HttpDelete]
        [Route("Municipios/{id}")]
        public HttpResponseMessage DeleteMunicipiosModel(int id)
        {
            MunicipiosModel municipiosModel = db.Municipio.Find(id);
            if (municipiosModel == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Municipio.Remove(municipiosModel);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, municipiosModel);
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

        private bool MunicipiosModelExists(int id)
        {
            return db.Municipio.Count(e => e.IdMunicipio == id) > 0;
        }
    }
}