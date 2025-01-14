using Chip8.Component;

namespace Chip8.Command;

// Display / Draw  
public class Op_DXYN(CPU cpu, Instruction instruction): ICommand 
{
    public void Execute()
    {
        // var y = instruction.ThirdNibble;
        // for (int i = cpu._index; i <= cpu._index + instruction.FourthNibble; i++)
        // {
        //     byte sprite = cpu.MainMemory.Data[i];
        //     int x = instruction.SecondNibble;
        //     if (y > 32)
        //     {
        //         y = 0;
        //     }
        //     // Iterate over each bit in the binary value
        //     for (int j = 0; j < 8; j++)
        //     {
        //         // Extract the i-th bit (from most significant to least significant)
        //         bool bit = (sprite & (1 << (7 - j))) != 0;
        //         
        //         // Set the value in the bool array
        //         if (x > 64)
        //         {
        //             x = 0;
        //         }
        //         cpu.Renderer.PixelScreen[x, y] = bit;
        //         x++;
        //     }
        //     y++;
        // }
        Console.WriteLine("Op_DXYN");
    }
}