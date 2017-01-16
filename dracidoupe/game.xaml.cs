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
        Enemy enemy;
        public game(Player _player)
        {
            InitializeComponent();
            player = _player;            
            createEnemies();

            //MUSI BYT UPLNE DOLE!
            Game();
        }
        public void createEnemies()
        {
            enemy = new Enemy();
            enemy.Name = "Pavouk";
            enemy.Health = 100;
            enemy.MaxHealth = 100;
            enemy.Attack = 10;
            enemy.Exp = 20;
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
            PlayerSecondRightLabel.Content = player.Health + "/" + player.MaxHealth;
            PlayerThirdRightLabel.Content = player.Exp;
            PlayerNameLabel.Content = player.Name;
        }
        public void enemyInfo()
        {
            EnemyFirstLeftLabel.Content = "Síla:";
            EnemySecondLeftLabel.Content = "Životy:";
            EnemyThirdLeftLabel.Content = "EXP:";

            EnemyFirstRightLabel.Content = enemy.Attack;
            EnemySecondRightLabel.Content = enemy.Health + "/" + enemy.MaxHealth;
            EnemyThirdRightLabel.Content = enemy.Exp;
            EnemyNameLabel.Content = enemy.Name;
        }
        private void AttackBtnClick(object sender, RoutedEventArgs e)
        {
            onAttack();
            
            playerInfo();
            enemyInfo();
            onDeath();
        }
        private void HealBtnClick(object sender, RoutedEventArgs e)
        {

            if (player.Exp > 9 && player.Health <= player.MaxHealth * 0.9)
            {
                player.Health += player.MaxHealth * 0.1;
                player.Exp -= 10;
            }
            else { MessageBox.Show("Nedostatek EXPŮ!", "Bohužel"); }
            playerInfo();
            enemyInfo();
        }
        
        public void onAttack()
        {
            enemy.Health -= player.Attack;
            player.Health -= enemy.Attack;
        }
        public void onDeath()
        {
            if (enemy.Health < 1)
            {
                if (player.Health < 1)
                {
                    MessageBox.Show("PIU PIU PIU !! Si zabil", ":DDDDD");
                }
            }
            else if (player.Health < 1)
            {
                MessageBox.Show("Zemřel jsi!", ":(((((");
                this.Close();
            }
        }
        
    }
}
