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
            //R dodanie nowego wydatku, trzeba jeszcze dodac formularz bo nie ma xdd
            Wydatki.Add(new Wydatek { Nazwa = "Test", Kwota = 10.00  });
        }
    }

}
