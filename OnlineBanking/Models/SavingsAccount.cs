using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineBanking.Models
{
    public class SavingsAccount
    {
        protected double savingsAccountBalance = 5000000; //set fields
        protected double deposit;
        protected double withdraw;
        protected string savingsAccountType;

        [Key]
        public int SavingsAccountID { get; set; }

        public double SavingsAccountBalance  //used this property to store savings acct. information
        {
            get { return this.savingsAccountBalance; }
            set { this.savingsAccountBalance = value; }
        }

        public double Deposit { get; set; }  //set more properites
        public double Withdraw { get; set; }
        public string SavingsAccountType { get; set; }

        [ForeignKey("Account")]
        public int AccountID { get; set; }
        public virtual Account Account { get; set; }

    }
}