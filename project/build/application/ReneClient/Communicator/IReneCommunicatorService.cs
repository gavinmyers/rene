using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReneData.Communicator
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(
       ConfigurationName = "IReneCommunicatorService",
        CallbackContract = typeof(ReneServiceCallback),
        SessionMode = System.ServiceModel.SessionMode.Required)]
    public interface IReneCommunicatorService
    {
        /* ApplicationInformation */
        /* ******************** */
        [System.ServiceModel.OperationContractAttribute(
          Action = "http://tempuri.org/IReneCommunicatorService/ApplicationInformation",
          ReplyAction = "http://tempuri.org/IReneCommunicatorService/ApplicationInformationResponse")]
        string ApplicationInformation();

        /* Upload */
        /* ******************** */
        [System.ServiceModel.OperationContractAttribute(IsOneWay = true, Action = "http://tempuri.org/IReneCommunicatorService/Upload")]
        void Upload(ReneCommunicatorFile request);




    }
}
