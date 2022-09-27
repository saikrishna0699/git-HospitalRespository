using HospitalManagementSystem.Core.Interface;
using HospitalManagementSystem.DataAccess;
using HospitalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Core.Repository
{
    public class Hospital:IHospital
    {
        private readonly HospitalDbContext _context;
        public Hospital(HospitalDbContext context)
        {
            _context = context;
        }
        public List<HospitalModel> DisplayAllHospitals()
        {
            var list = _context.hospitalModel.ToList();
            return list;
        }
        public HospitalModel AddHospital(HospitalModel hospitalModel)
        {
            _context.hospitalModel.AddAsync(hospitalModel);
            _context.SaveChangesAsync();
            return hospitalModel;
        }
    }
}
