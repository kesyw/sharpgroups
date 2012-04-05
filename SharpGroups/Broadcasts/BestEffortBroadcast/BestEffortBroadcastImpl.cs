using System;
using SharpGroups.Links.PerfectLinks;

namespace SharpGroups.Broadcasts.BestEffortBroadcast
{
    public class BestEffortBroadcastImpl : IBestEffortBroadcast, IDisposable
    {
        public event ReceiveDelegate Receive;

        private readonly IPerfectLink perfectLink;
        private bool disposed;

        public BestEffortBroadcastImpl (IPerfectLink perfectLink)
        {
            this.perfectLink = perfectLink;
            perfectLink.Receive += Deliver;
        }

        public void Dispose ()
        {
            if (!disposed)
            {
                perfectLink.Receive -= Deliver;
            }
            disposed = true;
        }

        private void Deliver (object source, object target, byte[] message)
        {
            var handler = Receive;
            if (handler != null)
                handler (source, target, message);
        }

        public void Send (object source, object[] targets, byte[] message)
        {
            if (targets != null)
                foreach (var target in targets)
                    perfectLink.Send (source, target, message);
        }
    }
}