﻿using mvcPet.Framework.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcPet.UI.Web.Areas.Admin.Models
{
    public class ListLogViewModel
    {
        public IList<LogEntry> LogFiles { get; set; }
    }
}