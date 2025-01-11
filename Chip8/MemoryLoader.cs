using Chip8.Component.Memory;

public static class MemoryLoader
{
    public static void LoadFontToMainMemory(string filePath, Memory memoryBuffer)
    {
        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                var index = 0x50;
                while (reader.ReadLine() is { } line)
                {
                    if (line.StartsWith("0b"))
                    {
                        string pureBinary = line.Substring(2);
                        byte result = Convert.ToByte(pureBinary, 2);
                        memoryBuffer.Data[index] = result;
                        index++;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public static void LoadRomToMainMemory(string filePath, Memory memoryBuffer)
    {
        try
        {
            using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
                long fileSize = reader.BaseStream.Length;

                const int START_INDEX = 0x200;
                
                if (memoryBuffer.Data.Length < (fileSize + START_INDEX))
                {
                    throw new InvalidOperationException($"Not enough space in main memory to hold the file starting at {START_INDEX}");
                }
                
                reader.BaseStream.Seek(0, SeekOrigin.Begin);
                for (int i = START_INDEX; i < (fileSize + START_INDEX); i++)
                {
                    memoryBuffer.Data[i] = reader.ReadByte();    
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading ROM file: {ex.Message}");
        }
    }
}