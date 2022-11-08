using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messagin
{
    public interface ITableBlocked
    {
        public Guid orderId { get; }
        public Guid ClientId { get; }
        public Dish? Preorder { get; }
        public bool Succes { get; }

    }
}
