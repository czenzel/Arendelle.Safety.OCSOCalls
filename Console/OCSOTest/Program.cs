using System;
using System.IO;
using System.Linq;
using Arendelle.Safety.OCSOCalls.Orange;
using Arendelle.Safety.OCSOCalls.Core.Extensions;
using System.Threading.Tasks;

namespace OCSOTest
{
    class Program
    {
        // This app could use a lot of clean up but expand into a nice functioning web site / module

        static void Main(string[] args)
        {
            Console.WriteLine(EmbeededText("About.txt"));
            Console.WriteLine();

            Task objCurrentTask;

            while (true)
            {
                objCurrentTask = Task.Run(() =>
                {
                    Refresh();
                });
                System.Threading.Thread.Sleep(1000 * 120);
            }
        }

        static DateTime DataRefresh { get; set; }

        static void Refresh()
        {
            var objResult = Client.GetActive();
            DataRefresh = DateTime.Now;

            var Calls = objResult.Where(a => FilterZones.Contains(a.ZoneAsNumeric())).ToArray();

            Console.Clear();

            string strHeader = @"These are the Calls for Service in Bay Lake, Florida [Zone 60 + 61]";
            Console.WriteLine(strHeader);
            Console.WriteLine();

            var objTable = new ConsoleTables.ConsoleTable(
                @"Incident (ID/PK)",
                @"Dispatch Entry",
                @"Description",
                @"Location",
                @"Active Time"
            );

            foreach (var objCall in Calls)
            {
                var tsActive = objCall.TimeActive();
                string strActive = "N/A";

                if (tsActive.TotalMinutes <= 3)
                {
                    strActive = string.Format("{0:0.0} seconds", tsActive.TotalSeconds);
                }
                else if (tsActive.TotalMinutes <= 60)
                {
                    strActive = string.Format("{0:0.0} minutes", tsActive.TotalMinutes);
                }
                else
                {
                    strActive = string.Format("{0:0.0} hours", tsActive.TotalHours);
                }

                objTable.AddRow(objCall.ID,
                    objCall.EntryAsTimestamp(),
                    objCall.Description,
                    objCall.Location,
                    strActive);
            }

            objTable.Write();

            Console.WriteLine();
            Console.WriteLine(string.Format("Last Data Refresh: {0}", DataRefresh));
        }

        static int[] FilterZones
        {
            get;
        } = new int[] { 60, 61 };

        static string EmbeededText(string Resource)
        {
            var objAssembly = typeof(Program).Assembly;
            var objStream = objAssembly.GetManifestResourceStream(string.Format("OCSOTest.{0}", Resource));

            var objReader = new StreamReader(objStream);
            var strText = objReader.ReadToEnd();
            objReader.Close();
            objStream.Close();

            return strText;
        }
    }
}
