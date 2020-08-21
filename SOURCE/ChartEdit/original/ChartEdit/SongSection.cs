using System;
using System.Collections.Generic;

namespace ChartEdit
{
	// Token: 0x02000027 RID: 39
	public class SongSection : List<SongSectionEntry>
	{
		// Token: 0x06000135 RID: 309 RVA: 0x00006898 File Offset: 0x00004A98
		public bool ContainsKey(string key)
		{
			foreach (SongSectionEntry songSectionEntry in this)
			{
				if (songSectionEntry.Key == key)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x17000039 RID: 57
		public SongSectionEntry this[string key]
		{
			get
			{
				foreach (SongSectionEntry songSectionEntry in this)
				{
					if (songSectionEntry.Key == key)
					{
						return songSectionEntry;
					}
				}
				return null;
			}
		}

		// Token: 0x040000C5 RID: 197
		public const string SectionName = "Song";
	}
}
