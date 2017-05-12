using System;
using System.Net;
using System.Text;
using System.Windows.Forms.VisualStyles;

namespace TraceabilityConnector.Helper
{
    public static class ModbusTcpHelper
    {
        public static int[] ByteArrayToWordArray (byte[] dataBytes)
        {
            if (dataBytes.Length < 2) return null;
            var word = new int[dataBytes.Length / 2];
            for (int x = 0; x < dataBytes.Length; x = x + 2)
            {
                word[x / 2] = dataBytes[x] * 256 + dataBytes[x + 1];
            }
            return word;
        }

        public static byte[] WordArrayToByteArray(int[] dataWord, int num)
        {

            var data = new byte[num * 2];
            for (int x = 0; x < num; x++)
            {
                byte[] dat = BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short) dataWord[x]));
                data[x * 2] = dat[0];
                data[x * 2 + 1] = dat[1];
            }
            return data;
        }

        public static byte[] ByteMachineShuffle(byte[] data)
        {
            var len = data.Length;
            var ganjil = len % 2 == 1;
            len = ganjil ? len + 1 : len;

            var temp = new byte[len];

            for (int i = 0; i < len; i++)
            {
                var j = i % 2;
                if (j == 0)
                    temp[i] = (i) == data.Length-1 && ganjil ? (byte) 0 : data[i + 1];
                else
                    temp[i] = data[i - 1];
            }
            return temp;
        }
        public static string ByteArrayToAsciiString(byte[] data)
        {
            var datas = ByteMachineShuffle(data);
            var result = Encoding.ASCII.GetString(datas);
            result = result.Substring(0, result.IndexOf("\0", StringComparison.Ordinal));
            return result;
        }

        public static byte[] AsciiStringToByteArray(string data)
        {
            return ByteMachineShuffle(Encoding.ASCII.GetBytes(data));
        }
    }
}
