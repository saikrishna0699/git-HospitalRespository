using HospitalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Core.Interface
{
    public interface IHospital
    {
        List<HospitalModel> DisplayAllHospitals();
        HospitalModel AddHospital(HospitalModel hospital);
    }
}
