﻿using System.Media;
using C4.Logic;
using C4.Logic.EventArg;
using System;
using System.Windows.Forms;

namespace C4.Presentation
{
    internal partial class GameOver : Form
    {
        internal GameOver()
        {
            InitializeComponent();
        }

        internal void RegisterForRefereeGameWonEvent(Referee referee)
        {
            referee.GameWon += DisplayGameWonNotification;
        }

        private void DisplayGameWonNotification(object sender, GameStatusEventArgs e)
        {
            _lblWinner.Text = e.WinningGameToken.ToString() + " Wins!";
            PlayGameOverFx();
            ShowDialog();
        }

        internal void RegisterForRefereeGameDrawnEvent(Referee referee)
        {
            referee.GameDrawn += DisplayGameDrawnDialog;
        }

        private void DisplayGameDrawnDialog(object sender, GameStatusEventArgs e)
        {
            _lblWinner.Text = "Game is Drawn";
            PlayGameOverFx();
            ShowDialog();            
        }

        private void RestartApplication_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void PlayGameOverFx()
        {
            var soundPlayer = new SoundPlayer(Properties.Resources.discs_drop_into_box);

            soundPlayer.Load();
            soundPlayer.Play();
        }

        private void FormCrossClicked(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
                Application.Exit();
        }

        private void ExitApplication_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
