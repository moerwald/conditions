using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics;

namespace Conditions.PreConditions
{
    public static class PreCondition
    {
        public static void Requires<T>(this T obj, Func<bool> predicate, string description)
           => Requires<T>(predicate, description);

        public static void Requires<T>(Func<bool> predicate, string description)
        {
            if (predicate?.Invoke() ?? false) return;

            Debug.Assert(false, description);
            throw new PreConditionFailedException(description);
        }

        public static void RequiresAll<T>(
            this IEnumerable<T> enumerable,
            Func<T, bool> predicate,
            string description)
            => 
            Requires<T>(() => enumerable.All(predicate), description);

        public static void RequiresAny<T>(
            this IEnumerable<T> enumerable,
            Func<T, bool> predicate,
            string description)
            => 
            Requires<T>(() => enumerable.Any(predicate), description);
    }

    public static class PostCondition
    {
        private const string Dbg = "DEBUG";
        [Conditional(Dbg)]
        public static void Ensures<T>(this T obj, Func<bool> predicate, string description)
            => Ensures(predicate, description);

        [Conditional("DEBUG")]
        public static void Ensures(Func<bool> predicate, string description)
        {
            if (predicate?.Invoke() ?? false) return;

            Debug.Assert(false, description);
        }

        [Conditional("DEBUG")]
        public static void EnsuresAll<T>(this IEnumerable<T> enumerable, Func<T,bool> predicate, string description)
            => Ensures(() => enumerable.All(predicate), description);

        [Conditional("DEBUG")]
        public static void EnsuresAny<T>(this IEnumerable<T> enumerable, Func<T,bool> predicate, string description)
            => Ensures(() => enumerable.Any(predicate), description);

        [Conditional("DEBUG")]
        public static void EnsuresSingle<T>(this IEnumerable<T> enumerable, Func<T,bool> predicate, string description)
            => Ensures(() => enumerable.SingleOrDefault(predicate).Equals(default) == false , description);

    }
}
