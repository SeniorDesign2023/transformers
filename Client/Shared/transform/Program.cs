using System; 
// namespace declaration 
namespace HadimardGen { 
    // Class declaration 
    class Generator { 
        
       
        public static void generate(int M){

            int[,] base_hadamard = new int[2, 2];
            base_hadamard[0, 0] = 1;
            base_hadamard[0, 1] = 1;
            base_hadamard[1, 0] = 1;
            base_hadamard[1, 1] = -1;
            
            int rows = (int)Math.Pow(2, M);
        
            
            

            

            for (int i = 1; i < M; i++)
            {
                for (int j = 0; j < (int)Math.Pow(2, i); j++)
                {
                    for (int k = 0; k < (int)Math.Pow(2, i); k++)
                    {
                        hadamard[j, k + (int)Math.Pow(2, i)] = hadamard[j, k];
                        hadamard[j + (int)Math.Pow(2, i), k] = hadamard[j, k];
                        hadamard[j + (int)Math.Pow(2, i), k + (int)Math.Pow(2, i)] = hadamard[j, k] * -1;
                    }
                }
            }

             // Displaying the final hadamard matrix
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < rows; j++) {
                    Console.Write(hadamard[i,j] + " ");
                }
                Console.WriteLine();
            }
        }

        // Main Method 
        static public void Main() { 
                
            generate(2);
                
        } 
    }
} 