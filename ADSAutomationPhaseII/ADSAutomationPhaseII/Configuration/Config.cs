using System;
using System.Collections.Generic;

namespace ADSAutomationPhaseII.Configuration
{
	public static class Config
	{
		public static string AppPath = System.Configuration.ConfigurationManager.AppSettings["APP_PATH"].ToString();
		public static int ProcessID;
		public static string TestCaseName;
		public static string ADSDB = "ads_db";
		public static string ADSDB_CAPS = "ADS_DB";
		public static string ADSDB1 = "ads_db1";
		public static string ADSDB1_CAPS = "ADS_DB1";
		public static string ADSTABLE = "ads_table";
		public static string AQUAFOLD = "aquafold";
		public static List<string> SchemaServers = new List<string> {"DB2 LUW 172.24.1.8 v11.1", "DB2 LUW 172.24.1.145 v10.5", "Oracle 172.24.1.140 v11g R2", "Oracle 172.24.1.199 v12.1.0.2.0", "Derby 172.24.1.199 v10.14", "Derby 172.24.1.8 v10.13"};
		public static double SIMILARITY = 0.75f;
	}
}
