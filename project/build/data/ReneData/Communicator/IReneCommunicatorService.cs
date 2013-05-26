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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(
       ConfigurationName = "IReneCommunicatorService",
        CallbackContract = typeof(ReneServiceCallback),
        SessionMode = System.ServiceModel.SessionMode.Required)]
    public interface IReneCommunicatorService
    {
        /* ******************** */
        /* ******************** */
        /* Generic Calls */
        /* ******************** */
        /* ******************** */

        #region Generic
        /* UserConnect */
        /* ******************** */
        [System.ServiceModel.OperationContractAttribute(
          Action = "http://tempuri.org/IReneCommunicatorService/UserConnect",
          ReplyAction = "http://tempuri.org/IReneCommunicatorService/UserConnect")]
        void UserConnect();

        /* UserDisconnect */
        /* ******************** */
        [System.ServiceModel.OperationContractAttribute(
          Action = "http://tempuri.org/IReneCommunicatorService/UserDisconnect",
          ReplyAction = "http://tempuri.org/IReneCommunicatorService/UserDisconnect")]
        void UserDisconnect();

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

        /* Download */
        /* ******************** */
        [System.ServiceModel.OperationContractAttribute(
            Action = "http://tempuri.org/IReneCommunicatorService/ServerDownload",
            ReplyAction = "http://tempuri.org/IReneCommunicatorService/ServerDownloadResponse")]
        ReneCommunicatorFile Download(ReneCommunicatorFileRequest request);
        #endregion

        /* ******************** */
        /* ******************** */
        /* Game Engine Calls */
        /* ******************** */
        /* ******************** */

        #region Game
        /* TankMove */
        /* ******************** */
        [System.ServiceModel.OperationContractAttribute(
          Action = "http://tempuri.org/IReneCommunicatorService/TankMove",
          ReplyAction = "http://tempuri.org/IReneCommunicatorService/TankMoveResponse")]
        bool TankMove(double x, double y);
        #endregion


        /* ******************** */
        /* ******************** */
        /* Database Calls */
        /* ******************** */
        /* ******************** */

        #region Database
        /* spUsers */
        /* ******************** */
        [System.ServiceModel.OperationContractAttribute(
          Action = "http://tempuri.org/IReneCommunicatorService/spUsers",
          ReplyAction = "http://tempuri.org/IReneCommunicatorService/spUsersResponse")]
        List<User> spUsers(User u);
        #endregion
        
    }
}
