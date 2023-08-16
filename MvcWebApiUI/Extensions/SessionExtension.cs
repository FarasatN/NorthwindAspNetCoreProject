using Newtonsoft.Json;

namespace MvcWebUI.Extensions
{
	public static class SessionExtension
	{
		public static void SetObject(this ISession session,string key, object obj)
		{
			string objectstring = JsonConvert.SerializeObject(obj);
			session.SetString(key, objectstring);
		}

		public static T GetObject<T>(this ISession session,string key) where T : class
		{
			string objectstring = session.GetString(key);
			if (string.IsNullOrEmpty(objectstring))
			{
				return null;
			}
			else
			{
				T value = JsonConvert.DeserializeObject<T>(objectstring);
				return value;
			}
		}
	}
}
