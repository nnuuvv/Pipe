# nuv.Pipe

Pipelining similar to |> from F# / Gleam in C#

### Usage

```csharp
var someString = "some string";

someString.Into(x => Console.WriteLine("The string is: " + x));

someString
    .Into(x => x.Length)
    .Into(x => "The strings length is: " + x)
    .Into(Console.WriteLine);

// Including async/task support
var task = Task.Run(() => "Something");

var result = await task
    .AwaitInto(x => x.Length)
    .AwaitInto(x => "The Task's string length is: " + x)
    .AwaitInto(Console.WriteLine);
```