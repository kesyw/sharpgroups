namespace SharpGroups.Links.PerfectLinks
{
    /// <summary>
    /// Perfect link capabilities. Send guarantees reliable delivery, no duplication, no creation.
    /// </summary>
    /// <typeparam name="TP">process ID type</typeparam>
    /// <typeparam name="TM">message type</typeparam>
    public interface IPerfectLink<TP, TM>
    {
        /// <summary>
        /// Sends a message to a given process. Guarantees reliable delivery, no duplication, no creation.
        /// </summary>
        void Send (TP source, TP target, TM message);

        /// <summary>
        /// Perfect link delivery event.
        /// </summary>
        event ReceiveDelegate<TP, TM> Receive;
    }
}
