﻿using CsvHelper.Configuration.Attributes;

namespace Core.Models.CzechNationalBank
{
    public class CzechNationalBankExchangeRateItem : BaseExchangeRateItem
    {
        [Name("Country")]
        public string Country { get; set; }
        [Name("Currency")]
        public string Currency { get; set; }
        [Name("Amount")]
        public int Amount { get; set; }
        [Name("Code")]
        public string Code { get; set; }
        [Name("Rate")]
        public decimal Rate { get; set; }
    }
}
