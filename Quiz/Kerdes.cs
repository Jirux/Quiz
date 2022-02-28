using System.Collections.Generic;

namespace Quiz;

public class Kerdes
{
    private Tantargy Tantargy { get; }
    private string Temakor { get; }
    private string _kerdes { get; }
    private List<Valasz> Valaszok { get; }

    public Kerdes(Tantargy tantargy, string temakor, string kerdes, List<Valasz> valaszok)
    {
        Tantargy = tantargy;
        Temakor = temakor;
        _kerdes = kerdes;
        Valaszok = valaszok;
    }
}