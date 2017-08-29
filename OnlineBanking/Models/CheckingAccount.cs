using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineBanking.Models
{
    public class CheckingAccount
    {
       

        [Key]
        public int CheckingAccountID { get; set; }
        public double Deposit { get; set; }  //set more properites
        public double Withdraw { get; set; }
        public string CheckingAccountType { get; set; }


        [ForeignKey("Account")]
        public int AccountID { get; set; }
        public virtual Account Account { get; set; }
    }
}