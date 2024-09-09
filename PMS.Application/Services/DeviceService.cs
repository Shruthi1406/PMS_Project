using PMS.Application.Interfaces;
using PMS.Application.Repository_Interfaces;
using PMS.Domain.Entities;
using System.Linq;

namespace PMS.Application.Services
{
    public class DeviceService:IDeviceService
    {
        public readonly IDeviceRepository _deviceRepository;
        private readonly IPatientRepository _patientRepository;
        public DeviceService(IDeviceRepository deviceRepository, IPatientService patientService)
        {
            _deviceRepository = deviceRepository; 
        } 
        public async Task<Device> CreateDevice(string patientEmail)
        {
            var patientList=await _patientRepository.GetAllPatients();
            var patient=patientList.FirstOrDefault(p=>p.PatientEmail==patientEmail);
            return await _deviceRepository.CreateDevice(patient);
        }
    }
}
