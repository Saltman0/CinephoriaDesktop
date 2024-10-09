using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace CinephoriaDesktop.Views.Incident;

public partial class IncidentReportWindow : Window
{
    public IncidentReportWindow()
    {
        InitializeComponent();
    }
    
    private void SubmitIncident(object? sender, RoutedEventArgs e)
    {
        // TODO Valider et envoyer une requête au serveur contenant les différentes informations pour l'enregistrer
        Console.WriteLine("Submitting Incident");
    }

    private void CloseWindow(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}