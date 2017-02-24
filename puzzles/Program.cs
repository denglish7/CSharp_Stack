using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public static void RandomArray(){
            int[] arr = new int[10];
            Random R = new Random();
            arr[0] = R.Next(5,25);
            int max = arr[0];
            int min = arr[0];
            Console.WriteLine(arr[0]);
            int sum = arr[0];
            for(int i = 1; i<arr.Length; i++){
                int numRest = R.Next(5,25);
                arr[i] = numRest;
                Console.WriteLine(arr[i]);
                sum += arr[i];
                if(arr[i] > max){
                    max = arr[i];
                }
                if(arr[i] < min){
                    min = arr[i];
                }
            }
            Console.WriteLine("max number is " + max);
            Console.WriteLine("min number is " + min);
            Console.WriteLine("sum is " + sum);
        }

        public static string TossCoin(Random ran){
            // Console.WriteLine("Tossing a Coin!");
            Random R = new Random();
            R = (ran == null) ? new Random() : ran;
            int flip = R.Next(0,2);
            string result = "coin";
            if(flip == 0){
                result = "Heads";
            }  
            else {
                result = "Tails";
            }
            return result;
        }

        public static Double TossMultipleCoins(int num){
            Double headCount = 0;
            Random random = new Random();
            for(int i = 1; i<=num; i++){
                string toss = TossCoin(random);
                if(toss == "Heads"){
                    headCount++;
                }
            }
            Double ratio = headCount/num;
            return ratio;
        }

        public static object Names(){
            string[] namesArray = new string[5]{"Todd", "Tiffany", "Charlie", "Geneva", "Sydney"};
            List<string> namesList = new List<string>();
                for(int i=0; i<namesArray.Length; i++){
                    string temp = namesArray[i];
                    Random R = new Random();
                    int r = R.Next(i, namesArray.Length);
                    namesArray[i] = namesArray[r];
                    namesArray[r] = temp;
                    Console.WriteLine(namesArray[i]);
                    if(namesArray[i].Length > 5){
                        namesList.Add(namesArray[i]);
                    }
                }
                for(int i=0; i<namesList.Count; i++){
                    Console.WriteLine(namesList[i]);
                }
                string[] longNames = namesList.ToArray();
                return longNames;
        }
        public static void Main(string[] args)
        {
            // RandomArray();
            // Console.WriteLine(TossCoin());
            // Console.WriteLine(TossMultipleCoins(50));
            Console.WriteLine(Names());

        }
    }
}
