using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace TrainingAcademy.Tests
{
    [TestClass]
    public class DelegateTest
    {
        BL.Concrete.Delegate @delegate = new BL.Concrete.Delegate();

        [TestMethod]
        public void ListDelegate()
        {
            int count = @delegate.ListDelegate().Count;

            Assert.AreNotEqual(0, count);
        }
    }
}
