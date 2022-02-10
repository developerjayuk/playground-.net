using DemoLibrary;
using System;
using System.Windows.Forms;

namespace WinFormUI
{
    public partial class Dashboard : Form
    {
        Customer customer = new Customer();

        public Dashboard()
        {
            InitializeComponent();

            LoadTestingData();

            WireUpForm();
        }

        private void LoadTestingData()
        {
            customer.CustomerName = "Jason Jones";
            customer.CheckingAccount = new Account();
            customer.SavingsAccount = new Account();

            customer.CheckingAccount.AccountName = "Jason's Checking Account";
            customer.SavingsAccount.AccountName = "Jason's Savings Account";

            customer.CheckingAccount.AddDeposit("Initial Balance", 175.43M);
            customer.SavingsAccount.AddDeposit("Initial Balance", 88.45M);
        }

        private void WireUpForm()
        {
            customerText.Text = customer.CustomerName;
            checkingTransactions.DataSource = customer.CheckingAccount.Transactions;
            savingsTransactions.DataSource = customer.SavingsAccount.Transactions;
            checkingBalanceValue.Text = $@"{customer.CheckingAccount.Balance:C2}";
            savingsBalanceValue.Text = $@"{customer.SavingsAccount.Balance:C2}";

            customer.CheckingAccount.TransactionApprovedEvent += CheckingAccount_TransactionApprovedEvent;
            customer.SavingsAccount.TransactionApprovedEvent += SavingsAccount_TransactionApprovedEvent;
            customer.CheckingAccount.OverdraftEvent += CheckingAccount_OverdraftEvent;
        }

        private void CheckingAccount_OverdraftEvent(object sender, OverdraftEventArgs e)
        {
            errorMessage.Text = $"You had an overdraft protection transfer of {e.AmountOverdrafted:C2}";
            errorMessage.Visible = true;
        }

        private void SavingsAccount_TransactionApprovedEvent(object sender, string e)
        {
            savingsTransactions.DataSource = null;
            savingsTransactions.DataSource = customer.SavingsAccount.Transactions;
            savingsBalanceValue.Text = $@"{customer.SavingsAccount.Balance:C2}";
        }

        private void CheckingAccount_TransactionApprovedEvent(object sender, string e)
        {
            checkingTransactions.DataSource = null;
            checkingTransactions.DataSource = customer.CheckingAccount.Transactions;
            checkingBalanceValue.Text = $@"{customer.CheckingAccount.Balance:C2}";
        }

        private void recordTransactionsButton_Click(object sender, EventArgs e)
        {
            var transactions = new Transactions(customer);
            transactions.Show();
        }

        private void errorMessage_Click(object sender, EventArgs e)
        {
            errorMessage.Visible = false;
        }
    }
}
