using System;
using System.Text.RegularExpressions;

namespace ChartEdit
{
	// Token: 0x0200001A RID: 26
	public class SyncTrackEntry
	{
		// Token: 0x060000D9 RID: 217 RVA: 0x00004C3C File Offset: 0x00002E3C
		public static SyncTrackEntry Parse(string entryStr)
		{
			Match match = SyncTrackEntry.SyncTrackRegex.Match(entryStr);
			SyncTrackEntry result;
			if (!match.Success)
			{
				result = null;
			}
			else
			{
				SyncTrackEntry syncTrackEntry = new SyncTrackEntry();
				int offset = int.Parse(match.Groups["offset"].Value.Trim());
				string text = match.Groups["type"].Value.Trim();
				int num;
				try
				{
					num = int.Parse(match.Groups["value"].Value.Trim());
				}
				catch (OverflowException)
				{
					num = int.MaxValue;
				}
				syncTrackEntry.Offset = offset;
				string text2 = text;
				if (text2 != null)
				{
					if (!(text2 == "A"))
					{
						if (text2 == "TS")
						{
							syncTrackEntry.TimeSignature = num;
							syncTrackEntry.Type = SyncType.TimeSignature;
							return syncTrackEntry;
						}
						if (text2 == "B")
						{
							syncTrackEntry.BPM = num;
							syncTrackEntry.FloatBPM = (float)num / 1000f;
							syncTrackEntry.Type = SyncType.BPM;
						}
						return syncTrackEntry;
					}
					else
					{
						syncTrackEntry.Anchor = num;
						syncTrackEntry.Type = SyncType.Anchor;
					}
				}
				result = syncTrackEntry;
			}
			return result;
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x060000DA RID: 218 RVA: 0x00004D9C File Offset: 0x00002F9C
		// (set) Token: 0x060000DB RID: 219 RVA: 0x00004DB3 File Offset: 0x00002FB3
		public int Anchor { get; set; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060000DC RID: 220 RVA: 0x00004DBC File Offset: 0x00002FBC
		// (set) Token: 0x060000DD RID: 221 RVA: 0x00004DD3 File Offset: 0x00002FD3
		public int BPM { get; set; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x060000DE RID: 222 RVA: 0x00004DDC File Offset: 0x00002FDC
		// (set) Token: 0x060000DF RID: 223 RVA: 0x00004DF3 File Offset: 0x00002FF3
		public float FloatBPM { get; set; }

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x060000E0 RID: 224 RVA: 0x00004DFC File Offset: 0x00002FFC
		// (set) Token: 0x060000E1 RID: 225 RVA: 0x00004E13 File Offset: 0x00003013
		public int Offset { get; set; }

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060000E2 RID: 226 RVA: 0x00004E1C File Offset: 0x0000301C
		// (set) Token: 0x060000E3 RID: 227 RVA: 0x00004E33 File Offset: 0x00003033
		public int TimeSignature { get; set; }

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x060000E4 RID: 228 RVA: 0x00004E3C File Offset: 0x0000303C
		// (set) Token: 0x060000E5 RID: 229 RVA: 0x00004E53 File Offset: 0x00003053
		public SyncType Type { get; set; }

		// Token: 0x0400007E RID: 126
		private static readonly Regex SyncTrackRegex = new Regex("(?<offset>\\d+)\\s*\\=\\s*(?<type>.*?)\\s*(?<value>\\d+)", RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);
	}
}
