using System;
using System.Xml.Serialization;

namespace ChartEdit
{
	// Token: 0x02000011 RID: 17
	public class GameProps
	{
		// Token: 0x04000062 RID: 98
		[XmlAttribute]
		public string Name;

		// Token: 0x04000063 RID: 99
		public TrackPropsList TrackProperties = new TrackPropsList();
	}
}
