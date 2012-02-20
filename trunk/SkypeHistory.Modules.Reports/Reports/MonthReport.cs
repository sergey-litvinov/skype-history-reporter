using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using SkypeHistory.Entities;
using SkypeHistory.Entities.Reports;
using SkypeHistory.Infrastructure;
using SkypeHistory.Infrastructure.Generators;
using SkypeHistory.Infrastructure.Net4Utils;
using SkypeHistory.Interfaces.Generators;

namespace SkypeHistory.Modules.MonthReport
{
	public class MonthReport : MessageReportGenerator, IChatReportGenerator
    {
        [Dependency]
        public ITableWriter TableWriter { get; set; }

        [Dependency]
        public ICommonWriter CommonWriter { get; set; }

        public override string Name
        {
            get { return "Month report"; }
        }

        public override void Generate(ReportContext context)
        {
            Dictionary<string, Dictionary<DateTime, int>> result = new Dictionary<string, Dictionary<DateTime, int>>();
            var messages = GetMessages();
            var minDate = DateTime.MaxValue;
            var maxDate = DateTime.MinValue;
            foreach (var message in messages)
            {
                var monthPart = DateUtils.GetMonth(message.Timestamp);
                Dictionary<DateTime, int> childDict;
                if (!result.ContainsKey(message.Author))
                {
                    childDict = new Dictionary<DateTime, int>();
                    result.Add(message.Author, childDict);
                }
                else
                {
                    childDict = result[message.Author];
                }
                if (childDict.ContainsKey(monthPart))
                {
                    childDict[monthPart]++;
                }
                else
                {
                    childDict.Add(monthPart, 1);
                }
                // for sorting purpose
                if (monthPart > maxDate)
                    maxDate = monthPart;
                if (monthPart < minDate)
                    minDate = monthPart;
            }
            CommonWriter.WriteTitle(context, "Report by month message count");

            GenerateHeader(context, minDate, maxDate);

            Dictionary<string, string> normalNames =
                result.Select(pair => new Tuple<string, string>(GetMember(pair.Key).DisplayName, pair.Key)).OrderBy(
                    i => i.Item1).ToDictionary(i => i.Item1, i => i.Item2);


            foreach (var key in normalNames)
            {
                var value = result[key.Value];
                List<string> data = new List<string>();
                data.Add(key.Key);
                for (DateTime item = minDate; item <= maxDate; item = item.AddMonths(1))
                {
                    if (value.ContainsKey(item))
                        data.Add(value[item].ToString());
                    else
                    {
                        data.Add("0");
                    }
                }

                TableWriter.WriteBody(context, data.ToArray());
            }
            TableWriter.WriteFooter(context);
        }

        private void GenerateHeader(ReportContext context, DateTime minDate, DateTime maxDate)
        {
            List<string> header = new List<string>();
            header.Add("Author");
            for (DateTime item = minDate; item <= maxDate; item = item.AddMonths(1))
            {
                header.Add(item.ToString("MMMM yyyy"));
            }
            TableWriter.WriteHeader(context, header.ToArray());
        }
    }
}