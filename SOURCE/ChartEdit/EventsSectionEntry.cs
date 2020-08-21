using System;
using System.Text.RegularExpressions;

namespace ChartEdit
{
	// Token: 0x0200002E RID: 46
	public class EventsSectionEntry
	{
		// Token: 0x06000162 RID: 354 RVA: 0x00007BEC File Offset: 0x00005DEC
		public static EventsSectionEntry Parse(string entryStr)
		{
			Match match = EventsSectionEntry.EventTextRegex.Match(entryStr);
			EventsSectionEntry eventsSectionEntry = new EventsSectionEntry();
			EventsSectionEntry result;
			if (!match.Success)
			{
				match = EventsSectionEntry.EventEffectRegex.Match(entryStr);
				if (!match.Success)
				{
					result = null;
				}
				else
				{
					int offset = int.Parse(match.Groups["offset"].Value.Trim());
					int effectType = int.Parse(match.Groups["type"].Value.Trim());
					int effectLength = int.Parse(match.Groups["len"].Value.Trim());
					eventsSectionEntry.Type = EventType.Effect;
					eventsSectionEntry.Offset = offset;
					eventsSectionEntry.EffectLength = effectLength;
					eventsSectionEntry.EffectType = effectType;
					result = eventsSectionEntry;
				}
			}
			else
			{
				int offset2 = int.Parse(match.Groups["offset"].Value.Trim());
				string textValue = match.Groups["value"].Value.Trim();
				eventsSectionEntry.Type = EventType.Text;
				eventsSectionEntry.Offset = offset2;
				eventsSectionEntry.TextValue = textValue;
				result = eventsSectionEntry;
			}
			return result;
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x06000163 RID: 355 RVA: 0x00007D24 File Offset: 0x00005F24
		// (set) Token: 0x06000164 RID: 356 RVA: 0x00007D3B File Offset: 0x00005F3B
		public int EffectLength { get; set; }

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000165 RID: 357 RVA: 0x00007D44 File Offset: 0x00005F44
		// (set) Token: 0x06000166 RID: 358 RVA: 0x00007D5B File Offset: 0x00005F5B
		public int EffectType { get; set; }

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000167 RID: 359 RVA: 0x00007D64 File Offset: 0x00005F64
		// (set) Token: 0x06000168 RID: 360 RVA: 0x00007D7B File Offset: 0x00005F7B
		public int Offset { get; set; }

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000169 RID: 361 RVA: 0x00007D84 File Offset: 0x00005F84
		// (set) Token: 0x0600016A RID: 362 RVA: 0x00007D9B File Offset: 0x00005F9B
		public string TextValue { get; set; }

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x0600016B RID: 363 RVA: 0x00007DA4 File Offset: 0x00005FA4
		// (set) Token: 0x0600016C RID: 364 RVA: 0x00007DBB File Offset: 0x00005FBB
		public EventType Type { get; set; }

		// Token: 0x040000D4 RID: 212
		private static readonly Regex EventEffectRegex = new Regex("\\s*(?<offset>\\d+)\\s*\\=\\s*H\\s*(?<type>\\d+)\\s*(?<len>\\d+)", RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);

		// Token: 0x040000D5 RID: 213
		private static readonly Regex EventTextRegex = new Regex("(?<offset>\\d+)\\s*\\=\\s*E\\s*\\\"(?<value>.*)\\\"", RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);
	}
}
