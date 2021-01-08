using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace KangShuoTech.Utilities.Common
{
    public class MessageProtocol
    {
        // 协议类别，值 = ( 0 直 254 )
        public byte XieYiFirstFlag;
        // 协议二级标志，值 = (0 至 254 )
        public byte XieYiSecondFlag;
        //实际消息长度   
        public int MessageContentLength;
        /// 实际消息内容
        public byte[] MessageContent;
        // 多余的Bytes
        public byte[] DuoYvBytes;

        public MessageProtocol(byte _xieYiFirstFlage, byte _xieYiSecondFlage, byte[] _messageContent)
        {
            XieYiFirstFlag = _xieYiFirstFlage;
            XieYiFirstFlag = _xieYiSecondFlage;
            MessageContentLength = _messageContent.Length;
            MessageContent = _messageContent;
        }
        public MessageProtocol()
        { 
        }
        /// <summary>
        /// byte[] 转换为 MessageXieYi
        /// </summary>
        /// <param name="buffer">字节数组缓冲器。</param>
        /// <returns></returns>
        public static MessageProtocol FromBytes(byte[] buffer)
        {
            int bufferLength = buffer.Length;

            MessageProtocol messageXieYi = new MessageProtocol();
            try
            {
              

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    BinaryReader binaryReader = new BinaryReader(memoryStream);

                    messageXieYi.XieYiFirstFlag = binaryReader.ReadByte(); //读取协议一级标志，读1个字节
                    messageXieYi.XieYiSecondFlag = binaryReader.ReadByte(); //读取协议二级标志，读1个字节
                    messageXieYi.MessageContentLength = binaryReader.ReadInt32(); //读取实际消息长度，读4个字节                

                    //如果【进来的Bytes长度】大于【一个完整的MessageXieYi长度】
                    if ((bufferLength - 6) > messageXieYi.MessageContentLength)
                    {
                        messageXieYi.MessageContent = binaryReader.ReadBytes(messageXieYi.MessageContentLength); //读取实际消息内容，从第7个字节开始读
                        messageXieYi.DuoYvBytes = binaryReader.ReadBytes(bufferLength - 6 - messageXieYi.MessageContentLength);
                    }

                    //如果【进来的Bytes长度】等于【一个完整的MessageXieYi长度】
                    if ((bufferLength - 6) == messageXieYi.MessageContentLength)
                    {
                        messageXieYi.MessageContent = binaryReader.ReadBytes(messageXieYi.MessageContentLength); //读取实际消息内容，从第7个字节开始读
                    }

                    binaryReader.Close(); //关闭二进制读取器，是否资源
                }
            }
            catch (Exception ex)
            {
                string s = ex.ToString();
            }

            return messageXieYi; //返回消息协议对象
        }

        /// <summary>
        /// 按照先后顺序合并字节数组，并返回合并后的字节数组。
        /// </summary>
        /// <param name="firstBytes">第一个字节数组</param>
        /// <param name="firstIndex">第一个字节数组的开始截取索引</param>
        /// <param name="firstLength">第一个字节数组的截取长度</param>
        /// <param name="secondBytes">第二个字节数组</param>
        /// <param name="secondIndex">第二个字节数组的开始截取索引</param>
        /// <param name="secondLength">第二个字节数组的截取长度</param>
        /// <returns></returns>
        public static byte[] ToArray(byte[] firstBytes, int firstIndex, int firstLength, byte[] secondBytes, int secondIndex, int secondLength)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryWriter bw = new BinaryWriter(ms);
                bw.Write(firstBytes, firstIndex, firstLength);
                bw.Write(secondBytes, secondIndex, secondLength);

                bw.Close();
                bw.Dispose();

                return ms.ToArray();
            }
        }
    }
}
