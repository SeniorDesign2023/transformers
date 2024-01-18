using Client.Models;

namespace Client.Services
{
    public class DataService
    {
        public Task<Data> GetDataAsync()
        {
            return Task.FromResult(new Data
            {
                Elements = new double[] { 1, 2, 3, 4, 5 }
            });

        }
    }
}
