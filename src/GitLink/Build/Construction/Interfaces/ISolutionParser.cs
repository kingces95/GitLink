using System.IO;

namespace GitLink.Build.Construction {
    public interface ISolutionParser {
        StreamReader SolutionReader { get; set; }
        object[] Projects { get; }
        void ParseSolution();
    }
}