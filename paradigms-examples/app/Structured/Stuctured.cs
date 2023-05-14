using System;
namespace Structured
{
    class Structures
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
        public Structures()
        {
            // if/else
            bool isTrue = true;
            if (isTrue)
            {
                Console.WriteLine("the if is true");
            }
            else
            {
                Console.WriteLine("the if is false");
            }
            isTrue = false;
            if (isTrue)
            {
                Console.WriteLine("the if is true");
            }
            else
            {
                Console.WriteLine("the if is false");
            }
            // for loops 
            for(int i = 0; i < 3; i++)
            {
                Console.WriteLine("this is for loop index: " + i);
            }
            // while
            while(true)
            {
                Console.WriteLine("this is one cycle of while");
                break;
            }

            int iStep = 1;
            // selects 
            switch(iStep)
            {
                case 0:
                    Console.WriteLine("this is {0} step of switch statement", iStep);
                    break;
                case 1:
                    Console.WriteLine("this is {0} step of switch statement", iStep);
                    break;
                default:
                    Console.WriteLine("this is default step of switch statement");
                    break;
            }

        }
    }
}