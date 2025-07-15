# SimpleScript

SimpleScript is an experimental scripting language and interpreter written in C#. The project started as a learning exercise but has grown into a small yet functional platform for running `.sc` scripts. It features a minimal syntax influenced by other dynamic languages and provides a handful of built‑in utilities for experimenting with language design.

## Key Features

- **Variables and Types** – supports `int`, `string`, `double`, `bool` and several pointer types.
- **Arrays** – typed arrays with automatic allocation and indexing helpers.
- **Control Flow** – `if`, `elif`, `else` and `while` blocks are parsed by the interpreter.
- **Methods** – the `.method` keyword allows declaring, calling and overwriting script functions.
- **Include System** – scripts can include other files or import single methods.
- **Memory Utilities** – a simple watcher lets the interpreter roll back changes when evaluating expressions.
- **Helper Library** – `testlib` exposes small C# helpers that scripts can call.

## Getting Started

1. **Clone** the repository.
2. **Build** using the .NET CLI:
   ```bash
   dotnet build Lexer.sln
   ```
   (The Codex environment may not have the `dotnet` command installed. If so, install the .NET SDK first.)
3. **Run** a script:
   ```bash
   Lex path/to/file.sc
   ```

### Example

```text
string message = "Hello";
.method call Print from testlib.sc
call::local Print(message)
```

The above snippet prints a greeting using the helper library.

## Repository Layout

```
Lexer/     – interpreter and core language files
EJE/       – command line entry point
Test/      – example projects
Test43/    – additional sample scripts
testlib/   – C# helper library
```

## Project Structure

The interpreter lives in `Lexer/` and is made up of several modules:

- `Lexer.cs` – main loop that processes tokens and dispatches handlers.
- `ConditionsHandler.cs` – evaluates `if`/`while` statements.
- `MethodHandler.cs` – creates and invokes methods defined with `.method`.
- `ValueHandler.cs` – parses assignments and arithmetic expressions.
- `MemoryHandler.cs` – stores variables and provides rollback when evaluating conditions.

Each module has inline comments explaining its public API and major routines.

## Extending

SimpleScript is intentionally small. Feel free to explore the interpreter source and add new operations or library functions. Most functionality is driven by regular expressions, so new syntax can often be implemented by adjusting the handlers.

## License

This project currently has no formal license. Use at your own risk.
