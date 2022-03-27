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
            _hystory = new List<string>();
        }

        public IList Dict { get; set; }

        private IList<string> _hystory { get; set;}

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
            if (_hystory.Count == 0)
            {
                return true;
            }
            return _hystory[^1][^1] == city[0];
        }

        public bool CheckRepeat(string city)
        {
            return ! _hystory.Contains(city);
        }

        public bool Check(object city)
        {
            return true;
        }

        public void Say(string city)
        {
            _hystory.Add(city);
        }
    }
}
