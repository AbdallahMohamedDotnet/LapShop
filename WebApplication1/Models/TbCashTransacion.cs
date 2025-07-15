using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class TbCashTransacion
{
    public int CashTransactionId { get; set; }

    public int CustomerId { get; set; }

    public DateTime CashDate { get; set; }

    public decimal CashValue { get; set; }
}
