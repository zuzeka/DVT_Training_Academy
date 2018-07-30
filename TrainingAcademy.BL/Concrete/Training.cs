using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingAcademy.BL.Abstract;
using TrainingAcademy.DAL;

namespace TrainingAcademy.BL.Concrete
{
    public class Training: ITraining
    {
        private readonly DVTEntities _db;
        public Training(DVTEntities dVTEntities)
        {
            _db = dVTEntities;
        }

        public IEnumerable<DAL.Training> GetAll()
        {
            return _db.Trainings.ToList();
        }
        public void Insert(DAL.Training training)
        {
            _db.Trainings.Add(training);
            _db.SaveChanges();
            
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            if (id < 1)
            {
                throw new Exception("The record you trying to deleted is not available");
            }
            else
            {
                DAL.Training training = _db.Trainings.Find(id);
                _db.Trainings.Remove(training);
                _db.SaveChanges();
            }
        }
        

        public DAL.Training getById(int id)
        {
            return _db.Trainings.Find(id);
        }
        public void Update(DAL.Training training)
        {
            _db.Entry(training).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public List<DAL.TrainingPayment> GetPaymentDesc()
        {
            return _db.TrainingPayments.ToList();
        }
        public List<DAL.Course> GetCourse()
        {
            return _db.Courses.ToList();
        }
        public int CurrentCourseID(int id)
        {
            DAL.Training training = _db.Trainings.Find(id);
            return training.CourseID;
        }
        public int CurrentTrainingPaymentID(int id)
        {
            DAL.Training training = _db.Trainings.Find(id);
            return training.TrainingPaymentID;
        }

        public int UpdateCourseID(DAL.Training training)
        {
            return training.CourseID;
        }
        public int UpdateTrainingPaymentID(DAL.Training training)
        {
            return training.TrainingPaymentID;
        }
    }
}
