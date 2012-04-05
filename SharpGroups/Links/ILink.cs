namespace SharpGroups.Links
{
    public delegate void ReceiveDelegate (object source, object target, byte[] message);

    public interface ILink
    {
        void Send (object source, object target, byte[] message);
        event ReceiveDelegate Receive;
    }
}
