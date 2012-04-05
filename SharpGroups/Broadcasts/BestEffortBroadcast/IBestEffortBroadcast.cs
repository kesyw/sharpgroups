namespace SharpGroups.Broadcasts.BestEffortBroadcast
{
    public delegate void ReceiveDelegate (object source, object target, byte[] message);

    public interface IBestEffortBroadcast
    {
        void Send (object source, object[] targets, byte[] message);
        event ReceiveDelegate Receive;
    }
}
