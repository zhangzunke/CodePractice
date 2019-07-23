using AutoFac.Repository.IRepository;
using AutoFac.Service.IService;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoFac.Service.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public string GetStudentName(long id)
        {
            return _studentRepository.GetName(id);
        }
    }
}
