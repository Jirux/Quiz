using System.Collections.Generic;

namespace Quiz;

public class Kerdes
{
    public Tantargy Tantargy { get; }
    public string Temakor { get; }
    public string _kerdes { get; }
    public List<Valasz> Valaszok { get; }

    public Kerdes(Tantargy tantargy, string temakor, string kerdes, List<Valasz> valaszok)
    {
        Tantargy = tantargy;
        Temakor = temakor;
        _kerdes = kerdes;
        Valaszok = valaszok;
    }
}