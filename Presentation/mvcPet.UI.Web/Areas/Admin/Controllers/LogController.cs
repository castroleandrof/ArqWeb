using mvcPet.Framework.Logging;
using mvcPet.UI.Web.Areas.Admin.Models;
using mvcPet.UI.Web.Models;
using mvcPet.UI.Web.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcPet.UI.Web.Areas.Admin.Controllers
{
    [Authorize (Roles = "Admin")]
    public class LogController : Controller
    {
        private ILoggingService _loggingService;

        public LogController(ILoggingService loggingService)
        {
            _loggingService = loggingService;
        }
        // GET: Admin/Log
        public ActionResult Index()
        {
            IList<LogEntry> logs = new List<LogEntry>();

            try
            {
                logs = _loggingService.ListLogFile();
            }
            catch (Exception ex)
            {
                var err = $"No se puede acceder a los registros: {ex.Message}";
                TempData[Application.MessageViewBagName] = new GenericMessageViewModel
                {
                    Message = err,
                    MessageType = GenericMessages.danger
                };

                _loggingService.Error(err);
            }

            ListLogViewModel listLog = new ListLogViewModel { LogFiles = logs };

            return View(listLog);
        }

        public ActionResult ClearLog()
        {
            _loggingService.ClearLogFiles();

            TempData[Application.MessageViewBagName] = new GenericMessageViewModel
            {
                Message = "Archivo de registro borrado",
                MessageType = GenericMessages.success
            };
            return RedirectToAction("Index");
        }

    }
}
