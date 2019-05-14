using System;
using System.Collections;
using System.Collections.Generic;
using static System.Console;

namespace NewFeaure
{
    class Program
    {
        public delegate void DelegateTest();
        public delegate void RequestDelegate(HttpContext context);
        private static List<Func<RequestDelegate, RequestDelegate>> _middlewares = new List<Func<RequestDelegate, RequestDelegate>>();
        static void Main(string[] args)
        {
            //PrintStarts(new Point());
            //GetTupe();
            //NewMethod();
            HttpContext context = new HttpContext();
            Use(TestMiddleware);
            Use(FooMiddleware);
            Use(BarMiddleware);

            RequestDelegate next = _ => { _.Body.Add("Hello"); };

            foreach (var middleware in _middlewares)
            {
                next = middleware(next);
            }

            next(context);
            
            WriteLine($"Hello {context.Body}");
            WriteLine("Hello World!");
            //NewMethod1();
        }

        static RequestDelegate TestMiddleware(RequestDelegate next)
        {
            return context => 
            {
                context.Body.Add("Test");
                next(context);
            };
        }

        static RequestDelegate FooMiddleware(RequestDelegate next)
            => context =>
            {
                context.Body.Add("Foo");
                next(context);
            };

        static RequestDelegate BarMiddleware(RequestDelegate next)
            => context =>
            {
                context.Body.Add("Bar");
                next(context);
            };

        static void Use(Func<RequestDelegate, RequestDelegate> middleware)
        {
            _middlewares.Add(middleware);
        }

        private static void NewMethod1()
        {
            int x = 10;
            Out(out x);
            int y = 20;
            Ref(ref y);
            int[,] arr = { { 10, 15 }, { 20, 25 } };
            ref var num = ref GetLocalRef(arr, c => c == 20);
            num = 600;
            WriteLine(arr[1, 0]);
        }

        private static void NewMethod()
        {
            DelegateTest delegate1 = new DelegateTest(Method1);
            DelegateTest delegate2 = new DelegateTest(Method2);
            DelegateTest delegateChain = null;
            delegateChain += delegate1;
            delegateChain += delegate2;
            delegateChain();
        }

        static void PrintCoordinates(Point p)
        {
            int x, y;
            p.GetCoordinates(out x, out y);
            WriteLine($"({x}, {y})");
        }

        static void NewPrintCoordinates(Point p)
        {
            p.GetCoordinates(out var x, out var y);
            WriteLine($"({x}, {y})");
        }

        static void PrintStarts(object o)
        {
            if (o is null)
                WriteLine("o is object");
            if (!(o is int i))
                WriteLine("o is not int i");
            //Console.WriteLine(new string('*', i));
        }
        static (int, int) CreateTupe()
        {
            //var tuple = (1, 2);
            //var tuple2 = ValueTuple.Create(1, 2);
            //var tuple3 = new ValueTuple<int, int>(1, 2);

            (int one, int two) tuple = (1, 2);
            WriteLine($"first: {tuple.one}, second: {tuple.two}");

            var tuple2 = (one: 1, two: 2);
            WriteLine($"first: {tuple.one}, second: {tuple.two}");
            return tuple;
        }

        static void GetTupe()
        {
            var (one, two) = CreateTupe();
            var (first, _) = CreateTupe();
            var (name, age) = new Student("Mike", 30);
            WriteLine($"name: {name}, age: {age}");
        }

        static int GetSum(IEnumerable<object> values)
        {
            var sum = 0;
            if (values == null) return sum;
            foreach (var item in values)
            {
                if (item is short)
                {
                    sum += (short)item;
                }
                else if (item is int val)
                {
                    sum += val;
                }
                else if (item is string str && int.TryParse(str, out var result))
                {
                    sum += result;
                }
            }
            return sum;
        }

        static void IndexInitializers()
        {
            ActiveUsers users = new ActiveUsers
            {
                new Student("Mike", 12)
            };

            try
            {
                var index = new Dictionary<string, Student>()
                {
                    ["Mike"] = new Student("Mike", 30),
                    ["Jack"] = new Student("Jack", 20)
                };
            }
            catch (Exception e) when (e.Message == string.Empty)
            {

                throw;
            }
        }

        static void Out(out int x)
        {
            x = 10;
        }

        static void Ref(ref int y)
        {

        }

        static ref int GetLocalRef(int[,] arr, Func<int, bool> func)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (func(arr[i, j]))
                    {
                        return ref arr[i, j];
                    }
                }
            }
            throw new InvalidOperationException("Not Found");
        }

        static void Method1()
        {
            WriteLine("This is method 1");
        }

        static void Method2()
        {
            WriteLine("This is method 2");
        }
    }
}
