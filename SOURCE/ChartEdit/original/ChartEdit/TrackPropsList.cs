using System;
using System.Collections.Generic;

namespace ChartEdit
{
	// Token: 0x02000017 RID: 23
	public class TrackPropsList : List<TrackProps>
	{
		// Token: 0x1700001C RID: 28
		public TrackProps this[string key]
		{
			get
			{
				foreach (TrackProps trackProps in this)
				{
					if (trackProps.Name.IndexOf(key, StringComparison.OrdinalIgnoreCase) == 0 && trackProps.Name.Length == key.Length)
					{
						return trackProps;
					}
				}
				return base[0];
			}
		}
	}
}
