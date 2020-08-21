using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace ChartEdit
{
	// Token: 0x0200001C RID: 28
	public class Chart
	{
		// Token: 0x060000E8 RID: 232 RVA: 0x00004E77 File Offset: 0x00003077
		public Chart()
		{
			this.Song = new SongSection();
			this.SyncTrack = new SyncTrackSection();
			this.Events = new EventsSection();
			this.NoteTracks = new NoteTracks();
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00004EB4 File Offset: 0x000030B4
		public Chart(string fileName)
		{
			this.Song = new SongSection();
			this.SyncTrack = new SyncTrackSection();
			this.Events = new EventsSection();
			this.NoteTracks = new NoteTracks();
			this.Load(fileName);
		}

		// Token: 0x060000EA RID: 234 RVA: 0x00004F04 File Offset: 0x00003104
		public void GetResolution()
		{
			if (this.Song.ContainsKey("Resolution"))
			{
				this.Resolution = int.Parse(this.Song["Resolution"].Value);
			}
			else
			{
				this.Resolution = 192;
			}
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00004F5C File Offset: 0x0000315C
		private bool HandleEvents(string entry)
		{
			EventsSectionEntry eventsSectionEntry = EventsSectionEntry.Parse(entry);
			bool result;
			if (eventsSectionEntry == null)
			{
				result = false;
			}
			else
			{
				if (eventsSectionEntry.Offset > this.LastIndex)
				{
					this.LastIndex = eventsSectionEntry.Offset;
				}
				this.Events.Add(eventsSectionEntry);
				result = true;
			}
			return result;
		}

		// Token: 0x060000EC RID: 236 RVA: 0x00004FB8 File Offset: 0x000031B8
		private bool HandleKeyValue(string title, string entry)
		{
			bool result;
			if (title == "Song")
			{
				result = this.HandleSong(entry);
			}
			else if (title == "SyncTrack")
			{
				result = this.HandleSyncTrack(entry);
			}
			else if (title == "Events")
			{
				result = this.HandleEvents(entry);
			}
			else
			{
				result = this.HandleNote(title, entry);
			}
			return result;
		}

		// Token: 0x060000ED RID: 237 RVA: 0x0000502C File Offset: 0x0000322C
		private bool HandleNote(string title, string entry)
		{
			Note note = Note.Parse(entry);
			bool result;
			if (note == null)
			{
				result = false;
			}
			else
			{
				if (!this.NoteTracks.ContainsTrack(title))
				{
					this.NoteTracks.Add(new NoteTrack(title));
				}
				NoteTrack noteTrack = this.NoteTracks[title];
				if (note.Offset > this.LastIndex)
				{
					this.LastIndex = note.Offset;
				}
				noteTrack.Add(note);
				result = true;
			}
			return result;
		}

		// Token: 0x060000EE RID: 238 RVA: 0x000050B4 File Offset: 0x000032B4
		private bool HandleSong(string entry)
		{
			SongSectionEntry songSectionEntry = SongSectionEntry.Parse(entry);
			bool result;
			if (songSectionEntry == null)
			{
				result = false;
			}
			else
			{
				this.Song.Add(songSectionEntry);
				result = true;
			}
			return result;
		}

		// Token: 0x060000EF RID: 239 RVA: 0x000050EC File Offset: 0x000032EC
		private bool HandleSyncTrack(string entry)
		{
			SyncTrackEntry syncTrackEntry = SyncTrackEntry.Parse(entry);
			bool result;
			if (syncTrackEntry == null)
			{
				result = false;
			}
			else
			{
				if (syncTrackEntry.Offset > this.LastIndex)
				{
					this.LastIndex = syncTrackEntry.Offset;
				}
				this.SyncTrack.Add(syncTrackEntry);
				result = true;
			}
			return result;
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00005148 File Offset: 0x00003348
		public void Load(string fileName)
		{
			if (!File.Exists(fileName))
			{
				throw new FileNotFoundException(fileName + " was not found.");
			}
			string text = File.ReadAllText(fileName);
			if (string.IsNullOrEmpty(text))
			{
				throw new IOException("Unable to load chart file.");
			}
			FileInfo fileInfo = new FileInfo(fileName);
			this.LoadPath = fileInfo.Directory.FullName;
			this.ParseChartData(text);
			this.GetResolution();
			this._ot = new OffsetTransformer(this);
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x000051C8 File Offset: 0x000033C8
		private void ParseChartData(string chartData)
		{
			foreach (object obj in Chart.TrackRegex.Matches(chartData))
			{
				Match match = (Match)obj;
				Group group = match.Groups["title"];
				Group group2 = match.Groups["entry"];
				string title = group.Value.Trim();
				foreach (object obj2 in group2.Captures)
				{
					Capture capture = (Capture)obj2;
					this.HandleKeyValue(title, capture.Value);
				}
			}
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x000052D4 File Offset: 0x000034D4
		public void Save(string fileName)
		{
			StringBuilder stringBuilder = new StringBuilder();
			this.WriteSongData(stringBuilder);
			this.WriteSyncTrackData(stringBuilder);
			this.WriteEventData(stringBuilder);
			foreach (NoteTrack noteTrack in this.NoteTracks)
			{
				this.WriteNoteTrackData(stringBuilder, noteTrack);
			}
			File.WriteAllText(fileName, stringBuilder.ToString());
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x0000535C File Offset: 0x0000355C
		private void WriteEventData(StringBuilder chartData)
		{
			chartData.Append("[Events]\r\n");
			chartData.Append("{\r\n");
			foreach (EventsSectionEntry eventsSectionEntry in this.Events)
			{
				chartData.Append("\t" + eventsSectionEntry.Offset + " = ");
				switch (eventsSectionEntry.Type)
				{
				case EventType.Text:
					chartData.Append("E \"" + eventsSectionEntry.TextValue + "\"");
					break;
				case EventType.Effect:
					chartData.Append(string.Concat(new object[]
					{
						"H ",
						eventsSectionEntry.EffectType,
						" ",
						eventsSectionEntry.EffectLength
					}));
					break;
				}
				chartData.Append("\r\n");
			}
			chartData.Append("}\r\n");
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x00005480 File Offset: 0x00003680
		private void WriteNoteTrackData(StringBuilder chartData, NoteTrack noteTrack)
		{
			chartData.Append("[" + noteTrack.Name + "]\r\n");
			chartData.Append("{\r\n");
			foreach (Note note in noteTrack)
			{
				chartData.Append("\t" + note.Offset + " = ");
				switch (note.Type)
				{
				case NoteType.Regular:
					chartData.Append(string.Concat(new object[]
					{
						"N ",
						note.Fret,
						" ",
						note.Length * 192 / 480
					}));
					break;
				case NoteType.Special:
					chartData.Append(string.Concat(new object[]
					{
						"S ",
						note.SpecialFlag,
						" ",
						note.Length
					}));
					break;
				case NoteType.Event:
					chartData.Append("E " + note.EventName);
					break;
				}
				chartData.Append("\r\n");
			}
			chartData.Append("}\r\n");
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x0000560C File Offset: 0x0000380C
		private void WriteSongData(StringBuilder chartData)
		{
			chartData.Append("[Song]\r\n");
			chartData.Append("{\r\n");
			foreach (SongSectionEntry songSectionEntry in this.Song)
			{
				chartData.Append(string.Concat(new string[]
				{
					"\t",
					songSectionEntry.Key,
					" = ",
					songSectionEntry.Value,
					"\r\n"
				}));
			}
			chartData.Append("}\r\n");
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x000056C4 File Offset: 0x000038C4
		private void WriteSyncTrackData(StringBuilder chartData)
		{
			chartData.Append("[SyncTrack]\r\n");
			chartData.Append("{\r\n");
			foreach (SyncTrackEntry syncTrackEntry in this.SyncTrack)
			{
				chartData.Append("\t" + syncTrackEntry.Offset + " = ");
				switch (syncTrackEntry.Type)
				{
				case SyncType.BPM:
					chartData.Append("B " + syncTrackEntry.BPM);
					break;
				case SyncType.TimeSignature:
					chartData.Append("TS " + syncTrackEntry.TimeSignature);
					break;
				case SyncType.Anchor:
					chartData.Append("A " + syncTrackEntry.Anchor);
					break;
				}
				chartData.Append("\r\n");
			}
			chartData.Append("}\r\n");
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060000F7 RID: 247 RVA: 0x000057E4 File Offset: 0x000039E4
		public int EighthResolution
		{
			get
			{
				return this.eRes;
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060000F8 RID: 248 RVA: 0x000057FC File Offset: 0x000039FC
		// (set) Token: 0x060000F9 RID: 249 RVA: 0x00005813 File Offset: 0x00003A13
		public EventsSection Events { get; set; }

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060000FA RID: 250 RVA: 0x0000581C File Offset: 0x00003A1C
		public int HalfResolution
		{
			get
			{
				return this.hRes;
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x060000FB RID: 251 RVA: 0x00005834 File Offset: 0x00003A34
		// (set) Token: 0x060000FC RID: 252 RVA: 0x0000584B File Offset: 0x00003A4B
		public int LastIndex { get; set; }

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x060000FD RID: 253 RVA: 0x00005854 File Offset: 0x00003A54
		// (set) Token: 0x060000FE RID: 254 RVA: 0x0000586B File Offset: 0x00003A6B
		public string LoadPath { get; set; }

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060000FF RID: 255 RVA: 0x00005874 File Offset: 0x00003A74
		// (set) Token: 0x06000100 RID: 256 RVA: 0x0000588B File Offset: 0x00003A8B
		public string Name { get; set; }

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000101 RID: 257 RVA: 0x00005894 File Offset: 0x00003A94
		// (set) Token: 0x06000102 RID: 258 RVA: 0x000058AB File Offset: 0x00003AAB
		public NoteTracks NoteTracks { get; set; }

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000103 RID: 259 RVA: 0x000058B4 File Offset: 0x00003AB4
		public int QuarterResolution
		{
			get
			{
				return this.qRes;
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000104 RID: 260 RVA: 0x000058CC File Offset: 0x00003ACC
		// (set) Token: 0x06000105 RID: 261 RVA: 0x000058E4 File Offset: 0x00003AE4
		public int Resolution
		{
			get
			{
				return this.res;
			}
			set
			{
				this.res = value;
				this.hRes = value / 2;
				this.qRes = value / 4;
				this.eRes = value / 8;
				this.sRes = value / 16;
				this.tRes = value / 32;
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000106 RID: 262 RVA: 0x00005920 File Offset: 0x00003B20
		public int SixteenthResolution
		{
			get
			{
				return this.sRes;
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000107 RID: 263 RVA: 0x00005938 File Offset: 0x00003B38
		// (set) Token: 0x06000108 RID: 264 RVA: 0x0000594F File Offset: 0x00003B4F
		public SongSection Song { get; set; }

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000109 RID: 265 RVA: 0x00005958 File Offset: 0x00003B58
		// (set) Token: 0x0600010A RID: 266 RVA: 0x0000596F File Offset: 0x00003B6F
		public float SongLength { get; set; }

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x0600010B RID: 267 RVA: 0x00005978 File Offset: 0x00003B78
		// (set) Token: 0x0600010C RID: 268 RVA: 0x0000598F File Offset: 0x00003B8F
		public SyncTrackSection SyncTrack { get; set; }

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x0600010D RID: 269 RVA: 0x00005998 File Offset: 0x00003B98
		public int ThirtysecondResolution
		{
			get
			{
				return this.tRes;
			}
		}

		// Token: 0x04000088 RID: 136
		private OffsetTransformer _ot;

		// Token: 0x04000089 RID: 137
		private int eRes;

		// Token: 0x0400008A RID: 138
		private int hRes;

		// Token: 0x0400008B RID: 139
		private int qRes;

		// Token: 0x0400008C RID: 140
		private int res;

		// Token: 0x0400008D RID: 141
		private int sRes;

		// Token: 0x0400008E RID: 142
		private static readonly Regex TrackRegex = new Regex("\\[(?<title>[a-zA-Z]+)\\]\\r\\n\\{\\r\\n(\\s(?<entry>.+?)\\r\\n)+\\}", RegexOptions.Multiline | RegexOptions.ExplicitCapture | RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace);

		// Token: 0x0400008F RID: 143
		private int tRes;
	}
}
