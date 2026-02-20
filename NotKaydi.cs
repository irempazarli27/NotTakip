class NotKaydi
{
    public int Id { get; set; }
    public string Ad { get; set; }
    public string Ders { get; set; }
    public int Notu { get; set; }

public bool GecerliMi()
{
    if (string.IsNullOrWhiteSpace(Ad)) return false;
    if (string.IsNullOrWhiteSpace(Ders)) return false;
    if (Notu < 0 || Notu > 100) return false;

    return true;
}
}