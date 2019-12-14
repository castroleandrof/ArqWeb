using mvcPet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcPet.Services.Contracts.Requests
{
    public partial class AddRequest
    {
        public Cita Cita { get; set; }
    }
}
