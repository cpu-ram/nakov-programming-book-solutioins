using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Hashtables
{
    public class HashDictionary<K, V> : IDictionary<K, V>, IEnumerable<KeyValuePair<K, V>>
    {
        private const int INITIAL_CAPACITY = 16;
        private const float DEFAULT_LOAD_FACTOR = 0.75f;
        private KeyValuePair<K, V>?[] table;
        private int count;
        private int capacity;
        private int[] hashKeys;
        private float loadFactor;
        private int threshold;

        public HashDictionary()
        {
            this.count = 0;
            this.capacity = INITIAL_CAPACITY;
            this.loadFactor = DEFAULT_LOAD_FACTOR;
            this.threshold = (int)(capacity * loadFactor);
            this.table = new KeyValuePair<K,V>?[capacity];
        }

        public V this[K key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ICollection<K> Keys => throw new NotImplementedException();

        public ICollection<V> Values => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(K key, V value)
        {
            AddElement(key, value);
        }

        public void Add(KeyValuePair<K, V> item)
        {
            this.Add(item.Key, item.Value);
        }
        public int[] GetHashCodes<T>(T key)
        {
            int keyHashCode = key.GetHashCode();
            int positionOne = keyHashCode % this.capacity;
            int positionTwo = ((keyHashCode * 83) + 7) % capacity;
            int positionThree = ((keyHashCode * keyHashCode) + 19) % capacity;
            int[] resultCodes = { positionOne, positionTwo, positionThree };
            return resultCodes;
        }
        internal void AddElement(K key, V value,
            int? previousPosition = null, HashSet<int> entryStreak = null)
        {
            HashSet<int> currentStreak = entryStreak;
            if (currentStreak == null)
            {
                currentStreak = new HashSet<int>();
            }

            KeyValuePair<K, V> entryElementPair = new KeyValuePair<K, V>(key, value);
            int[] hashCodes = GetHashCodes(key);
            int lastPossiblePosition = 0;
            HashSet<int> resultStreakSet = new HashSet<int>(currentStreak);
            bool positionFound = false; //non-functional, semantic
            for (int i = 0; i < hashCodes.Length; i++)
            {
                int currentHashCode = hashCodes[i];
                if (previousPosition != null)
                {
                    if (currentHashCode == previousPosition)
                    {
                        continue;
                    }
                }
                if (table[currentHashCode] == null)
                {
                    table[currentHashCode] = entryElementPair;
                    return;
                }
                lastPossiblePosition = currentHashCode;
            }

            if (!positionFound)
            {
                if (!currentStreak.Contains(lastPossiblePosition))
                {
                    KeyValuePair<K, V> pushedOutKeyValuePair = table[lastPossiblePosition].Value;
                    table[lastPossiblePosition] = entryElementPair;
                    resultStreakSet.Add(lastPossiblePosition);
                    AddElement(key, value, lastPossiblePosition, resultStreakSet);
                }
                else
                {
                        this.Expand();
                    AddElement(key, value);
                }
            }
        }
        private void Expand()
        {
            KeyValuePair<K, V>?[] oldTable = this.table;
            this.capacity = this.capacity * 2;
            this.table = new KeyValuePair<K, V>?[capacity];

            foreach (KeyValuePair<K, V> keyValuePair in oldTable)
            {
                this.Add(keyValuePair);
            }
        }


        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<K, V> item)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(K key)
        {
            int[] hashCodes = GetHashCodes(key);
            foreach (int hashCode in hashCodes)
            {
                if (table[hashCode].Value.Key.Equals(key))
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(KeyValuePair<K, V>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < capacity; i++)
            {
                if (table[i] != null)
                {
                    yield return table[i].Value;
                }
            }
        }

        public bool Remove(K key)
        {
            if (this.ContainsKey(key))
            {
                int[] hashCodes = this.GetHashCodes(key);
                foreach (int hashCode in hashCodes)
                {
                    if (table[hashCode].Value.Equals(key))
                    {
                        table[hashCode] = null;
                        return true;
                    }
                }
                throw new Exception();
            }
            else return false;
        }
        public bool Remove(KeyValuePair<K, V> item)
        {
            throw new NotImplementedException();
        }
        public bool TryGetValue(K key, [MaybeNullWhen(false)] out V value)
        {
            throw new NotImplementedException();
        }



        IEnumerator<KeyValuePair<K, V>> IEnumerable<KeyValuePair<K, V>>.GetEnumerator()
        {
            return null;
        }
    }
}
