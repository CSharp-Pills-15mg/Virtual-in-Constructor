# Virtual in Constructor

## Preparation Recipe

- Create a C# Console Application.

- Create a base class that contains a virtual method. Call the virtual method from the constructor.

  ```csharp
  internal class Base
  {
      public int Length { get; private set; }
  
      public Base()
      {
          Length = CalculateLength();
      }
  
      protected virtual int CalculateLength()
      {
          return 0;
      }
  }
  ```

- Create a second class derived from the first one, that has a field initialized in the constructor.

  ```csharp
  internal class Derived : Base
  {
      private readonly string value;
  
      public Derived(string value)
          : base()
      {
          this.value = value ?? throw new ArgumentNullException(nameof(value));
      }
  }
  ```

- In the second class, override the virtual method and use the object that was initialized in the constructor.

  ```csharp
  internal class Derived : Base
  {
      private readonly string value;
      
      ...
  
      protected override int CalculateLength()
      {
          return value.Length;
      }
  }
  ```

- Run the project and highlight that, when the virtual method is called, the field initialized in the constructor is, surprisingly, not initialized yet.

- Put breakpoints in all the methods and constructors from the base and derived classes, run again the application and explain what happens.

- Present the pictures from the article and explain again the situation.

### Two-Step Initialization

Talk about the two-step-initialization pattern and show it:

- Move the problematic call to the virtual method in a separate public method called `Initialize`

  ```csharp
  internal class Base
  {
      ...
  
      public Base()
      {
      }
  
      public void Initialize()
      {
          Length = CalculateLength();
      }
      
      ...
  }
  ```

  Now, the `Initialize` method must be manually called after the constructor.

- To force the `Initialize` method to be called, introduce the `IsInitialized` property in the base class that will be initially false.

  ```csharp
  internal class Base
  {
  	protected bool IsInitialized { get; private set; }
      
      ...
  }
  ```

- Set the `IsInitialized` property from the Initialize method

  ```csharp
  internal class Base
  {
      protected bool IsInitialized { get; private set; }
  
      ...
  
      public void Initialize()
      {
          Length = CalculateLength();
  
          IsInitialized = true;
      }
  }
  ```

- Show how to be used from a public method.

  ```csharp
  internal class Base
  {
      ...
  
      public void DoSomething()
      {
          if (!IsInitialized)
              throw new NotInitializedException(GetType());
  
          // do what we need to do
      }
  }
  ```

- In the same way it must be used from the derived class, too.

  ```csharp
  internal class Derived : Base
  {
      ...
  
      public void DoSomethingElse()
      {
          if (!IsInitialized)
              throw new NotInitializedException(GetType());
  
          // do what we need to do
      }
  }
  ```

- Optionally, show how to implement the `NotInitializedException` exception:

  ```csharp
  internal class NotInitializedException : Exception
  {
      private const string DefaultValue = "The instance of {0} is not fully initialized.";
  
      public NotInitializedException(Type type)
          : base(string.Format(DefaultValue, type.FullName))
          {
          }
  }
  ```

  
