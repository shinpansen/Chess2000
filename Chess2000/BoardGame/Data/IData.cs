using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2000.BoardGame.Data
{
    public interface IData
    {
        public void Add(IData data);
        public Dictionary<string, object> GetData();
        public bool TryGetData<T>(string key, out T data);
    }
}
