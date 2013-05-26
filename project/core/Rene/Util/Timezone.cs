using System;
using System.Collections;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Markup;
using System.Windows.Input;
using System.Windows.Media.Animation;



using Rene;
using Rene.Event;
using Rene.Controller;
using Rene.Model;
using System.Data;

using Rene.DataObject;
namespace Rene.Util
{
	public static class Timezone
	{
		public static DateTime Convert(DateTime StartDate, string StartTimezone, string EndTimezone)
		{
			return StartDate.AddHours(Timezone.Difference(StartTimezone, EndTimezone));
		}

		public static int Difference(string StartTimezone, string EndTimezone)
		{
			return Timezone.GMT(StartTimezone) - Timezone.GMT(EndTimezone);
		}

		public static int GMT(string TimeZone)
		{
			int s = 0;
			if (TimeZone == "EST")
			{
				s = -5;
			}
			else if (TimeZone == "CST")
			{
				s = -6;
			}
			else if (TimeZone == "CST")
			{
				s = -7;
			}
			else if (TimeZone == "CST")
			{
				s = -8;
			}
			return s;
		}
	}
}
