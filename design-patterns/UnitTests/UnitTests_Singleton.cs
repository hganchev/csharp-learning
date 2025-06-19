using Microsoft.VisualStudio.TestTools.UnitTesting;
using DesignPatterns.Singleton;
using System.Threading.Tasks;

[TestClass]
public class SingletonTests
{
    [TestMethod]
    public void TestLoggerSingleton()
    {
        // Act
        var logger1 = Logger.Instance;
        var logger2 = Logger.Instance;

        // Assert
        Assert.AreSame(logger1, logger2);
        Assert.IsNotNull(logger1);
    }

    [TestMethod]
    public void TestDatabaseConnectionSingleton()
    {
        // Act
        var db1 = DatabaseConnection.Instance;
        var db2 = DatabaseConnection.Instance;

        // Assert
        Assert.AreSame(db1, db2);
        Assert.IsNotNull(db1);
        // Note: Instance starts disconnected, need to connect first
        Assert.IsFalse(db1.IsConnected);
    }

    [TestMethod]
    public void TestConfigurationManagerSingleton()
    {
        // Act
        var config1 = ConfigurationManager.Instance;
        var config2 = ConfigurationManager.Instance;

        // Assert
        Assert.AreSame(config1, config2);
        Assert.IsNotNull(config1);
    }

    [TestMethod]
    public void TestConfigurationManagerSetGet()
    {
        // Arrange
        var config = ConfigurationManager.Instance;
        string key = "TestKey";
        string value = "TestValue";

        // Act
        config.SetSetting(key, value);
        string retrievedValue = config.GetSetting(key);

        // Assert
        Assert.AreEqual(value, retrievedValue);
    }    [TestMethod]
    public void TestCacheManagerSingleton()
    {
        // Act
        var cache1 = CacheManager.Instance;
        var cache2 = CacheManager.Instance;

        // Assert
        Assert.AreSame(cache1, cache2);
        Assert.IsNotNull(cache1);
    }

    [TestMethod]
    public void TestCacheManagerSetGet()
    {
        // Arrange
        var cache = CacheManager.Instance;
        string key = "testKey";
        string value = "testValue";

        // Act
        cache.Set(key, value, TimeSpan.FromMinutes(1));
        string? retrievedValue = cache.Get<string>(key);

        // Assert
        Assert.AreEqual(value, retrievedValue);
    }

    [TestMethod]
    public void TestCacheManagerExpiration()
    {
        // Arrange
        var cache = CacheManager.Instance;
        string key = "expireKey";
        string value = "expireValue";

        // Act
        cache.Set(key, value, TimeSpan.FromMilliseconds(100));
        Thread.Sleep(150); // Wait for expiration
        string? retrievedValue = cache.Get<string>(key);

        // Assert
        Assert.IsNull(retrievedValue);
    }

    [TestMethod]
    public async Task TestSingletonThreadSafety()
    {
        // Arrange
        const int taskCount = 10;
        var tasks = new Task<Logger>[taskCount];
        var instances = new Logger[taskCount];

        // Act
        for (int i = 0; i < taskCount; i++)
        {
            int index = i;
            tasks[i] = Task.Run(() => Logger.Instance);
        }

        var results = await Task.WhenAll(tasks);

        // Assert
        var firstInstance = results[0];
        for (int i = 1; i < taskCount; i++)
        {
            Assert.AreSame(firstInstance, results[i]);
        }
    }    [TestMethod]
    public void TestLoggerFunctionality()
    {
        // Arrange
        var logger = Logger.Instance;
        int initialLogCount = logger.GetLogCount();

        // Act & Assert (should not throw exceptions)
        logger.Log("Test info message");
        logger.Log("Test warning message");
        logger.Log("Test error message");
        
        // Verify logs were added
        Assert.AreEqual(initialLogCount + 3, logger.GetLogCount());
    }

    [TestMethod]
    public void TestDatabaseConnectionFunctionality()
    {
        // Arrange
        var db = DatabaseConnection.Instance;

        // Act & Assert (should not throw exceptions)
        Assert.IsFalse(db.IsConnected); // Initially disconnected
        
        db.Connect("TestConnectionString");
        Assert.IsTrue(db.IsConnected);
        
        // Test query execution
        db.ExecuteQuery("SELECT 1"); // This method returns void, just testing it doesn't throw
        
        db.Disconnect();
        Assert.IsFalse(db.IsConnected);
    }
}
