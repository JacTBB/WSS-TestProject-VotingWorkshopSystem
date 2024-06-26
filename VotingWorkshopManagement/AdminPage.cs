﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VotingWorkshopManagement.Models;

namespace VotingWorkshopManagement
{
    public partial class AdminPage : Form
    {
        public static VotingWorkshopSystemContext dbContext;

        Form votingTab = new VotingTab(dbContext)
        {
            TopLevel = false,
            AutoScroll = true,
            FormBorderStyle = FormBorderStyle.None,
            Dock = DockStyle.Fill,
        };

        Form saloonsTab = new SaloonsTab(dbContext)
        {
            TopLevel = false,
            AutoScroll = true,
            FormBorderStyle = FormBorderStyle.None,
            Dock = DockStyle.Fill,
        };

        Form resultstab = new ResultsTab(dbContext)
        {
            TopLevel = false,
            AutoScroll = true,
            FormBorderStyle = FormBorderStyle.None,
            Dock = DockStyle.Fill,
        };

        Form exhibitorsTab = new ExhibitorsTab(dbContext)
        {
            TopLevel = false,
            AutoScroll = true,
            FormBorderStyle = FormBorderStyle.None,
            Dock = DockStyle.Fill,
        };

        Form workshopsTab = new WorkshopsTab(dbContext)
        {
            TopLevel = false,
            AutoScroll = true,
            FormBorderStyle = FormBorderStyle.None,
            Dock = DockStyle.Fill,
        };

        public AdminPage(User user)
        {
            InitializeComponent();

            panelMain.Controls.Add(votingTab);
            panelMain.Controls.Add(saloonsTab);
            panelMain.Controls.Add(resultstab);
            panelMain.Controls.Add(exhibitorsTab);
            panelMain.Controls.Add(workshopsTab);

            votingTab.Show();

            lblUser.Text = "Hi, " + user.Username;
        }

        private void HideAllTabs()
        {
            votingTab.Hide();
            saloonsTab.Hide();
            resultstab.Hide();
            exhibitorsTab.Hide();
            workshopsTab.Hide();
        }

        private void btnVoting_Click(object sender, EventArgs e)
        {
            HideAllTabs();
            votingTab.Show();
        }

        private void btnSaloons_Click(object sender, EventArgs e)
        {
            HideAllTabs();
            saloonsTab.Show();
        }

        private void btnResults_Click(object sender, EventArgs e)
        {
            HideAllTabs();
            resultstab.Show();
        }

        private void btnExhibitors_Click(object sender, EventArgs e)
        {
            HideAllTabs();
            exhibitorsTab.Show();
        }

        private void btnWorkshops_Click(object sender, EventArgs e)
        {
            HideAllTabs();
            workshopsTab.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
