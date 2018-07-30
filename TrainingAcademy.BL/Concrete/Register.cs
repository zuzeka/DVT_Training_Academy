using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingAcademy.BL.Abstract;
using TrainingAcademy.DAL;
using System.Data.Entity;

namespace TrainingAcademy.BL.Concrete
{
    public class Register : IRegister
    {
        private readonly DVTEntities _db = new DVTEntities();

        public List<DAL.Registration> ListRegistration()
        {
            return _db.Registrations.ToList();
        }

        public void RegisterTraining(DAL.Registration register)
        {
            _db.Registrations.Add(register);
            _db.SaveChanges();
        }

        public List<DAL.Registration> ListRegister()
        {
            return _db.Registrations.ToList();
        }

        public void RemoveRegister(int id)
        {
            var register = _db.Registrations.Find(id);
            _db.Registrations.Remove(register);
            _db.SaveChanges();
        }

        public DAL.Registration UpdateRegister(int id)
        {
            var register = _db.Registrations.Where(x => x.RegistrationID == id).FirstOrDefault() as DAL.Registration;
            _db.Entry(register).State = EntityState.Modified;
            _db.SaveChanges();
            return register;
        }

        public Registration GetRegister(int Id)
        {

            return _db.Registrations.Find(Id);

        }
    }
}
