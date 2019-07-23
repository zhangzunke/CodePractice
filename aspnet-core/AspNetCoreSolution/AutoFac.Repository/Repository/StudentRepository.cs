using AutoFac.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoFac.Repository.Repository
{
    public class StudentRepository : IStudentRepository
    {
        public string GetName(long id)
        {
            return "Mike Zhang";
        }
    }
}
