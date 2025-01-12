using Chip8.Component.Memory;

namespace Chip8.Command;

// Clear screen
public class Op_00E0(MainMemory mainMemory): ICommand 
{
    public void Execute()
    {
        Array.Fill(mainMemory.Data, (byte)0, 0x100, 0x100 + (62*32));
    }
}