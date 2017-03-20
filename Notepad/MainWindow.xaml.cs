﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Notepad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string currentFile = "";
        private string initialDir;
        List<Persoon> personen = new List<Persoon>();

        public MainWindow()
        {
            InitializeComponent();

            initialDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            personen.Add(new Persoon { Voornaam = "Willy", Achternaam = "Janssens", GeboorteDatum = new DateTime(1990, 1, 2) });
            personen.Add(new Persoon { Voornaam = "James", Achternaam = "Moriarty", GeboorteDatum = new DateTime(1898, 7, 3) });
            people.ItemsSource = personen;

        }

        private void fileOpen_Click(object sender, RoutedEventArgs e)
        {
            StreamReader inputStream;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = initialDir;
            if (dialog.ShowDialog() == true)
            {
                currentFile = dialog.FileName;
                inputStream = File.OpenText(currentFile);
                textBox.Text = inputStream.ReadToEnd();
                inputStream.Close();
            }
        }

        private void fileSave_Click(object sender, RoutedEventArgs e)
        {
            if (currentFile == "")
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.InitialDirectory = initialDir;
                if (dialog.ShowDialog() == true)
                {
                    currentFile = dialog.FileName;
                }
            }
            StreamWriter outputStream = File.CreateText(currentFile);
            outputStream.Write(textBox.Text);
            outputStream.Close();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void fileSaveAs_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter outputStream;
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.InitialDirectory = initialDir;
            if (dialog.ShowDialog() == true)
            {
                currentFile = dialog.FileName;
                outputStream = File.CreateText(currentFile);
                outputStream.Write(textBox.Text);
                outputStream.Close();
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Dit is een ripoff van de normale notepad. Veel plezier!");
        }

        private void parseMenu_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
