using spotifycrud.Services;

namespace spotifycrud
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArtistService artistService = new ArtistService();
            //artistService.CreateArtist("Eminem", "Marshall", "II", "male", new DateTime(1972, 11, 2));
            foreach (var item in artistService.GetAll())
            {
                Console.WriteLine(item.StageName);
            }
            artistService.Delete(4);
        }
    }
}