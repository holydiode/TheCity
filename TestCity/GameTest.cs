using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheCity;

namespace TestCity
{
    [TestClass]
    public class GameTest
    {
        /// <summary>
        /// Проверка инициазизации класса игры
        /// </summary>
        [TestMethod]
        public void GameClassExist()
        {
            var game = new GameCity();
            Assert.IsNotNull(game);
        }

        [DataRow("Астрахань")]
        [TestMethod]
        public void AddOneCityInThePool(string city)
        {
            var game = new GameCity();
            game.AddCity(city);
            CollectionAssert.Contains(game.Dict, city);
        }

        [DataRow("Астрахань")]
        [TestMethod]
        public void AddArraInThePool(params string[] cities)
        {
            var game = new GameCity();
            game.AddCity(cities);
            foreach(string citie in cities)
            {
                CollectionAssert.Contains(game.Dict, citie);
            }
        }


    }
}
