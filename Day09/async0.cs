using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Day9
{

    public class async0
    {
        public static async Task Main()
        {
            await RunAsynchronous();
        }

        static async Task RunAsynchronous()
        {
            Stopwatch sw = Stopwatch.StartNew();

            Task task1 = GetStudentDetailsAsync();
            Task task2 = GetMarksAsync();
            Task task3 = GetAttendanceAsync();

            await Task.WhenAll(task1, task2, task3);

            sw.Stop();
            Console.WriteLine($"Total Time (Async): {sw.ElapsedMilliseconds} ms");
        }

        static async Task GetStudentDetailsAsync()
        {
            await Task.Delay(2000);
            Console.WriteLine("Student Details Loaded");
        }

        static async Task GetMarksAsync()
        {
            await Task.Delay(2000);
            Console.WriteLine("Marks Loaded");
        }

        static async Task GetAttendanceAsync()
        {
            await Task.Delay(2000);
            Console.WriteLine("Attendance Loaded");
        }
    }
}