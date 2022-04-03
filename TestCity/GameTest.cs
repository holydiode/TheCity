using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
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
        public void AddArrayInThePool(params string[] cities)
        {
            var game = new GameCity();
            game.AddCity(cities);
            foreach(string citie in cities)
            {
                CollectionAssert.Contains(game.Dict, citie);
            }
        }


        [DataRow("Астрахань", "Норильск", "Углич")]
        [TestMethod]
        public void AddComplexMethodInThePool(string city, params string[] cities)
        {
            var game = new GameCity();
            game.AddCity(city);
            game.AddCity(cities);
            CollectionAssert.Contains(game.Dict, city);
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

        [DataRow("Астрахань")]
        [TestMethod]
        public void CheckCityFromEmptyPool(string city)
        {
            var game = new GameCity();
            var result = game.CheckExist(city);
            Assert.IsFalse(result);
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

        [DataRow("Aрхангельск", "Aрхангельск")]
        [TestMethod]
        public void CheckCity(string city, params string[] pool)
        {
            var game = new GameCity();
            game.AddCity(pool);
            bool result = game.Check(city);
            Assert.IsTrue(result);
        }

        [DataRow("Aрхангельск", "Aрхангельск")]
        [TestMethod]
        public void CheckSay(string city, params string[] pool)
        {
            var game = new GameCity();
            game.AddCity(pool);
            var result = game.Say(city);
            Assert.IsTrue(result);
        }

        [DataRow("Aрхангельск", "Норильск", "Aрхангельск", "Норильск")]
        [DataRow("Aрхангельск", "Амазонка", "Aрхангельск", "Норильск")]
        [DataRow("Aрхангельск", "Aрхангельск", "Aрхангельск", "Норильск")]
        [TestMethod]
        public void CheckSayWrongAnswer(string firstCity, string secondCity, params string[] pool)
        {
            var game = new GameCity();
            game.AddCity(pool);
            game.Say(firstCity);
            bool result = game.Say(secondCity);
            Assert.IsFalse(result);
        }



        [DataRow("Aрхангельск")]
        [TestMethod]
        public void CheckSameCityTwice(string city)
        {
            var game = new GameCity();
            game.AddCity(city);
            game.Say(city);
            bool result = game.CheckRepeat(city);
            Assert.IsFalse(result);
        }


        [DataRow("Aрхангельск", "Норильск", "Aрхангельск", "Норильск")]
        [TestMethod]
        public void CheckLetersTwoWords(string firstCity, string secondCity, params string[] pool)
        {
            var game = new GameCity();
            game.AddCity(pool);
            game.Say(firstCity);
            bool result = game.CheckLetters(secondCity);
            Assert.IsFalse(result);
        }

        [DataRow("Астрахань", "Норильск")]
        [TestMethod]
        public void CheckLetersWithSpecialWords(string firstCity, string secondCity)
        {
            var game = new GameCity();
            game.Say(firstCity);
            bool result = game.CheckLetters(secondCity);
            Assert.IsTrue(result);
        }

        [DataRow("Aрхангельск", "Норильск", "Aрхангельск", "Норильск")]
        [DataRow("Aрхангельск", "Амазонка", "Aрхангельск", "Норильск")]
        [DataRow("Aрхангельск", "Aрхангельск", "Aрхангельск", "Норильск")]
        [TestMethod]
        public void CheckMainDoubleWorld(string firstCity, string secondCity, params string[] pool)
        {
            var game = new GameCity();
            game.AddCity(pool);
            game.Say(firstCity);
            bool result = game.Check(secondCity);
            Assert.IsFalse(result);
        }

        [DataRow(100)]
        [TestMethod]
        public void CheckTimerBreack(int time)
        {
            var game = new GameCity();
            game.StartTurn(time);
            bool throwHandle = false;

            try
            {
                Console.ReadLine();
            }
            catch (Exception)
            {
                throwHandle = true;
            }
            Assert.IsTrue(throwHandle);
        }


        [DataRow(100)]
        [TestMethod]
        public void CheckTimerNonEarlyBreack(int time)
        {
            var game = new GameCity();
            game.StartTurn(time);
            System.Threading.Thread.Sleep(time / 2);
        }


        [DataRow(100, "Астрахань", "Норильск", "Астрахань", "Норильск")]
        [TestMethod]
        public void CheckTurnMoveWithCoorect(int time,string firstCity, string secondCity, params string[] pool)
        {
            var game = new GameCity();
            game.AddCity(pool);
            game.StartTurn(time);
            System.Threading.Thread.Sleep(time - time / 5);
            game.Say(firstCity);
            System.Threading.Thread.Sleep(time - time / 5);
            game.Say(secondCity);
        }


        [DataRow(100, "Aрхангельск", "Норильск", "Aрхангельск", "Норильск")]
        [DataRow(100, "Aрхангельск", "Амазонка", "Aрхангельск", "Норильск")]
        [DataRow(100, "Aрхангельск", "Aрхангельск", "Aрхангельск", "Норильск")]
        [TestMethod]
        public void CheckTurnMoveWithWrong(int time, string firstCity, string secondCity, params string[] pool)
        {
            var game = new GameCity();
            game.AddCity(pool);
            game.StartTurn(time);
            System.Threading.Thread.Sleep(time - time / 5);
            game.Say(firstCity);
            System.Threading.Thread.Sleep(time - time / 5);
            game.Say(secondCity);

            try
            {
                System.Threading.Thread.Sleep(time);
                Assert.Fail();
            }
            catch (Exception)
            {
            }
        }

    }
}
