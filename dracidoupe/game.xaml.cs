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
    /// Interaction logic for game.xaml
    /// </summary>
    public partial class game : Window
    {
        Player player;
        public game(Player _player)
        {
            InitializeComponent();
            player = _player;
            Game();
        }
        public void Game()
        {
            playerInfo();
            enemyInfo();
        }
        public void playerInfo()
        {
            PlayerFirstLeftLabel.Content = "Síla:";
            PlayerSecondLeftLabel.Content = "Životy:";
            PlayerThirdLeftLabel.Content = "EXP:";
            AttackBtn.Content = "Útok";
            HealBtn.Content = "Uzdravit (10XP)";

            PlayerFirstRightLabel.Content = player.Attack;
            PlayerSecondRightLabel.Content = player.Health;
            PlayerThirdRightLabel.Content = player.Exp;
            PlayerNameLabel.Content = player.Name;
        }
        public void enemyInfo()
        {
            EnemyFirstLeftLabel.Content = "Síla:";
            EnemySecondLeftLabel.Content = "Životy:";
            EnemyThirdLeftLabel.Content = "EXP:";

            EnemyFirstRightLabel.Content = player.Attack;
            EnemySecondRightLabel.Content = player.Health;
            EnemyThirdRightLabel.Content = player.Exp;
            EnemyNameLabel.Content = player.Name;
        }
        private void AttackBtnClick(object sender, RoutedEventArgs e)
        {
           
        }
        private void HealBtnClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
