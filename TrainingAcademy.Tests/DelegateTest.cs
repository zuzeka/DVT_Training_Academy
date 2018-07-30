using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingAcademy.DAL;

namespace TrainingAcademy.Tests
{
    [TestClass]
    public class DelegateTest
    {
        DVTEntities db = new DVTEntities();
        [TestMethod]
        public void AddDelegate()
        {
            DAL.Delegate @delegate = new DAL.Delegate
            {
                AddressDetailID = 1,
                CompanyName ="DVT",
                DietaryID = 1,
                Email = "b@dvt.com",
                FirstName = "Bonginkosi",
                LastName = "Mahlangu",
                PhoneNumber = 123456789,
                
            };
        }
    }
}
