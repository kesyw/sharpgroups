namespace SharpGroups.Links
{
    /// <summary>
    /// Standard link receive delegate.
    /// </summary>
    public delegate void ReceiveDelegate<in TProcess, in TMessage> (TProcess source, TProcess target, TMessage message);

    /// <summary>
    /// Standard link interface.
    /// </summary>
    /// <typeparam name="TProcess">process ID type</typeparam>
    /// <typeparam name="TMessage">message type</typeparam>
    public interface ILink<TProcess, TMessage>
    {
        /// <summary>
        /// Sends a message to a given process. No guarantees.
        /// </summary>
        void Send (TProcess source, TProcess target, TMessage message);

        /// <summary>
        /// Standard link delivery event.
        /// </summary>
        event ReceiveDelegate<TProcess, TMessage> Receive;
    }
}
