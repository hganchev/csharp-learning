namespace AdvancedConcepts.Deadlocks;

/// <summary>
/// Real-world deadlock scenarios
/// </summary>
public static class RealWorldDeadlocks
{
    // SCENARIO 1: Database transaction deadlock
    public class DatabaseDeadlock
    {
        private readonly object _accountLock = new object();
        
        // ❌ DEADLOCK: Two transfers in opposite directions
        public void Transfer_Deadlock(Account from, Account to, decimal amount)
        {
            lock (from.Lock)
            {
                Thread.Sleep(10); // Simulate work
                lock (to.Lock)
                {
                    from.Balance -= amount;
                    to.Balance += amount;
                }
            }
        }
        
        // ✅ FIX: Lock ordering by account ID
        public void Transfer_Fixed(Account from, Account to, decimal amount)
        {
            var firstLock = from.Id < to.Id ? from.Lock : to.Lock;
            var secondLock = from.Id < to.Id ? to.Lock : from.Lock;
            
            lock (firstLock)
            {
                lock (secondLock)
                {
                    from.Balance -= amount;
                    to.Balance += amount;
                }
            }
        }
    }

    public class Account
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public object Lock { get; } = new object();
    }

    // SCENARIO 2: Reader-Writer deadlock
    public class ReaderWriterDeadlock
    {
        private readonly ReaderWriterLockSlim _rwLock = new ReaderWriterLockSlim();
        
        // ❌ DEADLOCK: Upgrading read lock to write lock
        public void Deadlock_UpgradeLock()
        {
            _rwLock.EnterReadLock();
            try
            {
                // Can't upgrade - would deadlock if another reader exists
                // _rwLock.EnterWriteLock(); // DEADLOCK!
            }
            finally
            {
                _rwLock.ExitReadLock();
            }
        }
        
        // ✅ FIX: Use UpgradeableReadLock
        public void Fixed_UpgradeableLock()
        {
            _rwLock.EnterUpgradeableReadLock();
            try
            {
                // Read data
                var needsUpdate = true;
                
                if (needsUpdate)
                {
                    _rwLock.EnterWriteLock();
                    try
                    {
                        // Write data
                    }
                    finally
                    {
                        _rwLock.ExitWriteLock();
                    }
                }
            }
            finally
            {
                _rwLock.ExitUpgradeableReadLock();
            }
        }
    }

    // SCENARIO 3: Async context deadlock
    public class AsyncContextDeadlock
    {
        // ❌ DEADLOCK: Blocking on async code in synchronous context
        public string Deadlock_BlockOnAsync()
        {
            // In a UI or ASP.NET context, this would deadlock:
            // return FetchDataAsync().Result;
            
            // The async method awaits and tries to resume on the original context,
            // but that context is blocked waiting for the result!
            return "Would deadlock in UI/ASP.NET context";
        }
        
        // ✅ FIX 1: Make method async
        public async Task<string> Fixed_MakeAsync()
        {
            return await FetchDataAsync();
        }
        
        // ✅ FIX 2: Use ConfigureAwait(false)
        public string Fixed_ConfigureAwait()
        {
            // Still not ideal, but won't deadlock
            return FetchDataAsync().ConfigureAwait(false).GetAwaiter().GetResult();
        }
        
        private async Task<string> FetchDataAsync()
        {
            await Task.Delay(10).ConfigureAwait(false);
            return "Data";
        }
    }
}
