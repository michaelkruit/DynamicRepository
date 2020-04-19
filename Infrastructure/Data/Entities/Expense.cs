using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infrastructure.Data.Entities
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateOfWithdrawal { get; set; }
        public int WithdrawnPerMonth { get; set; }
        public bool Notify { get; set; }
    }
}
