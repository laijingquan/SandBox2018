using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace LitJson
{
	// Token: 0x02000005 RID: 5
	public class JSONArray : JSONNode, IEnumerable
	{
		// Token: 0x1700000D RID: 13
		public override JSONNode this[int aIndex]
		{
			get
			{
				if (aIndex < 0 || aIndex >= this.m_List.Count)
				{
					return new JSONLazyCreator(this);
				}
				return this.m_List[aIndex];
			}
			set
			{
				if (aIndex < 0 || aIndex >= this.m_List.Count)
				{
					this.m_List.Add(value);
				}
				else
				{
					this.m_List[aIndex] = value;
				}
			}
		}

		// Token: 0x1700000E RID: 14
		public override JSONNode this[string aKey]
		{
			get
			{
				return new JSONLazyCreator(this);
			}
			set
			{
				this.m_List.Add(value);
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600003C RID: 60 RVA: 0x00002EAA File Offset: 0x000012AA
		public override int Count
		{
			get
			{
				return this.m_List.Count;
			}
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00002EB7 File Offset: 0x000012B7
		public override void Add(string aKey, JSONNode aItem)
		{
			this.m_List.Add(aItem);
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00002EC8 File Offset: 0x000012C8
		public override JSONNode Remove(int aIndex)
		{
			if (aIndex < 0 || aIndex >= this.m_List.Count)
			{
				return null;
			}
			JSONNode result = this.m_List[aIndex];
			this.m_List.RemoveAt(aIndex);
			return result;
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00002F09 File Offset: 0x00001309
		public override JSONNode Remove(JSONNode aNode)
		{
			this.m_List.Remove(aNode);
			return aNode;
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000040 RID: 64 RVA: 0x00002F1C File Offset: 0x0000131C
		public override IEnumerable<JSONNode> Childs
		{
			get
			{
				foreach (JSONNode N in this.m_List)
				{
					yield return N;
				}
				yield break;
			}
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00002F40 File Offset: 0x00001340
		public IEnumerator GetEnumerator()
		{
			foreach (JSONNode N in this.m_List)
			{
				yield return N;
			}
			yield break;
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00002F5C File Offset: 0x0000135C
		public override string ToString()
		{
			string text = "[ ";
			foreach (JSONNode jsonnode in this.m_List)
			{
				if (text.Length > 2)
				{
					text += ", ";
				}
				text += jsonnode.ToString();
			}
			text += " ]";
			return text;
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00002FEC File Offset: 0x000013EC
		public override string ToString(string aPrefix)
		{
			string text = "[ ";
			foreach (JSONNode jsonnode in this.m_List)
			{
				if (text.Length > 3)
				{
					text += ", ";
				}
				text = text + "\n" + aPrefix + "   ";
				text += jsonnode.ToString(aPrefix + "   ");
			}
			text = text + "\n" + aPrefix + "]";
			return text;
		}

		// Token: 0x06000044 RID: 68 RVA: 0x0000309C File Offset: 0x0000149C
		public override void Serialize(BinaryWriter aWriter)
		{
			aWriter.Write(1);
			aWriter.Write(this.m_List.Count);
			for (int i = 0; i < this.m_List.Count; i++)
			{
				this.m_List[i].Serialize(aWriter);
			}
		}

		// Token: 0x04000009 RID: 9
		private List<JSONNode> m_List = new List<JSONNode>();
	}
}
