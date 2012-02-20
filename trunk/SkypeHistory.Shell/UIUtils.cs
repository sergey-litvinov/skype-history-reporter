using System;
using System.Collections;
using System.Text;
using System.Windows.Forms;

namespace SkypeHistory.Shell
{
	public class UIUtils
	{
		public static void ShowException(Exception exception, bool closeApp)
		{
			StringBuilder builder = new StringBuilder();
			while (exception != null)
			{
				builder.AppendLine(exception.ToString());
				exception = exception.InnerException;
				if (exception != null)
					builder.Append("Inner error:");
			}
			MessageBox.Show("There was an error." + builder, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
			if (closeApp)
			{
				Application.Exit();
			}
		}
	}
}