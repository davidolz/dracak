﻿using System;
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
        //Axe axe = new Axe("Golden Sword", 200, 200);
        //pridani trid + definovani promennych
        Player player;
        Enemy enemy;        
        MainWindow MainWindow;
             
        Random r = new Random();
        private int level = 1;
        public game(Player _player)
        {
            InitializeComponent();
            player = _player;            
            createEnemy();          
            enemy.Attack = Math.Round(player.Attack * 0.9);

            
            Game();
        }
        private double randomMultiplier;
        private double randomGolds;
        private double randomVal;
        //vytvoreni enemaka
        public void createEnemy()
        {
            if (level == 10)
            {
                randomGolds = r.Next(40, 50);
                enemy = new Enemy();
                enemy.Name = "BOSS PILAŽ!";
                enemy.MaxHealth = Math.Round(player.MaxHealth * 1.1, 0);
                enemy.Health = enemy.MaxHealth;
                enemy.Attack = Math.Round(player.Attack * 1.1, 0);
                enemy.Exp = Math.Round(enemy.MaxHealth / randomGolds, 0);
                enemy.Attack += Math.Round(player.Exp / 2, 0);
            }
            else if (level == 20)
            {
                randomGolds = r.Next(30, 40);
                enemy = new Enemy();
                enemy.Name = "BOSS MENEŽERIS!";
                enemy.MaxHealth = Math.Round(player.MaxHealth * 1.2, 0);
                enemy.Health = enemy.MaxHealth;
                enemy.Attack = Math.Round(player.Attack * 1.2, 0);
                enemy.Exp = Math.Round(enemy.MaxHealth / randomGolds, 0);
                enemy.Attack += Math.Round(player.Exp / 4, 0);
            }
            else if (level == 30)
            {
                randomGolds = r.Next(20, 30);
                enemy = new Enemy();
                enemy.Name = "BOSS ČERT!";
                enemy.MaxHealth = Math.Round(player.MaxHealth * 1.3, 0);
                enemy.Health = enemy.MaxHealth;
                enemy.Attack = Math.Round(player.Attack * 1.3, 0);
                enemy.Exp = Math.Round(enemy.MaxHealth / randomGolds, 0);
                enemy.Attack += Math.Round(player.Exp / 6, 0);
            }
            else if (level == 40)
            {
                randomGolds = r.Next(10, 20);
                enemy = new Enemy();
                enemy.Name = "BOSS PEŤAN!";
                enemy.MaxHealth = Math.Round(player.MaxHealth * 1.4, 0);
                enemy.Health = enemy.MaxHealth;
                enemy.Attack = Math.Round(player.Attack * 1.4, 0);
                enemy.Exp = Math.Round(enemy.MaxHealth / randomGolds, 0);
                enemy.Attack += Math.Round(player.Exp / 8, 0);
            }
            else if (level == 50)
            {
                randomGolds = r.Next(1, 10);
                enemy = new Enemy();
                enemy.Name = "BREBURĎÁČEK!";
                enemy.MaxHealth = Math.Round(player.MaxHealth * 2, 0);
                enemy.Health = enemy.MaxHealth;
                enemy.Attack = Math.Round(player.Attack * 2, 0);
                enemy.Exp = Math.Round(enemy.MaxHealth / randomGolds, 0);
                enemy.Attack += Math.Round(player.Exp / 10, 0);
            }
            else
            {
                randomVal = r.Next(95, 105);
                randomMultiplier = randomVal / 100;
                randomGolds = r.Next(50, 75);
                enemy = new Enemy();
                enemy.Name = "Nepřítel";
                enemy.MaxHealth = Math.Round((player.Health * randomMultiplier), 0);
                enemy.Health = enemy.MaxHealth;
                enemy.Attack = Math.Round((player.Attack + player.Exp) * randomMultiplier, 0);
                enemy.Exp = Math.Round(enemy.MaxHealth / randomGolds, 0);
                enemy.Attack += Math.Round(player.Exp / 10, 0);
            }
        }
        //funkce na hru
        public void Game()
        {
            displayInfo();
            onRoundStart();

        }       
        //zobrazi info
        public void displayInfo()
        {
            PlayerFirstLeftLabel.Content = "Síla:";
            PlayerSecondLeftLabel.Content = "Životy:";
            PlayerThirdLeftLabel.Content = "Goldy:";
            AttackBtn.Content = "Útok";
            HealBtn.Content = "Uzdravit (1G)";

            PlayerFirstRightLabel.Content = Math.Round(player.Attack + player.Weapon.value, 0);
            PlayerSecondRightLabel.Content = Math.Round(player.Health, 0) + "/" + Math.Round(player.MaxHealth,0);
            PlayerThirdRightLabel.Content = Math.Round(player.Exp, 0);
            PlayerNameLabel.Content = player.Name;
            PlayerProgressBar.Value = Math.Round(player.Health, 0);
            PlayerProgressBar.Maximum = Math.Round(player.MaxHealth, 0);

            EnemyFirstLeftLabel.Content = "Síla:";
            EnemySecondLeftLabel.Content = "Životy:";
            EnemyThirdLeftLabel.Content = "Odměna:";

            EnemyFirstRightLabel.Content = Math.Round(enemy.Attack, 0);
            EnemySecondRightLabel.Content = Math.Round(enemy.Health, 0) + "/" + Math.Round(enemy.MaxHealth, 0);
            EnemyThirdRightLabel.Content = Math.Round(enemy.Exp, 0);
            EnemyNameLabel.Content = enemy.Name;
            EnemyProgressBar.Value = Math.Round(enemy.Health, 0);
            EnemyProgressBar.Maximum = Math.Round(enemy.MaxHealth, 0);

            LevelLabel.Content = "Level " + level;
            onRoundStart();
        }
        //kliknuti na attack button
        private void AttackBtnClick(object sender, RoutedEventArgs e)
        {
            onAttack();
            
            displayInfo();           
            onDeath();
            onRoundStart();
        }
        //kliknuti na heal
        private void HealBtnClick(object sender, RoutedEventArgs e)
        {

            if (player.Exp > 0 && player.Health <= player.MaxHealth * 0.9)
            {
                player.Health += player.MaxHealth * 0.1;
                Math.Round(player.Health, 0);
                player.Exp -= 1;
            }
            else if(player.Health == player.MaxHealth)
            {
                MessageBox.Show("Jsi již plně zdravý!", "!");
            }
            else if(player.Exp < 1)
            {
                MessageBox.Show("Nedostatek Goldů!", "Bohužel");
            }
            displayInfo();        
        }
        private void WeaponBtnClick(object sender, RoutedEventArgs e)
        {
            if(player.Exp >= player.Weapon.goldValue)
            {
                player.Exp -= player.Weapon.goldValue;
                player.Weapon.value += 10;                
                
                displayInfo();
            }
            else { }
        }
        private void ArmorBtnClick(object sender, RoutedEventArgs e)
        {
            if (player.Exp >= player.Armor.goldValue)
            {
                player.Exp -= player.Armor.goldValue;
                player.Armor.value += 50;                
                player.MaxHealth += 50;
                player.Health += 50;
                
                displayInfo();
            }
            else { }
        }
        //utok
        public void onAttack()
        {
            enemy.Health -= player.Attack + player.Weapon.value;
            player.Health -= enemy.Attack ;
        }
        //smrt
        public void onDeath()
        {
            if (enemy.Health < 1 && player.Health > 0)
            {
                
                
                onWin();
                displayInfo();           

            }
            else if (Math.Round(player.Health,0) < 1)
            {
                MessageBox.Show("Zemřel jsi!", ":( <3 !");
                MainWindow = new MainWindow();
                MainWindow.Show();
                
                this.Close();
            }
        }
        //vyhra
        public void onWin()
        {
            player.Exp += enemy.Exp;
            player.MaxHealth += r.Next(30,70);
            player.Attack += r.Next(10);           
            player.Health = player.MaxHealth;
            level++;
            createEnemy();           
            if(level >= 50)
            {
                MessageBox.Show("Úspěšně jsi dohrál tuto hru!!", "!");
                this.Close();
            }
            
        }
        //zacatek kola
        public void onRoundStart()
        {
            if(player.Health == player.MaxHealth && enemy.Health == enemy.MaxHealth)
            {
                WeaponBtn.Content = "10 Attack (10G)";
                ArmorBtn.Content =  "50 Health (10G)";            
                WeaponBtn.Visibility = Visibility.Visible;
                ArmorBtn.Visibility = Visibility.Visible;
            }
            else
            {
                WeaponBtn.Visibility = Visibility.Collapsed;
                ArmorBtn.Visibility = Visibility.Collapsed;
            }
        }
        
    }
}
