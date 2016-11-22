using Newtonsoft.Json.Linq;
using Robotics.Mobile.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TTT_Xamarin.Pages.Parts
{
    class AboutSections
    {
        private static List<AboutSection> _items;
        private static object _lock = new object();
        private static string sections = "[{Header: 'Getting Started',Text: 'To get started simply swipe to the right and scan for you sensortag.\nWhen you see it appear tap it and wait for the sensors to load.\nWhen the sensors are loaded their values will appear and you can tap them to view their graphs.'},{Header: 'Something wrong?',Text: 'If your sensortag is not showing up make sure the green light is blinking, and it is not already connected to another device.'},{Header: 'Warning!',Text: 'Xamarin BLE is still very buggy,so if the data seems wrong, or you get an error message. simply restart the app and try again.'  }]";
        public static List<AboutSection> getAll()
        {
            lock (_lock)
            {
                if (_items == null)
                    LoadItemsFromJson();
            }
            return _items;
        }

        public static void LoadItemsFromJson()
        {
            _items = new List<AboutSection>();
            AboutSection section;
            string itemsJson = sections;
            var json = JValue.Parse(itemsJson);
            foreach (var item in json.Children())
            {
                JObject prop = item as JObject;
                section = new AboutSection() { Header = prop.GetValue("Header").ToString(), Text = prop.GetValue("Text").ToString() };
                _items.Add(section);
            }
        }
    }
    public class AboutSection
    {
        public string Header { get; set; }
        public string Text { get; set; }
    }
}
