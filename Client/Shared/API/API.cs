using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Client.Shared.HadamardGen;
using static System.Math;
using Client.Services;


namespace Client.Shared.API
{
    public class API
    {

        // This function generates the inital Hadamard matrices
        public void initialize()
        {
            //string path = "C:\\Users\\fmart\\Senior_Design\\transformers\\Client";
            var settings = new SettingsService();
            string path = settings.GetPath();
            Console.WriteLine(path);
            int m = settings.GetM();
            Console.WriteLine(m);
            Generator.gen_hadimards(m, path);
        }

        // This function will eventually return a list of integers so we can graph them
        public int[] transformPow2(int[] list)
        {
            int len = list.Length;
            int size = (int)Floor(Log(len, 2));

            return Transform.hadimard_transform(list, size);
        }

        // Actually just a Walsh transform, assuming will be renamed in engine.
        public int[] forwardHadamardTransform(int[] list, bool truncate, int percent)
        {
            int len = list.Length;
            int size;
            float percentage = percent / (float)100;
            int[] tmp = new int[len];
            //creating a deep copy
            Array.Copy(list, tmp, len);

            // checking if we are truncating or not
            if (truncate)
            {
                size = (int)Floor(Log(len, 2));
            }
            else
            {
                size = (int)Ceiling(Log(len, 2));
            }
            // resizing the array to the calculated truncation
            Array.Resize(ref tmp, (int)Math.Pow(2, size));

            // actually doing transform
            int[] ret = Transform.hadimard_transform(tmp, size);

            // resizing based on percentage
            Array.Resize(ref ret, (int)(Math.Pow(2,size) * (1 - percentage)));

            return ret;
        }

        // Also Walsh as well, will be renamed
        public int[] inverseHadamardTransform(int[] list)
        {
            int len = list.Length;
            int size = (int)Floor(Log(len, 2));

            return Transform.inverse_hadimard_transform(list, size);
        }

    }
}
