# IMO Script Lexer

IMO is a small scripting language runtime and lexer written in C#. It provides a lightweight interpreter capable of loading custom script files, handling basic operations and calling .NET methods.

## Features

- **Dynamic Memory**: Values are stored in a runtime dictionary allowing dynamic assignment and retrieval via `ValueHandler`.
- **Arithmetic Operations**: `Add` and `Sub` keywords perform simple arithmetic on existing variables.
- **Arrays**: Basic array declaration and element access through `ArraysHandler`.
- **Conditions and Loops**: `if` and `while` blocks are supported by `ConditionsHandler`.
- **Method Calls**: Script methods can be created, overwritten and invoked. Built in support exists for calling local functions or .NET methods.
- **Include Support**: External script files may be included using `.include` syntax.
- **Error Handling**: `ErrorHandler` prints helpful error messages with line information.

## Building

This repository contains multiple .NET projects targeting **.NET 8.0**. Use the solution file `Lexer.sln` to build everything:

```bash
 dotnet build Lexer.sln
```

## Usage

To execute a script file using the `Lex` console app:

```bash
 dotnet run --project EJE/Lex.csproj <path to script>
```

Alternatively, the `Test` project contains a minimal example that runs a hard coded script when executed:

```bash
 dotnet run --project Test/Test.csproj
```

## Example Script

```text
string Text = Hello World
.method call [System]Console.WriteLine(string<-Text)
```

This will store a string and print it using `Console.WriteLine`.

## Repository Layout

- **Lexer** – Core library containing the interpreter and helper classes.
- **EJE** – Console application that loads and runs a script file provided as an argument.
- **Test** – Simple test project demonstrating usage.
