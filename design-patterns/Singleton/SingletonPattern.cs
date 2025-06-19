// Singleton Pattern Examples
// The Singleton pattern ensures that a class has only one instance and provides global access to it.
// Here are several implementations showing different approaches and thread-safety considerations.

namespace DesignPatterns.Singleton
{
    // 1. Thread-Safe Singleton with Lazy Initialization
    public sealed class Logger
    {
        private static readonly Lazy<Logger> _lazy = new Lazy<Logger>(() => new Logger());
        private readonly List<string> _logs;

        private Logger()
        {
            _logs = new List<string>();
            Console.WriteLine("Logger instance created");
        }

        public static Logger Instance => _lazy.Value;

        public void Log(string message)
        {
            var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var logEntry = $"[{timestamp}] {message}";
            _logs.Add(logEntry);
            Console.WriteLine(logEntry);
        }

        public void ShowAllLogs()
        {
            Console.WriteLine("\n=== All Logs ===");
            foreach (var log in _logs)
            {
                Console.WriteLine(log);
            }
        }

        public int GetLogCount()
        {
            return _logs.Count;
        }
    }

    // 2. Database Connection Singleton
    public sealed class DatabaseConnection
    {
        private static DatabaseConnection? _instance;
        private static readonly object _lock = new object();
        private bool _isConnected;
        private string _connectionString;

        private DatabaseConnection()
        {
            _connectionString = "DefaultConnectionString";
            _isConnected = false;
            Console.WriteLine("DatabaseConnection instance created");
        }

