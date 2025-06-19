using System;
using System.Collections.Generic;

namespace app.Imperative
{
    /// <summary>
    /// Demonstrates Procedural/Imperative Programming principles:
    /// - Step-by-step execution: Programs execute instructions in sequence
    /// - Procedures/Methods: Code is organized into reusable procedures
    /// - Mutable state: Variables can be modified during execution
    /// - Control structures: Using loops, conditionals, and jumps to control program flow
    /// - Top-down design: Breaking complex problems into smaller sub-problems
    /// </summary>
    public class ProceduralExamples
    {
        // Class-level variables (mutable state)
        private static List<string> _taskList = new();
        private static int _taskIdCounter = 1;
        
        public ProceduralExamples()
        {
            Console.WriteLine("=== Procedural Programming Examples ===");
            
            // Sequential execution of procedures
            InitializeSystem();
            DisplayWelcomeMessage();
            DemonstrateBasicOperations();
            DemonstrateControlStructures();
            DemonstrateTaskManagement();
            ShowSystemStats();
            CleanupAndExit();
        }
        
        // Procedure 1: System initialization
        private static void InitializeSystem()
        {
            Console.WriteLine("Step 1: Initializing system...");
            _taskList.Clear();
            _taskIdCounter = 1;
            Console.WriteLine("System initialized successfully.");
        }
        
        // Procedure 2: Display welcome message
        private static void DisplayWelcomeMessage()
        {
            Console.WriteLine("\nStep 2: Displaying welcome message...");
            Console.WriteLine("Welcome to the Procedural Programming Demo!");
            Console.WriteLine("This demonstrates step-by-step execution.");
        }
        
        // Procedure 3: Basic arithmetic operations
        private static void DemonstrateBasicOperations()
        {
            Console.WriteLine("\nStep 3: Performing basic operations...");
            
            // Variables that will be modified (mutable state)
            int a = 10;
            int b = 5;
            
            // Sequence of operations modifying variables
            int sum = AddNumbers(a, b);
            int product = MultiplyNumbers(a, b);
            int difference = SubtractNumbers(a, b);
            
            Console.WriteLine($"a = {a}, b = {b}");
            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"Product: {product}");
            Console.WriteLine($"Difference: {difference}");
            
            // Modifying variables in place
            a = ModifyValue(a, 3);
            b = ModifyValue(b, 2);
            Console.WriteLine($"After modification: a = {a}, b = {b}");
        }
        
        // Procedure 4: Control structures demonstration
        private static void DemonstrateControlStructures()
        {
            Console.WriteLine("\nStep 4: Demonstrating control structures...");
            
            // Conditional structures
            int number = 15;
            if (number > 10)
            {
                Console.WriteLine($"{number} is greater than 10");
            }
            else
            {
                Console.WriteLine($"{number} is not greater than 10");
            }
            
            // Switch statement
            string dayOfWeek = GetDayOfWeek(DateTime.Now.DayOfWeek);
            Console.WriteLine($"Today is {dayOfWeek}");
            
            // Loop structures
            Console.WriteLine("Counting from 1 to 5:");
            for (int i = 1; i <= 5; i++)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
            
            // While loop with mutable state
            int countdown = 3;
            Console.WriteLine("Countdown:");
            while (countdown > 0)
            {
                Console.WriteLine($"{countdown}...");
                countdown--; // Modifying state
            }
            Console.WriteLine("Go!");
        }
        
        // Procedure 5: Task management system
        private static void DemonstrateTaskManagement()
        {
            Console.WriteLine("\nStep 5: Task management operations...");
            
            // Adding tasks (modifying global state)
            AddTask("Complete project documentation");
            AddTask("Review code changes");
            AddTask("Prepare presentation");
            
            // Display all tasks
            DisplayAllTasks();
            
            // Mark task as completed (modifying state)
            CompleteTask(2);
            
            // Display updated task list
            Console.WriteLine("\nAfter completing task 2:");
            DisplayAllTasks();
        }
        
        // Procedure 6: System statistics
        private static void ShowSystemStats()
        {
            Console.WriteLine("\nStep 6: Displaying system statistics...");
            int totalTasks = CountTasks();
            int completedTasks = CountCompletedTasks();
            int remainingTasks = totalTasks - completedTasks;
            
            Console.WriteLine($"Total tasks: {totalTasks}");
            Console.WriteLine($"Completed tasks: {completedTasks}");
            Console.WriteLine($"Remaining tasks: {remainingTasks}");
            
            // Calculate completion percentage
            double completionPercentage = totalTasks > 0 ? (double)completedTasks / totalTasks * 100 : 0;
            Console.WriteLine($"Completion percentage: {completionPercentage:F1}%");
        }
        
        // Procedure 7: Cleanup and exit
        private static void CleanupAndExit()
        {
            Console.WriteLine("\nStep 7: Cleaning up and exiting...");
            
            // Clear all data (state modification)
            _taskList.Clear();
            _taskIdCounter = 1;
            
            Console.WriteLine("Cleanup completed. System is ready for shutdown.");
        }
        
        // Helper procedures (sub-routines)
        private static int AddNumbers(int x, int y)
        {
            return x + y;
        }
        
        private static int MultiplyNumbers(int x, int y)
        {
            return x * y;
        }
        
        private static int SubtractNumbers(int x, int y)
        {
            return x - y;
        }
        
        private static int ModifyValue(int value, int modifier)
        {
            return value * modifier;
        }
        
