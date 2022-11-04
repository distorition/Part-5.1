using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafka
{
    public class MessageProducer
    {
        private readonly IConfiguration configuration;
        public MessageProducer(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

    }
}
