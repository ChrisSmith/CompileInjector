# CompileInjector
Compile Time Dependency Injection Using Roslyn 


# Why
Primarily its a proof of concept using a `ICompileModule` to perform compile tasks. Dependency injection is typically a runtime process, so it can be very slow because it involves reflection, CompileInjector generates code at compile time to avoid this runtime cost. Its a POC and not production ready.

# Build

```sh
git clone git@github.com:ChrisSmith/CompileInjector.git
cd CompileInjector/CompileInjectorTest
dnu restore
dnu build
dnx run
```

# How it works
CompileInjector is implemented as an `ICompileModule` which allows it to run as part of your build process. It modifies the Abstract Syntax Tree that Roslyn provides it so can add aditional functionality (dependency injection in our case). 

The premise is that all classes with a special attribute `[RegisterService]` will get a method added to the class at compile time. This method is called `Factory()` and it returns an instance of the class.


Annotated code
```cs
[RegisterService]
public class Foo
{
    private Bar _bar;

    public Foo(Bar bar)
    {
        _bar = bar;
    }
}

[RegisterService]
public class Bar
{

}

```

Generated code
```cs
[RegisterService]
public class Foo
{
    private Bar _bar;

    public Foo(Bar bar)
    {
        _bar = bar;
    }
    
    public static Foo Factory(){
        return new Foo(Bar.Factory());
    }
}

[RegisterService]
public class Bar
{
    public static Bar Factory(){
        return new Bar();
    }
}

```




# Whats Next?

It'd be interesting to make this a real library. There's a lot we can learn from the implementation of [Dagger](https://github.com/google/dagger) which has the same goals but for Java. 

Major Tasks
- Allow interfaces to be injected
- Support for lifetime scopes (like singleton)
