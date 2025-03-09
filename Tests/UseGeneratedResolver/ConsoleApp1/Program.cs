// See https://aka.ms/new-console-template for more information
using ClassLibrary1;
using MessagePack;
using MessagePack.Formatters;
using MessagePack.Resolvers;

// use default
// Start Debugging using Visual Studio -> success
// dotnet publish and run ConsoleApp1.exe -> "Failed to serialize Sample value.", "A type initializer threw an exception. To determine which type, inspect the InnerException's StackTrace property."
Execute(null);

// Start Debugging using Visual Studio -> success
// dotnet publish and run ConsoleApp1.exe -> "Failed to serialize Sample value.", "No parameterless constructor defined for type 'MessagePack.Formatters.GenericEnumFormatter`1[ClassLibrary1.SampleEnum]'."
Execute(MessagePackSerializerOptions.Standard.WithResolver(CompositeResolver.Create(SourceGeneratedFormatterResolver.Instance, DynamicGenericResolver.Instance)));

// Start Debugging using Visual Studio -> success
// dotnet publish and run ConsoleApp1.exe -> success
Execute(MessagePackSerializerOptions.Standard.WithResolver(CompositeResolver.Create([new GenericEnumFormatter<SampleEnum>()], [SourceGeneratedFormatterResolver.Instance])));

Console.ReadKey();

void Execute(MessagePackSerializerOptions? options)
{
    try
    {
        var result = MessagePackSerializer.Serialize(new Sample(SampleEnum.A), options: options);
        Console.WriteLine($"success: " + string.Join(", ", result));
    }
    catch (Exception ex)
    {
        Console.Error.WriteLine(ex.Message);
        Console.Error.WriteLine(ex.InnerException?.Message);
    }
}

[MessagePackObject]
public record Sample(
    [property: Key(0)] SampleEnum Value);
