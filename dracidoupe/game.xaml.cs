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
        Random r = new Random();
        private int level = 1;
        public game(Player _player)
        {
            InitializeComponent();
            player = _player;            
            createEnemy();
            enemy.Attack = Math.Round(player.Attack * 0.9);

            //MUSI BYT UPLNE DOLE!
            Game();
        }
        private double randomMultiplier;
        private double randomGolds;
        private double randomVal;
        public void createEnemy()
        {
            randomVal = r.Next(99, 110);
            randomMultiplier = randomVal/100;
            randomGolds = r.Next(30, 50);
            enemy = new Enemy();
            enemy.Name = "Nepřítel";
            enemy.MaxHealth = Math.Round(player.Health * randomMultiplier,0);
            enemy.Health = enemy.MaxHealth;          
            enemy.Attack = Math.Round(player.Attack * randomMultiplier, 0);
            enemy.Exp = Math.Round(player.MaxHealth / randomGolds, 0);            
        }
        public void Game()
        {
            displayInfo();
            
        }       
        public void displayInfo()
        {
            PlayerFirstLeftLabel.Content = "Síla:";
            PlayerSecondLeftLabel.Content = "Životy:";
            PlayerThirdLeftLabel.Content = "Goldy:";
            AttackBtn.Content = "Útok";
            HealBtn.Content = "Uzdravit (1G)";

            PlayerFirstRightLabel.Content = Math.Round(player.Attack, 2);
            PlayerSecondRightLabel.Content = Math.Round(player.Health, 0) + "/" + Math.Round(player.MaxHealth,0);
            PlayerThirdRightLabel.Content = Math.Round(player.Exp, 0);
            PlayerNameLabel.Content = player.Name;
        
            EnemyFirstLeftLabel.Content = "Síla:";
            EnemySecondLeftLabel.Content = "Životy:";
            EnemyThirdLeftLabel.Content = "Odměna:";

            EnemyFirstRightLabel.Content = Math.Round(enemy.Attack, 0);
            EnemySecondRightLabel.Content = Math.Round(enemy.Health, 0) + "/" + Math.Round(enemy.MaxHealth, 0);
            EnemyThirdRightLabel.Content = Math.Round(enemy.Exp, 0);
            EnemyNameLabel.Content = enemy.Name;

            LevelLabel.Content = "Level " + level;
        }
        private void AttackBtnClick(object sender, RoutedEventArgs e)
        {
            onAttack();
            
            displayInfo();           
            onDeath();
        }
        private void HealBtnClick(object sender, RoutedEventArgs e)
        {

            if (player.Exp > 0 && player.Health <= player.MaxHealth * 0.9)
            {
                player.Health += Math.Round(player.MaxHealth * 0.1, 0);
                player.Exp -= 1;
            }
            else if(player.Health >= player.MaxHealth * 0.9)
            {
                MessageBox.Show("Jsi již plně zdravý!", "Brokolice");
            }
            else if(player.Exp < 1)
            {
                MessageBox.Show("Nedostatek Goldů!", "Bohužel");
            }
            displayInfo();        
        }
        
        public void onAttack()
        {
            enemy.Health -= player.Attack;
            player.Health -= enemy.Attack;
        }
        public void onDeath()
        {
            if (enemy.Health < 1 && player.Health > 0)
            {
                
                MessageBox.Show("PIU PIU PIU !! Si zabil", ":DDDDD");
                onWin();
                displayInfo();           

            }
            else if (player.Health < 1)
            {
                MessageBox.Show("Zemřel jsi!", ":(((((");
                this.Close();
            }
        }
        public void onWin()
        {
            player.Exp += enemy.Exp;
            player.MaxHealth += r.Next(20);
            player.Attack += r.Next(10);           
            player.Health = player.MaxHealth;
            createEnemy();
            level++;
        }
        
    }
}
