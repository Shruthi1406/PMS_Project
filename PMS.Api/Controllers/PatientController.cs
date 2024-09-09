﻿using Microsoft.AspNetCore.Mvc;
using PMS.Application.Interfaces;
using PMS.Domain.Entities;
using PMS.Domain.Entities.Request;
using PMS.Domain.Entities.Response;

namespace PMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : Controller
    {
        public readonly IPatientService _patientService;
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Patient>>> GetPatients()
        {
            var patients= await _patientService.GetAllPatients();
            return Ok(patients);
        }
        [HttpPost]
        public async Task<ActionResult<PatientRes>> RegisterPatient(PatientReq patientReq)
        {
            var PatientRes = await _patientService.RegisterPatient(patientReq);

            return Ok(PatientRes);
        }
    }
}
