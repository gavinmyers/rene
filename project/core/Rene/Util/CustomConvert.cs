using System;
using System.Collections.Generic;
using System.Text;

namespace Rene.Util
{
	public static class CustomConvert
	{
		public static string DateDiff(DateTime inDate1, DateTime inDate2)
		{

			TimeSpan t1 = inDate2.Subtract(inDate1);

			if (t1.TotalHours < 48)
			{
				return Math.Round(t1.TotalHours, 0) + "" + " hrs";
			}
			else
			{
				return Math.Round(t1.TotalDays, 0) + "" + " days";
			}
		}
	}
}
