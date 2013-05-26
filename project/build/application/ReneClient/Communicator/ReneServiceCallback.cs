using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReneData.Communicator
{

    /// <summary>
    /// SERVER to CLIENT communication
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface ReneServiceCallback
    {

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IReneCommunicatorService/Broadcast")]
        void Broadcast(string evt, object data);


    }
}
