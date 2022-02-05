namespace RandomNumbers
{
    class MyMethods
    {
        public static void PrintRandomNumber(Random random)
        {
            Console.WriteLine($"Your random int is: {random.Next(1, 11)}");
            Console.WriteLine($"Your random double is: {random.NextDouble() * 10}");
        }

        public static IList<T> ShuffleList<T>(IList<T> list, Random random)
        {
            return list.OrderBy(n => random.Next()).ToList();
        }
    }
}
