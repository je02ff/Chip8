namespace Chip8.Component.Memory;

public class MemoryFactory: IMemoryFactory
{
    public static Register CreateRegister() => new Register();
    public static MainMemory CreateMainMemory(int bytes) => new MainMemory(bytes);
}