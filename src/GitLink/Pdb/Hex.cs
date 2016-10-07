using System;
using System.Linq;
using Catel;

namespace GitLink.Pdb {
    public static class Hex {
        public static string Encode(byte[] buffer) {
            Argument.IsNotNullOrEmptyArray(() => buffer);

            return BitConverter.ToString(buffer).Replace("-", string.Empty);
        }

        public static byte[] Decode(string hex) {
            if (string.IsNullOrEmpty(hex)) {
                return new byte[0];
            }

            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
    }
}