        public static DatabaseConnection Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new DatabaseConnection();
                        }
                    }
                }
                return _instance;
            }
        }

        public void Connect(string connectionString = "")
        {
            if (!string.IsNullOrEmpty(connectionString))
            {
                _connectionString = connectionString;
            }

            if (!_isConnected)
            {
                _isConnected = true;
                Console.WriteLine($"Connected to database: {_connectionString}");
            }
            else
            {
                Console.WriteLine("Already connected to database");
            }
        }

        public void Disconnect()
        {
            if (_isConnected)
            {
                _isConnected = false;
                Console.WriteLine("Disconnected from database");
            }
            else
            {
                Console.WriteLine("Already disconnected from database");
            }
        }

        public void ExecuteQuery(string query)
        {
            if (_isConnected)
            {
                Console.WriteLine($"Executing query: {query}");
            }
            else
            {
                Console.WriteLine("Error: Not connected to database");
            }
        }

        public bool IsConnected => _isConnected;
    }

    // 3. Configuration Manager Singleton
    public sealed class ConfigurationManager
    {
        private static ConfigurationManager? _instance;
        private static readonly object _lock = new object();
        private readonly Dictionary<string, string> _settings;

        private ConfigurationManager()
        {
            _settings = new Dictionary<string, string>();
            LoadDefaultSettings();
            Console.WriteLine("ConfigurationManager instance created");
        }

        public static ConfigurationManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new ConfigurationManager();
                        }
                    }
                }
                return _instance;
            }
        }

        private void LoadDefaultSettings()
        {
            _settings["AppName"] = "Design Patterns Demo";
            _settings["Version"] = "1.0.0";
            _settings["Environment"] = "Development";
            _settings["MaxConnections"] = "100";
        }

        public string GetSetting(string key)
        {
            return _settings.TryGetValue(key, out var value) ? value : string.Empty;
        }

        public void SetSetting(string key, string value)
        {
            _settings[key] = value;
            Console.WriteLine($"Setting updated: {key} = {value}");
        }

        public void ShowAllSettings()
        {
            Console.WriteLine("\n=== Configuration Settings ===");
            foreach (var setting in _settings)
            {
                Console.WriteLine($"{setting.Key}: {setting.Value}");
            }
        }

        public bool HasSetting(string key)
        {
            return _settings.ContainsKey(key);
        }
    }

    // 4. Cache Manager Singleton with Generic Support
    public sealed class CacheManager
    {
        private static readonly Lazy<CacheManager> _lazy = new Lazy<CacheManager>(() => new CacheManager());
        private readonly Dictionary<string, object> _cache;
        private readonly Dictionary<string, DateTime> _expiration;

        private CacheManager()
        {
            _cache = new Dictionary<string, object>();
            _expiration = new Dictionary<string, DateTime>();
            Console.WriteLine("CacheManager instance created");
        }

        public static CacheManager Instance => _lazy.Value;

        public void Set<T>(string key, T value, TimeSpan? expiry = null)
        {
            _cache[key] = value!;
            if (expiry.HasValue)
            {
                _expiration[key] = DateTime.Now.Add(expiry.Value);
            }
            Console.WriteLine($"Cache set: {key} = {value}");
        }

        public T? Get<T>(string key)
        {
            if (_cache.ContainsKey(key))
            {
                if (_expiration.ContainsKey(key) && DateTime.Now > _expiration[key])
                {
                    Remove(key);
                    return default(T);
                }

                if (_cache[key] is T value)
                {
                    return value;
                }
            }
            return default(T);
        }

        public void Remove(string key)
        {
            if (_cache.Remove(key))
            {
                _expiration.Remove(key);
                Console.WriteLine($"Cache removed: {key}");
            }
        }

        public void Clear()
        {
            _cache.Clear();
            _expiration.Clear();
            Console.WriteLine("Cache cleared");
        }

        public void ShowCacheStats()
        {
            Console.WriteLine($"\n=== Cache Statistics ===");
            Console.WriteLine($"Total items: {_cache.Count}");
            Console.WriteLine($"Items with expiration: {_expiration.Count}");
            foreach (var item in _cache)
            {
                var hasExpiry = _expiration.ContainsKey(item.Key) ? $" (expires: {_expiration[item.Key]})" : "";
                Console.WriteLine($"  {item.Key}: {item.Value}{hasExpiry}");
            }
        }
    }

    // Demo class
    public class SingletonPatternDemo
    {
        public static void RunDemo()
        {
            Console.WriteLine("=== Singleton Pattern Demo ===");

            // Test Logger Singleton
            Console.WriteLine("\n--- Logger Singleton ---");
            var logger1 = Logger.Instance;
            var logger2 = Logger.Instance;

            Console.WriteLine($"Same instance? {ReferenceEquals(logger1, logger2)}");

            logger1.Log("Application started");
            logger2.Log("User logged in");
            logger1.Log("Processing request");

            logger1.ShowAllLogs();
            Console.WriteLine($"Total logs: {logger1.GetLogCount()}");

            // Test Database Connection Singleton
            Console.WriteLine("\n--- Database Connection Singleton ---");
            var db1 = DatabaseConnection.Instance;
            var db2 = DatabaseConnection.Instance;

            Console.WriteLine($"Same instance? {ReferenceEquals(db1, db2)}");

            db1.Connect("Server=localhost;Database=TestDB");
            db2.ExecuteQuery("SELECT * FROM Users");
            db1.Disconnect();

            // Test Configuration Manager Singleton
            Console.WriteLine("\n--- Configuration Manager Singleton ---");
            var config1 = ConfigurationManager.Instance;
            var config2 = ConfigurationManager.Instance;

            Console.WriteLine($"Same instance? {ReferenceEquals(config1, config2)}");

            config1.ShowAllSettings();
            config2.SetSetting("Theme", "Dark");
            config1.SetSetting("Language", "English");

            Console.WriteLine($"App Name: {config1.GetSetting("AppName")}");
            Console.WriteLine($"Theme: {config2.GetSetting("Theme")}");

            // Test Cache Manager Singleton
            Console.WriteLine("\n--- Cache Manager Singleton ---");
            var cache1 = CacheManager.Instance;
            var cache2 = CacheManager.Instance;

            Console.WriteLine($"Same instance? {ReferenceEquals(cache1, cache2)}");

            cache1.Set("user:123", "John Doe");
            cache2.Set("session:abc", "active", TimeSpan.FromMinutes(30));
            cache1.Set("temp:data", 42);

            Console.WriteLine($"User: {cache1.Get<string>("user:123")}");
            Console.WriteLine($"Session: {cache2.Get<string>("session:abc")}");
            Console.WriteLine($"Temp Data: {cache1.Get<int>("temp:data")}");

            cache1.ShowCacheStats();
        }
    }
}
