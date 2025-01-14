using Chip8.Command;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace Chip8;

public class Display
{
    public bool[,] PixelScreen { get; } = new bool[32, 64];
    private int _pixelScale = 16;
    private int _height;
    private int _width;
    private Color _backgroundColor= new Color(155, 188, 15, 0);
    private Color _foregroundColor = new Color(15, 56, 15, 255);

    private int _x = 0;
    private int _y = 0;

    public Display()
    {
        InitWindow(1024, 512, "Chip8 emulator");
        SetTargetFPS(60);
        _height = PixelScreen.GetLength(0);
        _width = PixelScreen.GetLength(1);
    }

    public void Render()
    {
        // PixelScreen[_x, _y] =  !PixelScreen[_x, _y];
        // _y++;
        // if (_y >= 64)
        // {
        //     _y = 0;
        //     _x++;
        // };
        // if (_x >= 32)
        // {
        //     _x = 0;
        //     _y = 0;
        // }
        
        BeginDrawing();
        ClearBackground(_backgroundColor);
        for (var x = 0; x < _height; x++)
        {
            for (var y = 0; y < _width; y++)
            {
                if (PixelScreen[x, y])
                {
                    DrawRectangle(y * _pixelScale, x * _pixelScale, _pixelScale, _pixelScale, _foregroundColor);
                }
            }
        }
        EndDrawing();
    }
}