using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Client.Shared.HadamardGen;
using static System.Math;
using Client.Services;
using Android.Provider;

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
            int m = settings.GetM();
            Generator.gen_hadimards(m, path);
        }

        // This function will eventually return a list of integers so we can graph them
        public int[] transformPow2(int[] list)
        {
            int len = list.Length;
            int size = (int)Floor(Log(len, 2));

            return Transform.hadimard_transform(list, size);
        }
    }
}
