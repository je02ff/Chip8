// See https://aka.ms/new-console-template for more information

// Allocate 4KB of memory
byte[] buffer = new byte[4096];

string filePath = "../../../Component/Memory/cosmacvipfont.txt";

try
{
    using (StreamReader reader = new StreamReader(filePath))
    {
        string line;
        var index = 0x50;
        while ((line = reader.ReadLine()) != null)
        {
            if (line.StartsWith("0b"))
            {
                string pureBinary = line.Substring(2);

                // Convert the binary string to a byte
                byte result = Convert.ToByte(pureBinary, 2);
                buffer[index] = result;
                index++;
            }
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}