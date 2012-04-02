﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Route53DDNS
{
    public partial class MainForm : Form
    {
        private NotifyIcon trayIcon;
        private ContextMenu trayMenu;
        private Runner runner;
        private Options opts;

        public MainForm()
        {
            InitializeComponent();
        }

        private void optionsLoad(object sender, EventArgs e)
        {
            opts = Options.loadFromConfig();
        }

        private void OnExit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        protected override void OnLoad(EventArgs e)
        {
            Visible = false; // Hide form window.
            ShowInTaskbar = false; // Remove from taskbar.

            base.OnLoad(e);
        }

        private void OnOptions(object sender, EventArgs e)
        {
            // save and reload opts, restart runner
        }

        private void OnRun(object sender, EventArgs e)
        {
            if (runner == null)
            {
                runner = new Runner(opts);
            }
            runner.start();
        }

        private void initializeTrayMenu() 
        {
            trayMenu = new ContextMenu();
            trayMenu.MenuItems.Add("Exit", OnExit);
            trayMenu.MenuItems.Add("Options", OnOptions);
            trayMenu.MenuItems.Add("Run", OnRun);


            trayIcon = new NotifyIcon();
            trayIcon.Text = "Route53DDNS";
            trayIcon.Icon = new Icon(SystemIcons.Application, 40, 40);
            
            trayIcon.ContextMenu = trayMenu;
            trayIcon.Visible = true;
        }
    }
}