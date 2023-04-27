using MessagePack;

namespace Sample.WithAsmdef
{
    public static class GeneratedMessagePackResolver
    {
        /// <summary>
        /// manualy export
        /// </summary>
        public static IFormatterResolver Instance => MessagePack.GeneratedMessagePackResolver.Instance;
    }
}