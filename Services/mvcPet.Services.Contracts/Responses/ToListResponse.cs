using mvcPet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcPet.Services.Contracts.Responses
{
    public partial class ToListResponse
    {
        public List<Cita> Result { get; set; }

    }
}
