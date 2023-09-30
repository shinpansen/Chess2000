using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2000.BoardGame.Data
{
    public class Data : IData
    {
        protected Dictionary<string, object> DataValues { get; set; }

        public Data()
        {
            DataValues = new();
        }

        public Data(IData data) : this()
        {
            Add(data);
        }

        public Data(string key, object value) : this()
        {
            DataValues.Add(key, value);
        }

        public void Add(IData data)
        {
            foreach (var item in data?.GetData())
                DataValues.Add(item.Key, item.Value);
        }

        public Dictionary<string, object> GetData()
        {
            return new Dictionary<string, object>(DataValues);
        }

        public bool TryGetData<T>(string key, out T data)
        {
            data = default;
            if (DataValues.TryGetValue(key, out var value))
            {
                try { data = (T)value; } 
                catch { return false; }
                return true;
            }
            return false;
        }
    }
}
