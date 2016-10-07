using System.Collections.Generic;
using Catel;

namespace GitLink.Pdb {
    public class PdbRoot {
        public PdbRoot(PdbStream stream) {
            Argument.IsNotNull(() => stream);

            Stream = stream;
            Streams = new List<PdbStream>();
        }

        public PdbStream Stream { get; set; }
        public List<PdbStream> Streams { get; private set; }

        public int AddStream(PdbStream stream) {
            Streams.Add(stream);

            return Streams.Count - 1;
        }
    }
}