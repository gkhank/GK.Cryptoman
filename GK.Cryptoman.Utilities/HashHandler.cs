﻿using System;
using System.Security.Cryptography;
using System.Text;

namespace GK.Cryptoman.Utilities
{
    public class HashHandler
    {
        public static String GetHash(String text, String key, string apiSecret)
        {

            // change according to your needs, an UTF8Encoding
            // could be more suitable in certain situations
            ASCIIEncoding encoding = new ASCIIEncoding();

            Byte[] textBytes = encoding.GetBytes(text);
            Byte[] keyBytes = encoding.GetBytes(apiSecret);

            Byte[] hashBytes;

            using (HMACSHA256 hash = new HMACSHA256(keyBytes))
                hashBytes = hash.ComputeHash(textBytes);

            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }

        public static String GetHash(Object value, String key)
        {
            return HashHandler.GetHash(value.ToString(), key);
        }
    }
}