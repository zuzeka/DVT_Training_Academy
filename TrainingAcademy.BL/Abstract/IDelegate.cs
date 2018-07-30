using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingAcademy.DAL;
using TrainingAcademy.UI.ViewModel;

namespace TrainingAcademy.BL.Abstract
{
    public interface IDelegate
    {
        void AddDelegate(DAL.Delegate @delegate);
        List<Dietary> GetDietaries();
        List<DAL.Delegate> ListDelegate();
        void RemoveDelegate(int id);
        DAL.Delegate UpdateDelegate(int id);
        DAL.Delegate GetDelegate(int Id);

    }
}
