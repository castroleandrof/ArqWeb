using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcPet.UI.Proces;
using mvcPet.Entities;
using mvcPet.UI.Web.Constants;
using mvcPet.Services.Contracts;
using mvcPet.UI.Web.Models;
using System.Security.Principal;
using Microsoft.AspNet.Identity;
using mvcPet.Services;

namespace mvcPet.UI.Web.Controllers
{

        public class CitaController : BaseController
        {


            private ICitaService _citaService;
            private IMedicoService _medicoService;
            private ISalaService _salaService;
            private ITipoServicioService _tipoServicioService;
            private IPacienteService _pacienteService;
            private List<SelectListItem> _horarios;

        public CitaController() { }

        public CitaController(
                ICitaService citaService,
                IMedicoService medicoService,
                ISalaService salaService,
                ITipoServicioService tipoServicioService,
                IPacienteService pacienteService)
            {
                _citaService = citaService;
                _medicoService = medicoService;
                _salaService = salaService;
                _tipoServicioService = tipoServicioService;
                _pacienteService = pacienteService;
                _horarios = new List<SelectListItem>();

            }
            // GET: Cita
            public ActionResult Index()
            {
                try
                {
                ICitaService citaService = new CitaService();
                var lista = citaService.ListarTodos();
                  //  this.LogService.Log("Listar Todas las citas.");
                    return View(lista);
                }
                catch (Exception ex)
                {
                    var err = $"No se puede listar el registro: {ex.Message}";
                    TempData[Application.MessageViewBagName] = new GenericMessageViewModel
                    {
                        Message = err,
                        MessageType = GenericMessages.danger
                    };
                // this.LogService.Log(err);
                    return View();
                }
            }

            // GET: ListarCitas
            public ActionResult ListarCitas(int pacienteId)
            {
                try
                {
                    var lista = _citaService.ListarTodos(pacienteId).Where(e => e.Deleted == false);
                    Paciente p = _pacienteService.BuscarPorId(pacienteId);
                    TempData["clienteId"] = p.ClienteId;
                    TempData["pacienteId"] = pacienteId;
                    this.LogService.Log("Listar Todas las citas de paciente.");
                    return View(lista);
                }
                catch (Exception ex)
                {
                    var err = $"No se puede listar el registro: {ex.Message}";
                    TempData[Application.MessageViewBagName] = new GenericMessageViewModel
                    {
                        Message = err,
                        MessageType = GenericMessages.danger
                    };
                    this.LogService.Log(err);
                    return View();
                }
            }



            // GET: Cita/Details/5
            public ActionResult Details(int? id)
            {
                this.LogService.Log("Detalle de cita.");
                if (id == null)
                {
                    return HttpNotFound();
                }
                Cita cita = _citaService.BuscarPorId(id.Value);
                cita.Medico = _medicoService.BuscarPorId(cita.MedicoId);
                cita.Paciente = _pacienteService.BuscarPorId(cita.PacienteId);
                cita.Sala = _salaService.BuscarPorId(cita.SalaId);
                cita.TipoServicio = _tipoServicioService.BuscarPorId(cita.TipoServicioId);
                if (cita == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View(cita);
                }
            }

            // GET: Cita/Create
            public ActionResult Create(int? pacienteId)
            {
                //if (pacienteId == null)
                //{
                //    return HttpNotFound();
                //}
                //TempData["pacienteId"] = pacienteId;
                //var listaMedicos = _medicoService.ListarTodos();
                //List<SelectListItem> itemsMedicos = listaMedicos.ConvertAll(e =>
                //{
                //    return new SelectListItem()
                //    {
                //        Text = e.Nombre.ToString() + " " + e.Apellido.ToString(),
                //        Value = e.Id.ToString(),
                //        Selected = false
                //    };
                //});

                //var listaSalas = _salaService.ListarTodos();
                //List<SelectListItem> itemsSalas = listaSalas.ConvertAll(e =>
                //{
                //    return new SelectListItem()
                //    {
                //        Text = e.Nombre.ToString() + " " + e.TipoSala.ToString(),
                //        Value = e.Id.ToString(),
                //        Selected = false
                //    };
                //});

                //var listaTipoServicio = _tipoServicioService.ListarTodos();
                //List<SelectListItem> itemsTipoServicio = listaTipoServicio.ConvertAll(e =>
                //{
                //    return new SelectListItem()
                //    {
                //        Text = e.Nombre.ToString(),
                //        Value = e.Id.ToString(),
                //        Selected = false
                //    };
                //});

                //ViewBag.itemsMedicos = itemsMedicos;
                //ViewBag.itemsSalas = itemsSalas;
                //ViewBag.itemsTipoServicio = itemsTipoServicio;
                //ViewBag.itemsHorario = Horarios();
                return View();
            }

