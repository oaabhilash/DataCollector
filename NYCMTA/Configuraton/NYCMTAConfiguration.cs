using NYCMTA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NYCMTA.Configuraton
{
    public class NYCMTAConfiguration : INYCMTAConfiguration
    {
        public NYCMTAConfiguration()
        {
            MtaUrl = System.Configuration.ConfigurationManager.AppSettings["NYCMTAUrl"];
        }
        public string MtaUrl { get; set; }
    }
}
