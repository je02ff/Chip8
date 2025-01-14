using Chip8.Component;
using Chip8.Component.Memory;

namespace Chip8.Command;

// Set register VX to value NN
public class Op_6XNN(CPU cpu, Instruction instruction): ICommand 
{
    public void Execute()
    {
        cpu.Ram.SetValue(instruction.SecondNibble, (byte)((instruction.ThirdNibble << 4) | instruction.FourthNibble));
    }
}