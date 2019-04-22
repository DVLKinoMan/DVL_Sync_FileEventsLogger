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
            ToastContent content = new ToastContent()
            {
                Launch = "app-defined-string",
                Visual = new ToastVisual()
                {
                    BindingGeneric = new ToastBindingGeneric()
                    {
                        Children = {
                            new AdaptiveText() {
                                Text = $"Action:  {operation.EventType.ToString()}"
                            },
                            new AdaptiveText() {
                                Text = operation.ToString()
                            },
                            new AdaptiveText() {
                                Text = "See More Details"
                            },
                            new AdaptiveImage() {
                                Source = "https://unsplash.it/360/180?image=1043"
                            }
                        },
                        AppLogoOverride = new ToastGenericAppLogo()
                        {
                            Source = "https://unsplash.it/64?image=883",
                            HintCrop = ToastGenericAppLogoCrop.Circle
                        }
                    }
                }
            };

            // Display toast
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(content.GetContent());

            ToastNotificationManager.CreateToastNotifier(applicationID).Show(new ToastNotification(doc));
        }
    }
}
