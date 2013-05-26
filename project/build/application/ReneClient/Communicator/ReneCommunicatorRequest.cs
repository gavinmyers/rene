using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReneData.Communicator
{
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "ReneCommunicatorFile", WrapperNamespace = "http://tempuri.org/", IsWrapped = true)]
    public partial class ReneCommunicatorFile
    {

        [System.ServiceModel.MessageHeaderAttribute(Namespace = "http://tempuri.org/")]
        public string FileDestination;

        [System.ServiceModel.MessageHeaderAttribute(Namespace = "http://tempuri.org/")]
        public string FileName;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://tempuri.org/", Order = 0)]
        public System.IO.Stream Data;

        public ReneCommunicatorFile()
        {
        }

        public ReneCommunicatorFile(string FileName, System.IO.Stream Data)
        {
            this.FileName = FileName;
            this.Data = Data;
        }
    }
}
