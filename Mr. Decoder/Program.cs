using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Mr.Decoder
{
    public class Program
    {
        public static string decode(string message_file)
        {
            List<string> text = File.ReadAllLines(message_file).ToList();
            Dictionary<int, string> map = new Dictionary<int, string>();
            List<int[]> pyramid = new List<int[]>();

            foreach (var pair in text)
            {
                string num_string = pair.Split(' ')[0];
                int number = Convert.ToInt32(num_string);
                map[number] = pair.Split(' ')[1];
            }


            int[] nums = new int[map.Count];
            for (int y = 0; y < nums.Length; y++)
            {
                nums[y] = map.Keys.ElementAt(y);

            }

            Array.Sort(nums);

            int count = 0; int addr = 2;
            int i = 1, j = 1, r = 1; int[] num = null;
            while (i <= map.Count)
            {
                if (j == 1)
                {
                    num = new int[r];
                    num[0] = nums[count];
                    count += 1;
                    j++;
                    r++;
                }
                else
                {
                    int jindex = 0;
                    num = new int[r];
                    r = r + 1;
                    while (j <= i)
                    {
                        num[jindex] = nums[count];
                        jindex++;
                        count += 1;
                        j++;
                    }
                }
                pyramid.Add(num);
                i += addr; addr++;
            }
            
            int[] last = new int[pyramid.Count];
            count = 0;
            foreach (var k in pyramid)
            {
             
                last[count] = k[k.Length - 1]; count++;
   
            }
            count = 0;
            string wordInLine = "";
            while (count < pyramid.Count)
            {
                
                wordInLine += map[last[count]] + " ";
                count++;
            }
            
            return wordInLine.Trim();

        }


        public static void Main(string[] args)
        {
            Console.WriteLine(decode("coding_qual_input.txt"));
            
             

            
            Console.ReadKey();

        }
    }
}
