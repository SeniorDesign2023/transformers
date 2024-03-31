using System.Text.Json;
using Client.Models;
using Client.Shared.HadamardGen;
using static System.Math;
using Client.Services;


namespace Client.Shared.API
{
    public class API
    {

        // This function generates the initial Hadamard matrices
        public void Initialize()
        {
            var settings = new SettingsService();
            string path = settings.GetPath();
            int m = settings.GetM();
            Generator.GenHadamards(m, path);
        }

        // This function will eventually return a list of integers so we can graph them
        public double[] TransformPow2(double[] list)
        {
            int len = list.Length;
            int size = (int)Floor(Log(len, 2));

            return Transform.HadamardTransform(list, size);
        }

        // Taking an int list as an arguement to hadamard transform
        public double[] ForwardHadamardTransform(double[] list, bool truncate, int percent)
        {
            int len = list.Length;
            int size;
            float percentage = percent / (float)100;
            double[] tmp = new double[len];
            //creating a deep copy
            Array.Copy(list, tmp, len);

            // checking if we are truncating or not
            if(len == 1)
            {
                size = 1;
            }
            else if (truncate)
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
            double[] ret = Transform.WalshTransform(tmp, size);

            // resizing based on percentage
            Array.Resize(ref ret, (int)(Math.Pow(2,size) * (1 - percentage)));

            return ret;
        }

        // Taking a JSON path as an arguement to hadamard transform

        public double[] ForwardHadamardTransform(string path, bool truncate, int percent)
        {
            double[] list = DeserializeFromPath(path);
            int len = list.Length;
            int size;
            float percentage = percent / (float)100;
            double[] tmp = new double[len];
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
            double[] ret = Transform.WalshTransform(tmp, size);

            // resizing based on percentage
            Array.Resize(ref ret, (int)(Math.Pow(2,size) * (1 - percentage)));

            return ret;
        }

        public double[] InverseHadamardTransform(double[] list)
        {
            int len = list.Length;
            int size = (int)Floor(Log(len, 2));

            return Transform.InverseWalshTransform(list, size);
        }

        // Deserializing JSON files to get an int list
        public double[] DeserializeFromPath(string path)
        {
            // Reading the text for the path
            string json = File.ReadAllText(path);

            var data = new Data {};

            data = JsonSerializer.Deserialize<Data>(json);

            return data.Elements;
        }

        public double[] Filter(double[] list, int percent){
            int len = list.Length;
            float percentage = percent / (float)100;
            int num = (int)(len * percentage);
            for(int i = len-num; i<len; i++){
                list[i] = 0;
            }
            return list;
        }

    }
}
