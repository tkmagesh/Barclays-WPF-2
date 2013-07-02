namespace ObjectBindingDemo.Models
{
    public class SalaryCalculator
    {
        public double CalculateSalary(double basic, double hra, double da, double tax)
        {
            var net = basic + hra + da;
            var taxable = net * (tax / 100);
            return net - taxable;
        }
    }
}
