# OneQubit's CodeLibrary

This is my personal Code Library, which I will be maintaining on GitHub and distributing as a NuGet package

** Prerequisites

Primary prerequisite is a high-level of tolerance for code smell and anti-patterns.

## Built With

* [Visual Studio 2017 Community](https://visualstudio.microsoft.com/vs/community/)
* [.NET Core 2.1](https://dotnet.microsoft.com/download/dotnet-core/2.1)

## Contributing

Please read [CONTRIBUTING.md](https://gist.github.com/PurpleBooth/b24679402957c63ec426) for details on our code of conduct, and the process for submitting pull requests to us.

## Author

* **Alfred Aquino** - *Initial work* - [onequbit](https://github.com/onequbit)

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Acknowledgments

* I acknowledge that this library is pretty horrible and I am a terrible person for inflicting it on the world.
* mwahahaha

## Code:

*class CLI:*
***CallCmd ( argstr )***
invokes argstr from cmd.exe

*class Console:*
***WaitForKeyPress ( message )***
writes a message to the console (without the EOL character) and waits for a key to be pressed before continuing

*class LibHash:*
***Sha256 ( rawData )***
takes the rawData string and returns a string representation of the SHA256 hash value in Hexadecimal characters

*class ThisApp:*
***Name***
returns a string containing the name of the currently executing program
(returns Environment.GetCommandLineArgs()[0];)

*class Lib:*
***RunTimer ( somethingToDo )***
uses a Stopwatch object to return the elapsed time for function delegate somethingToDo to run

*Extension Methods:*
***Join*** - concatenates the string representation of each element of T[] into a string with a given separator
***ForEach*** - a mapping function (with overloads)
***ToConsole*** - writes the string representation of this (almost any) object to the Console (with overloads)
***ToStringList<T>*** - converts IEnumerable<T> into a List<string>
***NumberString<T>*** - converts an IEnumberable<number> to a comma-separated string of numbers
***Product*** - computes the product of all elements of IEnumerable<int>
***Copy*** - creates a copy of this List<>
***ToHashSet*** - generates a HashSet from this List
***Last*** - returns the last item of this List
***CopyWith*** - uses this HashSet to create a copy
***IsEmpty*** - simple boolean test for this HashSet element count being zero
***Sum*** - returns the sum of elements in this HashSet<int>
***ThrowIfNull*** - throws a NullReferenceException if this object is null