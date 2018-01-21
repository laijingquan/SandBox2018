using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace LitJson
{
	// Token: 0x02000004 RID: 4
	public class JSONNode
	{
		// Token: 0x06000007 RID: 7 RVA: 0x00002145 File Offset: 0x00000545
		public virtual void Add(string aKey, JSONNode aItem)
		{
		}

		// Token: 0x17000001 RID: 1
		public virtual JSONNode this[int aIndex]
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		// Token: 0x17000002 RID: 2
		public virtual JSONNode this[string aKey]
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600000C RID: 12 RVA: 0x00002151 File Offset: 0x00000551
		// (set) Token: 0x0600000D RID: 13 RVA: 0x00002158 File Offset: 0x00000558
		public virtual string Value
		{
			get
			{
				return string.Empty;
			}
			set
			{
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000E RID: 14 RVA: 0x0000215A File Offset: 0x0000055A
		public virtual int Count
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x0600000F RID: 15 RVA: 0x0000215D File Offset: 0x0000055D
		public virtual void Add(JSONNode aItem)
		{
			this.Add(string.Empty, aItem);
		}

		// Token: 0x06000010 RID: 16 RVA: 0x0000216B File Offset: 0x0000056B
		public virtual JSONNode Remove(string aKey)
		{
			return null;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x0000216E File Offset: 0x0000056E
		public virtual JSONNode Remove(int aIndex)
		{
			return null;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002171 File Offset: 0x00000571
		public virtual JSONNode Remove(JSONNode aNode)
		{
			return aNode;
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000013 RID: 19 RVA: 0x00002174 File Offset: 0x00000574
		public virtual IEnumerable<JSONNode> Childs
		{
			get
			{
				yield break;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000014 RID: 20 RVA: 0x00002190 File Offset: 0x00000590
		public IEnumerable<JSONNode> DeepChilds
		{
			get
			{
				foreach (JSONNode C in this.Childs)
				{
					foreach (JSONNode D in C.DeepChilds)
					{
						yield return D;
					}
				}
				yield break;
			}
		}

		// Token: 0x06000015 RID: 21 RVA: 0x000021B3 File Offset: 0x000005B3
		public override string ToString()
		{
			return "JSONNode";
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000021BA File Offset: 0x000005BA
		public virtual string ToString(string aPrefix)
		{
			return "JSONNode";
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000017 RID: 23 RVA: 0x000021C4 File Offset: 0x000005C4
		// (set) Token: 0x06000018 RID: 24 RVA: 0x000021E8 File Offset: 0x000005E8
		public virtual int AsInt
		{
			get
			{
				int result = 0;
				if (int.TryParse(this.Value, out result))
				{
					return result;
				}
				return 0;
			}
			set
			{
				this.Value = value.ToString();
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000019 RID: 25 RVA: 0x00002200 File Offset: 0x00000600
		// (set) Token: 0x0600001A RID: 26 RVA: 0x0000222C File Offset: 0x0000062C
		public virtual float AsFloat
		{
			get
			{
				float result = 0f;
				if (float.TryParse(this.Value, out result))
				{
					return result;
				}
				return 0f;
			}
			set
			{
				this.Value = value.ToString();
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600001B RID: 27 RVA: 0x00002244 File Offset: 0x00000644
		// (set) Token: 0x0600001C RID: 28 RVA: 0x00002278 File Offset: 0x00000678
		public virtual double AsDouble
		{
			get
			{
				double result = 0.0;
				if (double.TryParse(this.Value, out result))
				{
					return result;
				}
				return 0.0;
			}
			set
			{
				this.Value = value.ToString();
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600001D RID: 29 RVA: 0x00002290 File Offset: 0x00000690
		// (set) Token: 0x0600001E RID: 30 RVA: 0x000022C1 File Offset: 0x000006C1
		public virtual bool AsBool
		{
			get
			{
				bool result = false;
				if (bool.TryParse(this.Value, out result))
				{
					return result;
				}
				return !string.IsNullOrEmpty(this.Value);
			}
			set
			{
				this.Value = ((!value) ? "false" : "true");
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600001F RID: 31 RVA: 0x000022DE File Offset: 0x000006DE
		public virtual JSONArray AsArray
		{
			get
			{
				return this as JSONArray;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000020 RID: 32 RVA: 0x000022E6 File Offset: 0x000006E6
		public virtual JSONClass AsObject
		{
			get
			{
				return this as JSONClass;
			}
		}

		// Token: 0x06000021 RID: 33 RVA: 0x000022EE File Offset: 0x000006EE
		public static implicit operator JSONNode(string s)
		{
			return new JSONData(s);
		}

		// Token: 0x06000022 RID: 34 RVA: 0x000022F6 File Offset: 0x000006F6
		public static implicit operator string(JSONNode d)
		{
			return (!(d == null)) ? d.Value : null;
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002310 File Offset: 0x00000710
		public static bool operator ==(JSONNode a, object b)
		{
			return (b == null && a is JSONLazyCreator) || object.ReferenceEquals(a, b);
		}

		// Token: 0x06000024 RID: 36 RVA: 0x0000232C File Offset: 0x0000072C
		public static bool operator !=(JSONNode a, object b)
		{
			return !(a == b);
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002338 File Offset: 0x00000738
		public override bool Equals(object obj)
		{
			return object.ReferenceEquals(this, obj);
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002341 File Offset: 0x00000741
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		// Token: 0x06000027 RID: 39 RVA: 0x0000234C File Offset: 0x0000074C
		internal static string Escape(string aText)
		{
			string text = string.Empty;
			foreach (char c in aText)
			{
				switch (c)
				{
				case '\b':
					text += "\\b";
					break;
				case '\t':
					text += "\\t";
					break;
				case '\n':
					text += "\\n";
					break;
				default:
					if (c != '"')
					{
						if (c != '\\')
						{
							text += c;
						}
						else
						{
							text += "\\\\";
						}
					}
					else
					{
						text += "\\\"";
					}
					break;
				case '\f':
					text += "\\f";
					break;
				case '\r':
					text += "\\r";
					break;
				}
			}
			return text;
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00002440 File Offset: 0x00000840
		public static JSONNode Parse(string aJSON)
		{
			Stack<JSONNode> stack = new Stack<JSONNode>();
			JSONNode jsonnode = null;
			int i = 0;
			string text = string.Empty;
			string text2 = string.Empty;
			bool flag = false;
			while (i < aJSON.Length)
			{
				char c = aJSON[i];
				switch (c)
				{
				case '\t':
					goto IL_333;
				case '\n':
				case '\r':
					break;
				default:
					switch (c)
					{
					case '[':
						if (flag)
						{
							text += aJSON[i];
							goto IL_45C;
						}
						stack.Push(new JSONArray());
						if (jsonnode != null)
						{
							text2 = text2.Trim();
							if (jsonnode is JSONArray)
							{
								jsonnode.Add(stack.Peek());
							}
							else if (text2 != string.Empty)
							{
								jsonnode.Add(text2, stack.Peek());
							}
						}
						text2 = string.Empty;
						text = string.Empty;
						jsonnode = stack.Peek();
						goto IL_45C;
					case '\\':
						i++;
						if (flag)
						{
							char c2 = aJSON[i];
							switch (c2)
							{
							case 'r':
								text += '\r';
								break;
							default:
								if (c2 != 'b')
								{
									if (c2 != 'f')
									{
										if (c2 != 'n')
										{
											text += c2;
										}
										else
										{
											text += '\n';
										}
									}
									else
									{
										text += '\f';
									}
								}
								else
								{
									text += '\b';
								}
								break;
							case 't':
								text += '\t';
								break;
							case 'u':
							{
								string s = aJSON.Substring(i + 1, 4);
								text += (char)int.Parse(s, NumberStyles.AllowHexSpecifier);
								i += 4;
								break;
							}
							}
						}
						goto IL_45C;
					case ']':
						break;
					default:
						switch (c)
						{
						case ' ':
							goto IL_333;
						default:
							switch (c)
							{
							case '{':
								if (flag)
								{
									text += aJSON[i];
									goto IL_45C;
								}
								stack.Push(new JSONClass());
								if (jsonnode != null)
								{
									text2 = text2.Trim();
									if (jsonnode is JSONArray)
									{
										jsonnode.Add(stack.Peek());
									}
									else if (text2 != string.Empty)
									{
										jsonnode.Add(text2, stack.Peek());
									}
								}
								text2 = string.Empty;
								text = string.Empty;
								jsonnode = stack.Peek();
								goto IL_45C;
							default:
								if (c != ',')
								{
									if (c != ':')
									{
										text += aJSON[i];
										goto IL_45C;
									}
									if (flag)
									{
										text += aJSON[i];
										goto IL_45C;
									}
									text2 = text;
									text = string.Empty;
									goto IL_45C;
								}
								else
								{
									if (flag)
									{
										text += aJSON[i];
										goto IL_45C;
									}
									if (text != string.Empty)
									{
										if (jsonnode is JSONArray)
										{
											jsonnode.Add(text);
										}
										else if (text2 != string.Empty)
										{
											jsonnode.Add(text2, text);
										}
									}
									text2 = string.Empty;
									text = string.Empty;
									goto IL_45C;
								}
								break;
							case '}':
								break;
							}
							break;
						case '"':
							flag ^= true;
							goto IL_45C;
						}
						break;
					}
					if (flag)
					{
						text += aJSON[i];
					}
					else
					{
						if (stack.Count == 0)
						{
							throw new Exception("JSON Parse: Too many closing brackets");
						}
						stack.Pop();
						if (text != string.Empty)
						{
							text2 = text2.Trim();
							if (jsonnode is JSONArray)
							{
								jsonnode.Add(text);
							}
							else if (text2 != string.Empty)
							{
								jsonnode.Add(text2, text);
							}
						}
						text2 = string.Empty;
						text = string.Empty;
						if (stack.Count > 0)
						{
							jsonnode = stack.Peek();
						}
					}
					break;
				}
				IL_45C:
				i++;
				continue;
				IL_333:
				if (flag)
				{
					text += aJSON[i];
				}
				goto IL_45C;
			}
			if (flag)
			{
				throw new Exception("JSON Parse: Quotation marks seems to be messed up.");
			}
			return jsonnode;
		}

		// Token: 0x06000029 RID: 41 RVA: 0x000028CC File Offset: 0x00000CCC
		public virtual void Serialize(BinaryWriter aWriter)
		{
		}

		// Token: 0x0600002A RID: 42 RVA: 0x000028D0 File Offset: 0x00000CD0
		public void SaveToStream(Stream aData)
		{
			BinaryWriter aWriter = new BinaryWriter(aData);
			this.Serialize(aWriter);
		}

		// Token: 0x0600002B RID: 43 RVA: 0x000028EB File Offset: 0x00000CEB
		public void SaveToCompressedStream(Stream aData)
		{
			throw new Exception("Can't use compressed functions. You need include the SharpZipLib and uncomment the define at the top of SimpleJSON");
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000028F7 File Offset: 0x00000CF7
		public void SaveToCompressedFile(string aFileName)
		{
			throw new Exception("Can't use compressed functions. You need include the SharpZipLib and uncomment the define at the top of SimpleJSON");
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002903 File Offset: 0x00000D03
		public string SaveToCompressedBase64()
		{
			throw new Exception("Can't use compressed functions. You need include the SharpZipLib and uncomment the define at the top of SimpleJSON");
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002910 File Offset: 0x00000D10
		public void SaveToFile(string aFileName)
		{
			Directory.CreateDirectory(new FileInfo(aFileName).Directory.FullName);
			using (FileStream fileStream = File.OpenWrite(aFileName))
			{
				this.SaveToStream(fileStream);
			}
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00002964 File Offset: 0x00000D64
		public string SaveToBase64()
		{
			string result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				this.SaveToStream(memoryStream);
				memoryStream.Position = 0L;
				result = Convert.ToBase64String(memoryStream.ToArray());
			}
			return result;
		}

		// Token: 0x06000030 RID: 48 RVA: 0x000029B8 File Offset: 0x00000DB8
		public static JSONNode Deserialize(BinaryReader aReader)
		{
			JSONBinaryTag jsonbinaryTag = (JSONBinaryTag)aReader.ReadByte();
			switch (jsonbinaryTag)
			{
			case JSONBinaryTag.Array:
			{
				int num = aReader.ReadInt32();
				JSONArray jsonarray = new JSONArray();
				for (int i = 0; i < num; i++)
				{
					jsonarray.Add(JSONNode.Deserialize(aReader));
				}
				return jsonarray;
			}
			case JSONBinaryTag.Class:
			{
				int num2 = aReader.ReadInt32();
				JSONClass jsonclass = new JSONClass();
				for (int j = 0; j < num2; j++)
				{
					string aKey = aReader.ReadString();
					JSONNode aItem = JSONNode.Deserialize(aReader);
					jsonclass.Add(aKey, aItem);
				}
				return jsonclass;
			}
			case JSONBinaryTag.Value:
				return new JSONData(aReader.ReadString());
			case JSONBinaryTag.IntValue:
				return new JSONData(aReader.ReadInt32());
			case JSONBinaryTag.DoubleValue:
				return new JSONData(aReader.ReadDouble());
			case JSONBinaryTag.BoolValue:
				return new JSONData(aReader.ReadBoolean());
			case JSONBinaryTag.FloatValue:
				return new JSONData(aReader.ReadSingle());
			default:
				throw new Exception("Error deserializing JSON. Unknown tag: " + jsonbinaryTag);
			}
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00002AB7 File Offset: 0x00000EB7
		public static JSONNode LoadFromCompressedFile(string aFileName)
		{
			throw new Exception("Can't use compressed functions. You need include the SharpZipLib and uncomment the define at the top of SimpleJSON");
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00002AC3 File Offset: 0x00000EC3
		public static JSONNode LoadFromCompressedStream(Stream aData)
		{
			throw new Exception("Can't use compressed functions. You need include the SharpZipLib and uncomment the define at the top of SimpleJSON");
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00002ACF File Offset: 0x00000ECF
		public static JSONNode LoadFromCompressedBase64(string aBase64)
		{
			throw new Exception("Can't use compressed functions. You need include the SharpZipLib and uncomment the define at the top of SimpleJSON");
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00002ADC File Offset: 0x00000EDC
		public static JSONNode LoadFromStream(Stream aData)
		{
			JSONNode result;
			using (BinaryReader binaryReader = new BinaryReader(aData))
			{
				result = JSONNode.Deserialize(binaryReader);
			}
			return result;
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00002B1C File Offset: 0x00000F1C
		public static JSONNode LoadFromFile(string aFileName)
		{
			JSONNode result;
			using (FileStream fileStream = File.OpenRead(aFileName))
			{
				result = JSONNode.LoadFromStream(fileStream);
			}
			return result;
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00002B5C File Offset: 0x00000F5C
		public static JSONNode LoadFromBase64(string aBase64)
		{
			byte[] buffer = Convert.FromBase64String(aBase64);
			return JSONNode.LoadFromStream(new MemoryStream(buffer)
			{
				Position = 0L
			});
		}
	}
}
