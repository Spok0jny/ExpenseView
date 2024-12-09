using System.Collections.ObjectModel;

namespace ExpenseView
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;// R ustawienie bindingcontext pozwala collectionview wiazac sie z wlasciwosciami, laczy xaml z cs, oznacza to ze wszystkie wlasciowsci jak wydatki beda 'widoczne' w xamlu do bindingu
        }

        //zmienne
        public double budzet = 1000;
        
       
        public class Wydatek
        {
            public required string Nazwa { get; set; }
            public required double Kwota { get; set; }

            public string KwotaZl => $"{Kwota:F2} zł";
            //R sformatowana kwota wydatku, 2 miejsca po przecinku i dopisane zł na koncu
        }

        public ObservableCollection<Wydatek> Wydatki { get; set; } = new ObservableCollection<Wydatek>();
        //R obserrvablecollection sprawia ze jak zmieni sie kolekcja to zmieni sie tez w xamlu
        private void dodajWydatekBtn_Clicked(object sender, EventArgs e)
        {
            
            var kwotaText = kwotaWydatkuEntry.Text;
            var nazwa = nazwaWydatkuEntry.Text; 

            double kwota = 0.0; 

            
            if (double.TryParse(kwotaText, out kwota))
            {
               
                Wydatki.Add(new Wydatek { Nazwa = nazwa, Kwota = kwota });
                budzet -= kwota;
                budzetLabel.Text = budzet.ToString() + "zl";
                if (budzet < 0)
                {
                    budzetLabel.TextColor = Color.FromRgb(255, 0, 0); 
                }
                else
                {
                    budzetLabel.TextColor = Color.FromRgb(0, 255, 0); 
                }
            }
            else
            {
              
                DisplayAlert("Błąd", "Wprowadź prawidłową kwotę", "OK");
            }

            nazwaWydatkuEntry.Text = string.Empty;
            kwotaWydatkuEntry.Text = string.Empty;

        }

        
        private async void zmienBudzet_Clicked(object sender, EventArgs e)
        {
            string nowyBudzet = await DisplayPromptAsync(
                "Zmień budżet",
                "Tutaj podaj nową wartość budżetu:",
                "OK",
                "COFNIJ",
                "1.000.000.000zl",
                initialValue: "1000zl",
                keyboard: Keyboard.Numeric


                );

            if (!string.IsNullOrEmpty(nowyBudzet) && double.TryParse(nowyBudzet, out double nowyBudzetDouble))
            {
                budzet = nowyBudzetDouble;
                await DisplayAlert("Sukces", $"Twój nowy budżet to {budzet:F2} zł", "OK");
                budzetLabel.Text = budzet.ToString() + "zl";
                if (budzet < 0)
                {
                    budzetLabel.TextColor = Color.FromRgb(255, 0, 0);
                }
                else
                {
                    budzetLabel.TextColor = Color.FromRgb(0, 255, 0);
                }
            }


        }
    }

}
