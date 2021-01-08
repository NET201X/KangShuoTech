using KangShuoTech.Utilities.Common;

namespace KangShuoTech.Utilities.CommonControl
{
    using System;
    using System.Management;

    public class USB
    {
        private ManagementEventWatcher insertWatcher;
        private ManagementEventWatcher removeWatcher;

        public bool AddUSBEventWatcher(EventArrivedEventHandler usbInsertHandler, EventArrivedEventHandler usbRemoveHandler, TimeSpan withinInterval)
        {
            try
            {
                ManagementScope scope = new ManagementScope(@"root\CIMV2") {
                    Options = { EnablePrivileges = true }
                };
                if (usbInsertHandler != null)
                {
                    WqlEventQuery query = new WqlEventQuery("__InstanceCreationEvent", withinInterval, "TargetInstance isa 'Win32_USBControllerDevice'");
                    this.insertWatcher = new ManagementEventWatcher(scope, query);
                    this.insertWatcher.EventArrived += usbInsertHandler;
                    this.insertWatcher.Start();
                }
                if (usbRemoveHandler != null)
                {
                    WqlEventQuery query2 = new WqlEventQuery("__InstanceDeletionEvent", withinInterval, "TargetInstance isa 'Win32_USBControllerDevice'");
                    this.removeWatcher = new ManagementEventWatcher(scope, query2);
                    this.removeWatcher.EventArrived += usbRemoveHandler;
                    this.removeWatcher.Start();
                }
                return true;
            }
            catch (Exception exception)
            {
                LogHelper.LogError(exception);
                this.RemoveUSBEventWatcher();
                return false;
            }
        }

        public void RemoveUSBEventWatcher()
        {
            if (this.insertWatcher != null)
            {
                this.insertWatcher.Stop();
                this.insertWatcher = null;
            }
            if (this.removeWatcher != null)
            {
                this.removeWatcher.Stop();
                this.removeWatcher = null;
            }
        }

        public static USBControllerDevice[] WhoUSBControllerDevice(EventArrivedEventArgs e)
        {
            ManagementBaseObject obj2 = e.NewEvent["TargetInstance"] as ManagementBaseObject;
            if ((obj2 == null) || (obj2.ClassPath.ClassName != "Win32_USBControllerDevice"))
            {
                return null;
            }
            string str = (obj2["Antecedent"] as string).Replace("\"", string.Empty).Split(new char[] { '=' })[1];
            string str2 = (obj2["Dependent"] as string).Replace("\"", string.Empty).Split(new char[] { '=' })[1];
            USBControllerDevice[] deviceArray = new USBControllerDevice[1];
            USBControllerDevice device = new USBControllerDevice {
                Antecedent = str,
                Dependent = str2
            };
            deviceArray[0] = device;
            return deviceArray;
        }
    }
}

