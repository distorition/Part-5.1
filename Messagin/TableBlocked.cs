namespace Messagin
{
    public class TableBlocked:ITableBlocked
    {
        public TableBlocked(Guid orderid,Guid clietnId,bool succes,Dish? preorder=null)
        {
            orderid = orderId;
            clietnId = ClientId;
            preorder = Preorder;
            succes = Succes;
        }

        public Guid orderId { get; }

        public Guid ClientId { get; }

        public Dish? Preorder { get; }

        public bool Succes { get; }
    }
}
