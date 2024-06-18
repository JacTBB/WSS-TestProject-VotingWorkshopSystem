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

        Form workshopsTab = new WorkshopsTab(dbContext)
        {
            TopLevel = false,
            AutoScroll = true,
            FormBorderStyle = FormBorderStyle.None,
        };

        public AdminPage()
        {
            InitializeComponent();

            panelMain.Controls.Add(workshopsTab);
        }

        private void HideAllTabs()
        {
            workshopsTab.Hide();
        }

        private void btnVoting_Click(object sender, EventArgs e)
        {
            HideAllTabs();
            //workshopsTab.Show();
        }

        private void btnSaloons_Click(object sender, EventArgs e)
        {
            HideAllTabs();
            //workshopsTab.Show();
        }

        private void btnResults_Click(object sender, EventArgs e)
        {
            HideAllTabs();
            //workshopsTab.Show();
        }

        private void btnExhibitors_Click(object sender, EventArgs e)
        {
            HideAllTabs();
            //workshopsTab.Show();
        }

        private void btnWorkshops_Click(object sender, EventArgs e)
        {
            HideAllTabs();
            workshopsTab.Show();
        }
    }
}
