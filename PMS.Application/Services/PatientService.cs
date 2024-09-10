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
        public PatientService(IPatientRepository repository)
        {
            _repository = repository;
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
            if(isPatientAdded)
            {
                return new PatientRes { IsSuccess = true, PatientEmail = newPatient.PatientEmail };
            }
            return new PatientRes { IsSuccess = false, ErrorMessage = "Patient not added" };


        }
    }
}
