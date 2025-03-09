// See https://aka.ms/new-console-template for more information
using ClassLibrary1;
using MessagePack;

try
{
    var result = MessagePackSerializer.Serialize(new Sample(SampleEnum.A));
    Console.WriteLine(string.Join(", ", result));
}
catch (Exception ex)
{
    Console.Error.WriteLine(ex.Message);
}

Console.ReadKey();

[MessagePackObject]
public record Sample(
    [property: Key(0)] SampleEnum Value);
