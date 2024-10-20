﻿using Cruceros.API.Habitaciones.Dto;
using Cruceros.API.Habitaciones.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cruceros.API.Habitaciones.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class HabitacionesController : ControllerBase
    {
        IHabitacionesService _habitacionesService { get; set; }

        public HabitacionesController(IHabitacionesService habitacionService)
        {
            _habitacionesService = habitacionService;
        }

        [HttpGet("ObtenerTodas")]
        public IEnumerable<HabitacionesDto> ObtenerTodas()
        {
            return _habitacionesService.GetAll();
        }
    }
}