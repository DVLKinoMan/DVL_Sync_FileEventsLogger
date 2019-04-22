using System;
using Windows.Data.Xml.Dom;
using DVL_Sync_FileEventsLogger.Domain.Abstractions;
using DVL_Sync_FileEventsLogger.Domain.Models;
using Microsoft.Toolkit.Uwp.Notifications;
using Windows.UI.Notifications;
using DVL_Sync_FileEventsLogger.DomainOnWindows.Helpers;

namespace DVL_Sync_FileEventsLogger.DomainOnWindows.Implementations
{
    public class FolderEventsLoggerInWindows10Notifications : IFolderEventsLogger
    {
        private readonly string applicationID;

        public FolderEventsLoggerInWindows10Notifications(string appid)
        {
            this.applicationID = appid;
            Windows10NotificationsHelper.TryCreateShortcut(applicationID);
        }

        public void LogOperation<Operation>(Operation operation) where Operation : OperationEvent
        {
            //This is not responsibility of this operation. It needs abstraction
            ToastContent content = new ToastContent()
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
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(content.GetContent());

            ToastNotificationManager.CreateToastNotifier(applicationID).Show(new ToastNotification(doc));
        }
    }
}
