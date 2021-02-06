using System.Collections;
using System.Collections.Generic;

namespace Common
{
    public class EnumerableStream<T> : IEnumerable<T>
    {
        private readonly IEnumerator<T> _enumerator;

        public EnumerableStream(IEnumerable<T> enumerable)
        {
            _enumerator = enumerable.GetEnumerator();
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            while (_enumerator.MoveNext())
            {
                yield return _enumerator.Current;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}