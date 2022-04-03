using System;
using System.Net;

namespace TheCity
{
    class Program
    {

        private class City
        {
            public string name;
        }


        static void Main(string[] args)
        {
            var game = new GameCity();
            game.WebLoad<City>("https://raw.githubusercontent.com/aZolo77/citiesBase/master/cities.json", a => a.name);
            Console.WriteLine("Победил игрок {0}" , game.Play(10000));
        }
    }
}
