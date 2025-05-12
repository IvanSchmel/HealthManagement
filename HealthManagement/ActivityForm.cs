﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthManagement
{
    public partial class ActivityForm : Form
    {
        private TextBox activityTypeTextBox;
        private TextBox durationTextBox;
        private Label activityTypeLabel;
        private Label durationLabel;
        public string ActivityType { get; private set; }
        public decimal Duration { get; private set; }
        public ActivityForm()
        {
            this.Text = "Добавить активность";
            this.Width = 250;
            this.Height = 150;
            CreateControls();
            InitializeComponent();
        }
        private void CreateControls()
        {
            activityTypeLabel = new Label
            {
                Text = "Тип активности:",
                Location = new System.Drawing.Point(10, 10)
            };
            activityTypeTextBox = new TextBox
            {
                Location = new System.Drawing.Point(10, 30),
                Size = new System.Drawing.Size(200, 20)
            };
            durationLabel = new Label
            {
                Text = "Продолжительность (минут):",
                Location = new System.Drawing.Point(10, 55)
            };
            durationTextBox = new TextBox
            {
                Location = new System.Drawing.Point(10, 75),
                Size = new System.Drawing.Size(200, 20)
            };
            var okButton = new Button
            {
                Text = "OK",
                Location = new System.Drawing.Point(10, 100),
                Size = new System.Drawing.Size(80, 25)
            };
            okButton.Click += (sender, e) =>
            {
                if (decimal.TryParse(durationTextBox.Text, out decimal duration))
                {
                    ActivityType = activityTypeTextBox.Text;
                    Duration = duration;
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Пожалуйста, введите корректное значение продолжительности.");
                }
            };
            var cancelButton = new Button
            {
                Text = "Отмена",
                Location = new System.Drawing.Point(130, 100),
                Size = new System.Drawing.Size(80, 25)
            };
            cancelButton.Click += (sender, e) =>
            {
                DialogResult = DialogResult.Cancel;
                Close();
            };
            this.Controls.Add(activityTypeLabel);
            this.Controls.Add(activityTypeTextBox);
            this.Controls.Add(durationLabel);
            this.Controls.Add(durationTextBox);
            this.Controls.Add(okButton);
            this.Controls.Add(cancelButton);
        }
        private void ActivityForm_Load(object sender, EventArgs e)
        {

        }
    }
}
