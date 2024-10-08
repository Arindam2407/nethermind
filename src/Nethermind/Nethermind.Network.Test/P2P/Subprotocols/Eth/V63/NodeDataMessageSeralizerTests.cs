// SPDX-FileCopyrightText: 2022 Demerzel Solutions Limited
// SPDX-License-Identifier: LGPL-3.0-only

using System;
using Nethermind.Core.Collections;
using Nethermind.Core.Test.Builders;
using Nethermind.Network.P2P.Subprotocols.Eth.V63.Messages;
using NUnit.Framework;

namespace Nethermind.Network.Test.P2P.Subprotocols.Eth.V63
{
    [Parallelizable(ParallelScope.All)]
    public class NodeDataMessageSerializerTests
    {
        private static void Test(IOwnedReadOnlyList<byte[]> data)
        {
            using NodeDataMessage message = new(data);

            NodeDataMessageSerializer serializer = new();
            SerializerTester.TestZero(serializer, message);
        }

        [Test]
        public void Roundtrip()
        {
            using ArrayPoolList<byte[]> data = new(3) { TestItem.KeccakA.BytesToArray(), TestItem.KeccakB.BytesToArray(), TestItem.KeccakC.BytesToArray() };
            Test(data);
        }

        [Test]
        public void Zero_roundtrip()
        {
            using ArrayPoolList<byte[]> data = new(3) { TestItem.KeccakA.BytesToArray(), TestItem.KeccakB.BytesToArray(), TestItem.KeccakC.BytesToArray() };
            Test(data);
        }

        [Test]
        public void Roundtrip_with_null_top_level()
        {
            Test(null);
        }

        [Test]
        public void Roundtrip_with_nulls()
        {
            using ArrayPoolList<byte[]> data = new(3) { TestItem.KeccakA.BytesToArray(), Array.Empty<byte>(), TestItem.KeccakC.BytesToArray() };
            Test(data);
        }
    }
}
