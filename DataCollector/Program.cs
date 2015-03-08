using NYCMTA.Configuraton;
using NYCMTA.Handler;
using NYCMTA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollector
{
    class Program
    {
        static void Main(string[] args)
        {
            //Neet to setup Ninject, logging and nunit
            INYCMTAConfiguration mtaConfig = new NYCMTAConfiguration();
            DataReader rdr = new DataReader(mtaConfig);

            rdr.ReadUrl();

            Console.Read();

        }
    }
}
