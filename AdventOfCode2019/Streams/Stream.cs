using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.Streams
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /*
        A Stream is an infinite sequence of items. It is defined recursively
        as a head item followed by the tail, which is another stream.
        Consequently, the tail has to be wrapped with Lazy to prevent
        evaluation.
    */
    public class Stream<T>
    {
        public readonly T Head;
        public readonly Lazy<Stream<T>> Tail;

        public Stream(T head, Lazy<Stream<T>> tail)
        {
            Head = head;
            Tail = tail;
        }
    }

    public static class Stream
    {
        public static Stream<T> Cons<T>(T h, Func<Stream<T>> t)
        {
            return new Stream<T>(h, new Lazy<Stream<T>>(t));
        }

        // .------------------------------.
        // | Static constructor functions |
        // '------------------------------'

        // Construct a stream by repeating a value.
        public static Stream<T> Repeat<T>(T x)
        {
            return Cons(x, () => Repeat(x));
        }

        // Construct a stream by repeatedly applying a function.
        public static Stream<T> Iterate<T>(Func<T, T> f, T x)
        {
            return Cons(x, () => Iterate(f, f(x)));
        }

        private static Stream<T> Cycle<T>(IEnumerable<T> a, int start)
        {
            return Cons(a.ToArray()[start], () => start == (a.Count() - 1) ? Cycle(a, 0) : Cycle(a, start + 1));
        }

        // Construct a stream by repeating an enumeration forever.
        public static Stream<T> Cycle<T>(IEnumerable<T> a)
        {
            return Cycle(a, 0);
        }

        // Construct a stream by counting numbers starting from a given one.
        public static Stream<int> From(int x)
        {
            return Cons(x, () => From(x + 1));
        }

        // Same as From but count with a given step width.
        public static Stream<int> FromThen(int x, int d)
        {
            return Cons(x, () => FromThen(x + d, d));
        }

        // .------------------------------------------.
        // | Stream reduction and modification (pure) |
        // '------------------------------------------'

        /*
            Being applied to a stream (x1, x2, x3, ...), Foldr shall return
            f(x1, f(x2, f(x3, ...))). Foldr is a right-associative fold.
            Thus applications of f are nested to the right.
        */
        public static U Foldr<T, U>(this Stream<T> s, Func<T, Func<U>, U> f)
        {
            return f(s.Head, () => Foldr(s.Tail.Value, f));
        }

        // Filter stream with a predicate function.
        public static Stream<T> Filter<T>(this Stream<T> s, Predicate<T> p)
        {
            if (p(s.Head)) return Cons(s.Head, () => Filter(s.Tail.Value, p));
            return Filter(s.Tail.Value, p);
        }

        // Returns a given amount of elements from the stream.
        public static IEnumerable<T> Take<T>(this Stream<T> s, int n)
        {
            if (n > 0)
            {
                yield return s.Head;
                foreach (var i in s.Tail.Value.Take(n - 1)) yield return i;
            }
        }

        // Drop a given amount of elements from the stream.
        public static Stream<T> Drop<T>(this Stream<T> s, int n)
        {
            while (n > 0)
            {
                s = s.Tail.Value;
                n--;
            }
            return s;
        }

        // Combine 2 streams with a function.
        public static Stream<R> ZipWith<T, U, R>(this Stream<T> s, Func<T, U, R> f, Stream<U> other)
        {
            return Cons(f(s.Head, other.Head), () => ZipWith(s.Tail.Value, f, other.Tail.Value));
        }

        // Map every value of the stream with a function, returning a new stream.
        public static Stream<U> FMap<T, U>(this Stream<T> s, Func<T, U> f)
        {
            return Cons(f(s.Head), () => FMap(s.Tail.Value, f));
        }

        private static Stream<int> Fib(int a, int b)
        {
            return Cons(a, () => Fib(b, a + b));
        }

        // Return the stream of all fibonacci numbers.
        public static Stream<int> Fib()
        {
            return Cons(0, () => Fib(1, 1));
        }

        private static BitArray IsPrime = ESieve(1000000);

        private static int FindNextPrime(int number)
        {
            number++;
            for (; number < IsPrime.Length; number++)
                //found a prime return that number
                if (IsPrime[number])
                    return number;
            //no prime return error code
            return -1;
        }

        private static BitArray ESieve(int upperLimit)
        {
            int sieveBound = (upperLimit - 1);
            int upperSqrt = (int)Math.Sqrt(sieveBound);
            BitArray PrimeBits = new BitArray(sieveBound + 1, true);
            PrimeBits[0] = false;
            PrimeBits[1] = false;
            for (int j = 4; j <= sieveBound; j += 2)
            {
                PrimeBits[j] = false;
            }
            for (int i = 3; i <= upperSqrt; i += 2)
            {
                if (PrimeBits[i])
                {
                    int inc = i * 2;
                    for (int j = i * i; j <= sieveBound; j += inc)
                    {
                        PrimeBits[j] = false;
                    }
                }
            }
            return PrimeBits;
        }

        private static Stream<int> Primes(int from)
        {
            int nextPrime = FindNextPrime(from);
            return Cons(nextPrime, () => Primes(nextPrime));
        }

        // Return the stream of all prime numbers.
        public static Stream<int> Primes()
        {
            return Cons(2, () => Primes(2));
        }
    }
}
