using Chip8.Component.Memory;


const string FONT_FILE_PATH = "../../../Component/Memory/cosmacvipfont.txt";
const string ROM_FILE_PATH = "../../../assets/rom/ibm.ch8";

MainMemory mainMemory = MemoryFactory.CreateMainMemory(4096);
MemoryLoader.LoadFontToMainMemory(FONT_FILE_PATH, mainMemory);
MemoryLoader.LoadRomToMainMemory(ROM_FILE_PATH, mainMemory);


Console.WriteLine("Loading font to main memory...");
