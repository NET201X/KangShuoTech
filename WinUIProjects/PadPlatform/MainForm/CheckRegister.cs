using KangShuoTech.Utilities.Common;

namespace KangShuo
{
    using Microsoft.Win32;

    using System;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Security.Cryptography;
    using System.Text;
    using System.Windows.Forms;
    using Common;
    using System.Management;

    internal class CheckRegister
    {
        private static string Key = "flymetothenoon";
        private static string _uriDeviecId = "SOFTWARE\\QCSoft";

        private static string fingerPrint = string.Empty;

        /// <summary>
        /// 系统是否64位
        /// </summary>
        /// <returns></returns>
        private static bool Is64Bit()
        {
            return System.IntPtr.Size == 8;
        }

        /// <summary>
        /// 取得注册表加密项值
        /// </summary>
        /// <returns></returns>
        public static string GetDeviceId()
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(Value()));

                StringBuilder sBuilder = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                string id = sBuilder.ToString();

                return id;
            }
        }

        /// <summary>
        /// 取得注册表项值
        /// </summary>
        /// <returns></returns>
        public static string GetRegisterValue()
        {
            string ret = string.Empty;

            if (Is64Bit()) _uriDeviecId = "SOFTWARE\\Wow6432Node\\QCSoft";

            using (var obj = Registry.LocalMachine.OpenSubKey(_uriDeviecId, false))
            {
                if (obj != null)
                {
                    var value = obj.GetValue("DeviceId");

                    if (value != null) ret = Convert.ToString(value);
                }
            }

            return ret;
        }

        /// <summary>
        /// 写入注册表值
        /// </summary>
        public static void SetDeviceId()
        {
            string id = GetDeviceId();

            using (var tempk = Registry.LocalMachine.CreateSubKey(_uriDeviecId))
            {
                tempk.SetValue("DeviceId", id);
            }
        }

        private static string byteArr2HexStr(byte[] arrB)
        {
            StringBuilder builder = new StringBuilder(arrB.Length * 2);
            for (int i = 0; i < 8; i++)
            {
                int num2 = arrB[i];
                while (num2 < 0)
                {
                    num2 -= 0x100;
                }
                if (num2 < 0x10)
                {
                    builder.Append("0");
                }
                builder.Append(Convert.ToString(num2, 0x10));
            }
            return builder.ToString();
        }

        public static string Decrypt(string FileName)
        {
            StreamReader reader = new StreamReader(FileName);
            byte[] buffer = new byte[reader.BaseStream.Length];
            reader.BaseStream.Read(buffer, 0, buffer.Length);
            reader.Close();
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider
            {
                Key = Encoding.Default.GetBytes(Key.ToArray<char>(), 0, 8),
                IV = new byte[] { 0xaf, 60, 0x4a, 0x51, 0xee, 250, 0xac, 0xef }
            };
            MemoryStream stream = new MemoryStream();
            CryptoStream stream2 = new CryptoStream(stream, provider.CreateDecryptor(), CryptoStreamMode.Write);
            stream2.Write(buffer, 0, buffer.Length);
            stream2.FlushFinalBlock();
            return Encoding.UTF8.GetString(stream.ToArray());
        }

        public static void Encrypt(string stringToEncrypt, string FileName)
        {
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            byte[] bytes = Encoding.GetEncoding("UTF-8").GetBytes(stringToEncrypt);
            provider.Key = Encoding.Default.GetBytes(Key.ToArray<char>(), 0, 8);
            provider.IV = new byte[] { 0xaf, 60, 0x4a, 0x51, 0xee, 250, 0xac, 0xef };
            MemoryStream stream = new MemoryStream();
            CryptoStream stream2 = new CryptoStream(stream, provider.CreateEncryptor(), CryptoStreamMode.Write);
            stream2.Write(bytes, 0, bytes.Length);
            stream2.FlushFinalBlock();
            FileStream stream3 = System.IO.File.Open(FileName, FileMode.OpenOrCreate);
            foreach (byte num in stream.ToArray())
            {
                stream3.WriteByte(num);
            }
            stream3.Close();
            stream.Close();
        }

        public static string Encryptor(string encryptorString, string decryptKey)
        {
            string str = "";
            for (int i = 0; i < encryptorString.Length; i++)
            {
                string s = encryptorString.Substring(i, 1);
                byte[] rgbKey = new byte[8];
                byte[] bytes = Encoding.Default.GetBytes(s);
                byte[] buffer3 = Encoding.Default.GetBytes(decryptKey);
                for (int k = 0; k < 8; k++)
                {
                    rgbKey[k] = buffer3[k];
                }
                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                MemoryStream stream = new MemoryStream();
                CryptoStream stream2 = new CryptoStream(stream, provider.CreateEncryptor(rgbKey, new byte[8]), CryptoStreamMode.Write);
                stream2.Write(bytes, 0, bytes.Length);
                stream2.FlushFinalBlock();
                stream.GetBuffer();
                str = str + byteArr2HexStr(stream.GetBuffer());
            }
            string str3 = "";
            for (int j = 0; j < str.Length; j++)
            {
                string str4 = str.Substring(j, 1);
                string str5 = "";
                if ((j < (str.Length - 1)) && (((j + 1) % 4) == 0))
                {
                    str5 = str5 + "-";
                }
                str3 = str3 + str4 + str5;
            }
            return str3.ToUpper();
        }

        public static bool GetRegisterCodeFromConfig(out string regcode)
        {
            bool flag = false;
            regcode = ConfigHelper.GetNode("orgCode");
            if (!string.IsNullOrEmpty(regcode))
            {
                flag = regcode.Length >= 6;
            }
            return flag;
        }

        public static string m_Decrypt(string FileName)
        {
            int num;
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider
            {
                Key = Encoding.Default.GetBytes(Key.ToArray<char>(), 0, 8),
                IV = new byte[] { 0xaf, 60, 0x4a, 0x51, 0xee, 250, 0xac, 0xef }
            };
            StreamReader reader = new StreamReader(FileName);
            byte[] buffer = new byte[reader.BaseStream.Length];
            reader.BaseStream.Read(buffer, 0, buffer.Length);
            reader.Close();
            MemoryStream stream = new MemoryStream(buffer);
            CryptoStream input = new CryptoStream(stream, provider.CreateDecryptor(), CryptoStreamMode.Read);
            BinaryReader reader2 = new BinaryReader(input);
            byte[] buffer2 = new byte[0x3e8];
            BinaryWriter writer = new BinaryWriter(new StreamWriter(FileName).BaseStream);
            long length = writer.BaseStream.Length;
            while ((num = reader2.Read(buffer2, 0, 0x3e8)) > 0)
            {
                writer.Write(buffer2, 0, num);
            }
            string str = Encoding.UTF8.GetString(buffer2);
            writer.Close();
            input.Close();
            stream.Close();
            return str;
        }

        public static void m_Encrypt(string FileName)
        {
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider
            {
                Key = Encoding.Default.GetBytes(Key.ToArray<char>(), 0, 8),
                IV = new byte[] { 0xaf, 60, 0x4a, 0x51, 0xee, 250, 0xac, 0xef }
            };
            FileStream stream = System.IO.File.OpenRead(FileName);
            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);
            stream.Close();
            MemoryStream stream2 = new MemoryStream();
            CryptoStream stream3 = new CryptoStream(stream2, provider.CreateEncryptor(), CryptoStreamMode.Write);
            stream3.Write(buffer, 0, buffer.Length);
            stream3.Close();
            FileStream stream4 = System.IO.File.OpenWrite(FileName);
            foreach (byte num in stream2.ToArray())
            {
                stream4.WriteByte(num);
            }
            stream2.Close();
            stream4.Close();
        }

        public static int RegInputCount { get; set; }

        public static string Value()
        {
            if (string.IsNullOrEmpty(fingerPrint))
                fingerPrint = "CPU >> " + cpuId() + "\nBASE >> " + baseId() + "\nDISK >> " + GetHardDiskID();

            return fingerPrint;
        }

        public static string GetValue()
        {
            if (string.IsNullOrEmpty(fingerPrint))
                fingerPrint = GetHash("CPU >> " + cpuId() + "\nBASE >> " + baseId() + "\nBIOS >> " + biosId());

            return fingerPrint;
        }

        private static string GetHash(string s)
        {
            MD5 sec = new MD5CryptoServiceProvider();
            ASCIIEncoding enc = new ASCIIEncoding();
            byte[] bt = enc.GetBytes(s);
            return GetHexString(sec.ComputeHash(bt));
        }

        private static string GetHexString(byte[] bt)
        {
            string s = string.Empty;

            for (int i = 0; i < bt.Length; i++)
            {
                byte b = bt[i];

                int n, n1, n2;

                n = (int)b;
                n1 = n & 15;
                n2 = (n >> 4) & 15;

                if (n2 > 9)
                    s += ((char)(n2 - 10 + (int)'A')).ToString();
                else
                    s += n2.ToString();

                if (n1 > 9)
                    s += ((char)(n1 - 10 + (int)'A')).ToString();
                else
                    s += n1.ToString();

                if ((i + 1) != bt.Length && (i + 1) % 2 == 0) s += "-";
            }

            return s;
        }

        #region Original Device ID Getting Code

        //Return a hardware identifier
        private static string identifier
        (string wmiClass, string wmiProperty, string wmiMustBeTrue)
        {
            string result = "";

            ManagementClass mc = new ManagementClass(wmiClass);
            ManagementObjectCollection moc = mc.GetInstances();

            foreach (System.Management.ManagementObject mo in moc)
            {
                if (mo[wmiMustBeTrue].ToString() == "True")
                {
                    //Only get the first one
                    if (result == "")
                    {
                        try
                        {
                            result = mo[wmiProperty].ToString();
                            break;
                        }
                        catch
                        {
                        }
                    }
                }
            }
            return result;
        }

        //Return a hardware identifier
        private static string identifier(string wmiClass, string wmiProperty)
        {
            string result = "";
            ManagementClass mc = new ManagementClass(wmiClass);
            System.Management.ManagementObjectCollection moc = mc.GetInstances();

            foreach (System.Management.ManagementObject mo in moc)
            {
                //Only get the first one
                if (result == "")
                {
                    try
                    {
                        result = mo[wmiProperty].ToString();
                        break;
                    }
                    catch
                    {
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// CPU
        /// </summary>
        /// <returns></returns>
        private static string cpuId()
        {
            //Uses first CPU identifier available in order of preference
            //Don't get all identifiers, as it is very time consuming
            string retVal = identifier("Win32_Processor", "UniqueId");
            if (retVal == "") //If no UniqueID, use ProcessorID
            {
                retVal = identifier("Win32_Processor", "ProcessorId");
                if (retVal == "") //If no ProcessorId, use Name
                {
                    retVal = identifier("Win32_Processor", "Name");
                    if (retVal == "") //If no Name, use Manufacturer
                    {
                        retVal = identifier("Win32_Processor", "Manufacturer");
                    }
                    //Add clock speed for extra security
                    retVal += identifier("Win32_Processor", "MaxClockSpeed");
                }
            }
            return retVal;
        }
        /// <summary>
        /// /BIOS Identifier
        /// </summary>
        /// <returns></returns>
        private static string biosId()
        {
            return identifier("Win32_BIOS", "Manufacturer")
            + identifier("Win32_BIOS", "SMBIOSBIOSVersion")
            + identifier("Win32_BIOS", "IdentificationCode")
            + identifier("Win32_BIOS", "SerialNumber")
            + identifier("Win32_BIOS", "ReleaseDate")
            + identifier("Win32_BIOS", "Version");
        }
        //Main physical hard drive ID
        private static string diskId()
        {
            return identifier("Win32_DiskDrive", "Model")
            + identifier("Win32_DiskDrive", "Manufacturer")
            + identifier("Win32_DiskDrive", "Signature")
            + identifier("Win32_DiskDrive", "TotalHeads");
        }
        //Motherboard ID
        private static string baseId()
        {
            return identifier("Win32_BaseBoard", "Model")
            + identifier("Win32_BaseBoard", "Manufacturer")
            + identifier("Win32_BaseBoard", "Name")
            + identifier("Win32_BaseBoard", "SerialNumber");
        }
        //Primary video controller ID
        private static string videoId()
        {
            return identifier("Win32_VideoController", "DriverVersion")
            + identifier("Win32_VideoController", "Name");
        }
        //First enabled network card ID
        private static string macId()
        {
            return identifier("Win32_NetworkAdapterConfiguration",
                "MACAddress", "IPEnabled");
        }

        private static string GetHardDiskID()
        {
            try
            {
                // 硬盘编号
                string pSQL = "SELECT * FROM Win32_PhysicalMedia";

                ManagementObjectSearcher searcher = new ManagementObjectSearcher(pSQL);
                String strHardDiskID = null;
                foreach (ManagementObject mo in searcher.Get())
                {
                    strHardDiskID = mo["SerialNumber"].ToString().Trim();
                    break;
                }
                return strHardDiskID;
            }
            catch
            {
                return "";
            }
        }

        #endregion
    }
}

