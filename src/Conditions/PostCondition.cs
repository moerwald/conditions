using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace Mwd.Conditions
{
    public static class PostCondition
    {
        private const string Dbg = "DEBUG";
        [Conditional(Dbg)]
        public static void Ensures<T>(this T obj, Func<bool> predicate, string description)
            => Ensures(predicate, description);

        [Conditional(Dbg)]
        public static void Ensures(Func<bool> predicate, string description)
        {
            if (predicate?.Invoke() ?? false) return;

            Debug.Assert(false, description);
        }

        [Conditional(Dbg)]
        public static void EnsuresAll<T>(this IEnumerable<T> enumerable, Func<T,bool> predicate, string description)
            => Ensures(() => enumerable.All(predicate), description);

        [Conditional(Dbg)]
        public static void EnsuresAny<T>(this IEnumerable<T> enumerable, Func<T,bool> predicate, string description)
            => Ensures(() => enumerable.Any(predicate), description);

        [Conditional(Dbg)]
        public static void EnsuresSingle<T>(this IEnumerable<T> enumerable, Func<T,bool> predicate, string description)
            => Ensures(() => enumerable.SingleOrDefault(predicate).Equals(default) == false , description);

    }
}
