using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System;

namespace WlosyMniamMniam
{
    public partial class MainWindow : Window
    {
        private double avgHairDensity = 200; // Średnia gęstość włosów (włosy/cm2)

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double hairDensity = Convert.ToDouble(HairDensityTextBox.Text);
                double headCircumference = Convert.ToDouble(HeadCircumferenceTextBox.Text);
                double foreheadHeight = Convert.ToDouble(ForeheadHeightTextBox.Text);

                // Obliczanie powierzchni głowy przybliżonej do elipsoidy
                double headArea = Math.PI * (headCircumference / Math.PI) * (headCircumference / (2 * Math.PI)) + foreheadHeight;

                // Szacunkowa liczba włosów
                double estimatedHairCount = hairDensity * headArea;

                // Procentowa różnica w stosunku do średniej
                double percentageDifference = ((estimatedHairCount - (avgHairDensity * headArea)) / (avgHairDensity * headArea)) * 100;

                // Wyświetlanie wyników
                EstimatedHairCountTextBlock.Text = estimatedHairCount.ToString("N0");
                PercentageDifferenceTextBlock.Text = percentageDifference.ToString("N2") + "%";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd: " + ex.Message);
            }
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            HairDensityTextBox.Text = "";
            HeadCircumferenceTextBox.Text = "";
            ForeheadHeightTextBox.Text = "";
            EstimatedHairCountTextBlock.Text = "";
            PercentageDifferenceTextBlock.Text = "";
        }
    }
}