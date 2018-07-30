using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingAcademy.BL.Abstract
{
    public interface ITraining
    {
        IEnumerable<DAL.Training> GetAll();
        void Save();
        void Insert(DAL.Training training);
        void Delete(int id);
        void Update(DAL.Training training);
        DAL.Training getById(int id);
        List<DAL.Course> GetCourse();
        List<DAL.TrainingPayment> GetPaymentDesc();
        int CurrentCourseID(int id);
        int CurrentTrainingPaymentID(int id);
        int UpdateCourseID(DAL.Training training);
        int UpdateTrainingPaymentID(DAL.Training training);
    }
}
