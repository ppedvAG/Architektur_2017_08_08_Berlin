namespace SingeltonExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //var c = new Configuration();

            var c = Configuration.Instance;
            c.LoadConfig();

            Configuration.Instance.LoadConfig();
        }
    }
}