        private static string GetDayOfWeek(DayOfWeek day)
        {
            switch (day)
            {
                case DayOfWeek.Monday:
                    return "Monday";
                case DayOfWeek.Tuesday:
                    return "Tuesday";
                case DayOfWeek.Wednesday:
                    return "Wednesday";
                case DayOfWeek.Thursday:
                    return "Thursday";
                case DayOfWeek.Friday:
                    return "Friday";
                case DayOfWeek.Saturday:
                    return "Saturday";
                case DayOfWeek.Sunday:
                    return "Sunday";
                default:
                    return "Unknown";
            }
        }
        
        private static void AddTask(string taskDescription)
        {
            string task = $"[{_taskIdCounter}] {taskDescription} - Pending";
            _taskList.Add(task);
            _taskIdCounter++;
            Console.WriteLine($"Added task: {taskDescription}");
        }
        
        private static void DisplayAllTasks()
        {
            Console.WriteLine("Current tasks:");
            if (_taskList.Count == 0)
            {
                Console.WriteLine("  No tasks available.");
                return;
            }
            
            for (int i = 0; i < _taskList.Count; i++)
            {
                Console.WriteLine($"  {_taskList[i]}");
            }
        }
        
        private static void CompleteTask(int taskId)
        {
            // Linear search through tasks to find and modify
            for (int i = 0; i < _taskList.Count; i++)
            {
                if (_taskList[i].StartsWith($"[{taskId}]"))
                {
                    string originalTask = _taskList[i];
                    string updatedTask = originalTask.Replace("Pending", "Completed");
                    _taskList[i] = updatedTask; // Modifying state
                    Console.WriteLine($"Task {taskId} marked as completed.");
                    return;
                }
            }
            Console.WriteLine($"Task {taskId} not found.");
        }
        
        private static int CountTasks()
        {
            return _taskList.Count;
        }
        
        private static int CountCompletedTasks()
        {
            int count = 0;
            // Iterating through list to count completed tasks
            for (int i = 0; i < _taskList.Count; i++)
            {
                if (_taskList[i].Contains("Completed"))
                {
                    count++;
                }
            }
            return count;
        }
    }
    
    // Additional example: Data processing with procedural approach
    public static class DataProcessor
    {
        public static void ProcessEmployeeData()
        {
            Console.WriteLine("\n=== Procedural Data Processing ===");
            
            // Step 1: Initialize data structures
            List<string> employeeNames = new();
            List<double> employeeSalaries = new();
            List<string> employeeDepartments = new();
            
            // Step 2: Load sample data
            LoadEmployeeData(employeeNames, employeeSalaries, employeeDepartments);
            
            // Step 3: Process data
            double totalSalary = CalculateTotalSalary(employeeSalaries);
            double averageSalary = CalculateAverageSalary(employeeSalaries);
            string highestPaidEmployee = FindHighestPaidEmployee(employeeNames, employeeSalaries);
            
            // Step 4: Display results
            DisplayProcessingResults(totalSalary, averageSalary, highestPaidEmployee);
            
            // Step 5: Generate department report
            GenerateDepartmentReport(employeeNames, employeeSalaries, employeeDepartments);
        }
        
        private static void LoadEmployeeData(List<string> names, List<double> salaries, List<string> departments)
        {
            // Procedural approach: step-by-step data loading
            names.Add("Alice Johnson");
            salaries.Add(75000);
            departments.Add("Engineering");
            
            names.Add("Bob Smith");
            salaries.Add(65000);
            departments.Add("Marketing");
            
            names.Add("Carol Williams");
            salaries.Add(80000);
            departments.Add("Engineering");
            
            names.Add("David Brown");
            salaries.Add(55000);
            departments.Add("Sales");
            
            Console.WriteLine($"Loaded {names.Count} employee records.");
        }
        
        private static double CalculateTotalSalary(List<double> salaries)
        {
            double total = 0;
            for (int i = 0; i < salaries.Count; i++)
            {
                total += salaries[i];
            }
            return total;
        }
        
        private static double CalculateAverageSalary(List<double> salaries)
        {
            if (salaries.Count == 0) return 0;
            return CalculateTotalSalary(salaries) / salaries.Count;
        }
        
        private static string FindHighestPaidEmployee(List<string> names, List<double> salaries)
        {
            if (names.Count == 0) return "No employees";
            
            int highestIndex = 0;
            double highestSalary = salaries[0];
            
            for (int i = 1; i < salaries.Count; i++)
            {
                if (salaries[i] > highestSalary)
                {
                    highestSalary = salaries[i];
                    highestIndex = i;
                }
            }
            
            return names[highestIndex];
        }
        
        private static void DisplayProcessingResults(double total, double average, string highestPaid)
        {
            Console.WriteLine($"Total salary budget: ${total:N0}");
            Console.WriteLine($"Average salary: ${average:N0}");
            Console.WriteLine($"Highest paid employee: {highestPaid}");
        }
        
        private static void GenerateDepartmentReport(List<string> names, List<double> salaries, List<string> departments)
        {
            Console.WriteLine("\nDepartment Report:");
            
            // Procedural approach to group and calculate by department
            List<string> uniqueDepartments = new();
            
            // Find unique departments
            for (int i = 0; i < departments.Count; i++)
            {
                if (!uniqueDepartments.Contains(departments[i]))
                {
                    uniqueDepartments.Add(departments[i]);
                }
            }
            
            // Calculate statistics for each department
            foreach (string dept in uniqueDepartments)
            {
                int employeeCount = 0;
                double departmentTotal = 0;
                
                for (int i = 0; i < departments.Count; i++)
                {
                    if (departments[i] == dept)
                    {
                        employeeCount++;
                        departmentTotal += salaries[i];
                    }
                }
                
                double departmentAverage = employeeCount > 0 ? departmentTotal / employeeCount : 0;
                Console.WriteLine($"  {dept}: {employeeCount} employees, avg salary: ${departmentAverage:N0}");
            }
        }
    }
}