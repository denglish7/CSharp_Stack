using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            for(int i=1; i<=255; i++){
                Console.WriteLine(i);
            }

            for(int i=1; i<=100; i++){
                if(i%5 == 0 ^ i%3 == 0){
                    Console.WriteLine(i);
                }
            }
        }
    }
}
