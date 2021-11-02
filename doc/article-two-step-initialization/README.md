# Two-Step Initialization Pattern

This pattern is used when a class, during its initialization process, needs to call a virtual method from the constructor.

## Initial situation

Let's take as example the following base class:

```csharp
internal class Base
{
    public int Length { get; }

    protected Base()
    {
        Length = CalculateLength();
    }

    protected virtual int CalculateLength()
    {
        return 0;
    }
}
```

We already discussed what is the problem with this code in another article:

- If a derived class overrides the virtual method and, in that method uses fields that are initialized by the derived constructor, by the time the virtual method is executed, the fields are not really initialized because the derived constructor is not yet executed.

## Proposed solution

The basic idea is to split the initialization process into two sections:

- one section, containing the safe instructions, that will remain in the constructor.
- a second section, containing the unsafe virtual calls, that are moved into a separate public method that is usually called `Initialize`.

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

### A problem arise

But, after doing so, the `Initialize` method must be manually called after the constructor to complete the initialization, before the instance can be used. If the method is not called, the instance is half-way initialized and cannot be used yet.

### Use a flag

To prevent the usage of a half-way initialized instance, we must implement a mechanism. The simplest way to do this is to use a flag initially set on false, that will be set on true by the `Initialize` method:

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
    
    ...
}
```

Then, each public method must use the flag to verify that the instance is fully initialized and throw an exception to prevent the execution if initialization is not completed.

```csharp
internal class Base
{
    protected bool IsInitialized { get; private set; }

    ...

    public void DoSomething()
    {
        if (!IsInitialized)
            throw new NotInitializedException(GetType());

        // do what we need to do
    }
}
```

Same flag must be used from all the public methods of the derived class:

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

