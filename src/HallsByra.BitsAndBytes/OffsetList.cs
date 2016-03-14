using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HallsByra.BitsAndBytes
{
    // The OffsetList acts as a facade over an existing list, offseting all request by a constant specified in the constructor.
    //
    // Example:
    // 
    // l = new List<char>
    // ol = new OffsetList(l, 2)
    //
    // l-Index  0 1 2 3 4
    // l-Item   A B C D E
    //            ^ ^ ^
    // ol-Index   0 1 2
    // 
    class OffsetList<T> : IList<T>
    {
        private readonly int offset;
        private readonly IList<T> backingList;

        public OffsetList(IList<T> backingList, int offset)
        {
            if (backingList.Count < offset)
            {
                throw new NotSupportedException("The offset is larger than the capacity of the list.");
            }
            this.backingList = backingList;
            this.offset = offset;
        }

        public int IndexOf(T item)
        {
            for (int index = offset; index <= Count; index++)
                if (this[index].Equals(item))
                    return index - offset;
            return -1;            
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException("Insert/remove is not supported.");
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException("Insert/remove is not supported.");
        }

        public T this[int index]
        {
            get
            {
                return backingList[index + offset];
            }
            set
            {
                backingList[index + offset] = value;
            }
        }

        public void Add(T item)
        {
            throw new NotImplementedException("Insert/remove is not supported.");
        }

        public void Clear()
        {
            throw new NotImplementedException("Insert/remove is not supported.");            
        }

        public bool Contains(T item)
        {
            return ((IEnumerable<T>)this).Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            backingList.CopyTo(array, arrayIndex + offset);
        }

        public int Count
        {
            get { return backingList.Count - offset; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException("Insert/remove is not supported.");
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int index = 0; index < Count; index++)
            {
                yield return this[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
