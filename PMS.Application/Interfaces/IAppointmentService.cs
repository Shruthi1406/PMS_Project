using PMS.Domain.Entities;

namespace PMS.Application.Interfaces
{
    public interface IAppointmentService
    {
        Task<Appointment> ScheduleAppointment(Appointment appointment);
        Task<Appointment> GetAppointment(int appointmentId);
        Task<Appointment> UpdateAppointment(int appointmentId, Appointment appointment);
        Task<List<Appointment>> GetAppointmentsByPatientId(int patientId);
        Task<List<Appointment>> GetAppointmentsByDoctorId(int doctorId);

    }
}
