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
            TimeSpan lunch_break = TimeSpan.FromHours(1);

            // Time variables
            DateTime dateTime_in = date.AddHours(9).AddMinutes(0);
            DateTime dateTime_out = date.AddHours(14).AddMinutes(0);

            // Base variables
            DateTime dateTime_base_in = date.AddHours(8).AddMinutes(0);
            DateTime dateTime_base_out = date.AddHours(17).AddMinutes(0);
            TimeSpan zremaining_time = dateTime_out.Subtract(dateTime_base_out);
            TimeSpan zlate_time = (dateTime_in > dateTime_base_in) ? dateTime_in.Subtract(dateTime_base_in) : TimeSpan.Zero;
            bool islate = (dateTime_in > dateTime_base_in + zlate_threshold);

            // Rate variables
            double late_deduction_perhour = 87.5;
            double zbasic_rate = 700;
            double ot_rate_perhour = 105;

            // reachedOT boolean variable
            bool reachedOT = (zremaining_time >= zot_threshold);

            TimeSpan timelate = islate ? zlate_time : TimeSpan.Zero;
            TimeSpan ottime = reachedOT ? zremaining_time : TimeSpan.Zero;

            // Adjust the expected_render to account for the lunch break
            TimeSpan expected_render = (dateTime_base_out - dateTime_base_in) - lunch_break;
            TimeSpan time_spent = (dateTime_out - dateTime_in) - lunch_break;

            // Percentage variables
            double timelate_percentage = (timelate.TotalMinutes / expected_render.TotalMinutes) * 100.0;
            double rate_percentage = (time_spent.TotalMinutes / expected_render.TotalMinutes) * 100.0;

            // Calculate the total late deduction
            double total_late = late_deduction_perhour * timelate.TotalHours;

            // Calculate the total rate and total OT
            double total_rate = zbasic_rate * rate_percentage / 100.0;
            double ot_percentage = (ottime.TotalMinutes / 60) * 100.0;
            double total_ot = ot_rate_perhour * ot_percentage / 100.0;

            // Calculate the take-home pay
            double takehome = (total_rate + total_ot) - total_late;
            Console.WriteLine("dateTime_in = " + dateTime_in);
            Console.WriteLine("dateTime_out = " + dateTime_out);
            Console.WriteLine("time_spent = " + time_spent);
            Console.WriteLine("zlate_threshold = " + zlate_threshold);
            Console.WriteLine("zot_threshold = " + zot_threshold);
            Console.WriteLine("dateTime_base_in = " + dateTime_base_in);
            Console.WriteLine("dateTime_base_out = " + dateTime_base_out);
            Console.WriteLine("zremaining_time = " + zremaining_time);
            Console.WriteLine("zlate_time = " + zlate_time);
            Console.WriteLine("zbasic_rate = " + zbasic_rate);
            Console.WriteLine("zot_rate = " + ot_rate_perhour);
            Console.WriteLine("reachedOT = " + reachedOT);
            Console.WriteLine("islate = " + islate);

            Console.WriteLine("timelate = " + timelate);

            Console.WriteLine("ottime = " + ottime);

            Console.WriteLine("total_rate = " + total_rate);
            Console.WriteLine("total_ot = " + total_ot);
            Console.WriteLine("total_late = " + total_late);
            Console.WriteLine("takehome = " + takehome);


        }
    }
}
