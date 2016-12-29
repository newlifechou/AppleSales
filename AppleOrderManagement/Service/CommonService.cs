using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AppleOrderManagement.Service
{

    public static class CommonService
    {
        private static string dataDir;
        static CommonService()
        {
            dataDir = Path.Combine(System.Environment.CurrentDirectory, "Data");
        }

        public static List<string> GetData(string dataFile)
        {
            string filePath = Path.Combine(dataDir, dataFile);
            List<string> result = new List<string>();
            if (File.Exists(filePath))
            {
                StreamReader sr = new StreamReader(filePath);
                string line = "";
                while (line!=null)
                {
                    line = sr.ReadLine();
                    if (line!=null)
                    {
                        result.Add(line);
                    }
                }
                sr.Close();
            }

            return result;
        }
    }
}
