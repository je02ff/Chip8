using Chip8.Component;

namespace Chip8.Command;

// Add value NN to VX
public class Op_7XNN(CPU cpu, Instruction instruction) : ICommand
{
    public void Execute()
    {
        // cpu.Ram.SetValue(instruction.SecondNibble,
        //     (byte)(cpu.Ram.GetValue(instruction.SecondNibble)
        //            + (byte)((instruction.ThirdNibble << 4) | instruction.FourthNibble))
        // );
        Console.WriteLine("Op_7XNN");
    }
}