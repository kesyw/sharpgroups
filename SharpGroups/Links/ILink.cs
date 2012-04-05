namespace SharpGroups.Links
{
    /// <summary>
    /// Standard link receive delegate.
    /// </summary>
    public delegate void ReceiveDelegate<in TP, in TM> (TP source, TP target, TM message);

    /// <summary>
    /// Standard link interface.
    /// </summary>
    /// <typeparam name="TP">process ID type</typeparam>
    /// <typeparam name="TM">message type</typeparam>
    public interface ILink<TP,TM>
    {
        /// <summary>
        /// Sends a message to a given process. No guarantees.
        /// </summary>
        void Send (TP source, TP target, TM message);

        /// <summary>
        /// Standard link delivery event.
        /// </summary>
        event ReceiveDelegate<TP,TM> Receive;
    }
}
