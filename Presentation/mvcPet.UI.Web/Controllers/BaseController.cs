using mvcPet.Framework.Common;
using mvcPet.Framework.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcPet.UI.Web.Controllers
{
    public class BaseController : Controller
    {
        public ILoggingService LogService;

        public BaseController()
        {
            LogService = ServiceFactory.Get<ILoggingService>();
        }

    }
}