using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Documents.Serialization;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Xps.Packaging;
using System.Xml;
using System.Windows.Media.Imaging;
namespace ReportPrint
{
	public static class DrawItems
	{
		public static TextBlock CreatGlyphs(string strVal, double orgX, double orgY, double fontSize, bool iswrap, int txtLen, bool isUnderline)
		{
			strVal = strVal.PadRight(txtLen, ' ').Substring(0, txtLen);
			TextBlock textBlock = new TextBlock();
			Canvas.SetLeft(textBlock, orgX);
			Canvas.SetTop(textBlock, orgY - fontSize);
			Panel.SetZIndex(textBlock, 99);
			textBlock.Foreground = Brushes.Black;
			textBlock.FontFamily = new FontFamily("宋体");
			textBlock.FontSize = fontSize;
			textBlock.Text = strVal;
			if (iswrap)
			{
				textBlock.TextWrapping = TextWrapping.WrapWithOverflow;
			}
			if (isUnderline)
			{
				textBlock.TextDecorations = TextDecorations.Underline;
			}
			return textBlock;
		}
		public static TextBlock CreatGlyphs(string strVal, double orgX, double orgY, double fontSize)
		{
			return DrawItems.CreatGlyphs(strVal, orgX, orgY, fontSize, false, 30, false);
		}
		public static TextBlock CreatGlyphs(string strVal, double orgX, double orgY, double fontSize, double width, double height)
		{
			TextBlock textBlock = new TextBlock();
			Canvas.SetLeft(textBlock, orgX);
			Canvas.SetTop(textBlock, orgY - fontSize);
			textBlock.Foreground = Brushes.Black;
			textBlock.FontFamily = new FontFamily("宋体");
			textBlock.FontSize = fontSize;
			textBlock.Text = strVal;
			textBlock.Width = width;
			textBlock.Height = height;
			textBlock.TextWrapping = TextWrapping.WrapWithOverflow;
			return textBlock;
		}
		public static Canvas CreatArchiveid(string archiveid, double orgX, double orgY, double fontSize)
		{
			if (archiveid.Length < 17)
			{
				archiveid = archiveid.PadRight(17, ' ');
			}
			fontSize = 12.0;
			Canvas canvas = new Canvas();
			canvas.Width = 150.0;
			canvas.Height = 20.0;
			canvas.Background = Brushes.Transparent;
			Canvas.SetLeft(canvas, orgX);
			Canvas.SetTop(canvas, orgY - fontSize);
			int num = 0;
			for (int i = 0; i < 17; i++)
			{
				Border border = new Border();
				border.BorderBrush = Brushes.Black;
				border.BorderThickness = new Thickness(1.0);
				border.Height = 12.0;
				border.Width = 12.0;
				border.Child = new TextBlock
				{
					Foreground = Brushes.Black,
					FontFamily = new FontFamily("Arial"),
					FontSize = 9.0,
					Text = archiveid.ToArray<char>()[i].ToString(),
					TextAlignment = TextAlignment.Center,
					HorizontalAlignment = HorizontalAlignment.Center,
					VerticalAlignment = VerticalAlignment.Center
				};
				if (i > 0)
				{
					num += 14;
				}
				Canvas.SetLeft(border, (double)num);
				canvas.Children.Add(border);
				if (i == 5 || i == 8 || i == 11)
				{
					TextBlock textBlock = new TextBlock();
					textBlock.Foreground = Brushes.Black;
					textBlock.FontSize = 9.0;
					textBlock.Text = "—";
					textBlock.TextAlignment = TextAlignment.Center;
					textBlock.HorizontalAlignment = HorizontalAlignment.Center;
					textBlock.VerticalAlignment = VerticalAlignment.Center;
					num += 13;
					Canvas.SetLeft(textBlock, (double)num);
					canvas.Children.Add(textBlock);
				}
			}
			return canvas;
		}
        public static Canvas CreatLongArchiveid(string archiveid, double orgX, double orgY, double fontSize)
        {
            if (archiveid.Length < 18)
            {
                archiveid = archiveid.PadRight(18, ' ');
            }
            fontSize = 12.0;
            Canvas canvas = new Canvas();
            canvas.Width = 150.0;
            canvas.Height = 20.0;
            canvas.Background = Brushes.Transparent;
            Canvas.SetLeft(canvas, orgX);
            Canvas.SetTop(canvas, orgY - fontSize);
            int num = 0;
            for (int i = 0; i < 18; i++)
            {
                Border border = new Border();
                border.BorderBrush = Brushes.Black;
                border.BorderThickness = new Thickness(1.0);
                border.Height = 12.0;
                border.Width = 12.0;
                border.Child = new TextBlock
                {
                    Foreground = Brushes.Black,
                    FontFamily = new FontFamily("Arial"),
                    FontSize = 9.0,
                    Text = archiveid.ToArray<char>()[i].ToString(),
                    TextAlignment = TextAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };
                if (i > 0)
                {
                    num += 14;
                }
                Canvas.SetLeft(border, (double)num);
                canvas.Children.Add(border);
            }
            return canvas;
        }
		public static Canvas CreatShortArchiveid(string archiveid, double orgX, double orgY, double fontSize)
		{
			if (archiveid.Length < 17)
			{
				archiveid = archiveid.PadRight(17, ' ');
			}
			fontSize = 12.0;
			Canvas canvas = new Canvas();
			canvas.Width = 150.0;
			canvas.Height = 20.0;
			canvas.Background = Brushes.Transparent;
			Canvas.SetLeft(canvas, orgX);
			Canvas.SetTop(canvas, orgY - fontSize);
			int num = 3;
			string source = archiveid.Substring(archiveid.Length - 8, 8);
			for (int i = 0; i < 8; i++)
			{
				Border border = new Border();
				border.BorderBrush = Brushes.Black;
				border.BorderThickness = new Thickness(1.0);
				border.Height = 12.0;
				border.Width = 12.0;
				border.Child = new TextBlock
				{
					Foreground = Brushes.Black,
					FontFamily = new FontFamily("Arial"),
					FontSize = 9.0,
					Text = source.ToArray<char>()[i].ToString(),
					TextAlignment = TextAlignment.Center,
					HorizontalAlignment = HorizontalAlignment.Center,
					VerticalAlignment = VerticalAlignment.Center
				};
				Canvas.SetLeft(border, (double)num);
				num += 16;
				canvas.Children.Add(border);
				if (i == 2)
				{
					TextBlock textBlock = new TextBlock();
					textBlock.Foreground = Brushes.Black;
					textBlock.FontSize = 9.0;
					textBlock.Text = "—";
					textBlock.TextAlignment = TextAlignment.Center;
					textBlock.HorizontalAlignment = HorizontalAlignment.Center;
					textBlock.VerticalAlignment = VerticalAlignment.Center;
					Canvas.SetLeft(textBlock, (double)num);
					num += 12;
					canvas.Children.Add(textBlock);
				}
			}
			return canvas;
		}
		public static Canvas CreatDate(string strDate, double orgX, double orgY, double fontSize)
		{
			strDate = strDate.Replace("-", "");
			if (strDate.Length < 8)
			{
				strDate = strDate.PadRight(8, ' ');
			}
			fontSize = 12.0;
			Canvas canvas = new Canvas();
			canvas.Width = 150.0;
			canvas.Height = 20.0;
			canvas.Background = Brushes.Transparent;
			Canvas.SetLeft(canvas, orgX);
			Canvas.SetTop(canvas, orgY - fontSize);
			int num = 0;
			for (int i = 0; i < 8; i++)
			{
				Border border = new Border();
				border.BorderBrush = Brushes.Black;
				border.BorderThickness = new Thickness(1.0);
				border.Height = 12.0;
				border.Width = 12.0;
				border.Child = new TextBlock
				{
					Foreground = Brushes.Black,
					FontFamily = new FontFamily("Arial"),
					FontSize = 9.0,
					Text = strDate.ToArray<char>()[i].ToString(),
					TextAlignment = TextAlignment.Center,
					HorizontalAlignment = HorizontalAlignment.Center,
					VerticalAlignment = VerticalAlignment.Center
				};
				Canvas.SetLeft(border, (double)num);
				num += 16;
				canvas.Children.Add(border);
				if (i == 3 || i == 5)
				{
					TextBlock textBlock = new TextBlock();
					textBlock.Foreground = Brushes.Black;
					textBlock.FontSize = 9.0;
					textBlock.Text = " ";
					textBlock.TextAlignment = TextAlignment.Center;
					textBlock.HorizontalAlignment = HorizontalAlignment.Center;
					textBlock.VerticalAlignment = VerticalAlignment.Center;
					num += 5;
					Canvas.SetLeft(textBlock, (double)num);
					canvas.Children.Add(textBlock);
				}
			}
			return canvas;
		}
		public static Canvas CreatCheck(string checkVal, double orgX, double orgY, double fontSize, int count)
		{
			string[] array = checkVal.Split(new char[]
			{
				','
			});
			fontSize = 12.0;
			Canvas canvas = new Canvas();
			canvas.Height = 20.0;
			canvas.Background = Brushes.Red;
			Canvas.SetLeft(canvas, orgX);
			Canvas.SetTop(canvas, orgY - fontSize);
			int num = 20;
			for (int i = 0; i < count; i++)
			{
				Border border = new Border();
				border.BorderBrush = Brushes.Black;
				border.BorderThickness = new Thickness(1.0);
				border.Height = 12.0;
				border.Width = 12.0;
				TextBlock textBlock = new TextBlock();
				textBlock.Foreground = Brushes.Black;
				textBlock.FontFamily = new FontFamily("Arial");
				textBlock.FontSize = 9.0;
				if (i > array.Length - 1)
				{
					textBlock.Text = "";
				}
				else
				{
					textBlock.Text = array[i];
				}
				textBlock.TextAlignment = TextAlignment.Center;
				textBlock.HorizontalAlignment = HorizontalAlignment.Center;
				textBlock.VerticalAlignment = VerticalAlignment.Center;
				border.Child = textBlock;
				Canvas.SetLeft(border, (double)(i * num));
				canvas.Children.Add(border);
				if (i > 0)
				{
					TextBlock textBlock2 = new TextBlock();
					textBlock2.Foreground = Brushes.Black;
					textBlock2.FontFamily = new FontFamily("Arial");
					textBlock2.FontSize = 15.0;
					textBlock2.Width = 12.0;
					textBlock2.Height = 12.0;
					textBlock2.Text = "/";
					Canvas.SetLeft(textBlock2, (double)(i * num - num / 3));
					canvas.Children.Add(textBlock2);
				}
			}
			return canvas;
		}
		public static TextBlock DrawCheck(double orgX, double orgY, double fontSize)
		{
			TextBlock textBlock = new TextBlock();
			Canvas.SetLeft(textBlock, orgX - fontSize / 5.0);
			Canvas.SetTop(textBlock, orgY - fontSize * 0.8);
			textBlock.Foreground = Brushes.Black;
			textBlock.FontFamily = new FontFamily("宋体");
			textBlock.FontSize = fontSize;
			textBlock.Text = "√";
			return textBlock;
		}
		public static FixedDocumentSequence setPage(string strFilename, List<ListValue> dicVal)
		{
			int num = 0;
			if (string.IsNullOrEmpty(strFilename))
			{
				return null;
			}
			XpsDocument xpsDocument = new XpsDocument(strFilename, FileAccess.Read);
			FixedDocumentSequence fixedDocumentSequence = xpsDocument.GetFixedDocumentSequence();
			foreach (DocumentReference current in fixedDocumentSequence.References)
			{
				bool forceReload = false;
				FixedDocument document = current.GetDocument(forceReload);
				foreach (PageContent current2 in document.Pages)
				{
					FixedPage pageRoot = current2.GetPageRoot(forceReload);
					Canvas canvas = new Canvas();
					canvas.Width = pageRoot.Width;
					canvas.Height = pageRoot.Height;
					canvas.Background = Brushes.Transparent;
					int arg_A8_0 = pageRoot.Children.Count;
					List<UIElement> list = new List<UIElement>();
					for (int i = 0; i < pageRoot.Children.Count; i++)
					{
						num++;
						UIElement uIElement = pageRoot.Children[i];
						if (uIElement is Glyphs)
						{
							Glyphs glyphs = (Glyphs)uIElement;
							string unicodeString = glyphs.UnicodeString;
							if (Regex.IsMatch(unicodeString, "\\{.*?\\}"))
							{
								list.Add(pageRoot.Children[i]);
								UIElement uIElement2 = DrawItems.ReplaceMark(glyphs, dicVal);
								if (uIElement2 != null)
								{
									canvas.Children.Add(uIElement2);
								}
							}
						}
					}
					foreach (UIElement current3 in list)
					{
						pageRoot.Children.Remove(current3);
					}
					pageRoot.Children.Add(canvas);
					((IAddChild)current2).AddChild(pageRoot);
				}
			}
			xpsDocument.Close();
			return fixedDocumentSequence;
		}
		public static UIElement ReplaceMark(Glyphs gps, List<ListValue> dicVal)
		{
			structMark Mk = DrawItems.ExplodeMark(gps);
			double fontSize = Mk.fontSize;
			double orgX = Mk.x;
			double y = Mk.y;
			UIElement result = new UIElement();
			ListValue listValue = new ListValue();
			listValue = (
				from m in dicVal
				where m.strMark == Mk.val.Trim()
				select m).FirstOrDefault<ListValue>();
			if (listValue == null)
			{
				listValue = new ListValue();
				listValue.strMark = Mk.val;
				listValue.strVal = "";
			}
			else
			{
				if (listValue.strVal == null)
				{
					listValue.strVal = "";
				}
			}
			if (Mk.val.Contains("archiveid"))
			{
				if (listValue.strType == "1")
				{
					result = DrawItems.CreatArchiveid(listValue.strVal, orgX, y, fontSize);
				}
                else if (listValue.strType == "2")
                {
                    result = DrawItems.CreatLongArchiveid(listValue.strVal, orgX, y, fontSize);
                }
				else
				{
					result = DrawItems.CreatShortArchiveid(listValue.strVal, orgX, y, fontSize);
				}
			}
			else
			{
				if (Mk.type == "#")
				{
					result = DrawItems.CreatCheck(listValue.strVal, orgX, y, fontSize, Mk.len);
				}
				else
				{
					if (Mk.type == "!")
					{
						result = DrawItems.CreatDate(listValue.strVal, orgX, y, fontSize);
					}
					else
					{
						if (Mk.type == "%")
						{
							result = DrawItems.CreatGlyphs(listValue.strVal, orgX, y, fontSize, Mk.width, Mk.height);
						}
                        else if (Mk.type == "&")
                        {
                            if (Mk.val.Contains("bchao"))
                            {
                                result = DrawItems.DrawIamgeBChao(listValue.strVal, orgX, y);
                            }
                            else if (Mk.val.Contains("ecg"))
                            {
                                result = DrawItems.DrawIamgeEcg(listValue.strVal, orgX, y);
                            }
                            else if (Mk.val.Contains("gumidu") || Mk.val.Contains("xinxueguan") || Mk.val.Contains("feigongneng"))
                            {
                                result = DrawItems.DrawIamgeBone(listValue.strVal, orgX, y);
                            }
                        }
						else
						{
							if (Mk.type == "@")
							{
								if (listValue.strVal == "1")
								{
									result = DrawItems.DrawCheck(orgX, y, 20.0);
								}
							}
							else
							{
								if (Mk.locat == "E")
								{
									int length = listValue.strVal.Length;
									orgX = Mk.x - (double)length * fontSize / 2.0;
								}
								//result = DrawItems.CreatGlyphs(listValue.strVal, orgX, y, fontSize, false, Mk.len, false);
                                result = DrawItems.CreatGlyphs(listValue.strVal, orgX, y, fontSize, false, listValue.strVal.Length, false);
							}
						}
					}
				}
			}
			return result;
		}
		public static structMark ExplodeMark(Glyphs gps)
		{
			structMark result = default(structMark);
			string text = gps.UnicodeString.Replace("{", "").Replace("}", "").Replace(" ", "");
			string[] array = text.Split(new char[]
			{
				','
			});
			result.fontSize = gps.FontRenderingEmSize;
			result.y = gps.OriginY;
			result.type = text.Substring(0, 1);
			if (array[0].Contains("*"))
			{
				result.locat = "E";
			}
			else
			{
				result.locat = "B";
			}
			result.val = array[0].Replace("*", "");
			if (array.Length > 1)
			{
				result.len = Convert.ToInt32(array[1]);
				if (result.type == "%")
				{
					result.width = (double)Convert.ToInt32(array[1]);
					if (array.Length > 2)
					{
						result.height = (double)Convert.ToInt32(array[2]);
					}
				}
			}
			else
			{
				if (result.type == "#")
				{
					result.len = 1;
				}
				else
				{
					result.len = 255;
				}
			}
			result.x = gps.OriginX;
			if (result.type == "#" && result.locat == "E")
			{
				result.x = gps.OriginX + result.fontSize * (double)(text.Length + 1) / 2.0;
				int len = result.len;
				result.x = result.x - (double)(len * 12) - (double)((len - 1) * 7) - 2.0;
			}
			if (result.type == "$" && result.locat == "E")
			{
				result.x = gps.OriginX + result.fontSize * (double)(text.Length + 2) / 2.0;
			}
			return result;
		}
		public static List<ListValue> lsCheck(string val, string type, string mark, int k)
		{
			List<ListValue> list = new List<ListValue>();
			string arg = "@" + type + mark;
			if (string.IsNullOrEmpty(val))
			{
				val = "";
			}
			int i;
			for (i = 1; i < k + 1; i++)
			{
				string value = (
					from m in val.Split(new char[]
					{
						','
					})
					where m == i.ToString()
					select m).FirstOrDefault<string>();
				if (!string.IsNullOrEmpty(value))
				{
					list.Add(new ListValue
					{
						strMark = arg + i,
						strVal = "1"
					});
				}
				else
				{
					list.Add(new ListValue
					{
						strMark = arg + i,
						strVal = "-1"
					});
				}
			}
			return list;
		}
		public static List<ListValue> lsCheck(string val, string mark, int k)
		{
			return DrawItems.lsCheck(val, "", mark, k);
		}
		public static string strToDate(object dateValue, int Flag)
		{
			if (dateValue == null || dateValue is DBNull)
			{
				return "";
			}
			string result;
			try
			{
				if (Flag == 1)
				{
					result = Convert.ToDateTime(dateValue).ToString("yyyy年MM月dd日");
				}
				else
				{
					if (Flag == 2)
					{
						result = Convert.ToDateTime(dateValue).ToString("yyyy-MM-dd");
					}
					else
					{
						if (Flag == 3)
						{
							result = Convert.ToDateTime(dateValue).ToString("yyyy年MM月");
						}
						else
						{
							if (Flag == 4)
							{
								result = Convert.ToDateTime(dateValue).ToString("MM月dd日");
							}
							else
							{
								result = Convert.ToDateTime(dateValue).ToString("yyyy-MM-dd");
							}
						}
					}
				}
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}
		public static string strToDate(object dateValue)
		{
			if (dateValue == null)
			{
				return "";
			}
			return DrawItems.strToDate(dateValue, 1);
		}
		public static string objToNumStr(object obj)
		{
			if (obj == null)
			{
				return "";
			}
			return DrawItems.objToNumStr(obj, 2);
		}
		public static string objToNumStr(object obj, int i)
		{
			if (obj == null)
			{
				return "";
			}
			if (obj.ToString() == "")
			{
				return "";
			}
			if (i == 0)
			{
				return string.Format("{0:#}", obj.ToString());
			}
			if (!((decimal)obj == 0m))
			{
				return string.Format("{0:0." + "0".PadRight(i, '0') + "}", obj);
			}
			if (i == 0)
			{
				return "0";
			}
			return string.Format("{0:0." + "0".PadRight(i, '0') + "}", obj);
		}
		public static string objToStr(object obj)
		{
			if (obj == null)
			{
				return "";
			}
			return obj.ToString();
		}
		public static bool SaveReport(string Filename, FixedDocumentSequence fqs)
		{
			bool result;
			try
			{
				File.Delete(Filename);
				SerializerProvider serializerProvider = new SerializerProvider();
				SerializerDescriptor serializerDescriptor = null;
				foreach (SerializerDescriptor current in serializerProvider.InstalledSerializers)
				{
					if (current.IsLoadable && Filename.EndsWith(current.DefaultFileExtension))
					{
						serializerDescriptor = current;
						break;
					}
				}
				if (serializerDescriptor != null)
				{
					Stream stream = File.Create(Filename);
					SerializerWriter serializerWriter = serializerProvider.CreateSerializerWriter(serializerDescriptor, stream);
					serializerWriter.Write(((IDocumentPaginatorSource)fqs).DocumentPaginator, null);
					stream.Close();
				}
				result = true;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}
        public static string GetECGConfig()
        {
            XmlDocument document = new XmlDocument();
            document.Load(Environment.CurrentDirectory + @"\ECGconfig.xml");
            XmlNode node = document.SelectSingleNode("//ECGType");

            if (node != null)
            {
                return node.InnerText.Trim();
            }

            return "";
        }
        public static Canvas DrawIamgeBChao(string checkVal, double orgX, double orgY)
        {
            Canvas canvas = new Canvas();
            Canvas.SetLeft(canvas, orgX);
            Canvas.SetTop(canvas, orgY - 15);
            if (!string.IsNullOrEmpty(checkVal))
            {
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.CacheOption = BitmapCacheOption.OnLoad;

                using (Stream ms = new MemoryStream(File.ReadAllBytes(checkVal)))
                {
                    bi.StreamSource = ms;
                    bi.EndInit();
                    bi.Freeze();
                }
                System.Windows.Controls.Image image = new System.Windows.Controls.Image();
                image.Source = bi;
                image.Width = 687;                       //设置图片宽度  
                image.Height = 971;                     //设置图片高度  
                image.SetValue(Canvas.LeftProperty, 1.0); //设置图片x坐标  
                image.SetValue(Canvas.TopProperty, 1.0);   //设置图片y坐标  
                canvas.Children.Add(image);
            }
            return canvas;
        }

        public static Canvas DrawIamgeEcg(string checkVal, double orgX, double orgY)
        {
            Canvas canvas = new Canvas();
            Canvas.SetLeft(canvas, orgX - 10);
            Canvas.SetTop(canvas, orgY - 10);
            if (!string.IsNullOrEmpty(checkVal))
            {
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.CacheOption = BitmapCacheOption.OnLoad;

                using (Stream ms = new MemoryStream(File.ReadAllBytes(checkVal)))
                {
                    bi.StreamSource = ms;
                    bi.EndInit();
                    bi.Freeze();
                }
                System.Windows.Controls.Image image = new System.Windows.Controls.Image();
                image.Source = bi;
                image.Width = 1200;                       //设置图片宽度  
                image.Height = 750;                     //设置图片高度  
                image.SetValue(Canvas.LeftProperty, 1.0); //设置图片x坐标  
                image.SetValue(Canvas.TopProperty, 1.0);   //设置图片y坐标  
                canvas.Children.Add(image);
            }
            return canvas;
        }
        public static Canvas DrawIamgeBone(string checkVal, double orgX, double orgY)
        {
            Canvas canvas = new Canvas();
            Canvas.SetLeft(canvas, orgX-60);
            Canvas.SetTop(canvas, orgY-50);
            if (!string.IsNullOrEmpty(checkVal))
            {
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.CacheOption = BitmapCacheOption.OnLoad;

                using (Stream ms = new MemoryStream(File.ReadAllBytes(checkVal)))
                {
                    bi.StreamSource = ms;
                    bi.EndInit();
                    bi.Freeze();
                }
                System.Windows.Controls.Image image = new System.Windows.Controls.Image();
                image.Source = bi;
                image.Width = 687;                       //设置图片宽度  
                image.Height = 971;                     //设置图片高度  
                image.SetValue(Canvas.LeftProperty, 1.0); //设置图片x坐标  
                image.SetValue(Canvas.TopProperty, 1.0);   //设置图片y坐标  
                canvas.Children.Add(image);
            }
            return canvas;
        }
        /// <summary>
        /// 删除文件夹以及文件
        /// </summary>
        /// <param name="file"> 文件夹路径 </param>
        public static void DeleteDir(string file)
        {
            try
            {
                // 去除文件夹和子文件的只读属性
                // 去除文件夹的只读属性
                System.IO.DirectoryInfo fileInfo = new DirectoryInfo(file);
                fileInfo.Attributes = FileAttributes.Normal & FileAttributes.Directory;

                //去除文件的只读属性
                File.SetAttributes(file, System.IO.FileAttributes.Normal);

                // 判断文件夹是否还存在
                if (Directory.Exists(file))
                {
                    foreach (string f in Directory.GetFileSystemEntries(file))
                    {
                        if (File.Exists(f))
                        {
                            // 如果有子文件删除文件
                            File.Delete(f);
                            Console.WriteLine(f);
                        }
                        else
                        {
                            // 循环递归删除子文件夹
                            DeleteDir(f);
                        }
                    }

                    // 删除空文件夹
                    if (file.ToLower() != "printtemp") Directory.Delete(file);
                    Console.WriteLine(file);
                }
            }
            catch (Exception ex) // 异常处理
            {
                Console.WriteLine(ex.Message.ToString());// 异常信息
            }
        }
    }
}
