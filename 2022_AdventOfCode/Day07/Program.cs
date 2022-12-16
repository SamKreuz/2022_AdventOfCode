//Part 1: 2h
using Day07;
string path = "../../../input/input.txt";
var lines = File.ReadAllLines(path);

Folder uppestFolder = null;
Folder currentFolder = null;
List<Folder> allFolders = new List<Folder>();

foreach (var line in lines)
{
    var lineStrings = line.Split(' ');

    // Move into folder
    if (line.StartsWith("$ cd") && lineStrings[2] != "..")
    {
        string name = lineStrings[2].Trim();
        if (uppestFolder == null)
        {
            uppestFolder = new Folder(name, null);
            currentFolder = uppestFolder;
            allFolders.Add(uppestFolder);
        }
        else
        {
            Folder subfolder = currentFolder.AddSubfolder(name);
            currentFolder = subfolder;
            allFolders.Add(subfolder);
        }
    }

    // Add Dir in Current
    if (line.StartsWith("dir"))
    {
        string name = lineStrings[1];
        currentFolder.AddSubfolder(name);
    }

    // Add File
    if (!line.StartsWith("dir") && !line.StartsWith('$'))
    {
        int size = int.Parse(lineStrings[0].Trim());
        string name = lineStrings[1];
        currentFolder.AddFile(name, size);
    }

    // Move out
    if (lineStrings.Length >= 3 && lineStrings[2] == "..")
    {
        currentFolder = currentFolder.Parent;
    }

}

uppestFolder.UpdateFolderSize();
var sum = allFolders.Where(x => x.Size <= 100000).Sum(y => y.Size);
Console.WriteLine("Part 1: " + sum);


//Part 2: 5min
int unusedSpace = 70000000 - uppestFolder.Size;
int neededSpace = 30000000 - unusedSpace;

var folder = allFolders.Where(y => y.Size >= neededSpace)
                       .OrderBy(x => x.Size)
                       .FirstOrDefault();

Console.WriteLine("Part 2: " + folder.Size);