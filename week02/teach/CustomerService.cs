/// <summary>
/// Maintain a Customer Service Queue. Allows new customers to be
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService
{
    public static void Run()
    {
        // =========================================================
        // TEST 1
        // Scenario: Create a CustomerService with a valid max size.
        // Expected Result: The max size should be the value provided.
        // =========================================================

        Console.WriteLine("Test 1: Valid Maximum Queue Size");

        var cs1 = new CustomerService(3);

        Console.WriteLine(cs1);

        Console.WriteLine("=================");


        // =========================================================
        // TEST 2
        // Scenario: Create a CustomerService with max size <= 0.
        // Expected Result: Max size should default to 10.
        // =========================================================

        Console.WriteLine("Test 2: Invalid Maximum Queue Size");

        var cs2 = new CustomerService(0);

        Console.WriteLine(cs2);

        Console.WriteLine("=================");


        // =========================================================
        // TEST 3
        // Scenario: Add customers to the queue.
        // Expected Result: Customers should be added to the queue.
        // =========================================================

        Console.WriteLine("Test 3: Add Customers");

        var cs3 = new CustomerService(3);

        // Simulate customer information entered by the user.
        Console.SetIn(new StringReader(
            "John\n123\nComputer is not working\n" +
            "Mary\n456\nInternet is slow\n"
        ));

        cs3.AddNewCustomer();
        cs3.AddNewCustomer();

        Console.WriteLine(cs3);

        Console.WriteLine("=================");


        // =========================================================
        // TEST 4
        // Scenario: Try to add a customer when the queue is full.
        // Expected Result: Error message should be displayed.
        // =========================================================

        Console.WriteLine("Test 4: Full Queue");

        var cs4 = new CustomerService(2);

        Console.SetIn(new StringReader(
            "John\n123\nComputer problem\n" +
            "Mary\n456\nInternet problem\n" +
            "Peter\n789\nAccount problem\n"
        ));

        cs4.AddNewCustomer();
        cs4.AddNewCustomer();
        cs4.AddNewCustomer();

        Console.WriteLine(cs4);

        Console.WriteLine("=================");


        // =========================================================
        // TEST 5
        // Scenario: Serve customers from the queue.
        // Expected Result: The first customer added should be
        // served first.
        // =========================================================

        Console.WriteLine("Test 5: Serve Customer");

        var cs5 = new CustomerService(3);

        Console.SetIn(new StringReader(
            "John\n123\nComputer problem\n" +
            "Mary\n456\nInternet problem\n" +
            "Peter\n789\nAccount problem\n"
        ));

        cs5.AddNewCustomer();
        cs5.AddNewCustomer();
        cs5.AddNewCustomer();

        Console.WriteLine("Before serving:");
        Console.WriteLine(cs5);

        Console.WriteLine("Serving:");
        cs5.ServeCustomer();

        Console.WriteLine("After serving:");
        Console.WriteLine(cs5);

        Console.WriteLine("=================");


        // =========================================================
        // TEST 6
        // Scenario: Try to serve a customer when the queue is empty.
        // Expected Result: Error message should be displayed.
        // =========================================================

        Console.WriteLine("Test 6: Empty Queue");

        var cs6 = new CustomerService(3);

        cs6.ServeCustomer();

        Console.WriteLine("=================");
    }


    // The actual queue
    private readonly List<Customer> _queue = new();

    // Maximum number of customers allowed
    private readonly int _maxSize;


    // =============================================================
    // Constructor
    // =============================================================

    public CustomerService(int maxSize)
    {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }


    // =============================================================
    // Customer class
    // =============================================================

    private class Customer
    {
        public Customer(string name, string accountId, string problem)
        {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }


        public override string ToString()
        {
            return $"{Name} ({AccountId}) : {Problem}";
        }
    }


    // =============================================================
    // Add a new customer
    // =============================================================

    private void AddNewCustomer()
    {
        // Defect #1 FIX:
        // We need >= instead of >
        //
        // If Count == maxSize, the queue is already full.

        if (_queue.Count >= _maxSize)
        {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }


        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();

        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();

        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();


        var customer = new Customer(name, accountId, problem);

        _queue.Add(customer);
    }


    // =============================================================
    // Serve a customer
    // =============================================================

    private void ServeCustomer()
    {
        // Defect #3 FIX:
        // Check if the queue is empty before trying to remove
        // anything.

        if (_queue.Count <= 0)
        {
            Console.WriteLine("No customers in queue.");
            return;
        }


        // Defect #2 FIX:
        // We must get the first customer BEFORE removing them.

        var customer = _queue[0];

        _queue.RemoveAt(0);

        Console.WriteLine(customer);
    }


    // =============================================================
    // Display the queue
    // =============================================================

    public override string ToString()
    {
        return $"[size={_queue.Count} max_size={_maxSize} => "
             + string.Join(", ", _queue) + "]";
    }
}