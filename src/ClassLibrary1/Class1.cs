using System;
using MessagePack;

namespace ClassLibrary1
{
    public class Class1
    {
        public void Test()
        {
            // generated resolver            
            _ = GeneratedMessagePackResolver.Instance;
        }

    }

    [MessagePackObject]
    public class Class2
    {
        [Key(0)]
        public int Value { get; set; }
    }
}
