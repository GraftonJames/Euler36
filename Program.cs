// See https://aka.ms/new-console-template for more information

using System;

namespace euler_thirtysix {
    class Program {
        static void Main()
        {
            List<int> decPalindrones = GenDecimalPalindrones(1000000);
            int sum = 0;
            foreach( int pal in decPalindrones) {
                
                if(isPalindrone(ConvertToBinary(pal)))
                {
                    sum += pal;
                    Console.WriteLine(pal);
                    Console.WriteLine(ConvertToBinary(pal));
                }
            }
            Console.WriteLine("Sum: "+ sum);
        }
        static bool isPalindrone(string number)
        {
            for (int i = 0; i < Math.Floor(((double)number.Length) / 2); i++)
            {
                if (number[i] != number[number.Length -1-i]){
                    return false;
                }
            }
            return true;
        }
        static string ConvertToBinary (int num)
        {
            List<char> binBuilder = new List<char>();
            while (num != 0){
                int newDigit = num % 2;
                char charDigit = Convert.ToChar(newDigit + 48);
                binBuilder.Add(charDigit);
                num = (num - newDigit) / 2;
            }
            binBuilder.Reverse();
            string bin = new string(binBuilder.ToArray());
            return bin;
        } 
        static List<int> GenDecimalPalindrones(int max)
        {
            List<int> output = new List<int>();
            output.AddRange(new List<int>() {1,2,3,4,5,6,7,8,9});
            Double maxDigits = Convert.ToString(max).Length;
            int iterations = Convert.ToInt32(Math.Pow((double)10,Math.Floor(maxDigits/2)));
            for (int i = 1; i < iterations; i++)
            {
                string stringInt = Convert.ToString(i);
                string mirrorInt = new string(stringInt.ToCharArray().Reverse().ToArray());
                int number = Convert.ToInt32(stringInt + mirrorInt);
                if (number <= max)
                {
                    output.Add(Convert.ToInt32(stringInt + mirrorInt));
                }
                for (int j = 0; j < 10; j++)
                {
                    string jAsString = Convert.ToString(j);
                    number = Convert.ToInt32(stringInt + jAsString + mirrorInt);
                    if (number <= max) 
                    {
                        output.Add(number);
                    }
                }
            }
            return output;
        }
    }
}