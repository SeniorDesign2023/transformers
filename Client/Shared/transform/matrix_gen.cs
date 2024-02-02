// namespace declaration 
namespace HadimardGen {
    using System.CodeDom.Compiler;

    // Class declaration 
    using Newtonsoft.Json;

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

    // public class Matrices{
    //     public IList<Matrix>? Hadamard {get; set;} = new List<Matrix>();
    //     public int number_of_matrices {get; set;} = 0;
       
    // }
    
    //Class to generate and display hadimard matrices
    class Generator { 
        //Function to generate hadimard matrices up to HM
        public static void generate_hadimard(int[,] previous_matrix, int start, int M){
            Matrix matrix = new();

            if(M == 1){
                var walsh = generate_walsh(previous_matrix);
                var valid_walsh = check_repeats(walsh);
                if (valid_walsh){
                    Console.WriteLine("Invalid walsh"); 
                    return;
                }
                matrix.walsh = walsh;
                matrix.name = "H" + 1;
                matrix.matrix = previous_matrix;
                var fileName = $"hadimard_{1}.json";
                Console.WriteLine(fileName);
                var jsonout= JsonConvert.SerializeObject(matrix);
                File.WriteAllText(fileName, jsonout);
                Console.WriteLine(jsonout);
                Console.WriteLine();

                return;
            }else{
                //Creates and displays each hadimard matrix up until HM
                for(int i = start; i <= M; i++){
                    int size = (int)Math.Pow(2, i);
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

                    var walsh = new int[size];
                    walsh = generate_walsh(temp);
                    var valid_walsh = check_repeats(walsh);
                    if (valid_walsh){
                        Console.WriteLine("Invalid walsh"); 
                        return;
                    }
                    //Writes Matrix to a JSON file
                    matrix.walsh = walsh;
                    matrix.name = "H" + i;
                    matrix.matrix = temp;
                    var fileName = $"hadimard_{i}.json";
                    Console.WriteLine(fileName);
                    var jsonout= JsonConvert.SerializeObject(matrix);
                    File.WriteAllText(fileName, jsonout);
                    Console.WriteLine(jsonout);
                    Console.WriteLine();

                    previous_matrix = temp;

                }

            }
        }

        public static int[] generate_walsh(int[,] matrix){
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
        public static bool check_repeats(int[] array){
            for(int i = 0; i < array.Length; i++){
                for(int j = i + 1; j < array.Length; j++){
                    if(array[i] == array[j]){
                        return true;
                    }
                }
            }

            return false;
        }

        public static void display_matrix(int[,] matrix, int size){
            // Displaying the final hadamard matrix
                for (int k = 0; k < size; k++) {
                    for (int j = 0; j < size; j++) {
                        Console.Write(matrix[k,j] + " ");
                    }
                    Console.WriteLine();
                }
        }

    }

    class Program{
         // Main Method 
        static public void Main() { 
            int[,] base_hadamard = new int[2,2] {{1, 1},{1,-1}};

                
            Generator.generate_hadimard(base_hadamard,1,5);
                
        } 
    }
} 