using System;

namespace Payslip2
{
    /// <summary>
    /// Base class, calculates and outputs the payslip to the console.
    /// </summary>
    class PayslipGenerator
    {
        public PayslipGenerator()
        {
            
        }
        
        public string Name {get; set;}

        public string Surname {get; set;}

        public decimal AnnualSalary {get; set;}

        public decimal SuperRate {get; set;}

        public string PaymentStartDate {get; set;}

        public string PaymentEndDate {get; set;}

        public string PayPeriod
        {
            get { return String.IsNullOrEmpty(PaymentEndDate) ? PaymentStartDate : $"{PaymentStartDate} - {PaymentEndDate}"; }
        }

        public decimal GrossIncome
        {
            get { return Math.Floor(AnnualSalary / 12); }
        }
        
        public decimal IncomeTax
        {
            get
            {
                return AnnualSalary switch
                {
                    <= 18200 => 0,
                    > 18200 and <= 37000 => Math.Ceiling((AnnualSalary - 18200) * (decimal) 0.19 / 12),
                    > 37000 and <= 87000 => Math.Ceiling((3572 + (AnnualSalary - 37000) * (decimal) 0.325) / 12),
                    > 87000 and <= 180000 => Math.Ceiling((19822 + (AnnualSalary - 87000) * (decimal) 0.37) / 12),
                    _ => Math.Ceiling((54232 + (AnnualSalary - 180000) * (decimal) 0.45) / 12)
                };
            }
        }

        public decimal NetIncome
        {
          get { return GrossIncome - IncomeTax; }
        }

        public decimal Super
        {
            get { return Math.Floor(GrossIncome * (SuperRate / 100)); }
        }

        public string PrintPaySlip()
        {
            return $"\nName: {Name} {Surname} \nPay Period: {PayPeriod} \nGross Income: {GrossIncome} \nIncome Tax: {IncomeTax} \nNet Income: {NetIncome} \nSuper: {Super}";
        }
    }
}
