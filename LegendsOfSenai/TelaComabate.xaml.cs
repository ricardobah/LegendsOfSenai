﻿using Legends_lib;
using Legends_lib.Batalha;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=234238

namespace LegendsOfSenai
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class BlankPage1 : Page
    {
        //  Personagem aux1,aux2;
        public int turno;
        public BlankPage1()
        {

            turno = 1;
            this.InitializeComponent();
            skillPlayer2.Opacity = 0;
            AtkBas2.Opacity = 0;
            Batalha();

        }
        //teste 
        private void Batalha()// ATT AS INFS DE BATALHA
        {
            Uri imgp1 = null;
            Uri imgp2 = null;
            Uri btsk2=null, btsk1=null;
            switch (ControleBatalha.personagem1.Nome)
            {
                case "Guerreiro":
                    imgp1 = new Uri("ms-appx:Assets/characters/Warrrior_spt/humano/guerreiro/paldino-dir.png", UriKind.Absolute);
                    btsk1 = new Uri("ms-appx:Assets/itens/para-batalha/slash.png", UriKind.Absolute);
                    break;
                case "Esqueleto":
                    imgp1 = new Uri("ms-appx:Assets/characters/Warrrior_spt/esqueleto/esqueleto guerreiro/soldado-esqueleto-parado dir.png", UriKind.Absolute);
                    btsk1 = new Uri("ms-appx:Assets/itens/para-batalha/slash.png", UriKind.Absolute);
                    break;
                case "Mago":
                    imgp1 = new Uri("ms-appx:Assets/characters/Mago_spt/humano/mago/mago_lado_dir.png", UriKind.Absolute);
                    btsk1 = new Uri("ms-appx:Assets/itens/para-batalha/magic.png", UriKind.Absolute);
                    break;
                case "Necromancer":
                    imgp1 = new Uri("ms-appx:Assets/characters/Mago_spt/esqueleto/necromancer/necromancer parado-lado.png", UriKind.Absolute);
                    btsk1 = new Uri("ms-appx:Assets/itens/para-batalha/magic.png", UriKind.Absolute);
                    break;
                case "Arqueiro":
                    imgp1 = new Uri("ms-appx:///Assets/characters/Arqueiro_spt/humano/paladino/paladino-frente.png", UriKind.Absolute);
                    btsk1 = new Uri("ms-appx:Assets/itens/para-batalha/arrow.gif", UriKind.Absolute);
                    break;
                case "Hunter":
                    imgp1 = new Uri("ms-appx:///Assets/characters/Arqueiro_spt/esqueleto/esqueleto arqueiro/esqueleto arqueiro -frente.png", UriKind.Absolute);
                    btsk1 = new Uri("ms-appx:Assets/itens/para-batalha/arrow.gif", UriKind.Absolute);
                    break;
              
            }
            switch (ControleBatalha.personagem2.Nome)
            {
                case "Guerreiro":
                    imgp2 = new Uri("ms-appx:Assets/characters/Warrrior_spt/humano/guerreiro/paldino-dir.png", UriKind.Absolute);
                    btsk2 = new Uri("ms-appx:Assets/itens/para-batalha/slash.png", UriKind.Absolute);
                    break;
                case "Esqueleto":
                    imgp2 = new Uri("ms-appx:Assets/characters/Warrrior_spt/esqueleto/esqueleto guerreiro/soldado-esqueleto-parado dir.png", UriKind.Absolute);
                    btsk2 = new Uri("ms-appx:Assets/itens/para-batalha/slash.png", UriKind.Absolute);
                    break;
                case "Mago":
                    imgp2 = new Uri("ms-appx:Assets/characters/Mago_spt/humano/mago/mago_lado_dir.png", UriKind.Absolute);
                    btsk2 = new Uri("ms-appx:Assets/itens/para-batalha/magic.png", UriKind.Absolute);
                    break;
                case "Necromancer":
                    imgp2 = new Uri("ms-appx:Assets/characters/Mago_spt/esqueleto/necromancer/necromancer parado-lado.png", UriKind.Absolute);
                    btsk2 = new Uri("ms-appx:Assets/itens/para-batalha/magic.png", UriKind.Absolute);
                    break;
                case "Arqueiro":
                    imgp2 = new Uri("ms-appx:///Assets/characters/Arqueiro_spt/humano/paladino/paladino-frente.png", UriKind.Absolute);
                    btsk2 = new Uri("ms-appx:Assets/itens/para-batalha/arrow.gif", UriKind.Absolute);
                    break;
                case "Hunter":
                    imgp2 = new Uri("ms-appx:///Assets/characters/Arqueiro_spt/esqueleto/esqueleto arqueiro/esqueleto arqueiro -frente.png", UriKind.Absolute);
                    btsk2 = new Uri("ms-appx:Assets/itens/para-batalha/arrow.gif", UriKind.Absolute);
                    break;

            }

            imgPlayer1.Source = new BitmapImage(imgp1);
            imgPlayer2.Source = new BitmapImage(imgp2);
            skillPlayer1.Source = new BitmapImage(btsk1);
            skillPlayer2.Source = new BitmapImage(btsk2);
            TextBlock_SelectionChanged();
            verificaVencedor();
        }
        public Canvas x = null;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

           x = (Canvas)e.Parameter;
          
         
        }

        private void voltarMapa()
            // quando personagem morre mapa perde referência do objeto
        {
            if (ControleBatalha.vencedor == 1)
            {
                x.Children.Remove(ControleBatalha.personagem2.Imagem);
            }
            else if(ControleBatalha.vencedor == 2)
            {
                x.Children.Remove(ControleBatalha.personagem1.Imagem);
            }
            this.Frame.Navigate(typeof(Tela1_Mapa));
        }

        private void verificaVencedor()
        {

            if (ControleBatalha.personagem1.VidaAtual <= 0)
            {
                ControleBatalha.vencedor = 2;
                voltarMapa();
            }
            if (ControleBatalha.personagem2.VidaAtual <= 0)
            {
                
                ControleBatalha.vencedor = 1;
                voltarMapa();
            }
        }

        private void TextBlock_SelectionChanged()
        {
            Hp1.Text = "HP: " + ControleBatalha.personagem1.VidaAtual.ToString();
            Hp2.Text = "HP: " + ControleBatalha.personagem2.VidaAtual.ToString();
            Mp1.Text = "MP: " + ControleBatalha.personagem1.Mp.ToString();
            Mp2.Text = "MP: " + ControleBatalha.personagem2.Mp.ToString();
        }

        private void botao_AtkBas2(object sender, RoutedEventArgs e)
        {
            if (turno == 2)
            {
                ControleBatalha.personagem1.VidaAtual -= 10;
                Batalha();//botar p deixar o botão meio transparente e ativar o outro
                turno = 1;
                AtkBas2.Opacity = 0;
                AtkBas1.Opacity = 1;
            }

        }

      private void btn_Sk2(object sender, RoutedEventArgs e)
        {
            if (turno == 2 && ControleBatalha.personagem2.Mp>10)
            {
                
                ControleBatalha.personagem1.VidaAtual -= 20;
                Batalha();//botar p deixar o botão meio transparente e ativar o outro
                turno = 1;
                AtkBas2.Opacity = 0;
                AtkBas1.Opacity = 1;
                skillPlayer1.Opacity = 1;
                skillPlayer2.Opacity = 0;
                ControleBatalha.personagem2.Mp -= 10;
            }

        }
        private void btn_Sk1(object sender, RoutedEventArgs e)
        {
            if (turno == 1 && ControleBatalha.personagem1.Mp > 10)
            {
                ControleBatalha.personagem2.VidaAtual -= 20;
                Batalha();//botar p deixar o botão meio transparente e ativar o outro
                turno = 2;
                skillPlayer1.Opacity = 0;
                AtkBas2.Opacity = 1;
                skillPlayer2.Opacity = 1;
                AtkBas1.Opacity = 0;
                ControleBatalha.personagem1.Mp -= 10;
            }

        }

        private void botao_AtkBas1(object sender, RoutedEventArgs e)
        {
            if (turno == 1)
            {
                ControleBatalha.personagem2.VidaAtual -= 10;
                Batalha();
                turno = 2;
                skillPlayer1.Opacity = 0;
                AtkBas2.Opacity = 1;
                skillPlayer2.Opacity = 1;
                AtkBas1.Opacity = 0;
            }

        }
        
    }
}
    

