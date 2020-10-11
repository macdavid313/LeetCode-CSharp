/*
 * File: 468ValidateIPAddress.cs
 * Project: String
 * Created Date: Sunday, 11th October 2020 1:47:00 pm
 * Author: David Gu (macdavid313@gmail.com)
 * Runtime: 84 ms, faster than 86.49% of C# online submissions for Validate IP Address.
 * Memory Usage: 23.9 MB, less than 7.43% of C# online submissions for Validate IP Address.
 * -----
 * Last Modified: Sunday, 11th October 2020 2:28:50 pm
 * Modified By: David Gu (macdavid313@gmail.com>)
 * -----
 * Copyright (c) David Gu 2020
 */


using System;
using System.Linq;

namespace ValidateIPAddress
{
    public class Solution
    {
        public string ValidIPAddress(string IP)
        {
            if (IP.Count(c => c == '.') == 3) return ValidateIPv4(IP);
            else if (IP.Count(c => c == ':') == 7) return ValidateIPv6(IP);
            else return "Neither";
        }

        string ValidateIPv4(string IP)
        {
            foreach (var block in IP.Split('.'))
            {
                if (block.Length == 0 || block.Length > 3 || (block.Length > 1 && block[0] == '0')) return "Neither";
                if (block.Any(c => !char.IsDigit(c))) return "Neither";
                var n = Convert.ToInt32(block);
                if (n > 255) return "Neither";
            }
            return "IPv4";
        }

        string ValidateIPv6(string IP)
        {
            foreach (var block in IP.Split(':'))
            {
                if (block.Length == 0 || block.Length > 4) return "Neither";
                if (!block.ToLower().All(c => char.IsDigit(c) || ('a' <= c && c <= 'f')))
                    return "Neither";
            }
            return "IPv6";
        }
    }
}