using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTT_UWP.Extensions
{
    public static class ListExtensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> collection)
        {
            var c = new ObservableCollection<T>();
            foreach (var e in collection)
                c.Add(e);
            return c;
        }
    }
}
