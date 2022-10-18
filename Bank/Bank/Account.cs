using System.Collections.Generic;
using System.Transactions;


namespace Bank
{
    public abstract class Account
    {
        public int Id { get; }
        public string AccountNumber { get; }
        public decimal Balance { get; protected set; }
        public string FirstName { get; }
        public string LastName { get; }
        public long Pesel { get; }
        public List<Transaction> transactions { get;}
        public Account(int id, string firstName, string lastName, long pesel)
        {
            Id = id;
            AccountNumber = generateAccountNumber(id);
            Balance = 0.0M;
            FirstName = firstName;
            LastName = lastName;
            Pesel = pesel;
            transactions = new List<Transaction>();
        }
        public abstract string TypeName();
        public string GetFullName()
        {
            string fullName = string.Format("{0} {1}", FirstName, LastName);

            return fullName;
        }

        public string GetBalance()
        {
            return string.Format("{0}zł", Balance);
        }
        public void ChangeBalance(decimal value)
        {
            Balance += value;
        }
        private string generateAccountNumber (int id)
        {
            var accountNumber = string.Format("94[0:D10]", id);
            return accountNumber;
        }
        public void Transfer(decimal transferAmount, string transferToId)
        {
            Balance += transferAmount;
            TransferTransaction newTransaction = new TransferTransaction(transferAmount, transferToId, Id);

        }



    }
}
