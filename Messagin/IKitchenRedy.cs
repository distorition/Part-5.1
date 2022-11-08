using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messagin
{
    public interface IKitchenRedy
    {
        public Guid OrderId { get; }
        public bool Redy { get; }

    }
}
