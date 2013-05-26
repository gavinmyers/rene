using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReneData.DataObject;

namespace ReneData.Communicator
{
    /// <summary>
    /// CLIENT to SERVER communication
    /// </summary>
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

        /* ******************** */
        /* ******************** */
        /* Generic Calls */
        /* ******************** */
        /* ******************** */
        #region Generic

        /* UserConnect */
        /* ******************** */
        bool HasUserConnected = false;
        public void UserConnect()
        {
            if (!HasUserConnected)
            {
                base.Channel.UserConnect();
            }
        }

        /* UserDisconnect */
        /* ******************** */
        public void UserDisconnect()
        {
            base.Channel.UserDisconnect();
        }

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

        /* Download */
        /* ******************** */
        public ReneCommunicatorFile Download(ReneCommunicatorFileRequest request)
        {
            return base.Channel.Download(request);
        }

        #endregion

        /* ******************** */
        /* ******************** */
        /* Game Engine Calls */
        /* ******************** */
        /* ******************** */
        #region Game
        /* TankMove */
        /* ******************** */
        public bool TankMove(double x, double y)
        {
            return base.Channel.TankMove(x, y);
        }
        #endregion

        /* ******************** */
        /* ******************** */
        /* Database Calls */
        /* ******************** */
        /* ******************** */
        #region Database
        /* spUsers */
        /* ******************** */
        public List<User> spUsers(User u) { return base.Channel.spUsers(u); }

        #endregion


    }
}