using PMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Application.Interfaces
{
    public interface IPatientService
    {
        Task<List<Patient>> GetAllPatients();
        Task<bool> RegisterPatient(Patient patient);
    }
}
