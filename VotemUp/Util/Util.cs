using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace VotemUp
{
    public static class Util
    {
        public static String readFile(String path)
        {
            System.IO.StreamReader myFile = new System.IO.StreamReader(path);
            string myString = myFile.ReadToEnd();
            myFile.Close();

            return myString;
        }

        public static String[] readFileToArray(String path)
        {
            String filecontent = readFile(path);
            return filecontent.Split('\n');           
        }

        public static String getMD5Hash(String toHash)
        {
            MD5 md5Hash = MD5.Create();
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(toHash));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        public static int getMD5HashAsInt(String toHash)
        {
            MD5 md5Hash = MD5.Create();
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(toHash));
            return BitConverter.ToInt32(data, 0);
        }

    }
}
