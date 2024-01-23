// namespace declaration 
namespace HadimardGen { 
    
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
    }

    public class Matrices{
        public IList<Matrix>? Hadamard {get; set;} = new List<Matrix>();
        public int number_of_matrices {get; set;} = 0;
       
    }
    
    //Class to generate and display hadimard matrices
    class Generator { 
        
        //Function to find and return the hadimard matrix of size M from the JSON file
        //If the matrix is not found, it will return the last generated hadimard matrix
        public static int[,] find_matrix(int M){
            //TODO: Search JSON file for desired matrix and return in correct form
            return null;
        }

       
        public static void generate(int[,] previous_matrix, int start, int M){
            Matrices matrices = new();
            if(M == 1){
                display_matrix(previous_matrix, 2);
                return;
            }else{
                //Creates and displays each hadimard matrix up until HM
                for(int i = start; i <= M; i++){
                    Console.WriteLine("Here " + i);
                    Console.WriteLine();
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
                    matrices.number_of_matrices++;
                    //display_matrix(temp, size);
                    matrices.Hadamard.Add(new Matrix(){name = "H" + i, matrix = temp});
                    //Console.WriteLine();

                    previous_matrix = temp;

                }

            }
            //var output = JsonSerializer.Serialize(matrices);
            var jsonout= JsonConvert.SerializeObject(matrices);
            File.WriteAllText("hadimard_matrices.json", jsonout);
            //Console.WriteLine(jsonout);
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
    
    //Class to create and work with JSON file
    public class JSON{
        public static void create_JSON(){
            string fileName = "hadimard_matrices.json";
            string jsonString = File.ReadAllText(fileName);
            Matrices matrices = JsonConvert.DeserializeObject<Matrices>(jsonString);
            Console.WriteLine(matrices.number_of_matrices);

        }

    }

    class Program{
         // Main Method 
        static public void Main() { 
            int[,] base_hadamard = new int[4, 4] {{1, 1,1,1}, {1, -1,1,-1}, {1, 1,-1,-1}, {1, -1,-1,1}};

                
            Generator.generate(base_hadamard,1,14);
                
        } 
    }
} 