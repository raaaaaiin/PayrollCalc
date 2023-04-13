using System;

namespace Payroll
{
    class Program
    {
        static void Main(string[] args)
        {

            DateTime date = new DateTime(2023, 4, 13);
            TimeSpan zlate_threshold = TimeSpan.FromMinutes(30);
            TimeSpan zot_threshold = TimeSpan.FromMinutes(30);

            // Time variables
            DateTime dateTime_in = date.AddHours(8).AddMinutes(0);
            DateTime dateTime_out = date.AddHours(9).AddMinutes(0);

            // Base variables
            DateTime dateTime_base_in = date.AddHours(8).AddMinutes(30);
            DateTime dateTime_base_out = date.AddHours(10).AddMinutes(45);
            TimeSpan zremaining_time = dateTime_out.Subtract(dateTime_base_out);
            TimeSpan zlate_time = (dateTime_in > dateTime_base_in) ? dateTime_in.Subtract(dateTime_base_in) : TimeSpan.Zero;

            // Rate variables
            int zbasic_rate = 700;
            int zot_rate = 50;

            // Amount variables
            int zbasic_amount = zbasic_rate;
            int zot_amount = (int)zremaining_time.TotalMinutes * zot_rate;
            double zdeduction_amount = ((dateTime_in - dateTime_base_in).TotalMinutes + (dateTime_base_out - dateTime_out).TotalMinutes) / (24 * 60);

            // Percentage variables
            double zbase_percentage = (dateTime_in - dateTime_base_in).TotalMinutes / (dateTime_base_out - dateTime_base_in).TotalMinutes;
            double zin_out_percentage = ((dateTime_out - dateTime_in).TotalMinutes / (24 * 60)) * 100.0;

            Console.WriteLine("dateTime_in = " + dateTime_in);
            Console.WriteLine("dateTime_out = " + dateTime_out);
            Console.WriteLine("zlate_threshold = " + zlate_threshold);
            Console.WriteLine("zot_threshold = " + zot_threshold);
            Console.WriteLine("dateTime_base_in = " + dateTime_base_in);
            Console.WriteLine("dateTime_base_out = " + dateTime_base_out);
            Console.WriteLine("zremaining_time = " + zremaining_time);
            Console.WriteLine("zlate_time = " + zlate_time);
            Console.WriteLine("zbasic_rate = " + zbasic_rate);
            Console.WriteLine("zot_rate = " + zot_rate);
            Console.WriteLine("zbasic_amount = " + zbasic_amount);
            Console.WriteLine("zot_amount = " + zot_amount);
            Console.WriteLine("zdeduction_amount = " + zdeduction_amount);
            Console.WriteLine("zbase_percentage = " + zbase_percentage);
            Console.WriteLine("zin_out_percentage = " + zin_out_percentage);



        }
    }
}
