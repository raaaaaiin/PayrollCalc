using System;

namespace Payroll
{
    class Program
    {
        static void Main(string[] args)
        {

            TimeSpan ztime_in = TimeSpan.Parse("8:30");
            TimeSpan ztime_out = TimeSpan.Parse("9:30");
            TimeSpan zlate_threshold = ztime_in.Add(TimeSpan.FromMinutes(30));
            TimeSpan zot_threshold = ztime_out.Add(TimeSpan.FromMinutes(30));

            // Base variables
            TimeSpan zbase_in = TimeSpan.Parse("8:30");
            TimeSpan zbase_out = TimeSpan.Parse("10:45");
            TimeSpan zremaining_time = ztime_out.Subtract(zbase_out);
            TimeSpan zlate_time = (ztime_in > zbase_in) ? ztime_in.Subtract(zbase_in) : TimeSpan.Zero;

            // Rate variables
            int zbasic_rate = 700;
            int zot_rate = 50;

            // Amount variables
            int zbasic_amount = zbasic_rate;
            int zot_amount = (int)zremaining_time.TotalMinutes * zot_rate;
            double zdeduction_amount = ((ztime_in - zbase_in).TotalMinutes + (zbase_out - ztime_out).TotalMinutes) / (24 * 60);

            // Percentage variables
            double zbase_percentage = (ztime_in - zbase_in).TotalMinutes / (zbase_out - zbase_in).TotalMinutes;
            double zin_out_percentage = ((ztime_out - ztime_in).TotalMinutes / (24 * 60)) * 100.0;

            Console.WriteLine("ztime_in = " + ztime_in);
            Console.WriteLine("ztime_out = " + ztime_out);
            Console.WriteLine("zlate_threshold = " + zlate_threshold);
            Console.WriteLine("zot_threshold = " + zot_threshold);
            Console.WriteLine("zbase_in = " + zbase_in);
            Console.WriteLine("zbase_out = " + zbase_out);
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
