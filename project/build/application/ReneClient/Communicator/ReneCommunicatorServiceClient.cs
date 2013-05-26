using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReneData.Communicator
{

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class ReneCommunicatorServiceClient : System.ServiceModel.DuplexClientBase<IReneCommunicatorService>, IReneCommunicatorService
    {

#region constructors
        public ReneCommunicatorServiceClient(System.ServiceModel.InstanceContext callbackInstance) :
            base(callbackInstance)
        {
        }

        public ReneCommunicatorServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) :
            base(callbackInstance, endpointConfigurationName)
        {
        }

        public ReneCommunicatorServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) :
            base(callbackInstance, endpointConfigurationName, remoteAddress)
        {
        }

        public ReneCommunicatorServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
            base(callbackInstance, endpointConfigurationName, remoteAddress)
        {
        }

        public ReneCommunicatorServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress)
            :
                base(callbackInstance, binding, remoteAddress)
        {
        }
#endregion



        /* ApplicationInformation */
        /* ******************** */
        public string ApplicationInformation()
        {
            return base.Channel.ApplicationInformation();
        }

        /* Upload */
        /* ******************** */
        void IReneCommunicatorService.Upload(ReneCommunicatorFile request)
        {
            base.Channel.Upload(request);
        }

        public void Upload(string FileName, System.IO.Stream Data)
        {
            ReneCommunicatorFile inValue = new ReneCommunicatorFile();
            inValue.FileName = FileName;
            inValue.Data = Data;
            inValue.FileDestination = "..\\..\\..\\ReneServerDownloads\\";
            ((IReneCommunicatorService)(this)).Upload(inValue);
        }


    }
}
