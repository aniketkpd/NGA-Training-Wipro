using System;


namespace Day7
{
    class FileManagement
    {
        static void Main(string[] args)
        {
            //Step 1: Define the file paths
            string filepath = "sample.txt";
            //string copyPath = "copy.txt";

            try
            {
                //Step 2: if there comes an error it will be handled by catch block
                Console.WriteLine("Creating a file...");
                File.Create(filepath).Close();// closing the file is imp

                //Step 3: Write Data to the file 
                Console.WriteLine("Writing to a file... ");
                File.WriteAllText(filepath, "hello, this is the first line of the file ..!!");

                //Step 4: Append data to file
                Console.WriteLine("Appending dta to the file ..!!");
                File.AppendAllText(filepath, "\nThis data is appended to the text");

                //Step 5: Read from the file 
                Console.WriteLine(" reading from the file ");
                string content = File.ReadAllText(filepath);
                Console.WriteLine(content);
            }

            catch (Exception ex) 
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}




