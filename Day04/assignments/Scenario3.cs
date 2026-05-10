using System;
using System.Collections.Generic;

class Transaction
{
    public string TransactionId;
    public double Amount;
}

class Scenario3
{
    static void Main()
    {
        // Collections

        // for transaction history 
        List<Transaction> history = new List<Transaction>();

        //for account balances
        Dictionary<string, double> accounts = new Dictionary<string, double>();

        //for pending transactions
        Queue<Transaction> pending = new Queue<Transaction>();

        //for rollback operations
        Stack<Transaction> rollback = new Stack<Transaction>();

        //to ensure unique transaction IDs
        HashSet<string> transactionIds = new HashSet<string>();


        // Create Accounts
        accounts["A1"] = 10000;
        accounts["A2"] = 5000;


        // Create Transactions
        Transaction t1 = new Transaction 
        { 
            TransactionId = "T001", 
            Amount = 2000 
        };
        
        Transaction t2 = new Transaction 
        { 
            TransactionId = "T002", 
            Amount = 3000
        };
        
        // duplicate
        Transaction t3 = new Transaction 
        { 
            TransactionId = "T001", 
            Amount = 1500
        }; 




        // Add to Queue if unique
        if (transactionIds.Add(t1.TransactionId))
        {
            pending.Enqueue(t1);
        }

        if (transactionIds.Add(t2.TransactionId))
        {
            pending.Enqueue(t2);
        }
        
        
        if (!transactionIds.Add(t3.TransactionId))
        { 
            Console.WriteLine("Duplicate Transaction Blocked: " + t3.TransactionId);
        }

        
        
        // Process Transactions
        Console.WriteLine("Processing Transactions:");
        while (pending.Count > 0)
        {
            Transaction t = pending.Dequeue();

            if (accounts["A1"] >= t.Amount)
            {
                accounts["A1"] -= t.Amount;
                accounts["A2"] += t.Amount;

                history.Add(t);
                rollback.Push(t);

                Console.WriteLine($"Transaction {t.TransactionId} Completed");
            }
            else
            {
                Console.WriteLine($"Transaction {t.TransactionId} Failed (Insufficient Balance)");
            }
        }

        
        
        
        // Rollback Last Transaction
        Console.WriteLine("\nRollback Last Transaction:");
        if (rollback.Count > 0)
        {
            Transaction last = rollback.Pop();

            accounts["A1"] += last.Amount;
            accounts["A2"] -= last.Amount;

            Console.WriteLine($"Transaction {last.TransactionId} Rolled Back");
        }

        
        
        // Display Balances
        Console.WriteLine("\nAccount Balances:");
        foreach (var acc in accounts)
        {
            Console.WriteLine($"{acc.Key}: {acc.Value}");
        }

        
        
        // Display History
        Console.WriteLine("\nTransaction History:");
        foreach (var t in history)
        {
            Console.WriteLine(t.TransactionId + " - " + t.Amount);
        }
    }
}