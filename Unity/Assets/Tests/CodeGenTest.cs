using System;
using MessagePack;
using MessagePack.Resolvers;
using NUnit.Framework;
using Sample.WithAsmdef;
using UnityEngine;

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
                    global::MessagePack.GeneratedMessagePackResolver.Instance,
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

        [MessagePackObject]
        public class Data01
        {
            [Key(0)]
            public int Value { get; set; }
        }
    }
}