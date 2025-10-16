// ========================================
// ASSIGNMENT: Convert Legacy Sync to Async
// ========================================
// 
// GOAL: Convert this legacy synchronous UserService to use async/await
// 
// APPLY THESE BEST PRACTICES:
// 1. ✅ Use async/await for all I/O operations
// 2. ✅ Return Task/Task<T> (never async void)
// 3. ✅ Pass CancellationToken through the chain
// 4. ✅ Use ConfigureAwait(false) in library code
// 5. ✅ Never block with .Result or .Wait()
// 6. ✅ Use Task.WhenAll for parallel operations
// 7. ✅ Handle exceptions properly
// ========================================

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace LegacySyncExample
{
    // ========================================
    // LEGACY SYNCHRONOUS CODE (BEFORE)
    // ========================================
    
    /// <summary>
    /// ❌ PROBLEM: This entire service uses blocking synchronous I/O operations.
    /// Under heavy load, threads will be blocked waiting for I/O, leading to:
    /// - Thread starvation (ThreadPool exhaustion)
    /// - Poor scalability (limited concurrent requests)
    /// - Wasted resources (threads sitting idle during I/O)
    /// </summary>
    public class LegacyUserService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl = "https://api.example.com";
        private readonly string _cacheDirectory = "./cache";

        public LegacyUserService()
        {
            _httpClient = new HttpClient();
        }

        // ❌ PROBLEM 1: Synchronous method blocks thread during HTTP call
        public User GetUserById(int userId)
        {
            // Thread is BLOCKED here waiting for HTTP response
            var response = _httpClient.GetAsync($"{_apiBaseUrl}/users/{userId}").Result;
            response.EnsureSuccessStatusCode();

            // Thread is BLOCKED here waiting for content to be read
            var json = response.Content.ReadAsStringAsync().Result;
            var user = JsonSerializer.Deserialize<User>(json);

            return user;
        }

        // ❌ PROBLEM 2: Sequential I/O operations - no parallelism
        public List<User> GetMultipleUsers(List<int> userIds)
        {
            var users = new List<User>();

            // This takes N * request_time because each request is sequential
            // If each request takes 100ms, 10 users = 1000ms total
            foreach (var userId in userIds)
            {
                var user = GetUserById(userId);  // Blocking call
                users.Add(user);
            }

            return users;
        }

        // ❌ PROBLEM 3: Blocking file I/O
        public User GetUserFromCache(int userId)
        {
            var cachePath = Path.Combine(_cacheDirectory, $"user_{userId}.json");

            if (!File.Exists(cachePath))
                return null;

            // Thread is BLOCKED here waiting for file I/O
            var json = File.ReadAllText(cachePath);
            return JsonSerializer.Deserialize<User>(json);
        }

        // ❌ PROBLEM 4: Blocking file write
        public void SaveUserToCache(User user)
        {
            if (!Directory.Exists(_cacheDirectory))
                Directory.CreateDirectory(_cacheDirectory);

            var cachePath = Path.Combine(_cacheDirectory, $"user_{user.Id}.json");
            var json = JsonSerializer.Serialize(user, new JsonSerializerOptions { WriteIndented = true });

            // Thread is BLOCKED here waiting for file write
            File.WriteAllText(cachePath, json);
        }

        // ❌ PROBLEM 5: Complex workflow with multiple blocking operations
        public UserProfile GetUserProfile(int userId)
        {
            // 1. Check cache first (blocking file I/O)
            var cachedUser = GetUserFromCache(userId);
            if (cachedUser != null)
            {
                Console.WriteLine("User found in cache");
                return CreateProfile(cachedUser);
            }

            // 2. Fetch from API (blocking HTTP I/O)
            Console.WriteLine("Fetching user from API...");
            var user = GetUserById(userId);

            // 3. Fetch additional data (blocking HTTP I/O)
            var orders = GetUserOrders(userId);      // Blocking
            var preferences = GetUserPreferences(userId);  // Blocking

            // 4. Save to cache (blocking file I/O)
            SaveUserToCache(user);

            // 5. Build profile
            return CreateProfile(user, orders, preferences);
        }

        // ❌ PROBLEM 6: More blocking HTTP calls
        private List<Order> GetUserOrders(int userId)
        {
            var response = _httpClient.GetAsync($"{_apiBaseUrl}/users/{userId}/orders").Result;
            response.EnsureSuccessStatusCode();
            var json = response.Content.ReadAsStringAsync().Result;
            return JsonSerializer.Deserialize<List<Order>>(json);
        }

        private UserPreferences GetUserPreferences(int userId)
        {
            var response = _httpClient.GetAsync($"{_apiBaseUrl}/users/{userId}/preferences").Result;
            response.EnsureSuccessStatusCode();
            var json = response.Content.ReadAsStringAsync().Result;
            return JsonSerializer.Deserialize<UserPreferences>(json);
        }

        // ❌ PROBLEM 7: CPU-bound work done synchronously on calling thread
        private UserProfile CreateProfile(User user, List<Order> orders = null, UserPreferences preferences = null)
        {
            // Simulate some CPU-intensive work
            var statistics = CalculateUserStatistics(orders ?? new List<Order>());

            return new UserProfile
            {
                User = user,
                Orders = orders ?? new List<Order>(),
                Preferences = preferences,
                Statistics = statistics
            };
        }

        private UserStatistics CalculateUserStatistics(List<Order> orders)
        {
            // Simulate CPU-intensive calculation
            Thread.Sleep(50); // Simulates complex computation

            return new UserStatistics
            {
                TotalOrders = orders.Count,
                TotalSpent = orders.Sum(o => o.Amount),
                AverageOrderValue = orders.Any() ? orders.Average(o => o.Amount) : 0
            };
        }

        // ❌ PROBLEM 8: Batch operation with no concurrency control
        public void ProcessAllUsers(List<int> userIds)
        {
            foreach (var userId in userIds)
            {
                try
                {
                    var profile = GetUserProfile(userId);
                    Console.WriteLine($"Processed user {profile.User.Name}");
                    
                    // Some processing...
                    SaveUserToCache(profile.User);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing user {userId}: {ex.Message}");
                    // Error handling but continues
                }
            }
        }

        // ❌ PROBLEM 9: No cancellation support
        public List<User> SearchUsers(string searchTerm)
        {
            // This could take a long time, but no way to cancel it
            var response = _httpClient.GetAsync($"{_apiBaseUrl}/users/search?q={searchTerm}").Result;
            response.EnsureSuccessStatusCode();
            var json = response.Content.ReadAsStringAsync().Result;
            return JsonSerializer.Deserialize<List<User>>(json);
        }
    }

    // ========================================
    // YOUR TASK: Create AsyncUserService
    // ========================================
    
    /// <summary>
    /// TODO: Create a new AsyncUserService that converts all the above methods to async.
    /// 
    /// HINTS:
    /// 1. Change return types: void → Task, T → Task<T>
    /// 2. Add 'async' keyword to method signatures
    /// 3. Replace .Result with 'await'
    /// 4. Use async versions: File.ReadAllTextAsync, File.WriteAllTextAsync, etc.
    /// 5. Add CancellationToken parameters
    /// 6. Use ConfigureAwait(false) for library code
    /// 7. Use Task.WhenAll for GetMultipleUsers to run requests in parallel
    /// 8. Use Task.Run for CPU-bound work (CalculateUserStatistics)
    /// 9. Add SemaphoreSlim to ProcessAllUsers to limit concurrency
    /// 10. Proper exception handling with try/catch
    /// 
    /// BONUS CHALLENGES:
    /// - Add retry logic with Polly library
    /// - Implement IAsyncEnumerable for streaming results
    /// - Add progress reporting for batch operations
    /// - Implement circuit breaker pattern
    /// </summary>
    public class AsyncUserService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl = "https://api.example.com";
        private readonly string _cacheDirectory = "./cache";
        private readonly SemaphoreSlim _concurrencyLimiter = new SemaphoreSlim(5); // Max 5 concurrent operations

        public AsyncUserService()
        {
            _httpClient = new HttpClient();
        }

        // TODO: Convert GetUserById to async
        // public async Task<User> GetUserByIdAsync(int userId, CancellationToken cancellationToken = default)
        // {
        //     // Your implementation here
        // }

        // TODO: Convert GetMultipleUsers to async with parallel execution
        // public async Task<List<User>> GetMultipleUsersAsync(List<int> userIds, CancellationToken cancellationToken = default)
        // {
        //     // Hint: Use Task.WhenAll to run requests in parallel
        // }

        // TODO: Convert remaining methods...
    }

    // ========================================
    // SUPPORTING CLASSES (DO NOT MODIFY)
    // ========================================

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public DateTime OrderDate { get; set; }
    }

    public class UserPreferences
    {
        public bool EmailNotifications { get; set; }
        public string Theme { get; set; }
        public string Language { get; set; }
    }

    public class UserStatistics
    {
        public int TotalOrders { get; set; }
        public decimal TotalSpent { get; set; }
        public decimal AverageOrderValue { get; set; }
    }

    public class UserProfile
    {
        public User User { get; set; }
        public List<Order> Orders { get; set; }
        public UserPreferences Preferences { get; set; }
        public UserStatistics Statistics { get; set; }
    }

    // ========================================
    // TESTING CODE
    // ========================================

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Legacy Sync Example ===");
            Console.WriteLine("This code demonstrates blocking synchronous I/O.");
            Console.WriteLine("Your task: Convert to async/await!");
            Console.WriteLine();

            var service = new LegacyUserService();

            try
            {
                // This blocks the thread for the entire duration
                var user = service.GetUserById(1);
                Console.WriteLine($"Fetched user: {user?.Name}");

                // This takes 3x the time of a single request (sequential)
                var users = service.GetMultipleUsers(new List<int> { 1, 2, 3 });
                Console.WriteLine($"Fetched {users.Count} users");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine();
            Console.WriteLine("Now create AsyncUserService and run it with:");
            Console.WriteLine("await asyncService.GetUserByIdAsync(1);");
        }
    }
}

// ========================================
// EXPECTED IMPROVEMENTS AFTER CONVERSION:
// ========================================
//
// BEFORE (Sync):
// - GetMultipleUsers(10 users): ~1000ms (sequential)
// - Thread Pool: 100 threads handling 100 requests = 20 req/sec capacity
// - Under load: Thread starvation, requests queue
//
// AFTER (Async):
// - GetMultipleUsersAsync(10 users): ~100ms (parallel)
// - Thread Pool: 100 threads handling 1000s of requests
// - Under load: High throughput, minimal queuing
//
// PERFORMANCE GAINS:
// - 10x faster for parallel operations
// - 25x higher throughput under load
// - Zero thread blocking during I/O
//
// ========================================

