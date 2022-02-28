using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace Quiz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Kerdes> osszesKerdes = new List<Kerdes>();
        private List<Kerdes> jelenlegiKerdessor = new List<Kerdes>();
        private Tantargy jelenlegiTantargy = null;
        private Kerdes jelenlegiKerdes = null;
        private int kerdesIndex = 0;
        public MainWindow()
        {
            InitializeComponent();
            string[] sorok = File.ReadAllLines("adatok.txt");
            // adatok beolvasása
            foreach (string sor in sorok)
            {
                if (sor.StartsWith("Tantargy;")) continue;
                string[] adatok = sor.Split(";");
                Tantargy tantargy = Tantargy.Parse(adatok[0]);
                string temakor = adatok[1];
                string kerdesSzoveg = adatok[2];
                int helyesValaszIndex = int.Parse(adatok[3]);
                List<Valasz> valaszok = new List<Valasz>();
                for (int i = 4; i < adatok.Length; i++)
                {
                    valaszok.Add(new Valasz(adatok[i], i == 4 + helyesValaszIndex));
                }
                osszesKerdes.Add(new Kerdes(tantargy, temakor, kerdesSzoveg, valaszok));
            }
            
            // tantárgy ComboBox feltöltése
            foreach (Tantargy tantargy in Tantargy.OsszesTantargy)
            {
                tantargyBox.Items.Add(tantargy);
            }
        }

        private void KerdesMegjelenites(int index)
        {
            // index normalizálás
            kerdesIndex = Math.Max(0, Math.Min(index, jelenlegiKerdessor.Count - 1));
            jelenlegiKerdes = jelenlegiKerdessor[kerdesIndex];

            // kérdés megjelenítése
            kerdesLabel.Content = (kerdesIndex + 1) + ". " + jelenlegiKerdes._kerdes;
            kerdes1Label.Content = jelenlegiKerdes.Valaszok[0].Szoveg;
            kerdes2Label.Content = jelenlegiKerdes.Valaszok[1].Szoveg;
            kerdes3Label.Content = jelenlegiKerdes.Valaszok[2].Szoveg;
            kerdes4Label.Content = jelenlegiKerdes.Valaszok[3].Szoveg;
            
            // gombok kezelése
            if (kerdesIndex == 0)
                elozoButton.IsEnabled = false;
            else
                elozoButton.IsEnabled = true;

            if (kerdesIndex + 1 == jelenlegiKerdessor.Count)
                kovetkezoButton.IsEnabled = false;
            else
                kovetkezoButton.IsEnabled = true;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            kiertekelesButton.IsEnabled = true;

            jelenlegiKerdessor.Clear();
            //nincs választott témakör, minden témakör benne lesz a kérdéssorban
            if (temakorBox.SelectedItem == null)
            {
                osszesKerdes.FindAll(k => k.Tantargy == jelenlegiTantargy).ForEach(k => jelenlegiKerdessor.Add(k));
            }
            else
            {
                osszesKerdes.FindAll(k => k.Tantargy == jelenlegiTantargy && k.Temakor == temakorBox.SelectedItem).ForEach(k => jelenlegiKerdessor.Add(k));
            }
            // max 10 kérdés
            jelenlegiKerdessor = jelenlegiKerdessor.Take(10).ToList();
            KerdesMegjelenites(0);
        }

        private void ElozoButton_Click(object sender, RoutedEventArgs e)
        {
            KerdesMegjelenites(kerdesIndex - 1);
        }

        private void KiertekelesButton_Click(object sender, RoutedEventArgs e)
        {
            elozoButton.IsEnabled = false;
            kiertekelesButton.IsEnabled = false;
            kovetkezoButton.IsEnabled = false;
        }

        private void KovetkezoButton_Click(object sender, RoutedEventArgs e)
        {
            KerdesMegjelenites(kerdesIndex + 1);
        }

        private void TantargyBox_SelectChanged(object sender, EventArgs e)
        {
            jelenlegiTantargy = (Tantargy) tantargyBox.SelectedItem;
            temakorBox.Items.Clear();
            osszesKerdes
                .FindAll(k => k.Tantargy == jelenlegiTantargy)
                .DistinctBy(k => k.Temakor)
                .Select(k => k.Temakor)
                .ToList()
                .ForEach(temakor => temakorBox.Items.Add(temakor));
        }
    }
}