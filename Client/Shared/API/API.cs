using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Client.Shared.HadamardGen;
using static System.Math;

namespace Client.Shared.API
{
    public class API
    {

        // This function generates the inital Hadamard matrices
        public void initialize()
        {
            //string path = "C:\\Users\\fmart\\Senior_Design\\transformers\\Client";
            string path = "";
            int m = 0;
            Generator.gen_hadimards(m, path);
        }

        // This function will eventually return a list of integers so we can graph them
        public int[] transformPow2(int[] list)
        {
            int len = list.Length;
            int size = (int)Floor(Log(len, 2));

            return Transform.hadimard_transform(list, size);
        }

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
            Array.Resize(ref tmp, size);

            // actually doing transform
            int[] ret = Transform.hadimard_transform(tmp, size);

            // resizing based on percentage
            Array.Resize(ref ret, (int)(size * (1 - percentage)));

            return ret;
        }

        public int[] inverseHadamardTransform(int[] list)
        {
            int len = list.Length;
            int size = (int)Floor(Log(len, 2));

            return Transform.inverse_hadimard_transform(list, size);
        }
    }
}
