namespace Manager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=DESKTOP-1VUANBN;Initial Catalog=Manager;Integrated Security=True;Trust Server Certificate=True";
            //int numRoW=DB.InsertProducts(connectionString);
            //Console.WriteLine($"rows effected {numRoW}");
            //DB.printProducts(connectionString);
            int numRoW1 = DB.InsertCategories(connectionString);
            Console.WriteLine($"rows effected {numRoW1}");
            DB.printCategories(connectionString);

            int numRoW2 = DB.InsertProducts(connectionString);
            Console.WriteLine($"rows effected {numRoW2}");
            DB.printProducts(connectionString);

        }
    }
}