using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;
using SkypeHistory.Entities.Reports;
using SkypeHistory.Infrastructure;
using SkypeHistory.Infrastructure.Generators;
using SkypeHistory.Interfaces.Generators;

namespace SkypeHistory.Modules.MonthReport
{
    public class DailyReport : MessageReportGenerator
    {
        [Dependency]
        public ITableWriter TableWriter { get; set; }

        [Dependency]
        public ICommonWriter CommonWriter { get; set; }

        public override string Name
        {
            get { return "Day report"; }
        }

        public override void Generate(ReportContext context)
        {
            var result = new Dictionary<string, Dictionary<short, int>>();
            var messages = GetMessages();
            var min = short.MaxValue;
            var max = short.MinValue;
            foreach (var message in messages)
            {
                short day = (short)message.Timestamp.Day;
                Dictionary<short , int> childDict;
                if (!result.ContainsKey(message.Author))
                {
                    childDict = new Dictionary<short, int>();
                    result.Add(message.Author, childDict);
                }
                else
                {
                    childDict = result[message.Author];
                }
                if (childDict.ContainsKey(day))
                {
                    childDict[day]++;
                }
                else
                {
                    childDict.Add(day, 1);
                }
                // for sorting purpose
                if (day > max)
                    max = day;
                if (day < min)
                    min = day;
            }
            CommonWriter.WriteTitle(context, "Report by days of month message count");

            GenerateHeader(context, min, max);
            Dictionary<string, string> normalNames =
                result.Select(pair => new Tuple<string, string>(GetMember(pair.Key).DisplayName, pair.Key)).OrderBy(
                    i => i.Item1).ToDictionary(i => i.Item1, i => i.Item2);


            foreach (var key in normalNames)
            {
                var value = result[key.Value];
                List<string> data = new List<string>();
                data.Add(key.Key);
                for (var i = min; i <= max; i++ )
                {
                    if (value.ContainsKey(i))
                    {
                        data.Add(value[i].ToString());
                    }
                    else
                    {
                        data.Add("0");
                    }
                }

                TableWriter.WriteBody(context, data.ToArray());
            }
            TableWriter.WriteFooter(context);
        }

        private void GenerateHeader(ReportContext context, short min, short max)
        {
            List<string> header = new List<string>();
            header.Add("Author");
            for (short i = min; i <= max; i++)
            {
                header.Add(i.ToString());
            }
            TableWriter.WriteHeader(context, header.ToArray());
        }
    }
}