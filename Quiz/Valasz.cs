namespace Quiz;

public class Valasz
{
    public string Szoveg { get; }
    public bool Helyes { get; }

    public Valasz(string szoveg, bool helyes)
    {
        Szoveg = szoveg;
        Helyes = helyes;
    }
}