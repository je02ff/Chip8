using Chip8.Component;

namespace Chip8.Command;

// Display / Draw  
public class Op_DXYN(CPU cpu, Instruction instruction): ICommand 
{
    public void Execute()
    {
        var yOffset = 0;
        var xOffset = 0;
        for (int byteCounter = 0; byteCounter < instruction.FourthNibble; byteCounter++)
        {
            byte sprite = cpu.MainMemory.Data[cpu._index+ (byte)byteCounter];
            var posX = cpu.Ram.GetValue(instruction.SecondNibble);
            var posY = cpu.Ram.GetValue(instruction.ThirdNibble);
            XorSpriteIntoFrameBuffer(posX, posY + yOffset, sprite);
            yOffset++;
        }
        Console.WriteLine();
    }
    
    public void XorSpriteIntoFrameBuffer(int startX, int startY, byte sprite)
    {
        int height = cpu.Renderer.PixelScreen.GetLength(0); // 32 rows
        int width = cpu.Renderer.PixelScreen.GetLength(1); // 64 columns

        for (int bitIndex = 0; bitIndex < 8; bitIndex++)
        {
            bool bit = (sprite & (1 << (7 - bitIndex))) != 0;
            int x = (startX + bitIndex) % width; // Wrap horizontally
            int y = startY % height; // Wrap vertically (sprite is 1 row tall)
            Console.WriteLine($"inserting {bit} at x: {x} y: {y}");

            // XOR the sprite bit into the frameBuffer
            cpu.Renderer.PixelScreen[y, x] ^= bit;
            
        }
    }
}