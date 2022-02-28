using System;
using System.Collections.Generic;

namespace Quiz;

public class Tantargy
{
    public static readonly Tantargy Matematika = new Tantargy("Matematika", "Hatványozás", "Gyökvonás", "Alapműveletek");
    public static readonly Tantargy Tortenelem = new Tantargy("Történelem", "Török hódoltság", "II. világháború", "Hidegháború");
    public static readonly Tantargy Irodalom = new Tantargy("Irodalom", "Ady munkássága", "Ómagyar mária siralom");
    public static readonly Tantargy Angol = new Tantargy("Angol", "Past simple", "Present continuous");
    public static readonly Tantargy Informatika = new Tantargy("Informatika", "Szövegszerkesztés", "Weboldalkészítés");

    public static List<Tantargy> OsszesTantargy = new List<Tantargy>
    {
        Matematika,
        Tortenelem,
        Irodalom,
        Angol,
        Informatika
    };
    
    private string Nev { get; }
    private string[] Temakorok { get; }

    private Tantargy(string nev, params string[] temakorok)
    {
        Nev = nev;
        Temakorok = temakorok;
    }

    public static Tantargy Parse(string value)
    {
        return OsszesTantargy.Find(t => t.Nev == value);
    }
}