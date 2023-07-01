using System;
using System.Linq;
using MessagePack;
using MessagePack.Resolvers;
using NUnit.Framework;
using Sample.WithAsmdef;
using Sample.WithAsmdef2;

namespace Test
{
    using Random = UnityEngine.Random;

    public class CodeGenTest
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            MessagePackSerializer.DefaultOptions = MessagePackSerializerOptions.Standard
                .WithResolver(CompositeResolver.Create(
                    StandardAotResolver.Instance,
                    global::HogeHoge.GeneratedMessagePackResolver.Instance,
                    Sample.WithAsmdef.GeneratedMessagePackResolver.Instance));
        }

        [Test]
        public void ErrorWithoutResolver()
        {
            var x = new Data01
            {
                Value = Random.Range(1, int.MaxValue),
            };

            // without generated resolver
            Assert.Throws<MessagePackSerializationException>(() => MessagePackSerializer.Serialize(x, MessagePackSerializerOptions.Standard));
        }

        [Test]
        public void Test01()
        {
            var value = Random.Range(1, int.MaxValue);

            var x = new Data01
            {
                Value = value,
            };

            var bytes = MessagePackSerializer.Serialize(x);

            var y = MessagePackSerializer.Deserialize<Data01>(bytes);

            Assert.AreEqual(value, y.Value);
        }

        [Test]
        public void Test02()
        {
            var value = Random.Range(1, int.MaxValue).ToString();

            var x = new Data02
            {
                Value = value,
            };

            var bytes = MessagePackSerializer.Serialize(x);

            var y = MessagePackSerializer.Deserialize<Data02>(bytes);

            Assert.AreEqual(value, y.Value);
        }

        [Test]
        public void Test03()
        {
            var value = ((MyEnum[])Enum.GetValues(typeof(MyEnum)))
                .OrderBy(_ => Guid.NewGuid())
                .First();

            var x = new Data03
            {
                Value = value,
            };

            var bytes = MessagePackSerializer.Serialize(x);

            var y = MessagePackSerializer.Deserialize<Data03>(bytes);

            Assert.AreEqual(value, y.Value);
        }

        /// <summary>
        /// https://github.com/neuecc/MessagePack-CSharp/issues/1563
        /// </summary>
        [Test]
        public void Test04()
        {
            var value = ((UnityEngine.KeyCode[])Enum.GetValues(typeof(UnityEngine.KeyCode)))
                .OrderBy(_ => Guid.NewGuid())
                .First();

            var x = new TestClass
            {
                Key = value,
            };

            var bytes = MessagePackSerializer.Serialize(x);

            var y = MessagePackSerializer.Deserialize<TestClass>(bytes);

            Assert.AreEqual(value, y.Key);
        }

        [MessagePackObject]
        public class Data01
        {
            [Key(0)]
            public int Value { get; set; }
        }
    }
}