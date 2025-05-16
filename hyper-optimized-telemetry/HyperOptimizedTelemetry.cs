public static class TelemetryBuffer
{
    
    public static byte[] ToBuffer(long reading)
    {
        bool signed = false;
        int bytes;
        switch (reading)
        {
            case <= 9_223_372_036_854_775_807 and >= 4_294_967_296:
                bytes = 8;
                signed = true;
                break;
            case <= 4_294_967_295 and >= 2_147_483_648:
                bytes = 4;
                break;
            case <= 2_147_483_647 and >= 65_536:
                bytes = 4;
                signed = true;
                break;
            case <= 65_535 and >= 0:
                bytes = 2;
                break;
            case <= -1 and >= -32_768:
                bytes = 2;
                signed = true;
                break;
            case <= -32_769 and >= -2_147_483_648:
                bytes = 4;
                signed = true;
                break;
            case <= -2_147_483_649 and >= -9_223_372_036_854_775_808:
                bytes = 8;
                signed = true;
                break;
        }

        int prefix = signed ? 256 - bytes : bytes;
        List<byte> buffer = [];
        buffer.Add((byte)prefix);
        buffer.AddRange(BitConverter.GetBytes(reading));


        for (int i = 0; i < buffer.Count; i++)
        {
            if (i > (bytes))
            {
                buffer[i] = 0;
            }
        }

        return buffer.ToArray();

    }

    public static long FromBuffer(byte[] buffer)
    {
        if (buffer[0] > 8 && buffer[0] < (256 - 8)) return 0;
        int bytes;
        bytes = buffer[0] > 128 ? buffer[0] - 256 : buffer[0];
        long result = bytes switch
        {
            8 => (long)BitConverter.ToUInt64(buffer, 1),
            4 => BitConverter.ToUInt32(buffer, 1),
            2 => BitConverter.ToUInt16(buffer, 1),
            -2 => BitConverter.ToInt16(buffer, 1),
            -4 => BitConverter.ToInt32(buffer, 1),
            -8 => BitConverter.ToInt64(buffer, 1),
            _ => 0
        };
        return result;
    }
}
