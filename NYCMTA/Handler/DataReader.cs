using NYCMTA.Interfaces;
using System;
using System.Web.Helpers;
using System.Text.RegularExpressions;

namespace NYCMTA.Handler
{
    public class DataReader
    {
        INYCMTAConfiguration configuration;
        public DataReader(INYCMTAConfiguration configuration)
        {
            this.configuration = configuration;
        }
        /// <summary>
        ///  The service status is retrived as a json object by js code at http://www.mta.info/sites/all/modules/custom/servicestatus/ss.js
        /// </summary>
        /// <returns></returns>
        public string ReadUrl()
        {
            Int64 differential = JSGetTime() / 60000;

            string url = @"http://www.mta.info/service_status_json/" + differential.ToString();
            string s = new System.Net.WebClient().DownloadString(url);

            dynamic data = Json.Decode(s);

            string jsonString = data.ToString();

            string pattern456 = "\"name\":\"(\\w+|\\w+\\s{1}\\w+|\\w+\\s{1}-\\s{1}\\w+|\\w+\\s{1}\\S+\\s{1}\\w+)\",\"status\":\"(GOOD SERVICE|PLANNED WORK|SERVICE CHANGE|DELAYS|SANDY REROUTE|SUSPENDED)\",";

            Regex rgx = new Regex(pattern456);

            MatchCollection matches = rgx.Matches(jsonString);
            if (matches.Count > 0)
            {
                Console.WriteLine(matches.Count);
                foreach (Match match in matches)
                {
                    Console.WriteLine(match.Groups[1].Value);
                    Console.WriteLine(match.Groups[2].Value);
                }
             }
        
            return s;
        }

        private Int64 JSGetTime()
        {
            Int64 retval = 0;
            var st = new DateTime(1970, 1, 1);
            TimeSpan t = (DateTime.Now.ToUniversalTime() - st);
            retval = (Int64)(t.TotalMilliseconds + 0.5);
            return retval;
        }
    }
}
