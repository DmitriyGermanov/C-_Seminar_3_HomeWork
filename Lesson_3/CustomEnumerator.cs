using System;
using System.Collections;
using System.Collections.Generic;

namespace Lesson_3
{
    internal class CustomEnumerator : IEnumerator<int>
    {
        private List<int> _ints;
        private int _position = -1;

        public CustomEnumerator(List<int> ints)
        {
            _ints = ints;
        }

        public int Current
        {
            get
            {
                if (_position < 0 || _position >= _ints.Count)
                {
                    throw new InvalidOperationException();
                }
                return _ints[_position];
            }
        }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (_position < _ints.Count - 1)
            {
                _position++;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            _position = -1;
        }

        public void Dispose()
        {

        }
    }
}