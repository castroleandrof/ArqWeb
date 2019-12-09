﻿using mvcPet.Business;
using mvcPet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace mvcPet.Services.Http
{
    [RoutePrefix("api/Cita")]
    public class CitaApiService : ApiController
    {

        [HttpGet]
        [Route("ListarTodas")]
        public List<Cita> ToList()
        {
            try
            {
                var response = new List<Cita>();
                var bc = new CitaComponent();
                response = bc.ListarTodos();
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
