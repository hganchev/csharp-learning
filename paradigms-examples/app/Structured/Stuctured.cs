using System;
using System.Collections.Generic;

namespace app.Structured
{
    /// <summary>
    /// Demonstrates Structured Programming principles:
    /// - Control Structures: Using loops, conditionals, and subroutines for control flow
    /// - Modularity: Breaking programs into smaller, manageable modules/subroutines
    /// - Top-down Design: Hierarchical program structure starting from main process
    /// - No GOTO: Avoiding unstructured jumps in favor of structured control flow
    /// - Sequential Execution: Clear, predictable flow of program execution
    /// </summary>
    public class StructuredExamples
    {
        // Structured programming is programming that uses loops, 
        // conditionals and subroutines for control flow, 
        // and modularity for readability and code reuse. 
        // Today, we just call that programming. 
        // Many professional programmers have never even seen an unstructured program,
        //  that’s how totally dominant it is as a paradigm. The closest we get 
        //  are monster methods that run a thosand lines with no modularity or 
        //  subroutine use. Even then, such methods make heavy use of conditionals and loops.
        // Components of structured programming
        // At the high level, structured programs consist of a structural hierarchy starting with the main 
        // process and decomposing downward to lower levels as the logic dictates. These lower structures 
        // are the modules of the program, and modules may contain both calls to other (lower-level) modules 
        // and blocks representing structured condition/action combinations. All of this can be combined into
        //  a single module or unit of code, or broken down into multiple modules, resident in libraries.
        // 
        // Modules can be classified as "procedures" or "functions." A procedure is a unit of code that performs
        //  a specific task, usually referencing a common data structure available to the program at large. 
        //  Much of the data operated on by procedures is external. A function is a unit of code that operates
        //   on specific inputs and returns a result when called.
        // 
        // Structured programs and modules typically have a header file or section that describes the modules 
        // or libraries referenced and the structure of the parameters and module interface. In some programming 
        // languages, the interface description is abstracted into a separate file, which is then implemented by 
        // one or more other units of code.
        public StructuredExamples()        {
            Console.WriteLine("=== Structured Programming Examples ===");
            
            // Main program structure - top-down design
            RunMainProgram();
        }
        
        // Main program - top-level control structure
        private void RunMainProgram()
        {
            Console.WriteLine("\n--- Main Program Started ---");
            
            // Sequential execution with structured control flow
            InitializeProgram();
            
            bool continueProgram = true;
            int operationCount = 0;
            
            // Main program loop (structured control)
            while (continueProgram && operationCount < 5)
            {
                // Conditional structure to determine operation
                if (operationCount < 2)
                {
                    PerformBasicOperations();
                }
                else if (operationCount < 4)
                {
                    PerformDataProcessing();
                }
                else
                {
                    PerformCleanupOperations();
                    continueProgram = false; // Structured exit condition
                }
                
                operationCount++;
                
                // Conditional pause between operations
                if (continueProgram)
                {
                    Console.WriteLine($"Operation {operationCount} completed. Continuing...\n");
                }
            }
            
            FinalizeProgram();
            Console.WriteLine("--- Main Program Completed ---");
        }
        
        // Module 1: Program initialization
        private void InitializeProgram()
        {
            Console.WriteLine("1. Initializing program components...");
            
            // Nested control structures
            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine($"   Loading component {i}...");
                
                // Conditional logic within loop
                if (i == 2)
                {
                    Console.WriteLine("   Critical component loaded successfully.");
                }
            }
            
            Console.WriteLine("   All components initialized.");
        }
        
        // Module 2: Basic operations with control structures
        private void PerformBasicOperations()
        {
            Console.WriteLine("2. Performing basic operations...");
            
            // Sequential operations with conditional logic
            int[] numbers = { 10, 25, 8, 33, 15, 42, 7, 28 };
            
            // Process numbers using structured control flow
            ProcessNumberArray(numbers);
            
            // Decision structure based on results
            int sum = CalculateSum(numbers);
            if (sum > 100)
            {
                Console.WriteLine($"   High sum detected: {sum}");
                PerformHighValueProcessing(sum);
            }
            else
            {
                Console.WriteLine($"   Normal sum: {sum}");
                PerformNormalProcessing(sum);
            }
        }
        
        // Module 3: Data processing with nested structures
        private void PerformDataProcessing()
        {
            Console.WriteLine("3. Processing data structures...");
            
            // Create sample data
            List<StudentRecord> students = CreateStudentData();
            
            // Process data using structured programming techniques
            AnalyzeStudentData(students);
        }
        
