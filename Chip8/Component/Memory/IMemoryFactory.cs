namespace Chip8.Component.Memory;

public interface IMemoryFactory
{
    public static abstract Register CreateRegister();
    public static abstract MainMemory CreateMainMemory(int bytes);
}