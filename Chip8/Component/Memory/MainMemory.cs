namespace Chip8.Component.Memory;

public class MainMemory(int bytes) : IMemory
{
    public byte[] Data { get; } = new byte[bytes];
}