namespace GitLink.Pdb {
    public class PdbName {
        public PdbName(string name = "") {
            Name = name;
        }

        public int Stream { get; set; }
        public string Name { get; set; }
        public int FlagIndex { get; set; }
    }
}