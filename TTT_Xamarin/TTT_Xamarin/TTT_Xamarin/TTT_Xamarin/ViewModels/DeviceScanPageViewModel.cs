using Plugin.Permissions;
using PPA = Plugin.Permissions.Abstractions;
using ble = Robotics.Mobile.Core.Bluetooth.LE;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;
using TTT_Xamarin.Pages;

namespace TTT_Xamarin.ViewModels
{
    public class DeviceScanPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsRefreshing { get; set; }
        public ICommand ScanCommand { get; protected set; }
        public INavigation navigation { get; set; }

        ObservableCollection<ble.IDevice> devices = new ObservableCollection<ble.IDevice>();
        public ObservableCollection<ble.IDevice> Devices { get { return devices; } }

        private Command<ble.IDevice> selectCmd;
        public Command<ble.IDevice> Select
        {
            get
            {
                selectCmd = selectCmd ?? new Command<ble.IDevice>(s =>
                {
                    navigation.PushModalAsync(new DeviceDetailsPage());
                    MessagingCenter.Send(this, "device selected", s);
                }
                );
                return selectCmd;
            }
        }


        public DeviceScanPageViewModel(INavigation navigation)
        {
            this.navigation = navigation;
            ScanCommand = new Command(scan);
            GetPermission();
            MessagingCenter.Subscribe<DeviceScanPage>(this, "scan", (sender) => { scan(); });
        }

        void scan()
        {
            App.Adapter.DeviceDiscovered += (object sender, ble.DeviceDiscoveredEventArgs e) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    var found = false;
                    foreach (ble.IDevice device in devices)
                    {
                        if (device.ID == e.Device.ID)
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        devices.Add(e.Device);
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Devices"));
                    }
                });
            };

            App.Adapter.ScanTimeoutElapsed += (sender, e) =>
            {
                StopScanning();
            };

            if (App.Adapter.IsScanning)
            {
                StopScanning();
            }
            else
            {
                devices.Clear();
                App.Adapter.StartScanningForDevices();
                IsRefreshing = true;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsRefreshing"));
                Debug.WriteLine("adapter.StartScanningForDevices()");
            }
        }

        void StopScanning()
        {
            App.Adapter.StopScanningForDevices();
            IsRefreshing = false;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsRefreshing"));
            Debug.WriteLine("adapter.StopScanningForDevices()");
        }

        private async void GetPermission()
        {
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(PPA.Permission.Location);
                if (status != PPA.PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(PPA.Permission.Location))
                    {

                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(PPA.Permission.Location);
                    status = results[PPA.Permission.Location];
                }

                if (status == PPA.PermissionStatus.Granted)
                {
                }
                else if (status != PPA.PermissionStatus.Unknown)
                {
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
