using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TheCity
{
    public class GameCity
    {
        private static readonly string _specialCheraters = "ъь";

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern IntPtr GetStdHandle(int nStdHandle);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool CancelIoEx(IntPtr handle, IntPtr lpOverlapped);

        private IList<string> _hystory { get; set; }

        public GameCity() {
            Dict = new List<string>();
            _hystory = new List<string>();
        }

        public IList Dict { get; set; }

        public void AddCity(string city)
        {
            Dict.Add(city);
        }

        public void AddCity(string[] cities)
        {
            foreach (string citie in cities)
            {
                Dict.Add(citie);
            }
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

            while (_specialCheraters.Contains(_hystory[^1][lastSym]) || lastSym == 0)
            {
                lastSym -= 1;
            }

            return _hystory[^1][lastSym] == city.ToLower()[0];
        }

        public bool CheckRepeat(string city)
        {
            return ! _hystory.Contains(city);
        }

        public bool Check(string city)
        {
            return CheckExist(city) && CheckLetters(city) && CheckRepeat(city);
        }

        public bool Say(string city)
        {
            if (Check(city)) {
                _hystory.Add(city);
                return true;
            }
            return false;
        }

        public void StartTurn(int v)
        {
            Task.Delay(v).ContinueWith(
                _ => {
                        var handle = GetStdHandle(-10);
                        CancelIoEx(handle, IntPtr.Zero);
                        throw new OperationCanceledException();
                    }
            );
        }

        public void AddCity()
        {
            throw new NotImplementedException();
        }
    }
}
