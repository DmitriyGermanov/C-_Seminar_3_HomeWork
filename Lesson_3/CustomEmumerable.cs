/*
 * Реализуйте класс с поддержкой IEnumerable<int> - CustomEnumerale 
который в случае использования его в следующем коде
*/
using System.Collections;

namespace Lesson_3
{
    internal class CustomEmumerable : IEnumerable<int>
    {
        private List<int> ints = [6, 2, 3, 4, 5, 6, 7, 8, 9, 10];

        public IEnumerator<int> GetEnumerator() => new CustomEnumerator(ints);

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

