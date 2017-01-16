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
using System.Windows.Shapes;

namespace dracidoupe
{
    /// <summary>
    /// Interaction logic for newgame.xaml
    /// </summary>
    public partial class newgame : Window
    {
        //Definování proměnných
        private string PlayerNameValue;
        private bool PlayerNameAnswered;
        private string PlayerTypeValue;
        private bool PlayerTypeAnswered;
        private string PlayerGenderValue;
        private bool PlayerGenderAnswered;
        private string PlayerRaceValue;
        private bool PlayerRaceAnswered;
        private bool PlayerInfoConfirmed; 
        private bool PlayerReset;
        private string DirectoryOfExe = System.Reflection.Assembly.GetEntryAssembly().Location;
        
        MainWindow Home;
        game Game;
        Random rr = new Random();
       
        public newgame()
        {
            InitializeComponent();           
            NewGameForm();
        }
        //Inicializace vytvoření postavy
        private void NewGameForm()
        {
            if (PlayerReset == true)
            {
                PlayerNameAnswered = false;
                PlayerTypeAnswered = false;
                PlayerGenderAnswered = false;
                PlayerRaceAnswered = false;
                PlayerInfoConfirmed = false;
                PlayerReset = false;
                NewGameForm();
            }
            else if (PlayerNameAnswered == false) { PlayerName(); }
            else if (PlayerNameAnswered == true &&
                PlayerTypeAnswered == false) { PlayerType(); }
            else if (PlayerNameAnswered == true &&
                 PlayerTypeAnswered == true &&
                 PlayerGenderAnswered == false) { PlayerGender(); }
            else if (PlayerNameAnswered == true &&
                 PlayerTypeAnswered == true &&
                 PlayerGenderAnswered == true &&
                 PlayerRaceAnswered == false) { PlayerRace(); }
            else if (PlayerNameAnswered == true &&
                 PlayerTypeAnswered == true &&
                 PlayerGenderAnswered == true &&
                 PlayerRaceAnswered == true) { PlayerConfirm(); }
            else { }

        }
        //Vytvoření jména
        private void PlayerName()
        {      
            ShowTextBox();            
            NewGameLabel.Content = "Název postavy";
            NameTextBox.Text = "";
            ConfirmBtn.Content = "Potvrdit";
            UnconfirmBtn.Content = "Zrušit";
        }
        //Zvolení typu postavy
        private void PlayerType()
        {
            ShowButtons();           
            NewGameLabel.Content = "Typ postavy";
            FirstBtn.Content = "Válečník";
            SecondBtn.Content = "Šermíř";
            ThirdBtn.Content = "Hraničář";
        }
        //Zvolení pohlaví
        private void PlayerGender()
        {
            NewGameLabel.Content = "Pohlaví postavy";
            FirstBtn.Content = "Muž";
            SecondBtn.Content = "Žena";
            if (PlayerTypeAnswered == true) { ThirdBtn.Visibility = Visibility.Collapsed; } else { }
        }
        //Zvolení rasy
        private void PlayerRace()
        {
            if (PlayerGenderAnswered == true) { ThirdBtn.Visibility = Visibility.Visible; } else { }
            NewGameLabel.Content = "Rasa postavy";
            FirstBtn.Content = "Člověk";
            SecondBtn.Content = "Trpaslík";
            ThirdBtn.Content = "Elf";
        }
        //Potvrzení postavy
        private void PlayerConfirm()
        {
            HideEverything();
            ShowPlayerInfo();
            ConfirmBtn.Visibility = Visibility.Visible;
            UnconfirmBtn.Visibility = Visibility.Visible;
            PlayerInfoLabel.Content = "Tvoje postava";
            FirstLeftLabel.Content = "Jméno:";
            SecondLeftLabel.Content = "Typ:";
            ThirdLeftLabel.Content = "Pohlaví:";
            FourthLeftLabel.Content = "Rasa:";

            FirstRightLabel.Content = PlayerNameValue;
            SecondRightLabel.Content = PlayerTypeValue;
            ThirdRightLabel.Content = PlayerGenderValue;
            FourthRightLabel.Content = PlayerRaceValue;
            

        }
        //První možnost
        private void FirstBtnClick(object sender, RoutedEventArgs e)
        {
            if (PlayerTypeAnswered == false) { PlayerTypeValue = "Válečník"; PlayerTypeAnswered = true; }
            else if (PlayerGenderAnswered == false) { PlayerGenderValue = "Muž"; PlayerGenderAnswered = true; }
            else if (PlayerRaceAnswered == false) { PlayerRaceValue = "Člověk"; PlayerRaceAnswered = true; }
            else { }
            NewGameForm();
        }
        //Druhá možnost
        private void SecondBtnClick(object sender, RoutedEventArgs e)
        {
            if (PlayerTypeAnswered == false) { PlayerTypeValue = "Mág"; PlayerTypeAnswered = true; }
            else if (PlayerGenderAnswered == false) { PlayerGenderValue = "Žena"; PlayerGenderAnswered = true; }
            else if (PlayerRaceAnswered == false) { PlayerRaceValue = "Trpaslík"; PlayerRaceAnswered = true; }
            else { }

            NewGameForm();
        }
        //Třetí možnost
        private void ThirdBtnClick(object sender, RoutedEventArgs e)
        {
            if (PlayerTypeAnswered == false) { PlayerTypeValue = "Hraničář"; PlayerTypeAnswered = true; }
            else if (PlayerRaceAnswered == false) { PlayerRaceValue = "Elf"; PlayerRaceAnswered = true; }
            else { }
            NewGameForm();
        }
        //Potvrovací tlačítko
        private void ConfirmBtnClick(object sender, RoutedEventArgs e)
        {
            if (NameTextBox.Text != "" && PlayerNameAnswered == false)
            {
                try
                {
                    PlayerNameValue = NameTextBox.Text;
                    PlayerNameAnswered = true;
                }
                catch (Exception ex)
                {
                    System.IO.File.WriteAllText(DirectoryOfExe + "error.txt", ex.ToString());
                }
            }
            //Pokud potvrdí svoji postavu, postava se uloží a otevře se hra
            else if (PlayerNameAnswered == true &&
                 PlayerTypeAnswered == true &&
                 PlayerGenderAnswered == true &&
                 PlayerRaceAnswered == true && PlayerInfoConfirmed == false)
            {
                PlayerInfoConfirmed = true ;

                Player player = new Player();
                player.Name = PlayerNameValue;
                player.Type = PlayerTypeValue;
                player.Gender = PlayerGenderValue;
                player.Race = PlayerRaceValue;
                player.Attack = rr.Next(8, 12);              
                player.MaxHealth = rr.Next(90, 110);
                player.Health = player.MaxHealth;
                player.Exp = rr.Next(1,3);

                Game = new game(player);
                Game.Show();
                this.Close();
            }
            else { }
            NewGameForm();
        }
        //Talčítko zrušit
        private void UnconfirmBtnClick(object sender, RoutedEventArgs e)
        {
            if(PlayerNameAnswered == true &&
                PlayerTypeAnswered == true &&
                PlayerGenderAnswered == true &&
                PlayerRaceAnswered == true)
            {
            HideEverything();
            PlayerReset = true;
            NewGameForm();
            }
            else
            {
            Home = new MainWindow();
            Home.Show();
            this.Close();
            }
            

        }
        //Ukázání tlačítek
        private void ShowButtons()
        {
            NameTextBox.Visibility = Visibility.Collapsed;
            ConfirmBtn.Visibility = Visibility.Collapsed;
            UnconfirmBtn.Visibility = Visibility.Collapsed;

            FirstBtn.Visibility = Visibility.Visible;
            SecondBtn.Visibility = Visibility.Visible;
            ThirdBtn.Visibility = Visibility.Visible;

            PlayerInfoLabel.Visibility = Visibility.Collapsed;
            NewGameLabel.Visibility = Visibility.Visible;
        }
        //Ukázání formuláře pro zvolení jména
        private void ShowTextBox()
        {
            FirstBtn.Visibility = Visibility.Collapsed;
            SecondBtn.Visibility = Visibility.Collapsed;
            ThirdBtn.Visibility = Visibility.Collapsed;

            NameTextBox.Visibility = Visibility.Visible;
            ConfirmBtn.Visibility = Visibility.Visible;
            UnconfirmBtn.Visibility = Visibility.Visible;

            PlayerInfoLabel.Visibility = Visibility.Collapsed;
            NewGameLabel.Visibility = Visibility.Visible;
        }
        //Schování všeho
        private void HideEverything()
        {
            FirstBtn.Visibility = Visibility.Collapsed;
            SecondBtn.Visibility = Visibility.Collapsed;
            ThirdBtn.Visibility = Visibility.Collapsed;
            NewGameLabel.Visibility = Visibility.Collapsed;
            NameTextBox.Visibility = Visibility.Collapsed;

            ConfirmBtn.Visibility = Visibility.Collapsed;
            UnconfirmBtn.Visibility = Visibility.Collapsed;
            PlayerInfoLabel.Visibility = Visibility.Collapsed;

           
            FirstLeftLabel.Visibility = Visibility.Collapsed;
            SecondLeftLabel.Visibility = Visibility.Collapsed;
            ThirdLeftLabel.Visibility = Visibility.Collapsed;
            FourthLeftLabel.Visibility = Visibility.Collapsed;

            FirstRightLabel.Visibility = Visibility.Collapsed;
            SecondRightLabel.Visibility = Visibility.Collapsed;
            ThirdRightLabel.Visibility = Visibility.Collapsed;
            FourthRightLabel.Visibility = Visibility.Collapsed;

        }
        //Zobrazení informací o hráči
        private void ShowPlayerInfo()
        {
            PlayerInfoLabel.Visibility = Visibility.Visible;


            FirstLeftLabel.Visibility = Visibility.Visible;
            SecondLeftLabel.Visibility = Visibility.Visible;
            ThirdLeftLabel.Visibility = Visibility.Visible;
            FourthLeftLabel.Visibility = Visibility.Visible;

            FirstRightLabel.Visibility = Visibility.Visible;
            SecondRightLabel.Visibility = Visibility.Visible;
            ThirdRightLabel.Visibility = Visibility.Visible;
            FourthRightLabel.Visibility = Visibility.Visible;
        }
       
    }
}
