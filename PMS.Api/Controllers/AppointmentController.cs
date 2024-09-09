using Microsoft.AspNetCore.Mvc;
using PMS.Application.Interfaces;
using PMS.Domain.Entities;

namespace PMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPost]
        [Route("Schedule/Appointments")]


        public async Task<IActionResult> ScheduleAppointmentForPatient([FromBody] Appointment appointment)
        {
            if (appointment == null)
            {
                return BadRequest("Appointment cannot be null");
            }
            var result=await _appointmentService.ScheduleAppointment(appointment);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> AppointmentByAppointmentId(int appointmentId)
        {
            var appointment = await _appointmentService.GetAppointment(appointmentId);
            if (appointment == null)
            {
                return NotFound();
            }
            return Ok(appointment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAppointment(int id, [FromBody] Appointment appointment)
        {
            if (id != appointment.AppointmentId)
            {
                return BadRequest("Appointment ID mismatch.");
            }

            var updatedAppointment = await _appointmentService.UpdateAppointment(id, appointment);
            if (updatedAppointment == null)
            {
                return NotFound();
            }

            return Ok(updatedAppointment);
        }

        [HttpGet("patient/{patientId}")]
        public async Task<IActionResult> AppointmentsByPatientId(int patientId)
        {
            var appointment=await _appointmentService.GetAppointmentsByPatientId(patientId);
            return Ok(appointment);
        }

        [HttpGet("doctor/{doctorId}")]
        public async Task<IActionResult> AppointmentsByDoctorId(int doctorId)
        {
            var appointment=await _appointmentService.GetAppointmentsByDoctorId(doctorId);
            return Ok(appointment);
        }
    }
}
