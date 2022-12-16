namespace Day07
{
    internal class Folder
    {
        public string Name { get; }
        public Folder Parent { get; }
        private List<Folder> Subfolders = new List<Folder>();
        private Dictionary<string, int> Files = new Dictionary<string, int>();
        public int Size { get; set; } = 0;

        public Folder(string name, Folder parent)
        {
            Name = name;
            Parent = parent;
        }

        public Folder AddSubfolder(string name)
        {
            Folder subfolder = Subfolders.FirstOrDefault(x => x.Name == name);

            if(subfolder == null)
            {
                subfolder = new Folder(name, this);
                Subfolders.Add(subfolder);
            }

            return subfolder;
        }

        public void AddFile(string name, int size)
        {
            Files.Add(name, size);
        }

        public void UpdateFolderSize() 
        {
            Size += Files.Sum(x => x.Value);
            Subfolders.ForEach(x => x.UpdateFolderSize());
            Subfolders.ForEach(x => Size += x.Size);
        }

    }


}
