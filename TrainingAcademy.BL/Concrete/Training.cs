using System;
using System.Collections.Generic;
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

        public IEnumerable<DAL.Training> GetTrainings()
        {
            return _db.Trainings.ToList();
        }
        public void Create()
        {
            //_db.Trainings.Add(training);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            DAL.Training train = getById(id);
            _db.Trainings.Remove(train);
        }

        public void Update(DAL.Training training)
        {
            int id = training.TrainingID;
            training = getById(id);

            _db.Trainings.Add(training);
        }

        public DAL.Training getById(int id)
        {
            return _db.Trainings.Where(x => x.TrainingID == id).SingleOrDefault();
        }
    }
}
