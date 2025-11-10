/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);
 
        // Test Cases
 
        // Test 1
        // Scenario: Add a new customer and then serve them
        // Expected Result: The customer information should be displayed
        Console.WriteLine("Test 1");
        var cs = new CustomerService(1);
        cs.AddNewCustomer();
        cs.ServeCustomer();
        // Defect(s) Found: i need to serve the customer first then dequeue them
 
        Console.WriteLine("=================");
 
        // Test 2
        // Scenario: The user shall specify the maximum size of the queue
        // Expected Result: The maximum size shall be set to 10
        Console.WriteLine("Test 2");
        cs = new CustomerService(0);
        Console.WriteLine($"The maximum size is set to: {cs}");
 
        // Defect(s) Found: no problems found(it gets set to 10 as expected)
 
        Console.WriteLine("=================");
 
        // Test 3
        // Scenario: Add multiple customers to the queue
        // Expected Result: The maximum size shall be set to 10
        Console.WriteLine("Test 3");
        cs = new CustomerService(4);
        cs.AddNewCustomer();
        cs.AddNewCustomer();
        Console.WriteLine($"Who is all queued up: {cs}");
        cs.ServeCustomer();
        cs.ServeCustomer();
        Console.WriteLine($"Who is all served in order: {cs}");
        // Defect(s) Found: no problems found
 
        Console.WriteLine("=================");
 
        // Test 4
        // Scenario: Does the max queue size give an error when exceeded?
        // Expected Result: An error message should be displayed
        Console.WriteLine("Test 4");
        cs = new CustomerService(2);
        cs.AddNewCustomer();
        cs.AddNewCustomer();
        cs.AddNewCustomer();
        Console.WriteLine($"Current Queue: {cs}");
 
        // Defect(s) Found: No error message was shown when max size exceeded( until fixed)
 
        Console.WriteLine("=================");
        // Test 5
        // Scenario: Serve a customer when there is no customer
        // Expected Result: An error message should be displayed
        Console.WriteLine("Test 5");
        cs = new CustomerService(2);
        cs.ServeCustomer();
 
        // Defect(s) Found: gave an error because there was no check for empty queue
 
        Console.WriteLine("=================");
 
        // Add more Test Cases As Needed Below
    }
 
    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;
 
    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }
 
    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }
 
        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }
 
        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }
 
    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        // Change 3: fixed the check to use >= instead of >
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }
 
        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();
 
        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }
 
    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        // Verify there is a customer to serve
        // change 1: added check for empty queue
        if (_queue.Count == 0)
        {
            Console.WriteLine("No Customers in Queue.");
            return;
        }
        // Change 2: Dequeue the customer
        var customer = _queue[0];
        _queue.RemoveAt(0);
        Console.WriteLine(customer);
    }
 
    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}
 