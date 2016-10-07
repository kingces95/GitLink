﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Catel;

namespace GitLink {
    public static class BinaryReaderExtensions {
        public static Guid ReadGuid(this BinaryReader binaryReader) {
            Argument.IsNotNull(() => binaryReader);

            return new Guid(binaryReader.ReadBytes(16));
        }

        public static string ReadCString(this BinaryReader binaryReader) {
            Argument.IsNotNull(() => binaryReader);

            var list = new List<byte>();

            var b = binaryReader.ReadByte();
            while (b != '\0') {
                list.Add(b);
                b = binaryReader.ReadByte();
            }

            return Encoding.UTF8.GetString(list.ToArray());
        }
    }
}