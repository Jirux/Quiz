namespace Quiz;

public class Valasz
{
    private string _szoveg { get; }
    private bool _helyes { get; }

    public Valasz(string szoveg, bool helyes)
    {
        _szoveg = szoveg;
        _helyes = helyes;
    }
}