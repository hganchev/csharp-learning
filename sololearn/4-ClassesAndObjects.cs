using System;
using System.Collections.Generic;

namespace Sololearn
{
    class ClassesAndObjects
    {
        public ClassesAndObjects()
        {
            Console.WriteLine("========= Class ==========");
            // In object-oriented programming, a class is a data type that defines a set of variables and methods for a declared object.
            // !An object is called an instance of a class.

            // Stack is used for static memory allocation, which includes all your value types, like x.
            // Heap is used for dynamic memory allocation, which includes custom objects, that might need additional memory during the runtime of your program.
            Person p1 = new Person();
            p1.SayHi();
            Console.WriteLine("========= Enacapsulation ==========");
            // Part of the meaning of the word encapsulation is the idea of "surrounding" an entity, not just to keep what's inside together, but also to protect it.
            // In programming, encapsulation means more than simply combining members together within a class; it also means restricting access to the inner workings of that class.
            // Encapsulation is implemented by using access modifiers. An access modifier defines the scope and visibility of a class member.
            // public, private, protected, internal, protected internal.
            Console.WriteLine("========= Constructors ==========");
            // A class constructor is a special member method of a class that is executed whenever a new object of that class is created.
            // A constructor has exactly the same name as its class, is public, and does not have any return type.
            Console.WriteLine("========= Property ==========");
            // A property is a member that provides a flexible mechanism to read, write, or compute the value of a private field.
            //  Properties can be used as if they are public data members, but they actually include special methods called accessors.
            // Accessor declarations can include a get accessor, a set accessor, or both.
            Console.WriteLine("========= Social Network Problem ==========");
            // Description:
            // You are making a social network application and want to add post creation functionality.
            // As a user creates a post, the text "New post" should be automatically outputted so that then the user can add the text he/she wants to share.
            // The program you are given declares a Post class with a text private field, and the ShowPost() method which outputs the content.
            // Complete the class with
            // - a constructor, which outputs "New post" as called,
            // - Text property, which will allow you to get and set the value of the text field.     
            // Once you have made the changes to the program so that it works correctly, then in main, 
            // the program will take the text of the post from the user, create a post object, assign the taken value to the text field and output it.
            Post post = new Post();
            post.Text = Console.ReadLine();
            post.ShowPost();
        }
    }

    class Post
    {
        private string text;
        
        //write a constructor here
        public Post()
        {
            Console.WriteLine("New post");
        }

        public void ShowPost()
        {
            Console.WriteLine(text);
        }
        
        //write a property for member text
        public string Text 
        { 
            get{return text;}
            set{text = value;} 
        }
        
    }

    class Person
    {
        int age;
        private string name; //field
        public string Name  // property
        { 
            get{return name;}
            set{name = value;}
        }

        public void SayHi()
        {
            Console.WriteLine("Hi");
        }
    }
}