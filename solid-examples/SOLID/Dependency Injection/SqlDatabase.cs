namespace SOLID
{
    class SqlDatabase : IDatabase
    {
        public void Save(string data)
        {
            // Save data to a SQL database
            Console.WriteLine(data);
        }
    }
}
