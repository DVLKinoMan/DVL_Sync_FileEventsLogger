using System;
using Windows.Data.Xml.Dom;
using DVL_Sync_FileEventsLogger.Abstractions;
using DVL_Sync_FileEventsLogger.Models;
using Microsoft.Toolkit.Uwp.Notifications;
using Windows.UI.Notifications;
using DVL_Sync_FileEventsLogger.OnWindows.Helpers;

//using DVL_Sync_FileEventsLogger.Domain.Extensions;

namespace DVL_Sync_FileEventsLogger.OnWindows.Implementations
{
    public class FolderEventsLoggerInWindows10Notifications : IFolderEventsLogger
    {
        private readonly string applicationID;
        private readonly FolderConfig folderConfig;

        public FolderEventsLoggerInWindows10Notifications(FolderConfig folderConfig, string appid)
        {
            this.folderConfig = folderConfig;
            applicationID = appid;
            Windows10NotificationsHelper.TryCreateShortcut(applicationID);
        }

        public void Dispose()
        {
            
        }

        public void LogOperation<Operation>(Operation operation) where Operation : OperationEvent
        {
            if (!folderConfig.IsValid(operation))
                return;

            //This is not responsibility of this operation. It needs abstraction
            var content = new ToastContent()
            {
                Launch = "app-defined-string",
                Visual = new ToastVisual()
                {
                    BindingGeneric = new ToastBindingGeneric()
                    {
                        Children =
                        {
                            new AdaptiveText()
                            {
                                Text = $"Action:  {operation.EventType.ToString()}"
                            },
                            new AdaptiveText()
                            {
                                Text = $"Action: {operation.EventType.ToString()}{Environment.NewLine}FileName: {operation.FileName}"
                            },
                            new AdaptiveImage()
                            {
                                Source = @"C:\Windows\WinSxS\amd64_microsoft-windows-t..nbackgrounds-client_31bf3856ad364e35_10.0.17134.1_none_c2974feb629c22da\img100.jpg"
                            }
                        },
                        AppLogoOverride = new ToastGenericAppLogo()
                        {
                            Source = @"C:\Windows\WinSxS\amd64_microsoft-windows-shell-wallpaper-theme2_31bf3856ad364e35_10.0.17134.1_none_bc5a789c0e1871e3\img8.jpg",
                            HintCrop = ToastGenericAppLogoCrop.Circle
                        }
                    }
                },
                DisplayTimestamp = operation.RaisedTime
            };

            // Display toast
            var doc = new XmlDocument();
            doc.LoadXml(content.GetContent());

            ToastNotificationManager.CreateToastNotifier(applicationID).Show(new ToastNotification(doc));
        }
    }
}
