using MessagePack;

namespace Sample.WithAsmdef
{
    // https://github.com/neuecc/MessagePack-CSharp/issues/1563
    [MessagePack.MessagePackObject]
    public class TestClass
    {
        [Key(0)]
        public UnityEngine.KeyCode Key;
    }
}