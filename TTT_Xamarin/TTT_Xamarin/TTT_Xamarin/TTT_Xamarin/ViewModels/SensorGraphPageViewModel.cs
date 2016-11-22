
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using TTT_Xamarin.Models;
using Xamarin.Forms;

namespace TTT_Xamarin.ViewModels

{
    public class SensorGraphPageViewModel : INotifyPropertyChanged
    {
        private Sensor sensor;
        public string Name { get { return sensor?.ImageId; } }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Sensor.dataPoint> History { get; }

        public SensorGraphPageViewModel()
        {
            History = new ObservableCollection<Sensor.dataPoint>();
            MessagingCenter.Subscribe<DeviceDetailsPageViewModel, Sensor>(this, "open graph", (sender, arg) => {

                this.sensor = arg;
                sensor.NewDataDelegate += test;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
            });
        }

        private void test(Sensor sensor)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                History.Clear();
                foreach (Sensor.dataPoint point in sensor.history.ToArray())
                {
                    History.Add(point);
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("History"));
            });
        }
    }
}