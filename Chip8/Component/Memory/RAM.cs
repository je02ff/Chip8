namespace Chip8.Component.Memory;

public class RAM
{
    private Register[] _registerArray = new Register[16];

    public RAM()
    {
        for (int i = 0; i < _registerArray.Length; i++)
        {
            _registerArray[i] = MemoryFactory.CreateRegister();
        }

    }
    
}