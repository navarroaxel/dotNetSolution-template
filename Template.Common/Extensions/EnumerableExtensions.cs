using System;
using System.Collections.Generic;
using System.Linq;

namespace Template.Common.Extensions
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Performs the specified action on each element of the specified collection.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the collection.</typeparam>
        /// <param name="collection">The collection on whose elements the action is to be performed.</param>
        /// <param name="action">The System.Action<T> to perform on each element of array.</param>
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            if (collection == null)
                return;

            foreach (var item in collection)
            {
                action(item);
            }
        }

        /// <summary>
        /// Performs the specified action on each element of the specified collection.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the collection.</typeparam>
        /// <param name="collection">The collection on whose elements the action is to be performed.</param>
        /// <param name="action">The System.Action<T, int> to perform on each element of array.</param>
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T, int> action)
        {
            if (collection == null)
                return;

            int i = 0;
            foreach (var item in collection)
            {
                action(item, i++);
            }
        }

        /// <summary>
        /// Retorna true si la coleccion es null o no tiene elementos.
        /// </summary>
        /// <typeparam name="T">Tipo de dato de la coleccion.</typeparam>
        /// <param name="collection">Coleccion a verificar.</param>
        /// <returns>True si esta null o esta vacia la coleccion.</returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> collection)
        {
            return collection == null || !collection.Any();
        }

        public static IEnumerable<IGrouping<int, T>> ToPaged<T>(this IEnumerable<T> collection, int pageSize)
        {
            return collection.Select((item, index) => new { item, index })
                .GroupBy(x => x.index / pageSize, x => x.item);
        }
    }
}