        // Module 4: Cleanup operations
        private void PerformCleanupOperations()
        {
            Console.WriteLine("4. Performing cleanup operations...");
            
            // Structured cleanup sequence
            CleanupTemporaryFiles();
            CleanupMemoryResources();
        }
        
        // Module 5: Program finalization
        private void FinalizeProgram()
        {
            Console.WriteLine("5. Finalizing program...");
            
            // Final operations in structured order
            SaveProgramState();
            LogProgramCompletion();
        }
        
        // Subroutine: Process array of numbers
        private void ProcessNumberArray(int[] numbers)
        {
            Console.WriteLine("   Processing number array:");
            
            // Loop with conditional logic
            for (int i = 0; i < numbers.Length; i++)
            {
                int number = numbers[i];
                
                // Multiple conditional branches
                if (number % 2 == 0)
                {
                    Console.WriteLine($"     {number} is even");
                }
                else
                {
                    Console.WriteLine($"     {number} is odd");
                }
                
                // Additional conditional check
                if (number > 20)
                {
                    Console.WriteLine($"     {number} is a large number");
                }
            }
        }
        
        // Subroutine: Calculate sum using loop
        private int CalculateSum(int[] numbers)
        {
            int sum = 0;
            
            // Simple loop structure
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            
            return sum;
        }
        
        // Subroutine: High value processing
        private void PerformHighValueProcessing(int sum)
        {
            Console.WriteLine("   Executing high-value processing routine...");
            
            // Nested loop structure
            for (int i = 1; i <= 3; i++)
            {
                for (int j = 1; j <= 2; j++)
                {
                    Console.WriteLine($"     High-value step {i}.{j} completed");
                }
            }
        }
        
        // Subroutine: Normal processing
        private void PerformNormalProcessing(int sum)
        {
            Console.WriteLine("   Executing normal processing routine...");
            Console.WriteLine($"     Processing sum value: {sum}");
        }
        
        // Data structure for student records
        private struct StudentRecord
        {
            public string Name;
            public int Age;
            public double GPA;
            
            public StudentRecord(string name, int age, double gpa)
            {
                Name = name;
                Age = age;
                GPA = gpa;
            }
        }
        
        // Subroutine: Create sample student data
        private List<StudentRecord> CreateStudentData()
        {
            List<StudentRecord> students = new List<StudentRecord>();
            
            // Sequential data creation
            students.Add(new StudentRecord("Alice", 20, 3.8));
            students.Add(new StudentRecord("Bob", 19, 3.2));
            students.Add(new StudentRecord("Carol", 21, 3.9));
            
            Console.WriteLine($"   Created {students.Count} student records");
            return students;
        }
        
        // Subroutine: Analyze student data using structured programming
        private void AnalyzeStudentData(List<StudentRecord> students)
        {
            Console.WriteLine("   Analyzing student data...");
            
            double totalGPA = 0;
            int highPerformers = 0;
            
            // Main analysis loop
            for (int i = 0; i < students.Count; i++)
            {
                StudentRecord student = students[i];
                
                // Accumulate total GPA
                totalGPA += student.GPA;
                
                // Count high performers
                if (student.GPA >= 3.5)
                {
                    highPerformers++;
                    Console.WriteLine($"     High performer: {student.Name} (GPA: {student.GPA})");
                }
            }
            
            // Calculate and display results
            double averageGPA = students.Count > 0 ? totalGPA / students.Count : 0;
            Console.WriteLine($"     Average GPA: {averageGPA:F2}");
            Console.WriteLine($"     High performers: {highPerformers} out of {students.Count}");
        }
        
        // Cleanup subroutines
        private void CleanupTemporaryFiles()
        {
            Console.WriteLine("   Cleaning up temporary files...");
            
            // Simulate file cleanup with loop
            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine($"     Removing temp file {i}");
            }
        }
        
        private void CleanupMemoryResources()
        {
            Console.WriteLine("   Releasing memory resources...");
            Console.WriteLine("     Memory cleanup completed");
        }
        
        private void SaveProgramState()
        {
            Console.WriteLine("   Saving program state...");
            Console.WriteLine("     State saved successfully");
        }
        
        private void LogProgramCompletion()
        {
            Console.WriteLine("   Logging program completion...");
            Console.WriteLine($"     Program completed at: {DateTime.Now}");
        }
    }
}