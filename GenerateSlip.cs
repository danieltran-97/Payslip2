using System;

namespace Payslip2
{
    /// <summary>
    /// Base class, calculates and outputs the payslip to the console.
    /// </summary>
    class GenerateSlip
    {
        protected string Name
        {get; set;}

        protected string Surname
        {get; set;}

        protected double AnnualSalary
        {get; set;}

        protected double SuperRate
        {get; set;}

        protected string PaymentStartDate
        {get; set;}

        protected string PaymentEndDate
        {get; set;}

        protected string PayPeriod()
        {
            return String.IsNullOrEmpty(PaymentEndDate) ? PaymentStartDate : $"{PaymentStartDate} - {PaymentEndDate}";
        }

        protected double GrossIncome()
        {
            return Math.Floor(AnnualSalary/12);
        }
        
        /// <summary>
        /// Income tax calculator 
        /// </summary>
        /// <returns>Income tax based on Annual salary</returns>
        protected double IncomeTax()
        {
            switch (AnnualSalary)
            {
                case <= 18200:
                    return 0;
                case > 18200 and <= 37000:
                    return Math.Ceiling(((AnnualSalary - 18200) * 0.19) / 12);
                case > 37000 and <= 87000:
                    return Math.Ceiling((3572 + (AnnualSalary - 37000) * 0.325) / 12);
                case > 87000 and <= 180000:
                    return Math.Ceiling((19822 + (AnnualSalary - 87000) * 0.37) / 12);
                default:
                    return Math.Ceiling((54232 + (AnnualSalary - 180000) * 0.45) / 12);
            }
        }

        protected double NetIncome()
        {
            return GrossIncome() - IncomeTax();
        }

        protected double Super()
        {
            return Math.Floor(GrossIncome() * (SuperRate/100));
        }

        protected string PrintPaySlip()
        {
            return $"Name: {Name} {Surname} \nPay Period: {PayPeriod()} \nGross Income: {GrossIncome()} \nIncome Tax: {IncomeTax()} \nNet Income: {NetIncome()} \nSuper: {Super()} \n";
        }

    }
}
