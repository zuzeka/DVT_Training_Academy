using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingAcademy.BL.Abstract
{
    public interface ITraining
    {
        IEnumerable<DAL.Training> GetTrainings();
        void Save();
        void Create();
        void Delete(int id);
        void Update(DAL.Training training);
        DAL.Training getById(int id);
    }
}
