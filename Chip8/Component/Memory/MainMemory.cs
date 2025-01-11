namespace Chip8.Component.Memory;

public class MainMemory: Memory
{
    public MainMemory(int bytes)
    {
        Data = new byte[bytes];
    }
}