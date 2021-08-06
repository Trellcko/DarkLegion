using System;
using System.Collections.Generic;

namespace DarkLegion.Core.Pooling
{
    public class Pool<T>
    {
        public Action<T> Added = delegate { };
        public Action<T> Got = delegate { };

        private readonly Queue<T> _queue = new Queue<T>();

        private readonly Func<T> _create;

        public Pool(Func<T> create)
        {
            _create = create;
        }

        public void Add(T poolObject)
        {
            Added.Invoke(poolObject);
            _queue.Enqueue(poolObject);
        }

        public T Get()
        {
            T poolObject = default;
            if (_queue.Count == 0)
            {
                poolObject = _create();
            }
            else
            {
                poolObject = _queue.Dequeue();
            }
            Got(poolObject);
            return poolObject;
        }
    }
}