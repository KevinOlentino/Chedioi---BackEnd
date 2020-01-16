using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiBackendTeste.Model;
using WebApiBackendTeste.Context;
using WebApiBackendTeste.Model.POCO;

namespace WebApiBackendTeste.Controller
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("Api")]
    public class ProfissoesController : ApiController
    {
        private ContextModel db = new ContextModel();
        /// <summary>
        /// 
        /// </summary>
        public ProfissoesController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        //GET: api/Profissoes
        [HttpGet]
        [Route("Profissao/")]
        public HttpResponseMessage GetProfissoes()
        {
            try
            {
                List<ProfissoesPOCO> profissaoPOCOs = db.Profissao.Select(Profissoes => new ProfissoesPOCO()
                {
                    idprofissao = Profissoes.IdProfissao,
                    descricao = Profissoes.Descricao,
                    links = new List<LinkDTO>()
                    {
                        new LinkDTO()
                        {
                            Rel = "self",
                            Href = "http://localhost/Profissoes/" + Profissoes.IdProfissao.ToString(),
                            Metodo = "GET"
                        },
                        new LinkDTO()
                        {
                            Rel = "Update-Profissoes",
                            Href = "http://localhost/Profissoes" + Profissoes.IdProfissao.ToString(),
                            Metodo = "UPDATE"
                        },
                        new LinkDTO()
                        {
                            Rel = "Delete-Profissoes",
                            Href = "http://localhost/Profissoes" + Profissoes.IdProfissao.ToString(),
                            Metodo = "DELETE"
                        },
                    }
                }).ToList();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception EX)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, EX);
            }
        }
        // GET: api/Profissoes/id
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Profissao/{id}")]
        public HttpResponseMessage GetProfissao(int id)
        {
            ProfissoesModel profissoes = db.Profissao.SingleOrDefault(est => est.IdProfissao == id);
            try
            {
                ProfissoesPOCO profissaoPOCOs = new ProfissoesPOCO()
                {
                    idprofissao = profissoes.IdProfissao,
                    descricao = profissoes.Descricao,
                    links = new List<LinkDTO>()
                    {
                        new LinkDTO()
                        {
                            Rel = "self",
                            Href = "http://localost/profissoes" + profissoes.IdProfissao.ToString(),
                            Metodo = "GET"
                        },
                        new LinkDTO()
                        {
                            Rel = "update-profissoes",
                            Href = "http://localhost/Profissoes" + profissoes.IdProfissao.ToString(),
                            Metodo = "PUT"
                        },
                        new LinkDTO()
                        {
                            Rel = "delete-profissoes",
                            Href = "http://localhost/Profissoes/" + profissoes.IdProfissao.ToString(),
                            Metodo = "DELETE",
                        }
                    }
                };
                if (profissoes == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, profissaoPOCOs);
                }
            }
            catch (Exception EX)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, EX);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="profissoes"></param>
        /// <returns></returns>
        // POST: api/Profissoes/id
        [HttpPost]
        [Route("Profissao/")]
        public HttpResponseMessage PostProfissao(ProfissoesModel profissoes)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }

                db.Profissao.Add(profissoes);
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.Created, profissoes);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="profissoes"></param>
        /// <returns></returns>
        //PUT: api/Profissoes/id
        [HttpPut]
        [Route("Profissao/{id}")]
        public HttpResponseMessage PutProfissao(int id, ProfissoesModel profissoes)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            if (id != profissoes.IdProfissao)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            db.Entry(profissoes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!ProfissoesExists(id))
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
                }
            }

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/Profissoes/id
        [HttpDelete]
        [Route("Profissao/{id}")]
        public HttpResponseMessage DeleteProfissao(int id)
        {
            ProfissoesModel profissoes = db.Profissao.Find(id);
            if (profissoes == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Profissao.Remove(profissoes);
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
        private bool ProfissoesExists(int id)
        {
            return db.Profissao.Count(e => e.IdProfissao == id) > 0;
        }
    }
}


