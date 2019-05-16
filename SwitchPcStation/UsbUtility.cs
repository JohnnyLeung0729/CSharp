using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SwitchPcStation
{
    public class UsbUtility
    {
        const string Key_File_Name = "Usb.key";

        /// <summary> 
        /// 获取优盘唯一序列号，可能需要以管理员身份运行程序 
        /// </summary> 
        /// <returns></returns> 
        public static string GetUSBId()
        {
            ManagementObjectSearcher wmiSearcher = new ManagementObjectSearcher("Select * From Win32_USBHub");
            string id = "";
            foreach (ManagementObject wmi_USB in wmiSearcher.Get())
            {
                string strPath = wmi_USB.Path.RelativePath;
                string[] strArr = strPath.Split('\"');
                string strTemp = strArr[1];

                //VID_ 是真正的优盘标示 
                if (strTemp.StartsWith("USB\\\\VID_"))
                    id += strTemp + ";";

            }
            return id.TrimEnd(';');
        }

        /// <summary> 
        /// 获取当前UsbKey，根据当前附加的序列号，生成 "序列号,UsbId"格式的字符串，并返回加密后的结果 
        /// 如果没有找到设备，那么返回空字符串 
        /// 如果返回值为空，请检查 message 的值。 
        /// </summary> 
        /// <param name="sourceNumber">要附加的序列号</param> 
        /// <param name="message">生成的操作信息</param> 
        /// <returns>当前加密后的UsbKey字符串</returns> 
        public static string GetCurrentUsbKey(string sourceNumber, out string message)
        {
            string strUsbId = GetUSBId();
            if (strUsbId != "")
            {
                if (strUsbId.Split(';').Length == 1)
                {
                    CheckCode cc = new CheckCode();
                    message = "OK";
                    string strTemp = sourceNumber + "," + strUsbId;
                    return cc.Encode(strTemp);
                }
                else
                {
                    message = "当前有多个U盘，请拨除其它U盘。";
                    return "";
                }
            }
            message = "未找到U盘或者U盘没有物理序列号。";
            return "";
        }

        /// <summary> 
        /// 将一个新的UsbKey写到当前U盘上 
        /// </summary> 
        /// <param name="sourceNumber">U盘所在盘符</param> 
        /// <param name="sourceNumber">要附加的序列号</param> 
        /// <param name="message">生成的操作信息</param> 
        /// <returns></returns> 
        public static bool WriteUsbKeyFile(string driveName, string sourceNumber, out string message)
        {
            string strCurrentUsbKey = GetCurrentUsbKey(sourceNumber, out message);
            if (strCurrentUsbKey != "")
            {
                if (driveName.EndsWith("\\"))
                    driveName += "\\";
                string strCurrKeyFileName = driveName + Key_File_Name;
                try
                {
                    using (StreamWriter writer = File.CreateText(strCurrKeyFileName))
                    {
                        writer.Write(strCurrentUsbKey);
                        writer.Flush();
                    }
                    message = "OK";
                    return true;
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                }
            }
            return false;
        }

        /// <summary> 
        /// 读取UsbKey文件的内容，返回内容格式为 "序列号,UsbId"格式的字符串 
        /// 如果未能正确读取文件，返回空字符。 
        /// </summary> 
        /// <param name="driveName">U盘所在盘符</param> 
        /// <param name="message">操作的消息</param> 
        /// <returns>UsbKey文件的内容</returns> 
        public static string ReadUsbKeyFile(string driveName, out string message)
        {
            if (driveName.EndsWith("\\"))
                driveName += "\\";
            string strCurrKeyFileName = driveName + Key_File_Name;
            message = "";
            try
            {
                string strResult = "";
                using (StreamReader reader = File.OpenText(strCurrKeyFileName))
                {
                    strResult = reader.ReadToEnd();
                }
                if (strResult != "")
                {
                    message = "OK";
                    CheckCode cc = new CheckCode();
                    return cc.Decode(strResult);
                }
                else
                {
                    message = "未能正确读取文件，文件内容可能为空！";
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return "";
        }
    }

    /// <summary> 
    /// 检查编码情况 
    /// </summary> 
    class CheckCode
    {
        const string KEY_64 = "fasfgew";
        const string IV_64 = "JDLJMAMI"; //注意了，是8个字符，64位  

        /// <summary> 
        /// 加密 
        /// </summary> 
        /// <param name="data"></param> 
        /// <returns></returns> 
        public string Encode(string data)
        {
            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(KEY_64);
            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(IV_64);
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            int i = cryptoProvider.KeySize;
            MemoryStream ms = new MemoryStream();
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateEncryptor(byKey, byIV), CryptoStreamMode.Write);
            StreamWriter sw = new StreamWriter(cst);
            sw.Write(data);
            sw.Flush();
            cst.FlushFinalBlock();
            sw.Flush();
            return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
        }

        /// <summary> 
        /// 解密 
        /// </summary> 
        /// <param name="data"></param> 
        /// <returns></returns> 
        public string Decode(string data)
        {
            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(KEY_64);
            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(IV_64);
            byte[] byEnc;
            try
            {
                byEnc = Convert.FromBase64String(data);
            }
            catch
            {
                return null;
            }
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream ms = new MemoryStream(byEnc);
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateDecryptor(byKey, byIV), CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cst);
            return sr.ReadToEnd();

        }
    }
}
