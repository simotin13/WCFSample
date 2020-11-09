using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    [ServiceContract]
    public interface IGet
    {
        [OperationContract]
        int GetNumber();

        [OperationContract]
        string GetString();

    }
}
