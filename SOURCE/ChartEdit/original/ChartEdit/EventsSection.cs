using System;
using System.Collections.Generic;

namespace ChartEdit
{
	// Token: 0x02000035 RID: 53
	public class EventsSection : List<EventsSectionEntry>
	{
		// Token: 0x17000044 RID: 68
		public EventsSectionEntry this[string s]
		{
			get
			{
				foreach (EventsSectionEntry eventsSectionEntry in this)
				{
					if (eventsSectionEntry.TextValue == s)
					{
						return eventsSectionEntry;
					}
				}
				return null;
			}
		}

		// Token: 0x04000108 RID: 264
		public const string SectionName = "Events";
	}
}
