using Moq;
using NUnit.Framework;
using SharpGroups.Broadcasts.BestEffortBroadcast;
using SharpGroups.Links.PerfectLinks;

namespace SharpGroups.Tests.Broadcasts.BestEffortBroadcast
{
    [TestFixture]
    public class Test
    {
        [Test]
        public void DummyTest ()
        {
            var perfectLinkMock = new Mock<IPerfectLink> ();
            IBestEffortBroadcast bebcast = new BestEffortBroadcastImpl (perfectLinkMock.Object);
            var anyReceived = false;
            bebcast.Receive += delegate (object source, object target, byte[] message)
                {
                    anyReceived = true;
                };
            bebcast.Send (null, null, null);
            Assert.IsFalse (anyReceived);
        }
    }
}
