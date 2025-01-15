using Chip8.Component;

namespace Chip8.Command;

// Display / Draw  
public class Op_DXYN(CPU cpu, Instruction instruction): ICommand 
{
    public void Execute()
    {
        var y = instruction.ThirdNibble;
        for (int byteCounter = cpu._index; byteCounter < cpu._index + instruction.FourthNibble; byteCounter++)
        {
            byte sprite = cpu.MainMemory.Data[byteCounter];
            XorSpriteIntoFrameBuffer(instruction.SecondNibble, instruction.ThirdNibble, sprite);
        }
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

            // XOR the sprite bit into the frameBuffer
            cpu.Renderer.PixelScreen[y, x] ^= bit;
        }
    }
}