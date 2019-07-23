using System;
using System.Collections.Generic;
using System.Text;

namespace AutoFac.Repository.IRepository
{
    public interface IStudentRepository
    {
        string GetName(long id);
    }
}
