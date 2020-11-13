namespace GameOfLife.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Game of Life!");
            var runner = new Runner(2);
            System.Console.Read();
        }
    }
}
