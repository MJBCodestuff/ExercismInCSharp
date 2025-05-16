static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        string idPart = "";
        if (id != null)
        {
            idPart = $"[{id}] - ";
        }
        return $"{idPart}{name} - {department?.ToUpper() ?? "OWNER"}";
    }
}
