using System;

namespace Quiz;

public class Tantargy
{
    public static readonly Tantargy Matematika = new Tantargy("Matematika", "Hatványozás", "Gyökvonás", "Alapműveletek");
    public static readonly Tantargy Tortenelem = new Tantargy("Történelem", "Török hódoltság", "II. világháború", "Hidegháború");
    public static readonly Tantargy Irodalom = new Tantargy("Irodalom", "Ady munkássága", "Ómagyar mária siralom");
    public static readonly Tantargy Angol = new Tantargy("Angol", "Past simple", "Present continuous");
    public static readonly Tantargy Informatika = new Tantargy("Informatika", "Szövegszerkesztés", "Weboldalkészítés");
    
    private string Nev { get; }
    private string[] Temakorok { get; }

    private Tantargy(string nev, params string[] temakorok)
    {
        Nev = nev;
        Temakorok = temakorok;
    }

    public static Tantargy Parse(string value)
    {
        switch (value)
        {
            case "Matematika":
                return Matematika;
            case "Történelem":
                return Tortenelem;
            case "Irodalom":
                return Irodalom;
            case "Angol":
                return Angol;
            case "Informatika":
                return Informatika;
            default:
                throw new ArgumentException("Nem létező tantárgy");
        }
    }
}