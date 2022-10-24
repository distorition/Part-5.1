using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_5._1
{
    public class Table
    {
        public State _State { get;private set; }
        public int SitCounts { get;  }
        public int id { get; }
        public Random random = new Random();

        public Table( int id)
        { 
            _State = State.Free;
            SitCounts = random.Next(2, 5);
            this.id = id;
        }

        public bool SetState(State state)
        {
            //if(state == State.Free)
            //{
            //    _State=state;
            //    return true;
            //}
            //return false;
            if(state == _State)
            {
                return false;
            }
            _State = state;
            return true;
        }
    }
}