            // POST: Cita/Create
            [HttpPost]
            public ActionResult Create(Cita model)
            {
                try
                {
                    ICitaService citaService = new CitaService();
                    model.CreatedBy = User.Identity.GetUserId();
                    model.CreatedDate = DateTime.Now;
                    int hora = model.Hora;
                    model.Fecha = model.Fecha.AddHours((double)hora);
                    if (model.Fecha <= DateTime.Now)
                    {
                        TempData[Application.MessageViewBagName] = new GenericMessageViewModel
                        {
                            Message = "La fecha tiene que ser a partir de hoy.",
                            MessageType = GenericMessages.info
                        };
                        //this.LogService.Log("Error al crear cita con fecha menor a la fecha actual.");
                        return RedirectToAction("Create", new { pacienteId = model.PacienteId });
                    }
                    if (citaService.ExisteCita(model))
                    {
                        TempData[Application.MessageViewBagName] = new GenericMessageViewModel
                        {
                            Message = "Ya existe una cita con esa fecha, hora, médico y sala.",
                            MessageType = GenericMessages.info
                        };
                        //this.LogService.Log("Error al crear registro duplicado.");
                        return RedirectToAction("Create", new { pacienteId = model.PacienteId });
                    }
                    citaService.Agregar(model);
                    //this.LogService.Log("Agragar una cita.");
                    TempData[Application.MessageViewBagName] = new GenericMessageViewModel
                    {
                        Message = "Registro agregado a la base de datos.",
                        MessageType = GenericMessages.success
                    };
                    return RedirectToAction("ListarCitas", new { pacienteId = model.PacienteId });
                }
                catch (Exception ex)
                {
                    var err = $"No se puede agregar el registro: {ex.Message}";
                    TempData[Application.MessageViewBagName] = new GenericMessageViewModel
                    {
                        Message = err,
                        MessageType = GenericMessages.danger
                    };
                    //this.LogService.Log(err);
                    return View();
                }
            }

            // GET: Cita/Edit/5
            public ActionResult Edit(int? id)
            {
                if (id == null)
                {
                    return HttpNotFound();
                }
                Cita cita = _citaService.BuscarPorId(id.Value);
                var listaMedicos = _medicoService.ListarTodos();
                List<SelectListItem> itemsMedicos = listaMedicos.ConvertAll(e =>
                {
                    return new SelectListItem()
                    {
                        Text = e.Nombre.ToString() + " " + e.Apellido.ToString(),
                        Value = e.Id.ToString(),
                        Selected = false
                    };
                });

                var listaSalas = _salaService.ListarTodos();
                List<SelectListItem> itemsSalas = listaSalas.ConvertAll(e =>
                {
                    return new SelectListItem()
                    {
                        Text = e.Nombre.ToString() + " " + e.TipoSala.ToString(),
                        Value = e.Id.ToString(),
                        Selected = false
                    };
                });

                var listaTipoServicio = _tipoServicioService.ListarTodos();
                List<SelectListItem> itemsTipoServicio = listaTipoServicio.ConvertAll(e =>
                {
                    return new SelectListItem()
                    {
                        Text = e.Nombre.ToString(),
                        Value = e.Id.ToString(),
                        Selected = false
                    };
                });

                ViewData["itemsMedicos"] = itemsMedicos;
                ViewData["itemsSalas"] = itemsSalas;
                ViewData["itemsTipoServicio"] = itemsTipoServicio;
                _horarios = Horarios();
                ViewData["itemsHorario"] = _horarios;
                if (cita == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View(cita);
                }
            }

            // POST: Cita/Edit/5
            [HttpPost]
            public ActionResult Edit(Cita cita)
            {
                try
                {
                    cita.ChangedBy = User.Identity.GetUserId();
                    cita.ChangedDate = DateTime.Now;
                    int hora = cita.Hora;
                    DateTime fechaNueva = new DateTime(cita.Fecha.Year, cita.Fecha.Month, cita.Fecha.Day);
                    fechaNueva = fechaNueva.AddHours((double)hora);
                    cita.Fecha = fechaNueva;
                    if (cita.Fecha <= DateTime.Now)
                    {
                        TempData[Application.MessageViewBagName] = new GenericMessageViewModel
                        {
                            Message = "La fecha tiene que ser a partir de hoy.",
                            MessageType = GenericMessages.info
                        };
                        this.LogService.Log("Error al editar cita con fecha menor a la fecha actual.");
                        return RedirectToAction("Edit", new { pacienteId = cita.PacienteId });
                    }
                    if (_citaService.ExisteCita(cita))
                    {
                        TempData[Application.MessageViewBagName] = new GenericMessageViewModel
                        {
                            Message = "Ya existe una cita con asa fecha, hora, médico y sala.",
                            MessageType = GenericMessages.info
                        };
                        this.LogService.Log("Error al crear registro duplicado.");
                        return RedirectToAction("Create", new { pacienteId = cita.PacienteId });
                    }
                    _citaService.Editar(cita);
                    this.LogService.Log("Editar cita.");
                    TempData[Application.MessageViewBagName] = new GenericMessageViewModel
                    {
                        Message = "Registro editado en la base de datos.",
                        MessageType = GenericMessages.success
                    };
                    return RedirectToAction("ListarCitas", new { pacienteId = cita.PacienteId });
                }
                catch (Exception ex)
                {
                    var err = $"No se puede editar el registro: {ex.Message}";
                    TempData[Application.MessageViewBagName] = new GenericMessageViewModel
                    {
                        Message = err,
                        MessageType = GenericMessages.danger
                    };
                    this.LogService.Log(err);
                    return RedirectToAction("Edit", new { pacienteId = cita.PacienteId });
                }
            }

