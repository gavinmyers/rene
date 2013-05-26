using System;
using System.Collections.Generic;
using System.Text;

namespace Rene.Util
{
	public static class DistanceUtil
	{
		//HTTP http = new HTTP();
		//MessageBox.Show(http.HttpPost("http://rpc.geocoder.us/service/csv", "address=1221%20jackson%20st,%20lacrosse,%20wi,%2054601"));

		public static double Distance(double lat1, double lon1, double lat2, double lon2)
		{
			double theta = lon1 - lon2;
			double dist = Math.Sin(deg2rad(lat1)) * Math.Sin(deg2rad(lat2)) + Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) * Math.Cos(deg2rad(theta));
			dist = Math.Acos(dist);
			dist = rad2deg(dist);
			dist = dist * 60 * 1.1515;
			return (dist);
		}

		//:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
		//::  This function converts decimal degrees to radians             :::
		//:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
		private static double deg2rad(double deg)
		{
			return (deg * Math.PI / 180.0);
		}

		//:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
		//::  This function converts radians to decimal degrees             :::
		//:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
		private static double rad2deg(double rad)
		{
			return (rad / Math.PI * 180.0);
		}
	}
}
