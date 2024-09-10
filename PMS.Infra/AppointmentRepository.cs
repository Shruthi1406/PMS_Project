using Microsoft.EntityFrameworkCore;
using PMS.Application.Interfaces;
using PMS.Domain.Entities;

namespace PMS.Infra
{
    public class AppointmentRepository :IAppointmentService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public AppointmentRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Appointment> ScheduleAppointment(Appointment appointment)
        {
            _applicationDbContext.Appointments.Add(appointment);
            _applicationDbContext.SaveChanges();
            return appointment;
        }

        public async Task<Appointment> GetAppointment(int appointmentId)
        {
            return await _applicationDbContext.Appointments.FindAsync(appointmentId);
        }

        public async Task<Appointment> UpdateAppointment(int appointmentId, Appointment updatedAppointment)
        {
            var appointment = await _applicationDbContext.Appointments.FindAsync(appointmentId);
            if (appointment == null)
            {
                return null;
            }
            appointment.PatientId = updatedAppointment.PatientId;
            appointment.DoctorId = updatedAppointment.DoctorId;
            appointment.AppointmentDate = updatedAppointment.AppointmentDate;
            appointment.Status = updatedAppointment.Status;
            appointment.HospitalName = updatedAppointment.HospitalName;
            appointment.Reason = updatedAppointment.Reason;
            appointment.CreatedAt = updatedAppointment.CreatedAt;

            _applicationDbContext.Appointments.Update(appointment);
            await _applicationDbContext.SaveChangesAsync();

            return appointment;

        }

        public async Task<List<Appointment>> GetAppointmentsByPatientId(int patientId)
        {
            return await _applicationDbContext.Appointments.Where(a=>a.PatientId == patientId).ToListAsync();
        }

        public async Task<List<Appointment>> GetAppointmentsByDoctorId(int doctorId)
        {
            return await _applicationDbContext.Appointments.Where(a=>a.DoctorId == doctorId).ToListAsync();
        }

    }
}
