using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingAcademy.BL.Abstract;
using TrainingAcademy.DAL;
using TrainingAcademy.UI.ViewModel;

namespace TrainingAcademy.BL.Concrete
{
    public class Delegate : IDelegate
    {
        private readonly DVTEntities _db = new DVTEntities();

        public void AddDelegate(DAL.Delegate @delegate)
        {
            _db.Delegates.Add(@delegate);
            _db.SaveChanges();
        }

        public List<DAL.Delegate> ListDelegate()
        {
            return _db.Delegates.ToList();
        }

        public void RemoveDelegate(int id)
        {
            var @delegate = _db.Delegates.Find(id);
            _db.Delegates.Remove(@delegate);
            _db.SaveChanges();
        }

        public DAL.Delegate UpdateDelegate(int id)
        {
            var @delegate = _db.Delegates.Where(x => x.DelegateID == id).FirstOrDefault() as DAL.Delegate;
            _db.Entry(@delegate).State = EntityState.Modified;
            _db.SaveChanges();
            return @delegate;
        }

        public List<Dietary> GetDietaries()
        {
            return _db.Dietaries.ToList();
        }

        public DAL.Delegate GetDelegate(int Id)
        {

            return _db.Delegates.Find(Id);

        }
    }
}
