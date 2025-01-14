using Chip8.Component;

namespace Chip8.Command;

// Jump
public class Op_1NNN(CPU cpu, Instruction instruction): ICommand 
{
    public void Execute()
    {
        // cpu._PC = (short)((instruction.SecondNibble << 8) | (instruction.ThirdNibble << 4) | instruction.FourthNibble);
        Console.WriteLine("Op_1NNN");
    }
}