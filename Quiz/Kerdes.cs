using System.Collections.Generic;

namespace Quiz;

public class Kerdes
{
    private Tantargy Tantargy { get; }
    private string _kerdes { get; }
    private List<Valasz> Valaszok { get; }

    public Kerdes(Tantargy tantargy, string kerdes, List<Valasz> valaszok)
    {
        Tantargy = tantargy;
        _kerdes = kerdes;
        Valaszok = valaszok;
    }
}