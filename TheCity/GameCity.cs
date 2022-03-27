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

        private static readonly string specialCheraters = "ъь";

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

            var lastSym = _hystory[^1].Length - 1;

            while (specialCheraters.Contains(_hystory[^1][lastSym]) || lastSym == 0)
            {
                lastSym -= 1;
            }

            return _hystory[^1][lastSym] == city.ToLower()[0];
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
