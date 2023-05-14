using System;
namespace SOLID
{
    class Logger
    {
        private readonly IDatabase _database;

        public Logger(IDatabase database)
        {
            _database = database;
        }

        public void Log(string message)
        {
            string data = $"{DateTime.Now}: {message}";
            _database.Save(data);
        }
    }
}