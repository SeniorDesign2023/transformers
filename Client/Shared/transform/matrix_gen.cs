// namespace declaration 
namespace Client.Shared.HadamardGen { 
    
    // Class declaration 
    using Newtonsoft.Json;

    public class Options{
        public string? alter_data{
            get;
            set;
        }
    }

    public class Matrix{
         public string? name{
            get;    
            set;
        }

        public int[,]? matrix{
            get;
            set;
        }

        public int[]? walsh{
            get;
            set;
        }
    }
    
    //Class to generate and display hadamard matrices
    class Generator { 
        
        //Function to generate hadamard matrices up to HM
        //M is the number of matricies to generate
        public static void genHadmards(int M, string json_path){
            int [,] previous_matrix = new int[2,2] {{1, 1},{1,-1}};

            for(int i = 1; i <= M; i++){
                var name = "H" + i;
                var temp = kroneckerProduct(previous_matrix, i);

                var walsh = generateWalsh(temp);
                var valid_walsh = checkRepeats(walsh);
                if (valid_walsh){
                    Console.WriteLine("Invalid walsh"); 
                    return;
                }

                createJson(temp, walsh, name, json_path);

                previous_matrix = temp;
            }


        }

        public static int[,] kroneckerProduct(int[,] previous_matrix, int index){
            int size = (int)Math.Pow(2, index);
            int[,] temp = new int[size, size];

            //Fills the top left quadrant of the matrix with the previous matrix
            for(int j = 0; j < size/2; j++){
                for(int k = 0; k < size/2; k++){
                    temp[j,k] = previous_matrix[j,k];
                }
            }

            //Fills the top right quadrant of the matrix with the previous matrix
            for(int j = 0; j < size/2; j++){
                for(int k = size/2; k < size; k++){
                    temp[j,k] = previous_matrix[j,k - size/2];
                }
            }

            //Fills the bottom left quadrant of the matrix with the previous matrix
            for(int j = size/2; j < size; j++){
                for(int k = 0; k < size/2; k++){
                    temp[j,k] = previous_matrix[j - size/2,k];
                }
            }

            //Fills the bottom right quadrant of the matrix with the inverse of the previous matrix
            for(int j = size/2; j < size; j++){
                for(int k = size/2; k < size; k++){
                    temp[j,k] = -1 * previous_matrix[j - size/2,k - size/2];
                }
            }

            return temp;
        }

        //Function to add a hadamard matrix and its walsh array to a json file
        public static void createJson(int[,] hadamard, int[] walsh, string name, string json_path){
            Matrix matrix = new();

            matrix.walsh = walsh;
            matrix.name = name;
            matrix.matrix = hadamard;

            var fileName = $"{json_path}/hadamard_{name}.json";
            Console.WriteLine(fileName);
            var jsonout = JsonConvert.SerializeObject(matrix);
            File.WriteAllText(fileName, jsonout);
            Console.WriteLine();
            
        }
        
        //Function that generates an array that correlates the number of flips in each hadamard row
        public static int[] generateWalsh(int[,] matrix){
            int[] walsh = new int[matrix.GetLength(0)];
            for(int i = 0; i < matrix.GetLength(0); i++){
                int flips = 0;
                var prev = 0;
                for(int j = 0; j < matrix.GetLength(1); j++){
                    if(j == 0){
                        prev = matrix[i,0];
                    }else{
                        prev = matrix[i,j-1];
                    }

                    if(matrix[i,j] != prev){
                        flips++;
                    }
                }

                walsh[i] = flips;
            }

            return walsh;
            
        }

        //Function to check for repeated numbers in an array
        public static bool checkRepeats(int[] array){
            for(int i = 0; i < array.Length; i++){
                for(int j = i + 1; j < array.Length; j++){
                    if(array[i] == array[j]){
                        return true;
                    }
                }
            }

            return false;
        }

    }

    public class Transform{

        public static int[] hadamardTransform(int[] input, int size){
            Matrix hadamard = new();
            int[] output = new int[input.Length];

            var name = "H" + size;
            hadamard = getHadamard(name);
            var matrix = hadamard.matrix;
            var walsh = hadamard.walsh;
        
            for(int i = 0; i < input.Length; i++){
                int sum = 0;
                for(int j = 0; j < input.Length; j++){

                    sum += input[j] * matrix[i,j];
                }
                // output[walsh[i]] = sum;
                output[i] = sum;
            }
            
            return output;
        }

        public static int[] inverseHadamardTransform(int[] input, int size){
            Matrix hadamard = new();
            int[] output = new int[input.Length];
            var N = Math.Pow(2, size);

            var name = "H" + size;
            hadamard = getHadamard(name);
            var matrix = hadamard.matrix;
            var walsh = hadamard.walsh;

            for(int i = 0; i < input.Length; i++){
                int sum = 0;
                for(int j = 0; j < input.Length; j++){
                    sum += input[j] * matrix[j,i];
                }
                
                // output[walsh[i]] = (int)(sum/N);
                output[i] = (int)(sum/N);
            }
            
            return output;
        }


        public static int[] walshTransform(int[] input, int size){
            Matrix hadamard = new();
            int[] output = new int[input.Length];

            var name = "H" + size;
            hadamard = getHadamard(name);
            var matrix = hadamard.matrix;
            var walsh = hadamard.walsh;
        
            for(int i = 0; i < input.Length; i++){
                int sum = 0;
                for(int j = 0; j < input.Length; j++){

                    sum += input[j] * matrix[i,j];
                }
                output[walsh[i]] = sum;
            }
            
            return output;
        }

        public static int[] inverseWalshTransform(int[] input, int size){
            Matrix hadamard = new();
            int[] output = new int[input.Length];
            var N = Math.Pow(2, size);

            var name = "H" + size;
            hadamard = getHadamard(name);
            var matrix = hadamard.matrix;
            var walsh = hadamard.walsh;

            for(int i = 0; i < input.Length; i++){
                int sum = 0;
                for(int j = 0; j < input.Length; j++){
                    sum += input[j] * matrix[j,i];
                }
                
                // output[walsh[i]] = (int)(sum/N);
                output[walsh[i]] = (int)(sum/N);
            }
            
            return output;
        }

        public static Matrix getHadamard(string name){
            Matrix matrix = new();
            var fileName = $"./hadamard_{name}.json";
            var json = File.ReadAllText(fileName);
            matrix = JsonConvert.DeserializeObject<Matrix>(json);
            return matrix;
        }
    }

    class Program{
         // Main Method
        // static public void Main() { 

        //     Generator.gen_hadamards(5, "./");

        //     var size = 4;
        //     var transform = Transform.hadamard_transform(new int[] {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16}, size);
        //     var inverse = Transform.inverse_hadamard_transform(transform, size);

        //     Console.WriteLine("Transform:\n");

        //     for(int i = 0; i < transform.Length; i++){
        //         Console.WriteLine(transform[i]);
        //     }
        //     Console.WriteLine();
        //     Console.WriteLine("Inverse:\n");
        //     for(int i = 0; i < inverse.Length; i++){
        //         Console.WriteLine(inverse[i]);
        //     }
        //     // Console.WriteLine(output);
        // }
    }
} 