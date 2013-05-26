using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReneData.DataObject;

namespace ReneData.Communicator
{

    /// <summary>
    /// SERVER to CLIENT communication
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface ReneServiceCallback
    {

        /* ******************** */
        /* ******************** */
        /* Generic Calls */
        /* ******************** */
        /* ******************** */
        #region GENERIC
            [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IReneCommunicatorService/User")]
            User User();

            [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IReneCommunicatorService/Broadcast")]
            void Broadcast(string evt, User sender, object data);

            [System.ServiceModel.OperationContractAttribute(IsOneWay = true, Action = "http://tempuri.org/IReneCommunicatorService/Download")]
            void Download(ReneCommunicatorFile request);
        #endregion


        /* ******************** */
        /* ******************** */
        /* Game Engine Calls */
        /* ******************** */
        /* ******************** */
        #region Custom
            [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IReneCommunicatorService/TankMove")]
            void TankMove(string evt, User sender, double x, double y);
        #endregion
    }
}
