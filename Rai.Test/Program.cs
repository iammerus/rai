using System;
using System.Threading.Tasks;
using Rai.Core.IoC;

namespace Rai.Test
{
    class Program
    {
        static void Main(string[] args)
        {
           var app = new Rai.Application( new Container() );

            app.Boot();

           
            Console.WriteLine(app.GetSpeechRecognitionEngineTitle());

            app.SpeakAsync("Melvin and Oliver are typical of the tomfoolery kind of behaviour, for example the famous line ihwooooo ");


            Console.ReadKey();
        }
    }
}
