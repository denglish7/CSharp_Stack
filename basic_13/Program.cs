using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void printNums(){
            for(int i=1; i<256; i++){
                Console.WriteLine(i);
            }
        }
        
        public static void printOdds(){
            for( int i=1; i<256; i++){
                if(i%2 != 0){
                    Console.WriteLine(i);
                }
            }
        }

        public static void printSum(){
            int sum = 0;
            for(int i = 0; i<256; i++){ 
                Console.WriteLine(i);
                sum+=i;
                Console.WriteLine(sum);
            }
        }

        public static void iterArr(int[] Array){
            for(int i=0; i<Array.Length; i++){
                Console.WriteLine(Array[i]);
            }
        }

        public static void findMax(int[] Array){
            int max = Array[0];
            for(int i=1; i<Array.Length; i++){
                if(Array[i]>max){
                    max = Array[i];
                }
            }
            Console.WriteLine(max);
        }

        public static void getAverage(int[] Array){
            Double sum = 0;
            for(int i=0; i<Array.Length; i++){
                sum+=Array[i];
            }
            Double avg = sum/Array.Length;
            Console.WriteLine(avg);
        }

        public static void oddArr(){
            int[] y = new int[128];
            int count = 0;
            for(int i=1; i<256; i++){
                if(i%2 != 0){
                    y[count] = i; 
                    Console.WriteLine(y[count]);
                    count++;
                } 
            }
        }

        public static void greaterThan(int[] Array, int y){
            int count = 0;
            for(int i=0; i<Array.Length; i++){
                if(Array[i] > y){
                    count++;
                }
            }
            Console.WriteLine(count);
        }

        public static void squareValues(int[] Array){
            for(int i=0; i<Array.Length; i++){
                Console.WriteLine(Array[i]*Array[i]);
            }
        }

        public static void noNegatives(int[] Array){
            for(int i=0; i<Array.Length; i++){
                if(Array[i] < 0){
                    Array[i] = 0;
                }
                Console.WriteLine(Array[i]);
            }
        }

        public static void minMaxAvg(int[] Array){
            int max = Array[0];
            Double sum = 0;
            int min = Array[0];
            for(int i=0; i<Array.Length; i++){
                sum+= Array[i];
                if(Array[i] > max){
                    max = Array[i];
                }
                if(Array[i] < min){
                    min = Array[i];
                }
            }
            Console.WriteLine(max);
            Console.WriteLine(min);
            Double avg = sum/Array.Length;
            Console.WriteLine(avg);
        }

        public static void shiftArray(int[] Array){
            for(int i=1; i<Array.Length; i++){
                Array[i-1] = Array[i];
                Console.WriteLine(Array[i]);
            }
            Array[Array.Length-1] = 0;
            Console.WriteLine(Array[Array.Length-1]);
        }
        public static void numberString(object[] Array){
            for(int i=0; i<Array.Length; i++){
                if((int)Array[i] < 0){
                    Array[i] = "Dojo";
                }
                Console.WriteLine(Array[i]);
            }
        }

        public static void Main(string[] args)
        {
            // printNums();
            // printOdds();
            // printSum();
            // iterArr(new int[6]{1,3,5,7,9,13});
            // findMax(new int[3]{-3,-5,-7});
            // getAverage(new int[3]{2,10,3});
            // oddArr(new int[newLength] y, Value);
            // greaterThan(new int[4]{1,3,5,7}, 3);
            // squareValues(new int[4]{1,5,10,-2});
            // noNegatives(new int[4]{1,5,10,-2});
            // minMaxAvg(new int[4]{1,5,10,-2});
            // numberString(new object[3]{-1,-3,2});
            // shiftArray(new int[]{1,5,10,7,-2});
            // oddArr();
        }
    }
}
