using mvcPet.Business;
using mvcPet.Entities;
using mvcPet.Services.Contracts.Requests;
using mvcPet.Services.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace mvcPet.Services
{
    [RoutePrefix("api/Cita")]
    public class CitaApiService : ApiController
    {

        [HttpGet]
        [Route("Listar")]
        public ToListResponse ToList()
        {
            try
            {
                var response = new ToListResponse();
                var bc = new CitaComponent();
                response.Result = bc.ListarTodos();
                return response;
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };

                throw new HttpResponseException(httpError);
            }
        }

        [HttpPost]
        [Route("Agregar")]
        public AddResponse Add(AddRequest request)
        {
            try
            {
                var response = new AddResponse();
                var bc = new CitaComponent();
                response.Result = bc.Agregar(request.Cita);
                return response;
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };

                throw new HttpResponseException(httpError);
            }
        }
    }
}
