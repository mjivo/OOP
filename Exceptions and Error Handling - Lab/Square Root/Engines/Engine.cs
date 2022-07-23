namespace Square_Root.Engines
{
    using System;
    public class Engine : IEngine
    {
        public Engine(int num)
        {
            this.Start(num);
        }
        public void Start(int num)
        {
            try
            {
                Num number = new Num(num);
                Console.WriteLine(number.SquareRoot);
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye!");
            }
        }
    }
}
