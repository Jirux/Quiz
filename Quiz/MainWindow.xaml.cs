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
        public MainWindow()
        {
            InitializeComponent();
            string[] sorok = File.ReadAllLines("adatok.txt");
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
            
            foreach (Tantargy tantargy in Tantargy.OsszesTantargy)
            {
                tantargyBox.Items.Add(tantargy);
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ElozoButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void KiertekelesButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void KovetkezoButton_Click(object sender, RoutedEventArgs e)
        {
            
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

        private void TemaBox_SelectChanged(object sender, EventArgs e)
        {
            
        }
    }
}