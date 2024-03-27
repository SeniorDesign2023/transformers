namespace Client.Models 
{
    public class Signal
    {
        public int[] Elements { get; set; }
        public int Weight { get; set; }
        public Guid Id { get; set; }

        public Signal()
        {
            Id = Guid.NewGuid();
        }
        
    }
}