            // GET: Cita/StateChange/5
            public ActionResult StateChange(int? id)
            {
                if (id == null)
                {
                    return HttpNotFound();
                }
                Cita cita = _citaService.BuscarPorId(id.Value);
                cita.Medico = _medicoService.BuscarPorId(cita.MedicoId);
                cita.Paciente = _pacienteService.BuscarPorId(cita.PacienteId);
                cita.Sala = _salaService.BuscarPorId(cita.SalaId);
                cita.TipoServicio = _tipoServicioService.BuscarPorId(cita.TipoServicioId);
                if (cita == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View(cita);
                }
            }

            // POST: Cita/StateChange/5
            [HttpPost]
            public ActionResult StateChange(Cita cita)
            {
                try
                {
                   // logState(cita);
                    _citaService.Editar(cita);
                    this.LogService.Log("Cambio de estado, cita.");
                    TempData[Application.MessageViewBagName] = new GenericMessageViewModel
                    {
                        Message = "Registro modificado.",
                        MessageType = GenericMessages.success
                    };
                    return RedirectToAction("ListarCitas", new { pacienteId = cita.PacienteId });
                }
                catch (Exception ex)
                {
                    var err = $"No se puede eliminar el registro: {ex.Message}";
                    TempData[Application.MessageViewBagName] = new GenericMessageViewModel
                    {
                        Message = err,
                        MessageType = GenericMessages.danger
                    };
                    this.LogService.Log(err);
                    return RedirectToAction("StateChange", new { pacienteId = cita.PacienteId });
                }
            }

            //private void logState(Cita cita)
            //{
            //    string userId = User.Identity.GetUserId();
            //    if (cita.Estado == Estado.Cancelado)
            //    {
            //        cita.DeletedBy = userId;
            //        cita.DeletedDate = DateTime.Now;
            //        cita.Deleted = true;
            //    }
            //    else if (cita.Estado == Estado.Realizado)
            //    {
            //        cita.ChangedBy = userId;
            //        cita.ChangedDate = DateTime.Now;
            //        cita.Deleted = true;
            //    }
            //    else if (cita.Estado == Estado.Confirmado)
            //    {
            //        cita.ChangedBy = userId;
            //        cita.ChangedDate = DateTime.Now;
            //        cita.Deleted = false;
            //    }
            //    else if (cita.Estado == Estado.Reservado)
            //    {
            //        cita.ChangedBy = userId;
            //        cita.ChangedDate = DateTime.Now;
            //        cita.Deleted = false;
            //    }
            //}

            public List<SelectListItem> Horarios()
            {
                return new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "08:00",
                    Value = "08"
                },
                new SelectListItem()
                {
                    Text = "09:00",
                    Value = "09"
                },
                new SelectListItem()
                {
                    Text = "10:00",
                    Value = "10"
                },
                new SelectListItem()
                {
                    Text = "11:00",
                    Value = "11"
                },
                new SelectListItem()
                {
                    Text = "12:00",
                    Value = "12"
                },
                new SelectListItem()
                {
                    Text = "13:00",
                    Value = "13"
                },
                new SelectListItem()
                {
                    Text = "14:00",
                    Value = "14"
                },
                new SelectListItem()
                {
                    Text = "15:00",
                    Value = "15"
                },
                new SelectListItem()
                {
                    Text = "16:00",
                    Value = "16"
                },
                new SelectListItem()
                {
                    Text = "17:00",
                    Value = "17"
                },
                new SelectListItem()
                {
                    Text = "18:00",
                    Value = "18"
                },
                new SelectListItem()
                {
                    Text = "19:00",
                    Value = "19"
                },
                new SelectListItem()
                {
                    Text = "20:00",
                    Value = "20"
                },
            };
            }
        }
    }

