using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace Mwd.Conditions
{
    public static class PreCondition
    {
        public static void Requires<T>(this T obj, Func<bool> predicate, string description)
           => Requires<T>(predicate, description);
        public static void RequiresNotNull<T>(this T obj, string description) where T : class
           => Requires<T>(() => obj != null, description);

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
}
