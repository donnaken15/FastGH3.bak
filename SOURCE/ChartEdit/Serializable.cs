using System;
using System.IO;
using System.Xml.Serialization;

namespace ChartEdit
{
	// Token: 0x02000014 RID: 20
	public class Serializable<T> where T : Serializable<T>
	{
		// Token: 0x060000C5 RID: 197 RVA: 0x00004474 File Offset: 0x00002674
		public static T Load(string fileName)
		{
			FileStream fileStream = null;
			T result = default(T);
			try
			{
				fileStream = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
				result = (T)((object)xmlSerializer.Deserialize(fileStream));
				fileStream.Close();
			}
			catch (Exception)
			{
				return default(T);
			}
			finally
			{
				if (fileStream != null)
				{
					fileStream.Close();
				}
			}
			return result;
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x0000450C File Offset: 0x0000270C
		public bool Save(string fileName)
		{
			return Serializable<T>.Save(fileName, (T)((object)this));
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x0000452C File Offset: 0x0000272C
		public static bool Save(string fileName, T data)
		{
			FileStream fileStream = null;
			bool result;
			try
			{
				fileStream = File.Create(fileName);
				new XmlSerializer(typeof(T)).Serialize(fileStream, data);
				fileStream.Close();
				result = true;
			}
			catch (Exception)
			{
				result = false;
			}
			finally
			{
				if (fileStream != null)
				{
					fileStream.Close();
				}
			}
			return result;
		}
	}
}
