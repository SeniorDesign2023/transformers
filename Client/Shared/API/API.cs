using System.Text.Json;
using Client.Models;
using Client.Shared.HadamardGen;
using static System.Math;
using Client.Services;


namespace Client.Shared.API
{
    public class API
    {

        // This function generates the inital Hadamard matrices
        public void Initialize()
        {
            var settings = new SettingsService();
            string path = settings.GetPath();
            int m = settings.GetM();
            Generator.genHadamards(m, path);
        }

        // This function will eventually return a list of integers so we can graph them
        public int[] TransformPow2(int[] list)
        {
            int len = list.Length;
            int size = (int)Floor(Log(len, 2));

            return Transform.hadamardTransform(list, size);
        }

        // Taking an int list as an arguement to hadamard transform
        public int[] ForwardHadamardTransform(int[] list, bool truncate, int percent)
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
            int[] ret = Transform.hadamardTransform(tmp, size);

            // resizing based on percentage
            Array.Resize(ref ret, (int)(Math.Pow(2,size) * (1 - percentage)));

            return ret;
        }

        // Taking a JSON path as an arguement to hadamard transform

        public int[] ForwardHadamardTransform(string path, bool truncate, int percent)
        {
            int[] list = DeserializeFromPath(path);
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
            int[] ret = Transform.hadamardTransform(tmp, size);

            // resizing based on percentage
            Array.Resize(ref ret, (int)(Math.Pow(2,size) * (1 - percentage)));

            return ret;
        }

        public int[] InverseHadamardTransform(int[] list)
        {
            int len = list.Length;
            int size = (int)Floor(Log(len, 2));

            return Transform.inverseHadamardTransform(list, size);
        }

        // Deserializing JSON files to get an int list
        public int[] DeserializeFromPath(string path)
        {
            // Reading the text for the path
            string json = File.ReadAllText(path);

            var data = new Data {};

            data = JsonSerializer.Deserialize<Data>(json);

            return data.Elements;
        }

    }
}
