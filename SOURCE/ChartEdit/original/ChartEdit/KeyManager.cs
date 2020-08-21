using System;
using System.Collections.Generic;
using System.Linq;

namespace ChartEdit
{
	// Token: 0x0200000B RID: 11
	public class KeyManager
	{
		// Token: 0x06000078 RID: 120 RVA: 0x0000329C File Offset: 0x0000149C
		public KeyManager()
		{
			this.Keys.Add(new KMKey(KeyType.Note, NoteType.Regular, 49, 0));
			this.Keys.Add(new KMKey(KeyType.Note, NoteType.Regular, 50, 1));
			this.Keys.Add(new KMKey(KeyType.Note, NoteType.Regular, 51, 2));
			this.Keys.Add(new KMKey(KeyType.Note, NoteType.Regular, 52, 3));
			this.Keys.Add(new KMKey(KeyType.Note, NoteType.Regular, 53, 4));
			this.Keys.Add(new KMKey(KeyType.Note, NoteType.Regular, 54, 5));
			this.Keys.Add(new KMKey(KeyType.Note, NoteType.Regular, 55, 6));
			this.Keys.Add(new KMKey(KeyType.MoveUp, NoteType.Regular, 38, 0));
			this.Keys.Add(new KMKey(KeyType.MoveDown, NoteType.Regular, 40, 0));
			this.Keys.Add(new KMKey(KeyType.QuantizeDown, NoteType.Regular, 37, 0));
			this.Keys.Add(new KMKey(KeyType.QuantizeUp, NoteType.Regular, 39, 0));
			this.Keys.Add(new KMKey(KeyType.Play, NoteType.Regular, 32, 0));
		}

		// Token: 0x06000079 RID: 121 RVA: 0x000033DC File Offset: 0x000015DC
		public List<KMKey> KeysPressed()
		{
			return this.KeysPressed(false);
		}

		// Token: 0x0600007A RID: 122 RVA: 0x000033F8 File Offset: 0x000015F8
		public List<KMKey> KeysPressed(bool ordered)
		{
			List<int> list;
			if (ordered)
			{
				list = this.KbKeysOrdered;
			}
			else
			{
				list = this.KbKeys;
			}
			List<KMKey> list2 = new List<KMKey>();
			foreach (int num in list)
			{
				foreach (KMKey kmkey in this.Keys)
				{
					if (kmkey.Key == num)
					{
						list2.Add(kmkey);
					}
				}
			}
			return list2;
		}

		// Token: 0x0600007B RID: 123 RVA: 0x000034D8 File Offset: 0x000016D8
		public void Press(int key)
		{
			if (this.KbKeys.Count<int>() == 0 || this.KbKeys.Last<int>() != key)
			{
				this.KbKeysOrdered.Add(key);
			}
			foreach (int num in this.KbKeys)
			{
				if (num == key)
				{
					return;
				}
			}
			this.KbKeys.Add(key);
		}

		// Token: 0x0600007C RID: 124 RVA: 0x0000357C File Offset: 0x0000177C
		public void Release(int key)
		{
			this.KbKeys.Remove(key);
			if (this.KbKeys.Count<int>() == 0)
			{
				this.KbKeysOrdered.Clear();
			}
		}

		// Token: 0x04000057 RID: 87
		public List<int> KbKeys = new List<int>();

		// Token: 0x04000058 RID: 88
		public List<int> KbKeysOrdered = new List<int>();

		// Token: 0x04000059 RID: 89
		public List<KMKey> Keys = new List<KMKey>();
	}
}
