using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LitJson
{
	// Token: 0x02000006 RID: 6
	public class JSONClass : JSONNode, IEnumerable
	{
		// Token: 0x17000011 RID: 17
		public override JSONNode this[string aKey]
		{
			get
			{
				if (this.m_Dict.ContainsKey(aKey))
				{
					return this.m_Dict[aKey];
				}
				return new JSONLazyCreator(this, aKey);
			}
			set
			{
				if (this.m_Dict.ContainsKey(aKey))
				{
					this.m_Dict[aKey] = value;
				}
				else
				{
					this.m_Dict.Add(aKey, value);
				}
			}
		}

		// Token: 0x17000012 RID: 18
		public override JSONNode this[int aIndex]
		{
			get
			{
				if (aIndex < 0 || aIndex >= this.m_Dict.Count)
				{
					return null;
				}
				return this.m_Dict.ElementAt(aIndex).Value;
			}
			set
			{
				if (aIndex < 0 || aIndex >= this.m_Dict.Count)
				{
					return;
				}
				string key = this.m_Dict.ElementAt(aIndex).Key;
				this.m_Dict[key] = value;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600004A RID: 74 RVA: 0x000034BC File Offset: 0x000018BC
		public override int Count
		{
			get
			{
				return this.m_Dict.Count;
			}
		}

		// Token: 0x0600004B RID: 75 RVA: 0x000034CC File Offset: 0x000018CC
		public override void Add(string aKey, JSONNode aItem)
		{
			if (!string.IsNullOrEmpty(aKey))
			{
				if (this.m_Dict.ContainsKey(aKey))
				{
					this.m_Dict[aKey] = aItem;
				}
				else
				{
					this.m_Dict.Add(aKey, aItem);
				}
			}
			else
			{
				this.m_Dict.Add(Guid.NewGuid().ToString(), aItem);
			}
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00003538 File Offset: 0x00001938
		public override JSONNode Remove(string aKey)
		{
			if (!this.m_Dict.ContainsKey(aKey))
			{
				return null;
			}
			JSONNode result = this.m_Dict[aKey];
			this.m_Dict.Remove(aKey);
			return result;
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00003574 File Offset: 0x00001974
		public override JSONNode Remove(int aIndex)
		{
			if (aIndex < 0 || aIndex >= this.m_Dict.Count)
			{
				return null;
			}
			KeyValuePair<string, JSONNode> keyValuePair = this.m_Dict.ElementAt(aIndex);
			this.m_Dict.Remove(keyValuePair.Key);
			return keyValuePair.Value;
		}

		// Token: 0x0600004E RID: 78 RVA: 0x000035C4 File Offset: 0x000019C4
		public override JSONNode Remove(JSONNode aNode)
		{
			JSONNode result;
			try
			{
				KeyValuePair<string, JSONNode> keyValuePair = (from k in this.m_Dict
				where k.Value == aNode
				select k).First<KeyValuePair<string, JSONNode>>();
				this.m_Dict.Remove(keyValuePair.Key);
				result = aNode;
			}
			catch
			{
				result = null;
			}
			return result;
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600004F RID: 79 RVA: 0x00003634 File Offset: 0x00001A34
		public override IEnumerable<JSONNode> Childs
		{
			get
			{
				foreach (KeyValuePair<string, JSONNode> N in this.m_Dict)
				{
					yield return N.Value;
				}
				yield break;
			}
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00003658 File Offset: 0x00001A58
		public IEnumerator GetEnumerator()
		{
			foreach (KeyValuePair<string, JSONNode> N in this.m_Dict)
			{
				yield return N;
			}
			yield break;
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00003674 File Offset: 0x00001A74
		public override string ToString()
		{
			string text = "{";
			foreach (KeyValuePair<string, JSONNode> keyValuePair in this.m_Dict)
			{
				if (text.Length > 2)
				{
					text += ", ";
				}
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					"\"",
					JSONNode.Escape(keyValuePair.Key),
					"\":",
					keyValuePair.Value.ToString()
				});
			}
			text += "}";
			return text;
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00003734 File Offset: 0x00001B34
		public override string ToString(string aPrefix)
		{
			string text = "{ ";
			foreach (KeyValuePair<string, JSONNode> keyValuePair in this.m_Dict)
			{
				if (text.Length > 3)
				{
					text += ", ";
				}
				text = text + "\n" + aPrefix + "   ";
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					"\"",
					JSONNode.Escape(keyValuePair.Key),
					"\" : ",
					keyValuePair.Value.ToString(aPrefix + "   ")
				});
			}
			text = text + "\n" + aPrefix + "}";
			return text;
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00003818 File Offset: 0x00001C18
		public override void Serialize(BinaryWriter aWriter)
		{
			aWriter.Write(2);
			aWriter.Write(this.m_Dict.Count);
			foreach (string text in this.m_Dict.Keys)
			{
				aWriter.Write(text);
				this.m_Dict[text].Serialize(aWriter);
			}
		}

		// Token: 0x0400000A RID: 10
		private Dictionary<string, JSONNode> m_Dict = new Dictionary<string, JSONNode>();
	}
}
