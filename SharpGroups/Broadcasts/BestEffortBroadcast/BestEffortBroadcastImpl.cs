using System;
using SharpGroups.Links.PerfectLinks;

namespace SharpGroups.Broadcasts.BestEffortBroadcast
{
    /// <summary>
    /// Best Effort Broadcast implementation.
    /// </summary>
    /// <typeparam name="TP">process ID type</typeparam>
    /// <typeparam name="TM">message type</typeparam>
    public class BestEffortBroadcastImpl<TP,TM> : IBestEffortBroadcast<TP,TM>, IDisposable
        where TM : class
    {
        /// <summary>
        /// Best Effort Broadcast delivery event.
        /// </summary>
        public event ReceiveDelegate<TP,TM> Receive;

        private IPerfectLink<TP,TM> perfectLink;
        private bool disposed;

        public BestEffortBroadcastImpl (IPerfectLink<TP, TM> perfectLink)
        {
            if (perfectLink == null) throw new ArgumentNullException ("perfectLink");

            this.perfectLink = perfectLink;
            perfectLink.Receive += Deliver;
        }

        /// <summary>
        /// Disposes resources.
        /// </summary>
        public void Dispose ()
        {
            if (disposed) return;

            perfectLink.Receive -= Deliver;
            perfectLink = null;
            Receive = null;
            disposed = true;
        }

        private void Deliver (TP source, TP target, TM message)
        {
            var handler = Receive;
            if (handler != null)
                handler (source, target, message);
        }

        /// <summary>
        /// Broadcasts a message. Provides Best Effort Broadcast guarantees.
        /// </summary>
        public void Send (TP source, TP[] targets, TM message)
        {
            if (disposed) throw new ObjectDisposedException (GetType ().FullName);

            if (targets != null)
                foreach (var target in targets)
                    perfectLink.Send (source, target, message);
        }
    }
}