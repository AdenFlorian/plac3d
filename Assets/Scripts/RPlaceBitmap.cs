public struct RPlaceBitmap
{
    public readonly int Width;
    public readonly int Height;
    public int Area { get { return Width * Height; } }

    public readonly byte[] _bytes;

    /// <summary>
    /// Bytes array should have 0's in the 4 high order bits, and the color in the 4 lower order bits.
    /// One 4 bit color per byte.
    /// </summary>
    /// <param name="bytes"></param>
    public RPlaceBitmap(byte[] bytes, int width, int height)
    {
        _bytes = bytes;
        Width = width;
        Height = height;
    }

    public byte GetByte(int x, int y)
    {
        return _bytes[x + (y * Width)];
    }
}