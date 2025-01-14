using Chip8.Component;

namespace Chip8.Command;

// Sets the index register I to the value NNN
public class Op_ANNN(CPU cpu, Instruction instruction): ICommand 
{
    public void Execute()
    {
        // cpu._index =
        //     (short)((instruction.SecondNibble << 8) | (instruction.ThirdNibble << 4) | instruction.FourthNibble);
        Console.WriteLine("Op_ANNN");
    }
}