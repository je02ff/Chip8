using Chip8.Component.Memory;

public static class MemoryLoader
{
    public static void LoadFontToMainMemory(string filePath, MainMemory memoryBuffer)
    {
        int START_ADDRESS = 0x50;

        try
        {
            Console.WriteLine("Loading font to main memory...");
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (reader.ReadLine() is { } line)
                {
                    if (line.StartsWith("0b"))
                    {
                        string pureBinary = line.Substring(2);
                        byte result = Convert.ToByte(pureBinary, 2);
                        memoryBuffer.Data[START_ADDRESS] = result;
                        START_ADDRESS++;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public static void LoadRomToMainMemory(string filePath, MainMemory memoryBuffer)
    {
        const int START_ADDRESS = 0x200;
        
        try
        {
            Console.WriteLine("Loading rom to main memory...");            
            using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
                long fileSize = reader.BaseStream.Length;
                
                if (memoryBuffer.Data.Length < (fileSize + START_ADDRESS))
                {
                    throw new InvalidOperationException($"Not enough space in main memory to hold the file starting at {START_ADDRESS}");
                }
                
                reader.BaseStream.Seek(0, SeekOrigin.Begin);
                for (int i = START_ADDRESS; i < (fileSize + START_ADDRESS); i++)
                {
                    memoryBuffer.Data[i] = reader.ReadByte();    
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}