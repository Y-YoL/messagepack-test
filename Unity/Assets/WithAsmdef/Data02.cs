using MessagePack;

namespace Sample.WithAsmdef
{
    [MessagePackObject]
    public class WithAsmdef
    {
        [Key(0)]
        public string Value { get; set; }
    }
}