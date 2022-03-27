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

        [DataRow("Астрахань", "Норильск", "Углич")]
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


        [DataRow("Астрахань")]
        [TestMethod]
        public void CheckCityFromPool(string city)
        {
            var game = new GameCity();
            game.AddCity(city);
            var result = game.CheckExist(city);
            Assert.IsTrue(result);
        }

        [DataRow("Архангельск")]
        [TestMethod]
        public void CheckCompareLetterInCitiesName(string city)
        {
            var game = new GameCity();
            bool result = game.CheckLetters(city);
            Assert.IsTrue(result);
        }

        [DataRow("Aрхангельск")]
        [TestMethod]
        public void CheckSameCity(string city)
        {
            var game = new GameCity();
            bool result = game.CheckRepeat(city);
            Assert.IsTrue(result);
        }


        [DataRow("Aрхангельск")]
        [TestMethod]
        public void CheckCity(string city)
        {
            var game = new GameCity();
            bool result = game.Check(city);
            Assert.IsTrue(result);
        }

    }
}
