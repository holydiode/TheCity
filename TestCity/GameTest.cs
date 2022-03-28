using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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

            try
            {
                System.Threading.Thread.Sleep(time * 2);
                Assert.Fail();
            }
            catch (Exception)
            {
            }
        }


        [DataRow(100)]
        [TestMethod]
        public void CheckTimerNonEarlyBreack(int time)
        {
            var game = new GameCity();
            
            try
            {
                game.StartTurn(time);
                System.Threading.Thread.Sleep(time / 2);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }


        [DataRow(100)]
        [TestMethod]
        public void CheckTimerRestrt(int time)
        {
            var game = new GameCity();
           
            for (int i = 0; i < 2; i++)
            {
                try
                {
                    game.StartTurn(time);
                    System.Threading.Thread.Sleep( (int)((float)time / 1.1));
                }
                catch (Exception)
                {
                    Assert.Fail();
                }
            }
            try
            {
                System.Threading.Thread.Sleep(time * 2);
                Assert.Fail();
            }
            catch (Exception)
            {
            }
        }


        [DataRow("Aрхангельск", "Норильск", "Aрхангельск", "Норильск")]
        public void CheckTurnMoveWithCoorect(string firstCity, string secondCity, params string[] pool)
        {
            var game = new GameCity();
            game.AddCity(pool);
            game.Say(firstCity);
        }


    }
}
