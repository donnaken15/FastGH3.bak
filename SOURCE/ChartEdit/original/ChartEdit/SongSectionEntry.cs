using System;
using System.Text.RegularExpressions;

namespace ChartEdit
{
	// Token: 0x02000026 RID: 38
	public class SongSectionEntry
	{
		// Token: 0x0600012E RID: 302 RVA: 0x000067AC File Offset: 0x000049AC
		public static SongSectionEntry Parse(string entryStr)
		{
			Match match = SongSectionEntry.SongRegex.Match(entryStr);
			SongSectionEntry result;
			if (!match.Success)
			{
				result = null;
			}
			else
			{
				SongSectionEntry songSectionEntry = new SongSectionEntry();
				string key = match.Groups["key"].Value.Trim();
				string value = match.Groups["value"].Value.Trim().Trim("\"".ToCharArray());
				songSectionEntry.Key = key;
				songSectionEntry.Value = value;
				result = songSectionEntry;
			}
			return result;
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x0600012F RID: 303 RVA: 0x0000683C File Offset: 0x00004A3C
		// (set) Token: 0x06000130 RID: 304 RVA: 0x00006853 File Offset: 0x00004A53
		public string Key { get; set; }

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x06000131 RID: 305 RVA: 0x0000685C File Offset: 0x00004A5C
		// (set) Token: 0x06000132 RID: 306 RVA: 0x00006873 File Offset: 0x00004A73
		public string Value { get; set; }

		// Token: 0x040000C2 RID: 194
		private static readonly Regex SongRegex = new Regex("(?<key>.+)\\s*\\=\\s*(?<value>.+)", RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);
	}
}
