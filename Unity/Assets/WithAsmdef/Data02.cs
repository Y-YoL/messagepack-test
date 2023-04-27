using MessagePack;

namespace Sample.WithAsmdef
{
    [MessagePackObject]
    public class Data02
    {
        [Key(0)]
        public string Value { get; set; }
    }
}