namespace SharpGroups.Links.PerfectLinks
{
    /// <summary>
    /// Perfect link capabilities. Send guarantees reliable delivery, no duplication, no creation.
    /// </summary>
    /// <typeparam name="TProcess">process ID type</typeparam>
    /// <typeparam name="TMessage">message type</typeparam>
    public interface IPerfectLink<TProcess, TMessage>
    {
        /// <summary>
        /// Sends a message to a given process. Guarantees reliable delivery, no duplication, no creation.
        /// </summary>
        void Send (TProcess source, TProcess target, TMessage message);

        /// <summary>
        /// Perfect link delivery event.
        /// </summary>
        event ReceiveDelegate<TProcess, TMessage> Receive;
    }
}
