using ble = Robotics.Mobile.Core.Bluetooth.LE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace TTT_Xamarin.Models
{
    public class Sensor : INotifyPropertyChanged
    {
        public ble.IService service;

        EventHandler<ble.CharacteristicReadEventArgs> valueUpdatedHandler;
        public event PropertyChangedEventHandler PropertyChanged;
        public string ImageId { get; set; }
        public string Data { get; set; }
        public bool Loading { get; set; }
        private ble.IDevice BleDevice { get; set; }

        private ble.ICharacteristic dataChar;
        private ble.ICharacteristic onOffChar;
        private ble.ICharacteristic sampleChar;
        public NewDataDelegate NewDataDelegate;

        public Queue<dataPoint> history = new Queue<dataPoint>();
        private int counter = 0;

        public Sensor(ble.IAdapter adapter, ble.IDevice device, ble.IService service)
        {
            BleDevice = device;
            Loading = true;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Loading"));
            this.service = service;
            switch (service.Name)
            {
                case "TI SensorTag Barometer":
                    ImageId = "Pressure";
                    break;
                case "TI SensorTag Humidity":
                    ImageId = "Humidity";
                    break;
                case "TI SensorTag Infrared Thermometer":
                    ImageId = "Thermometer";
                    break;
            }
            service.CharacteristicsDiscovered += async (s, e) =>
            {
                foreach (var characteristic in service.Characteristics)
                {
                    if (characteristic.Name.Contains("Data"))
                    {
                        dataChar = await characteristic.ReadAsync();
                        await Task.Delay(1000);
                    }
                    else if (characteristic.Name.Contains("On/Off"))
                    {
                        onOffChar = await characteristic.ReadAsync();
                        onOffChar.Write(new byte[] { 0x01 });
                        await Task.Delay(1000);
                    }
                    else if (characteristic.Name.Contains("Sample Rate"))
                    {
                        sampleChar = await characteristic.ReadAsync();
                        await Task.Delay(1000);
                    }
                }
                if (dataChar.CanUpdate)
                {
                    valueUpdatedHandler = (se, ea) =>
                    {
                        Data = Decode(dataChar);
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Data"));
                    };
                    dataChar.ValueUpdated += valueUpdatedHandler;
                    dataChar = await dataChar.ReadAsync();
                    await Task.Delay(2000);
                    dataChar.StartUpdates();
                    Loading = false;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Loading"));
                }
            };
            service.DiscoverCharacteristics();
        }



        public string Decode(ble.ICharacteristic _characteristic)
        {
            var sensorData = _characteristic.Value;
            if (_characteristic.Name.Contains("Temp"))
            {
                double ambientTemperature = BitConverter.ToUInt16(sensorData, 2) / 128.0;
                record(ambientTemperature);
                return "temperature: " + Math.Round(ambientTemperature, 1) + "C";
            }
            else if (_characteristic.Name.Contains("Humidity"))
            {
                int a = BitConverter.ToUInt16(sensorData, 2);
                a = a - (a % 4);
                double humidity = (-6f) + 125f * (a / 65535f);
                record(humidity);
                return "humidity: " + Math.Round(humidity, 1) + "%rH";
            }
            else
            {
                double pressure = (_characteristic.Value[3] | (_characteristic.Value[4] << 8) | (_characteristic.Value[5] << 16));
                record(pressure);
                return "pressure: " + Math.Round(pressure / 100, 1) + "hPa";
            }
        }
        private void record(double data)
        {
            if (history.Count >= 20)
            {
                history.Dequeue();
            }
            history.Enqueue(new dataPoint(counter++, data));
            NewDataDelegate?.Invoke(this);
            //TODO: push data to api
        }

        public class dataPoint
        {
            public int Id { get; set; }
            public double Value { get; set; }
            public dataPoint(int id, double value)
            {
                Id = id;
                Value = value;
            }
        }
    }
}
