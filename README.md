# Virtual in Constructor

## Pill Category

Language (C#)

## Description

If we call a virtual method from the constructor, Resharper raises a warning: "Virtual member call in constructor"

Same warning is raised if we call an abstract method and also if we call a virtual or abstract property.

### Question

- Why is it a problem to call virtual or abstract methods or properties from the constructor?