using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.DataStructures
{
    /// <summary>
    /// Class representing the node of linked list in each bucket of hash table
    /// </summary>
    /// <typeparam name="KeyType">The data type of the key</typeparam>
    /// <typeparam name="ValueType">The data type of the value</typeparam>
    class HashNode<KeyType, ValueType>
    {
        KeyType _key;
        ValueType _value;        

        public KeyType Key { get; set; }
        public ValueType Value { get; set; }

        public HashNode(KeyType key,ValueType value)
        {
            this._key=key;
            this._value=value;            
        }
    }

    class HashTable<KeyType,ValueType>
    {
        private List<List<HashNode<KeyType, ValueType>>> _table;
        //private Double _loadFactor = 0;
        private int _tableSize = 10;
        private int _noOfElements = 0;        

        /// <summary>
        /// Default Constructor 
        /// </summary>
        HashTable()
        {
            _table = new List<List<HashNode<KeyType, ValueType>>>();
        }         

        /// <summary>
        /// Caluculate the hash vallue for a key
        /// </summary>
        /// <param name="key">Input key</param>
        /// <returns></returns>
        public int CalculateHash(KeyType key)
        {
            int hash = 0;
            hash = key.GetHashCode();

            return hash % _tableSize;
        }

        private double CalculateLoadFactor()
        {
            return _noOfElements/_tableSize;
        }

        //A method to calculate the immediate prime number after a number.
        private int nextPrime(int num)
        {
            int i = 0, j = 0;
            for (i = num + 1; ; i++)
            {
                //loop from the next number
                for (j = 2; i % j != 0; j++) ;// check if the number is divisible by any other and break then.
                if (i == j)
                {               //if the number that divides is by self then it is a prime number
                    return i;
                }
            }
        }

      /*  private void ReHash()
        {
            List<T> temp = new List<T>();
            temp.InsertRange(0, _table);
            _table.Clear();

            _tableSize = nextPrime(_tableSize * 2);
            _table = new List<T>(_tableSize);

            foreach(var item in temp)
            {
                Add(item);
            }
        }*/

        public bool Add(KeyType key, ValueType value)
        {
            /* Changed the implementation to follow chaining in each bucket , so we won't double or change the size of the hashtable
            if (CalculateLoadFactor() >= 1)
            {
                reHash();
            }*/

            //if ((EqualityComparer<KeyType>.Default.Equals(key, default(KeyType))) || (EqualityComparer<ValueType>.Default.Equals(key, default(ValueType))))
            //{
            //    return false;
            //}

            HashNode<KeyType, ValueType> temp = new HashNode<KeyType, ValueType>(key,value);

            temp.Key = key;
            temp.Value = value;

            int hashValue = CalculateHash(key);

            if (_table[hashValue] != null)
            {                
                _table[hashValue].Insert(0, temp);
            }
            else
            {
                _table[hashValue] = new List<HashNode<KeyType, ValueType>>();

                _table[hashValue].Insert(0, temp);
            }

            return true;
        }

        /// <summary>
        /// Method to remove the element from the hash table
        /// </summary>
        /// <param name="key">Key to delete</param>
        /// <returns></returns>
        public bool Remove(KeyType key)
        {
            int hashValue = CalculateHash(key);

            //if(_table[hashValue].Find(element))
            foreach (var item in _table[hashValue])
            {
                //if (IEqualityComparer<KeyType>.Equals(key))
                //{
                //    _table[hashValue].Remove(item);
                //    return true;
                //}
            }
            return false;
        }

        /// <summary>
        /// Find an element the value by key in Hash Table
        /// </summary>
        /// <param name="key">Key value in the Hash table</param>
        /// <returns></returns>
        public ValueType Find(KeyType key)
        {
            int hashValue = CalculateHash(key);

            //if(_table[hashValue].Find(element))
            foreach (var item in _table[hashValue])
            {
                //if (IEqualityComparer<KeyType>.Equals(key))
                //{
                //    //_table[hashValue].Remove(item);
                //    return item.Value;
                //}
            }

            return default(ValueType);
        }
    }
}
