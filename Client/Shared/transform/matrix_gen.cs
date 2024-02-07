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
    
    //Class to generate and display hadimard matrices
    class Generator { 
        //Function to generate hadimard matrices up to HM
        public static void gen_hadimards(int M){
            int [,] previous_matrix = new int[2,2] {{1, 1},{1,-1}};

            for(int i = 1; i <= M; i++){
                var name = "H" + i;
                var temp = next_matrix(previous_matrix, i);

                var walsh = generate_walsh(temp);
                var valid_walsh = check_repeats(walsh);
                if (valid_walsh){
                    Console.WriteLine("Invalid walsh"); 
                    return;
                }

                create_json(temp, walsh, name);

                previous_matrix = temp;
            }


        }

        public static int[,] next_matrix(int[,] previous_matrix, int index){
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

        public static void create_json(int[,] hadimard, int[] walsh, string name){
            Matrix matrix = new();

            matrix.walsh = walsh;
            matrix.name = name;
            matrix.matrix = hadimard;

            var fileName = $"hadimard_{name}.json";
            Console.WriteLine(fileName);
            var jsonout= JsonConvert.SerializeObject(matrix);
            File.WriteAllText(fileName, jsonout);
            // Console.WriteLine(jsonout);
            Console.WriteLine();
            
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

    }

    class Program{
         // Main Method 
        static public void Main() { 

            Generator.gen_hadimards(14);
                
        } 
    }
} 