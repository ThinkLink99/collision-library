using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CarKrash.Collision.Utils
{
    public class Database<T> : IList<T>
    {
        public T this[int index]
        {
            get { return Db[index]; }
            set { Db[index] = value; }
        }

        private List<T> Db;

        public int Count => ((ICollection<T>)Db).Count;
        public bool IsReadOnly => ((ICollection<T>)Db).IsReadOnly;

        public Database()
        {
            Db = new List<T>();
        }

        public void Add(T add)
        {
            Db.Add(add);
        }
        public void Remove(T remove)
        {
            Db.Remove(remove);
        }

        public void LoadJson(string location)
        {
            using (StreamReader reader = new StreamReader(location))
            {
                var json = reader.ReadToEnd().Replace("\n", "");
                JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                Db.AddRange(JsonConvert.DeserializeObject<List<T>>(json, settings));
                reader.Close();
            }
        }

        public T Find(T matchRecord)
        {
            return Db.Where(d => d.Equals(matchRecord)).FirstOrDefault();
        }
        public T Find(Func<T, bool> predicate)
        {
            return Db.Where(predicate).FirstOrDefault();
        }

        public int IndexOf(T item)
        {
            return ((IList<T>)Db).IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            ((IList<T>)Db).Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            ((IList<T>)Db).RemoveAt(index);
        }

        public void Clear()
        {
            ((ICollection<T>)Db).Clear();
        }

        public bool Contains(T item)
        {
            return ((ICollection<T>)Db).Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            ((ICollection<T>)Db).CopyTo(array, arrayIndex);
        }

        bool ICollection<T>.Remove(T item)
        {
            return ((ICollection<T>)Db).Remove(item);
        }
        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)Db).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Db).GetEnumerator();
        }
    }
}
