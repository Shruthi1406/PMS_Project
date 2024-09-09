using PMS.Application.Repository_Interfaces;
using PMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Infra
{
    public class PatientRepository:IPatientRepository
    {
        public readonly IApplicationDbContext _applicationDbContext;
        public PatientRepository(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public List<Patient> Patients = new List<Patient>
        {
            new Patient() {
                PatientId = 1,
                PatientName = "John Doe",
                PatientEmail = "john.doe@example.com",
                ContactNumber = "+1234567890",
                Password = "password123", // Note: Storing passwords in plain text is not secure. This is just for demonstration.
                Age = 30,
                Gender = "Male",
                Date = DateTime.Now
            }
        };
        
        public async Task<List<Patient>> GetAllPatients()
        {
            return _applicationDbContext.Patients.ToList();
        }
    }
}
