using System;


namespace Day9
{
    class UseOfAsync_Await
    {
        //static async Task DoWorkAsync()
        //{
        //    Console.WriteLine("Downloading...");
        //    await Task.Delay(5000); // wait 5 seconds
        //    Console.WriteLine("Done");
        //}


        //static async Task Main()
        //{
        //    Console.WriteLine("Start");
        //    await DoWorkAsync();
        //    Console.WriteLine("End");
        //}


        static async Task<int> GetNumberAsync()
        {
            Console.WriteLine("Downloading the number...");
            await Task.Delay(5000);
            return 42;
        }

        static async Task Main()
        {
            //GetNumberAsync().Result; // This will block the main thread until the result is available

            int result = await GetNumberAsync();
            Console.WriteLine(result);
        }
    }
}
