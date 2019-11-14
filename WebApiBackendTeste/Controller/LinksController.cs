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
using WebApiBackendTeste.Model;

namespace WebApiBackendTeste.Controller
{
    public class LinksController : ApiController
    {
        private readonly UrlHelper _urlHelper;
        private ContextModel db = new ContextModel();
        public LinksController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        public LinksController(UrlHelper urlHelper)
        {
            this._urlHelper = urlHelper;
        }
    }
}
