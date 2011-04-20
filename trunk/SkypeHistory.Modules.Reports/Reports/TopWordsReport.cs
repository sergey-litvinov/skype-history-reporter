using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Practices.Unity;
using SkypeHistory.Entities.Reports;
using SkypeHistory.Infrastructure.Generators;
using SkypeHistory.Interfaces.Generators;

namespace SkypeHistory.Modules.MonthReport
{
    public class TopWordsReport : MessageReportGenerator
    {
        [Dependency]
        public ITableWriter TableWriter { get; set; }

        [Dependency]
        public ICommonWriter CommonWriter { get; set; }

        public override string Name
        {
            get { return "Top words report"; }
        }

        public override void Generate(ReportContext context)
        {
            var result = new Dictionary<string, int>(StringComparer.CurrentCultureIgnoreCase);
            var messages = GetMessages();
            var smileRegex = new Regex("<[^>]*>", RegexOptions.Compiled | RegexOptions.CultureInvariant);
            foreach (var message in messages)
            {
                if (string.IsNullOrWhiteSpace(message.Text))
                    continue;
                var text = message.Text;
                text = smileRegex.Replace(text, string.Empty);
                var words = text.Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in words)
                {
                    if (word.Length <= 1) continue;
                    if (result.ContainsKey(word))
                    {
                        result[word]++;
                    }
                    else
                    {
                        result.Add(word, 1);
                    }
                }
            }
            CommonWriter.WriteTitle(context, "Report by top words");
            TableWriter.WriteHeader(context, "Word", "Count");
            foreach (var item in result.OrderByDescending(i => i.Value).Take(40))
            {
                TableWriter.WriteBody(context, item.Key, item.Value.ToString());
            }
            TableWriter.WriteFooter(context);
        }
    }
}