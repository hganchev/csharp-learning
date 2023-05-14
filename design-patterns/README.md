# CSharp_Design_Patterns
Design patterns for OOP

## The Abstract Factory 
pattern is a creational design pattern that provides an interface for creating families of related or dependent objects without specifying their concrete classes. The main idea behind the Abstract Factory pattern is to abstract the process of object creation and make it possible to create families of related objects without having to specify their concrete classes directly


## The Builder design pattern 
is a creational pattern that allows you to separate the construction of a complex object from its representation, so that you can create different representations of the same object.

The Builder pattern involves the following participants:

- The Builder interface, which defines the steps involved in creating the complex object.
- The ConcreteBuilder classes, which implement the Builder interface and provide specific implementations of the steps       involved in creating the complex object.
- The Director class, which uses the Builder interface to create the complex object.
- The Product class, which represents the complex object being built.
