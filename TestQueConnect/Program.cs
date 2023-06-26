using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QueueConnect;

namespace TestQueConnect
{
    class Program
    {
        static void Main(string[] args)
        {
            
            /*
             * These settings are best to be read from config file; Url & Serviceid
             */
            string serverIp = "10.10.10.171"; //url to be connected to the queue machine
            string db = "UniQUEUE"; //database to connect 
            int serviceId = 1; //Service id set by the queue system; i,e Deposit,Cash..etc.
            if (args != null && args.Length > 0) {
                serverIp = args[0] != null ? args[0] : serverIp;
                db = args[1] != null ? args[1] : db;
                serviceId = args[2] != null ? Int32.Parse(args[2]) : serviceId;
            }
            try
            {
                Queue q = new Queue();

                /*
                 * @input string ip, string db, int serviceId; Mandatory
                 * @returns  <QueueNo>##<ComeTime>
                 * Or throws exceptions
                 */
                String result = q.getQueue(serverIp,db,serviceId);
                Console.WriteLine("Raw Output: "+result); // raw result
                String[] data = result.Split(new string[] { "##" }, StringSplitOptions.None);
                Console.WriteLine(data[0]); // queue number
                Console.WriteLine(data[1]); // Come time
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.Read();
        }
    }
}
