namespace API
{
    public class Program
    {


        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run(); //per creare e configurare un oggetto generatore

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)     //Returns the IHostBuilder. 
        .ConfigureWebHostDefaults(webBuilder =>        //Imposta Kestrel il server come server Web e lo configura usando i provider di configurazione di hosting dell'app.
        {
            webBuilder.UseStartup<Startup>();
        });
    }
}