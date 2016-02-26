using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace log4net.RabbitMQ.Console
{
    class Program
    {

        private static readonly ILog _Logger = LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.config");

            XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo(path));



            System.Console.WriteLine(path);


            _Logger.Debug("ok");



            System.Console.ReadKey();

            while (true)
            {
                string s = System.Console.ReadLine();

                _Logger.Debug(s);
            }
        }
    }
}
