using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace InterfaceExtensionPractice
{
    public static class Program
    {
        static void Main(string[] args)
        {
            string line = "1,21,80,33,11,0,-5";
            char[] separatorsArr = {' ', '.', ',', ';', '?', '!'};
            string[] words = line.Split(separatorsArr, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine("{0}\n{1}\n{2}\n{3}", Sum(words), Min(words),
                Max(words), Average(words));
        }
        public static decimal Sum<T>(this IEnumerable<T> collection)
        {
            decimal sum = 0;
            try
            {
                foreach (T item in collection)
                {
                    decimal currentDecimalValue = Convert.ToInt32(item, CultureInfo.InvariantCulture);
                    sum += currentDecimalValue;
                }
            }
            catch (FormatException formEx)
            {
                throw new ArgumentException("Collection cannot be modifed with the default transformer!", formEx);
            }
            catch (InvalidCastException invEx)
            {
                throw new ArgumentException("Collection cannot be modifed with the default transformer!", invEx);
            }
            return sum;
        }

        static T Min<T>(this IEnumerable<T> elements)
        {
            T firstElement;

            T minElement;
            int minElementNumeral;

            IEnumerator<T> enumerator = elements.GetEnumerator();
            if (enumerator.MoveNext())
            {
                firstElement = enumerator.Current;
                int firstElementNumeral = Convert.ToInt32(firstElement);
                minElement = firstElement;
                minElementNumeral = firstElementNumeral;
            }
            else
            {
                throw new ArgumentNullException();
            }

            while (enumerator.MoveNext())
            {
                T currentElement = enumerator.Current;
                int currentElementNumeral = Convert.ToInt32(currentElement);
                if (currentElementNumeral < minElementNumeral)
                {
                    minElement = currentElement;
                    minElementNumeral = currentElementNumeral;
                }
            }
            return minElement;
        }
        static T Max<T>(this IEnumerable<T> elements)
        {
            T firstElement;

            T maxElement;
            int maxElementNumeral;

            IEnumerator<T> enumerator = elements.GetEnumerator();
            if (enumerator.MoveNext())
            {
                firstElement = enumerator.Current;
                int firstElementNumeral = Convert.ToInt32(firstElement);
                maxElement = firstElement;
                maxElementNumeral = firstElementNumeral;
            }
            else
            {
                throw new ArgumentNullException();
            }

            while (enumerator.MoveNext())
            {
                T currentElement = enumerator.Current;
                int currentElementNumeral = Convert.ToInt32(currentElement);
                if (currentElementNumeral > maxElementNumeral)
                {
                    maxElement = currentElement;
                    maxElementNumeral = currentElementNumeral;
                }
            }
            return maxElement;
        }

        static decimal Average<T>(this IEnumerable<T> element)
        {
            decimal sum = 0;
            decimal count = 0;
            decimal resultAverage;

            IEnumerator<T> enumerator = element.GetEnumerator();
            if (enumerator.MoveNext())
            {
                decimal firstElement = Convert.ToDecimal(enumerator.Current);
                sum += firstElement;
                count++;
            }
            else
            {
                throw new ArgumentNullException();
            }
            while (enumerator.MoveNext())
            {
                decimal currentElement = Convert.ToInt32(enumerator.Current);
                sum += currentElement;
                count++;
            }
            resultAverage = sum / count;
            return resultAverage;
        }
    }
}
