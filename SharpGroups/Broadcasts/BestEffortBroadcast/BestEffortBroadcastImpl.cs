using System;
using SharpGroups.Links.PerfectLinks;

namespace SharpGroups.Broadcasts.BestEffortBroadcast
{
    /// <summary>
    /// Best Effort Broadcast implementation.
    /// </summary>
    /// <typeparam name="TProcess">process ID type</typeparam>
    /// <typeparam name="TMessage">message type</typeparam>
    public class BestEffortBroadcastImpl<TProcess, TMessage> : IBestEffortBroadcast<TProcess, TMessage>, IDisposable
        where TMessage : class
    {
        /// <summary>
        /// Best Effort Broadcast delivery event.
        /// </summary>
        public event ReceiveDelegate<TProcess, TMessage> Receive;

        private IPerfectLink<TProcess, TMessage> perfectLink;
        private bool disposed;

        public BestEffortBroadcastImpl (IPerfectLink<TProcess, TMessage> perfectLink)
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

        private void Deliver (TProcess source, TProcess target, TMessage message)
        {
            var handler = Receive;
            if (handler != null)
                handler (source, target, message);
        }

        /// <summary>
        /// Broadcasts a message. Provides Best Effort Broadcast guarantees.
        /// </summary>
        public void Send (TProcess source, TProcess[] targets, TMessage message)
        {
            if (disposed) throw new ObjectDisposedException (GetType ().FullName);

            if (targets != null)
                foreach (var target in targets)
                    perfectLink.Send (source, target, message);
        }
    }
}