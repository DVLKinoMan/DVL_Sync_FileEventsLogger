using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using MS.WindowsAPICodePack.Internal;
using System;
using System.Diagnostics;
using System.IO;
//using static DVL_Sync_FileEventsLogger.OnWindows.Helpers.ShellHelpers;

namespace DVL_Sync_FileEventsLogger.OnWindows.Helpers
{
    public static class Windows10NotificationsHelper
    {
        public static bool TryCreateShortcut(string APP_ID)
        {
            //\\Microsoft\\Windows\\Start Menu
            string shortcutPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu) + "\\Programs\\Desktop Toasts Sample CS.lnk";
            if (!File.Exists(shortcutPath))
            {
                InstallShortcut(APP_ID, shortcutPath);
                return true;
            }
            return false;
        }

        public static  void InstallShortcut(string APP_ID, string shortcutPath)
        {
            // Find the path to the current executable
            string exePath = Process.GetCurrentProcess().MainModule.FileName;
            ShellHelpers.IShellLinkW newShortcut = (ShellHelpers.IShellLinkW)new ShellHelpers.CShellLink();

            // Create a shortcut to the exe
            ShellHelpers.ErrorHelper.VerifySucceeded(newShortcut.SetPath(exePath));
            ShellHelpers.ErrorHelper.VerifySucceeded(newShortcut.SetArguments(""));

            // Open the shortcut property store, set the AppUserModelId property
            ShellHelpers.IPropertyStore newShortcutProperties = (ShellHelpers.IPropertyStore)newShortcut;

            using (PropVariant appId = new PropVariant(APP_ID))
            {
                ShellHelpers.ErrorHelper.VerifySucceeded(newShortcutProperties.SetValue(SystemProperties.System.AppUserModel.ID, appId));
                ShellHelpers.ErrorHelper.VerifySucceeded(newShortcutProperties.Commit());
            }

            // Commit the shortcut to disk
            ShellHelpers.IPersistFile newShortcutSave = (ShellHelpers.IPersistFile)newShortcut;

            ShellHelpers.ErrorHelper.VerifySucceeded(newShortcutSave.Save(shortcutPath, true));
        }
    }
}
