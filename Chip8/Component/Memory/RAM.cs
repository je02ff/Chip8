namespace Chip8.Component.Memory;

public class RAM
{
    private Register _PC;
    private Register _SP;
    private Register[] _registerArray = new Register[16];

    public RAM()
    {
        _PC = MemoryFactory.CreateRegister();
        _SP = MemoryFactory.CreateRegister();
        for (int i = 0; i < _registerArray.Length; i++)
        {
            _registerArray[i] = MemoryFactory.CreateRegister();
        }
    }
    
}