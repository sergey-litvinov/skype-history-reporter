using System.Collections.Generic;
using System.IO;

namespace SkypeHistory.Entities.Reports
{
    public class ReportContext
    {
    	public ReportContext()
    	{
    		Parameters = new Dictionary<string, ReportParameters>();
    	}

    	public StreamWriter Writer { get; set; }

    	public Dictionary<string, ReportParameters> Parameters { get; set; }
    }
}