using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mvcPet.Services.Contracts;
using mvcPet.Entities;
using mvcPet.Services.Contracts.Responses;
using mvcPet.UI.Process;
using mvcPet.Services.Contracts.Requests;

namespace mvcPet.UI.Proces
{
    public class CitaProcess : ProcessComponent
    {
        public List<Cita> ListarCita()
        {
            var lista = HttpGet<ToListResponse>("/api/Cita/ToList", new Dictionary<string, object>(), MediaType.Json);
            return lista.Result;
        }

        public Cita AddSettings(Cita cita)
        {
            var result = default(Cita);
            try
            {
                AddRequest requests = new AddRequest();
                requests.Cita = cita;
                var response = HttpPost<AddRequest>("api/Cita/Add", requests, MediaType.Json);
                result = response.Cita;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
            return result;
        }

    }
}
