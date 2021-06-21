using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebdriverTestProject.Utils
{
    public static class JsonConvertor
    {
        public static TestDataGenerator GetTestData()
        {
            if (File.Exists(@"D:\ATM_Module_6\WebdriverTestProject\Utils\TestData.json"))
            {
                string data = File.ReadAllText(@"D:\ATM_Module_6\WebdriverTestProject\Utils\TestData.json");
                return JsonConvert.DeserializeObject<TestDataGenerator>(data);
            }
            else
            {
                throw new FileNotFoundException();
            }
        }
    }
}
