using ble = Robotics.Mobile.Core.Bluetooth.LE;
using System.ComponentModel;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System;
using System.Diagnostics;
using TTT_Xamarin.Pages.Parts;
using System.Threading.Tasks;
using System.Collections.Generic;
using TTT_Xamarin.Pages;
using TTT_Xamarin.Models;

namespace TTT_Xamarin.ViewModels
{
    public class DeviceDetailsPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name { get { return BleDevice?.Name; } }

        public ble.IDevice BleDevice { get; set; }
        public ble.IAdapter adapter;
        public bool Loading { get; set; }

        private ObservableCollection<Sensor> sensors = new ObservableCollection<Sensor>();
        public ObservableCollection<Sensor> Sensors { get { return sensors; } }

        private Command<Sensor> selectCmd;
        private INavigation navigation;

        public Command<Sensor> Select
        {
            get
            {
                return selectCmd;
            }
        }

        public DeviceDetailsPageViewModel(INavigation navigation)
        {
            this.navigation = navigation;
            selectCmd = selectCmd ?? new Command<Sensor>(s =>
            {
                navigation.PushModalAsync(new SensorGraphPage());
                MessagingCenter.Send(this, "open graph", s);
            }
            );
            selectCmd.CanExecute(false);
            prepareAdapter();
            MessagingCenter.Subscribe<DeviceScanPageViewModel,ble.IDevice>(this, "device selected", (sender,arg) => {
                BleDevice = arg;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
                adapter.ConnectToDevice(BleDevice);
                Loading = true;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Loading"));
            });
        }
        private void prepareAdapter()
        {
            adapter = App.Adapter;
            adapter.DeviceConnected += (s, e) =>
            {
                Loading = false;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Loading"));
                BleDevice = e.Device;
                BleDevice.ServicesDiscovered += (se, ea) =>
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        foreach (var service in BleDevice.Services)
                        {
                            switch (service.Name)
                            {
                                case "TI SensorTag Barometer":
                                    sensors.Add(new Sensor(adapter, BleDevice, service));
                                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Sensors"));
                                    await Task.Delay(3000);
                                    break;
                                case "TI SensorTag Humidity":
                                    sensors.Add(new Sensor(adapter, BleDevice, service));
                                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Sensors"));
                                    await Task.Delay(3000);
                                    break;
                                case "TI SensorTag Infrared Thermometer":
                                    sensors.Add(new Sensor(adapter, BleDevice, service));
                                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Sensors"));
                                    await Task.Delay(3000);
                                    break;
                            }
                        }
                    });
                };
                BleDevice.DiscoverServices();
            };
        }
    }
}