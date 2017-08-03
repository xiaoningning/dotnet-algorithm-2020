namespace helloworld
{
    using System;
    class helloworld
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! .Net Core");
            Console.WriteLine("Yep!");

            if (args.Length >= 1)
            {
                Console.WriteLine("args : " + args[0]);
            }

            Help();
        }

        static void Help()
        {
            Console.WriteLine("print help");
        }
    }
}
