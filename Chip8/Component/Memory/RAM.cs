namespace Chip8.Component.Memory;

public class RAM
{
    private Dictionary<byte, Register> _registers = new();

    public RAM()
    {
        _registers.Add(0x0, MemoryFactory.CreateRegister());
        _registers.Add(0x1, MemoryFactory.CreateRegister());
        _registers.Add(0x2, MemoryFactory.CreateRegister());
        _registers.Add(0x3, MemoryFactory.CreateRegister());
        _registers.Add(0x4, MemoryFactory.CreateRegister());
        _registers.Add(0x5, MemoryFactory.CreateRegister());
        _registers.Add(0x6, MemoryFactory.CreateRegister());
        _registers.Add(0x7, MemoryFactory.CreateRegister());
        _registers.Add(0x8, MemoryFactory.CreateRegister());
        _registers.Add(0x9, MemoryFactory.CreateRegister());
        _registers.Add(0xA, MemoryFactory.CreateRegister());
        _registers.Add(0xB, MemoryFactory.CreateRegister());
        _registers.Add(0xC, MemoryFactory.CreateRegister());
        _registers.Add(0xD, MemoryFactory.CreateRegister());
        _registers.Add(0xE, MemoryFactory.CreateRegister());
        _registers.Add(0xF, MemoryFactory.CreateRegister());
    }

    public byte GetValue(byte register)
    {
        return _registers[register].Data;
    }

    public bool SetValue(byte register, byte value)
    {
        if (_registers.ContainsKey(register))
        {
            _registers[register].Data = value;

            return true;
        }

        return false;
    }
}