using System;

// Custom Exception: Insufficient Balance
class InsufficientBalanceException : Exception
{
    public InsufficientBalanceException(string message) : base(message) 
    {
        

    }
}

// Custom Exception: Invalid Amount
class InvalidAmountException : Exception
{
    public InvalidAmountException(string message) : base(message) 
    {
    

    }
}





// BankAccount Class
class BankAccount
{
    string AccountHolderName;
    double Balance;

    public BankAccount(string name, double balance)
    {
        this.AccountHolderName = name;
        this.Balance = balance;
    }

    public void Deposit(double amount)
    {
        if (amount <= 0)
            throw new InvalidAmountException("Deposit must be greater than 0");

        Balance += amount;
        Console.WriteLine($"₹{amount} deposited successfully.");
    }

    public void Withdraw(double amount)
    {
        if (amount <= 0)
            throw new InvalidAmountException("Withdrawal must be greater than 0");

        if (amount > Balance)
            throw new InsufficientBalanceException("Insufficient balance");

        if ((Balance - amount) < 1000)
            throw new InsufficientBalanceException("Minimum balance ₹1000 required");

        Balance -= amount;
        Console.WriteLine($"₹{amount} withdrawn successfully.");
    }

    public void CheckBalance()
    {
        Console.WriteLine($"Current Balance: ₹{Balance}");
    }
}





class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        Console.Write("Enter initial balance: ");
        double ibalance = Convert.ToDouble(Console.ReadLine());

        BankAccount person1 = new BankAccount(name, ibalance);

        int choice;

        do
        {
            Console.WriteLine("\n--- MENU ---");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Check Balance");
            Console.WriteLine("4. Exit");
            Console.Write("Enter choice: ");

            choice = Convert.ToInt32(Console.ReadLine());

            try
            {
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter deposit amount: ");
                        double dAmount = Convert.ToDouble(Console.ReadLine());
                        person1.Deposit(dAmount);
                        break;

                    case 2:
                        Console.Write("Enter withdrawal amount: ");
                        double wAmount = Convert.ToDouble(Console.ReadLine());
                        person1.Withdraw(wAmount);
                        break;

                    case 3:
                        person1.CheckBalance();
                        break;

                    case 4:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
            catch (InvalidAmountException ex)
            {
                Console.WriteLine("Invalid Amount Error: " + ex.Message);
            }
            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine("Balance Error: " + ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input! Enter numbers only.");
            }
            finally
            {
                Console.WriteLine("Operation completed.\n");
            }

        } while (choice != 4);
    }
}