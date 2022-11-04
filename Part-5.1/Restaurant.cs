using Messagin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_5._1
{
    public class Restaurant
    {
        private readonly List<Table> tables=new List<Table>();
        private readonly Producer producer = new Producer("BookingNotification", "localHost");
        public Restaurant()
        {
            for (ushort i = 1; i <= 10; i++)
            {
                tables.Add(new Table(i));
            }
        }

        public void BookFreeTable(int CounPerson)
        {
            Console.WriteLine("Подбираем столик");
            var table = tables.FirstOrDefault(t => t.SitCounts > CounPerson && t._State == State.Free);
           var bloc= table.SetState(State.Blocked);
            Thread.Sleep(1000*5);
            Console.WriteLine(table is null
                ? $"Все занято"
                :$"Нашли свободный столик{table.id}");
           Thread.Sleep(2000 * 10);
           bloc= table.SetState(State.Free);
        }

        public void BookFreeTableAsync(int countPerson)
        {
            Console.WriteLine("Search are table");
            Task.Run(async () =>
            {
                var table=tables.FirstOrDefault(t=>t.SitCounts>countPerson&&t._State==State.Free);
                await Task.Delay(1000*5);
                table.SetState(State.Blocked);
                producer.Send(table is null
                    ? "ВСе столики заняты"
                    : $"Готово ваш столик номер {table.id}");
                //Console.WriteLine(table is null 
                //    ?$"Now all table ocupate"
                //    :$"We find table {table.id}");
                //await Task.Delay(2000 * 10);
                //table.SetState(State.Free);

            });
        }
    }
}
