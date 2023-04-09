using MessagePack;
using Sample.WithAsmdef2;

namespace Sample.WithAsmdef
{
    [MessagePackObject]
    public class Data03
    {
        [Key(0)]
        public MyEnum Value { get; set; }
    }
}