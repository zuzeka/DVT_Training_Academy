using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingAcademy.DAL;

namespace TrainingAcademy.BL.Abstract
{
    public interface IRegister
    {
        List<DAL.Registration> ListRegistration();
        void RegisterTraining(DAL.Registration register);
        List<Registration> ListRegister();
        Registration UpdateRegister(int id);
        void RemoveRegister(int id);
        Registration GetRegister(int id);
        
    }
}
