using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pex7s
{
    public class MyHashSet
    {
        // a simple implementation of a hashtable, fixed in size, slightly buggy
        int[] buckets = new int[13];
        private int getInitialBucketIndex(int value)
        {
            return (value ^ 101010101) % buckets.Length;
        }
        public void Add(int value)
        {
            if (value == 0) throw new ArgumentException("'0' not allowed");
            var index = getInitialBucketIndex(value);
            // this loop deals with collisions
            while (buckets[index] != value && buckets[index] != 0)
            {
                index = (index + 1) % buckets.Length;
                Console.WriteLine("[DEBUG INFO] collision in Add at index {0}", index);
            }
            buckets[index] = value;
        }
        public bool Contains(int value)
        {
            if (value == 0) throw new ArgumentException("'0' not allowed");
            var index = getInitialBucketIndex(value);
            while (buckets[index] != value && buckets[index] != 0)
                index = (index + 1) % buckets.Length;
            return buckets[index] == value;
        }
    }
}
