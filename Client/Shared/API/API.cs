using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Shared.HadamardGen;
using static System.Math;

namespace Client.Shared.API
{
    public class API
    {
        // This function generates the inital Hadamard matrices
        public void initialize()
        {
        }

        // This function will eventually return a list of integers so we can graph them
        public int[] transformPow2(int[] list)
        {
            int len = list.Length;
            int size = (int)Floor(Log(len, 2));

            var transformer = new Transform();

            return Transform.hadimard_transform(list, size);
        }
    }
}
