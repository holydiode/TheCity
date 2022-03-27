using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCity
{
    public class GameCity
    {
        public GameCity() {
            Dict = new List<string>();
        }

        public IList Dict { get; set; }

        public void AddCity(string city)
        {
            Dict = new List<string> { city };
        }

        public void AddCity(string[] cities)
        {
            Dict = new List<string>(cities);
        }

        public bool CheckExist(string city)
        {
            return Dict.Contains(city);
        }

        public bool CheckLetters(string city)
        {
            return true;
        }

        public bool CheckRepeat(string city)
        {
            return true;
        }

        public bool Check(object city)
        {
            return true;
        }

        public void Say(string city)
        {
        }
    }
}
