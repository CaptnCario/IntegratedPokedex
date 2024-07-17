using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Integrated_Pokedex
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static char pokedexID;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void National_Dex_Click(object sender, RoutedEventArgs e)
        {

            pokedexID = 'N';
            InsideDex iDexFenster = new InsideDex();
            iDexFenster.ShowDialog();
            
        }

        private void Kanto_Dex_Click(object sender, RoutedEventArgs e)
        {
            pokedexID = 'K';
            InsideDex iDexFenster = new InsideDex();
            iDexFenster.ShowDialog();
        }

        private void Jotho_Dex_Click(object sender, RoutedEventArgs e)
        {
            pokedexID = 'J';
            InsideDex iDexFenster = new InsideDex();
            iDexFenster.ShowDialog();
        }

        private void Hoenn_Dex_Click(object sender, RoutedEventArgs e)
        {
            pokedexID = 'H';
            InsideDex iDexFenster = new InsideDex();
            iDexFenster.ShowDialog();
        }

        private void Sinnoh_Dex_Click(object sender, RoutedEventArgs e)
        {
            pokedexID = 'S';
            InsideDex iDexFenster = new InsideDex();
            iDexFenster.ShowDialog();
        }

        private void Einall_Dex_Click(object sender, RoutedEventArgs e)
        {
            pokedexID = 'E';
            InsideDex iDexFenster = new InsideDex();
            iDexFenster.ShowDialog();
        }

        
        private void Paldea_Dex_Click(object sender, RoutedEventArgs e)
        {
            pokedexID = 'P';
            InsideDex iDexFenster = new InsideDex();
            iDexFenster.ShowDialog();
        }

        private void Kalos_Dex_Click(object sender, RoutedEventArgs e)
        {
            pokedexID = 'L';
            InsideDex iDexFenster = new InsideDex();
            iDexFenster.ShowDialog();
        }

        private void Galar_Dex_Click(object sender, RoutedEventArgs e)
        {
            pokedexID = 'G';
            InsideDex iDexFenster = new InsideDex();
            iDexFenster.ShowDialog();
        }

        private void Alola_Dex_Click(object sender, RoutedEventArgs e)
        {
            pokedexID = 'A';
            InsideDex iDexFenster = new InsideDex();
            iDexFenster.ShowDialog();

        }
    }
}
