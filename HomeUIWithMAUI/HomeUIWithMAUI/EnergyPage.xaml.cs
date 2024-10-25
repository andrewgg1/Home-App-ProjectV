namespace HomeUIWithMAUI
{
    public partial class EnergyPage : ContentPage
    {
        public EnergyPage()
        {
            InitializeComponent();
        }

        private async void OnGenerateGraphClicked(object sender, EventArgs e)
        {
            // Simulate generating a graph
            UsageGraph.Source = "graph_placeholder.png";  // Replace with an actual graph image if available
            UsageGraph.IsVisible = true;
            await DisplayAlert("Energy Graph", "Graph generated successfully.", "OK");
        }
    }
}
