using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CsvHelper;
using CsvHelper.Configuration;

namespace TextFileChallenge
{
    public partial class ChallengeForm : Form
    {
        BindingList<UserModel> users = new BindingList<UserModel>();

        public ChallengeForm()
        {
            InitializeComponent();

            users = new BindingList<UserModel>(LoadStandardData());

            // add event handlers
            addUserButton.Click += new System.EventHandler(this.addUserButton_Click);
            saveListButton.Click += new System.EventHandler(this.saveUserList_Click);

            WireUpDropDown();
        }

        private List<UserModel> LoadStandardData()
        {
            List<UserModel> records;

            using (var reader = new StreamReader("StandardDataSet.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                records = csv.GetRecords<UserModel>().ToList();
            }

            return records;
        }

        private void AddNewUser(UserModel user)
        {
            users.Add(user);
            
            // append new user to existing file 
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                // Don't write the header again.
                HasHeaderRecord = false,
            };
            using (var stream = File.Open("StandardDataSet.csv", FileMode.Append))
            using (var writer = new StreamWriter(stream))
            using (var csv = new CsvWriter(writer, config))
            {
                csv.WriteRecords(users);
            }
        }

        private void WireUpDropDown()
        {
            usersListBox.DataSource = users;
            usersListBox.DisplayMember = nameof(UserModel.DisplayText);
        }

        private void addUserButton_Click(object sender, EventArgs e)
        {
            var user = new UserModel()
            {
                FirstName = firstNameText.Text,
                LastName = lastNameText.Text,
                IsAlive = isAliveCheckbox.Checked,
                Age = Convert.ToInt32(agePicker.Value)
            };

            AddNewUser(user);

            addUserButton.Text = "updated";
        }
        private void saveUserList_Click(object sender, EventArgs e)
        {
            saveListButton.Text = "updated";
        }
    }
}
