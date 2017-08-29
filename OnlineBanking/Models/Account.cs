using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineBanking.Models
{
    public class Account
    {
        protected int checkingAccountNumber; //set fields
        protected int savingsAccountNumber;
        protected string accountType;

        [Key]
        public int AccountID { get; set; }
        public string AccountType { get; set; }  //set properties
        public int CheckingAccountNumber { get; set; }
        public int SavingsAccountNumber { get; set; }


        public virtual ICollection<CheckingAccount> CheckingAccounts { get; set; }
        public virtual ICollection<SavingsAccount> SavingsAccounts { get; set; }
    }
}