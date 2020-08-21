using System;
using System.Text.RegularExpressions;

namespace ChartEdit
{
	// Token: 0x02000002 RID: 2
	public class Note
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public Note()
		{
		}

		// Token: 0x06000002 RID: 2 RVA: 0x0000205C File Offset: 0x0000025C
		public Note(NoteProp noteProp)
		{
			this.Type = NoteType.Regular;
			this.IsANote = noteProp.IsNote;
			this.FlipsHOPO = noteProp.FlipsHOPO;
			this.ForcesHOPO = noteProp.ForcesHOPO;
			this.ForcesStrum = noteProp.ForcesStrum;
			this.ForcesTapping = noteProp.ForcesTapping;
			this.PointValue = noteProp.PointValue;
			this.Fret = noteProp.Fret;
		}

		// Token: 0x06000003 RID: 3 RVA: 0x000020D8 File Offset: 0x000002D8
		public int LengthMilliseconds(OffsetTransformer ot)
		{
			return (int)Math.Round(1000.0 * (double)(this.TimeEndOffset(ot) - this.TimeOffset(ot)));
		}

		// Token: 0x06000004 RID: 4 RVA: 0x0000210C File Offset: 0x0000030C
		public int OffsetMilliseconds(OffsetTransformer ot)
		{
			return (int)Math.Round(1000.0 * (double)this.TimeOffset(ot));
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002138 File Offset: 0x00000338
		public static Note Parse(string entry)
		{
			Match match = Note.NoteRegex.Match(entry);
			Note note = new Note();
			Note result;
			if (!match.Success)
			{
				match = Note.NoteEventRegex.Match(entry);
				if (!match.Success)
				{
					result = null;
				}
				else
				{
					int offset = int.Parse(match.Groups["offset"].Value.Trim());
					string eventName = match.Groups["name"].Value.Trim();
					note.Offset = offset;
					note.Type = NoteType.Event;
					note.EventName = eventName;
					result = note;
				}
			}
			else
			{
				int offset2 = int.Parse(match.Groups["offset"].Value.Trim());
				string text = match.Groups["type"].Value.Trim();
				int num = int.Parse(match.Groups["fret"].Value.Trim());
				int length = int.Parse(match.Groups["length"].Value.Trim());
				note.Offset = offset2;
				string text2 = text;
				if (text2 != null)
				{
					if (!(text2 == "N"))
					{
						if (text2 == "S")
						{
							note.Type = NoteType.Special;
							note.SpecialFlag = num;
						}
					}
					else
					{
						note.Type = NoteType.Regular;
						note.Fret = num;
					}
				}
				note.Length = length;
				result = note;
			}
			return result;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000022DC File Offset: 0x000004DC
		public float TimeEndOffset(OffsetTransformer ot)
		{
			return ot.GetTime(this.OffsetEnd);
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000022FC File Offset: 0x000004FC
		public float TimeOffset(OffsetTransformer ot)
		{
			return ot.GetTime(this.Offset);
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000008 RID: 8 RVA: 0x0000231C File Offset: 0x0000051C
		// (set) Token: 0x06000009 RID: 9 RVA: 0x00002333 File Offset: 0x00000533
		public bool ArmoredNote { get; set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600000A RID: 10 RVA: 0x0000233C File Offset: 0x0000053C
		// (set) Token: 0x0600000B RID: 11 RVA: 0x00002353 File Offset: 0x00000553
		public string EventName { get; set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600000C RID: 12 RVA: 0x0000235C File Offset: 0x0000055C
		// (set) Token: 0x0600000D RID: 13 RVA: 0x00002373 File Offset: 0x00000573
		public bool FlipsHOPO { get; set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000E RID: 14 RVA: 0x0000237C File Offset: 0x0000057C
		// (set) Token: 0x0600000F RID: 15 RVA: 0x00002393 File Offset: 0x00000593
		public bool ForcesHOPO { get; set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000010 RID: 16 RVA: 0x0000239C File Offset: 0x0000059C
		// (set) Token: 0x06000011 RID: 17 RVA: 0x000023B3 File Offset: 0x000005B3
		public bool ForcesStrum { get; set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000012 RID: 18 RVA: 0x000023BC File Offset: 0x000005BC
		// (set) Token: 0x06000013 RID: 19 RVA: 0x000023D3 File Offset: 0x000005D3
		public bool ForcesTapping { get; set; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000014 RID: 20 RVA: 0x000023DC File Offset: 0x000005DC
		// (set) Token: 0x06000015 RID: 21 RVA: 0x000023F3 File Offset: 0x000005F3
		public int Fret { get; set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000016 RID: 22 RVA: 0x000023FC File Offset: 0x000005FC
		// (set) Token: 0x06000017 RID: 23 RVA: 0x00002413 File Offset: 0x00000613
		public bool IsANote { get; set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000018 RID: 24 RVA: 0x0000241C File Offset: 0x0000061C
		// (set) Token: 0x06000019 RID: 25 RVA: 0x00002433 File Offset: 0x00000633
		public bool IsArmored { get; set; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600001A RID: 26 RVA: 0x0000243C File Offset: 0x0000063C
		// (set) Token: 0x0600001B RID: 27 RVA: 0x00002453 File Offset: 0x00000653
		public bool IsChord { get; set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600001C RID: 28 RVA: 0x0000245C File Offset: 0x0000065C
		// (set) Token: 0x0600001D RID: 29 RVA: 0x00002473 File Offset: 0x00000673
		public bool IsHopo { get; set; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600001E RID: 30 RVA: 0x0000247C File Offset: 0x0000067C
		// (set) Token: 0x0600001F RID: 31 RVA: 0x00002493 File Offset: 0x00000693
		public bool IsInSlide { get; set; }

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000020 RID: 32 RVA: 0x0000249C File Offset: 0x0000069C
		// (set) Token: 0x06000021 RID: 33 RVA: 0x000024B3 File Offset: 0x000006B3
		public bool IsInSP { get; set; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000022 RID: 34 RVA: 0x000024BC File Offset: 0x000006BC
		// (set) Token: 0x06000023 RID: 35 RVA: 0x000024D3 File Offset: 0x000006D3
		public bool IsTapping { get; set; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000024 RID: 36 RVA: 0x000024DC File Offset: 0x000006DC
		// (set) Token: 0x06000025 RID: 37 RVA: 0x000024F3 File Offset: 0x000006F3
		public int Length { get; set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000026 RID: 38 RVA: 0x000024FC File Offset: 0x000006FC
		// (set) Token: 0x06000027 RID: 39 RVA: 0x00002513 File Offset: 0x00000713
		public int Mult { get; set; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000028 RID: 40 RVA: 0x0000251C File Offset: 0x0000071C
		// (set) Token: 0x06000029 RID: 41 RVA: 0x00002533 File Offset: 0x00000733
		public int Offset { get; set; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600002A RID: 42 RVA: 0x0000253C File Offset: 0x0000073C
		// (set) Token: 0x0600002B RID: 43 RVA: 0x0000255B File Offset: 0x0000075B
		public int OffsetEnd
		{
			get
			{
				return this.Offset + this.Length;
			}
			set
			{
				this.Length = value - this.Offset;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600002C RID: 44 RVA: 0x00002570 File Offset: 0x00000770
		// (set) Token: 0x0600002D RID: 45 RVA: 0x00002587 File Offset: 0x00000787
		public int PointValue { get; set; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600002E RID: 46 RVA: 0x00002590 File Offset: 0x00000790
		// (set) Token: 0x0600002F RID: 47 RVA: 0x000025A7 File Offset: 0x000007A7
		public int SpecialFlag { get; set; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000030 RID: 48 RVA: 0x000025B0 File Offset: 0x000007B0
		// (set) Token: 0x06000031 RID: 49 RVA: 0x000025C7 File Offset: 0x000007C7
		public int TickValue { get; set; }

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000032 RID: 50 RVA: 0x000025D0 File Offset: 0x000007D0
		// (set) Token: 0x06000033 RID: 51 RVA: 0x000025E7 File Offset: 0x000007E7
		public NoteType Type { get; set; }

		// Token: 0x04000001 RID: 1
		private static readonly Regex NoteEventRegex = new Regex("(?<offset>\\d+)\\s*\\=\\s*E\\s*(?<name>.*)", RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);

		// Token: 0x04000002 RID: 2
		private static readonly Regex NoteRegex = new Regex("(?<offset>\\d+)\\s*\\=\\s*(?<type>.*?)\\s*(?<fret>\\d+)\\s*(?<length>\\d+)", RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);
	}
}
