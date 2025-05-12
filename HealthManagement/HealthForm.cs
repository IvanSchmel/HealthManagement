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
    public partial class HealthForm : Form
    {
        private HealthManager healthManager;
        private Button trackActivityButton;
        private Button trackNutritionButton;
        private Button trackSleepButton;
        private Button displayReportButton;
        public HealthForm()
        {
            this.Text = "Управление здоровьем";
            this.Width = 300;
            this.Height = 200;
            CreateControls();
            healthManager = new HealthManager();
            InitializeComponent();
        }
        private void CreateControls()
        {
            trackActivityButton = new Button
            {
                Location = new System.Drawing.Point(10, 20),
                Text = "Отслеживать активность",
                Size = new System.Drawing.Size(120, 25)
            };
            trackActivityButton.Click += (sender, e) =>
            {
                var activityForm = new ActivityForm();
                activityForm.ShowDialog();
                if (activityForm.DialogResult == DialogResult.OK)
                {
                    healthManager.TrackActivity(activityForm.ActivityType, activityForm.Duration);
                }
            };
            trackNutritionButton = new Button
            {
                Location = new System.Drawing.Point(140, 20),
                Text = "Отслеживать питание",
                Size = new System.Drawing.Size(120, 25)
            };
            trackNutritionButton.Click += (sender, e) =>
            {
                var nutritionForm = new NutritionForm();
                nutritionForm.ShowDialog();
                if (nutritionForm.DialogResult == DialogResult.OK)
                {
                    healthManager.TrackNutrition(nutritionForm.FoodItem, nutritionForm.Calories);
                }
            };
            trackSleepButton = new Button
            {
                Location = new System.Drawing.Point(10, 50),
                Text = "Отслеживать сон",
                Size = new System.Drawing.Size(120, 25)
            };
            trackSleepButton.Click += (sender, e) =>
            {
                var sleepForm = new SleepForm();
                sleepForm.ShowDialog();
                if (sleepForm.DialogResult == DialogResult.OK)
                {
                    healthManager.TrackSleep(sleepForm.Date, sleepForm.Hours);
                }
            };
            displayReportButton = new Button
            {
                Location = new System.Drawing.Point(140, 50),
                Text = "Показать отчёт",
                Size = new System.Drawing.Size(120, 25)
            };
            displayReportButton.Click += (sender, e) => healthManager.DisplayActivityReport();
            this.Controls.Add(trackActivityButton);
            this.Controls.Add(trackNutritionButton);
            this.Controls.Add(trackSleepButton);
            this.Controls.Add(displayReportButton);
        }
        private void HealthForm_Load(object sender, EventArgs e)
        {

        }
    }
}
