# Virtual in Constructor

## Preparation Recipe

- Create a C# Console Application.
- Create a base class that contains a virtual method. Call the virtual method from the constructor.
- Create a second class derived from the first one, that has a field initialized in the constructor.
- In the second class, override the virtual method and use the object that was initialized in the constructor.
- Run the project and highlight that, when the virtual method is called, the field initialized in the constructor is, surprisingly, not initialized yet.
