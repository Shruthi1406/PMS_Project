using PMS.Application.Interfaces;
using PMS.Application.Repository_Interfaces;
using PMS.Domain.Entities;
using PMS.Domain.Entities.Request;
using PMS.Domain.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Application.Services
{
    public class PatientService:IPatientService
    {
        private readonly IPatientRepository _repository;
        /*private readonly IDeviceService _deviceService;
        private readonly IVitalSignService _vitalSignService;*/
        public PatientService(
            IPatientRepository repository,
            IDeviceService deviceService, 
            IVitalSignService vitalSignService)
        {
            _repository = repository;
            /*_deviceService = deviceService;
            _vitalSignService = vitalSignService;*/
        }


        public async Task<List<Patient>> GetAllPatients()
        {
            return await _repository.GetAllPatients();
        }

        public async Task<PatientRes> RegisterPatient(PatientReq patientReq)
        {
            if(patientReq == null)
            {
                return new PatientRes { IsSuccess=false,ErrorMessage="Required a patient"};
            }
            var newPatient = new Patient
            {
                PatientName = patientReq.FirstName + " " + patientReq.LastName,
                PatientEmail = patientReq.PatientEmail,
                Password = patientReq.Password,
                Age = patientReq.Age,
                Gender = patientReq.Gender,
                ContactNumber = patientReq.ContactNumber,
                DeviceName = patientReq.DeviceName,
                Date = DateTime.Now,
            };
            var isPatientAdded=await _repository.RegisterPatient(newPatient);

            /*if(isPatientAdded)
            {
                var device=await _deviceService.CreateDevice(newPatient.PatientEmail);
                var vitalSign = await _vitalSignService.CreateVitalSign(device.DeviceId);
                device.VitalSign = vitalSign;
                return new PatientRes { IsSuccess=true};
            }
            return new PatientRes { IsSuccess = false,ErrorMessage="Patient Not Added"};*/

        }
    }
}
