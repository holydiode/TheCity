using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheCity;

namespace TestCity
{
    [TestClass]
    public class GameTest
    {
        /// <summary>
        /// �������� ������������� ������ ����
        /// </summary>
        [TestMethod]
        public void GameClassExist()
        {
            var game = new GameCity();
            Assert.IsNotNull(game);
        }
    }
}
