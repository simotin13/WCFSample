using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;
namespace test.service
{
    public class GetServiceHost : IGet
    {
        public int GetNumber()
        {
            return 123;
        }
        public string GetString()
        {
             return "abc";
        }

    }
}
