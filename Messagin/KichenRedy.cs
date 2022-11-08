namespace Messagin
{
    public class KichenRedy : IKitchenRedy
    {
        public KichenRedy(Guid order,bool redy)
        {
            order=OrderId;
            redy=Redy;
        }

        public Guid OrderId { get; }

        public bool Redy { get; }
        
    }
}
