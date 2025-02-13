using Microsoft.Maui.Controls;
using System;
using System.IO;

namespace MauiApp2
{
    public partial class MainPage : ContentPage
    {
        string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");

        public MainPage()
        {
            InitializeComponent();

            // Cargar el contenido del archivo si existe
            if (File.Exists(_fileName))
            {
                editor.Text = File.ReadAllText(_fileName);
            }
        }

        // Método para guardar las notas
        private void OnSaveButtonClicked(object sender, EventArgs e)
        {
            File.WriteAllText(_fileName, editor.Text);
        }

        // Método para eliminar las notas
        private void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            if (File.Exists(_fileName))
            {
                File.Delete(_fileName);
                editor.Text = string.Empty; // Limpiar el editor después de eliminar el archivo
            }
        }
    }
}
