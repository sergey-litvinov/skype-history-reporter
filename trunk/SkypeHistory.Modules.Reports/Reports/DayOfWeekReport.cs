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
    public class DayOfWeekReport : MessageReportGenerator
    {
        [Dependency]
        public ITableWriter TableWriter { get; set; }

        [Dependency]
        public ICommonWriter CommonWriter { get; set; }

        public override string Name
        {
            get { return "Hour report"; }
        }

        public override void Generate(ReportContext context)
        {
            var result = new Dictionary<string, Dictionary<DayOfWeek, int>>();
            var messages = GetMessages();
            foreach (var message in messages)
            {
                var day = message.Timestamp.DayOfWeek;
                Dictionary<DayOfWeek, int> childDict;
                if (!result.ContainsKey(message.Author))
                {
                    childDict = new Dictionary<DayOfWeek, int>();
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
            }
            CommonWriter.WriteTitle(context, "Report by day of week message count");

            GenerateHeader(context);
            Dictionary<string, string> normalNames =
                result.Select(pair => new Tuple<string, string>(GetMember(pair.Key).DisplayName, pair.Key)).OrderBy(
                    i => i.Item1).ToDictionary(i => i.Item1, i => i.Item2);


            foreach (var key in normalNames)
            {
                var value = result[key.Value];
                List<string> data = new List<string>();
                data.Add(key.Key);
                foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
                {
                    if (value.ContainsKey(day))
                    {
                        data.Add(value[day].ToString());
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

        private void GenerateHeader(ReportContext context)
        {
            List<string> header = new List<string>();
            header.Add("Author");
            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
            {
                header.Add(day.ToString());
            }
            TableWriter.WriteHeader(context, header.ToArray());
        }
    }
}