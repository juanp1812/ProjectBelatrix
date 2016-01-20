using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BelatrixTest
{
    class Program
    {
        public static void Main(string[] args)
        {
            var strResult = "";
            var log = new JobLogger();

            var lstSource = new List<Source>();
            lstSource.Add(Source.File);
            lstSource.Add(Source.Console);
            lstSource.Add(Source.Database);

            var typeMessage = TypeMessage.Warning;

            strResult = log.SetLog("test 2000", typeMessage, lstSource);

            Console.Write(strResult);
            Console.ReadKey();
        }
    }
}
