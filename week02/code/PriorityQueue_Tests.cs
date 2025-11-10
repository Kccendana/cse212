using System.Diagnostics;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add 3 Priority Queue items and remove them in order of priority.
    // Kathy (4), Bob (2), Sue (3)
    //Expected result: Kathy, Sue, Bob 
    // Defect(s) Found: Dequeue method does not return item in correct priority order.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Kathy", 4);
        priorityQueue.Enqueue("Bob", 2);
        priorityQueue.Enqueue("Sue", 3);

        string[] expectedResult = { "Kathy", "Sue", "Bob" };

        Debug.WriteLine($"Initial Queue: {priorityQueue.ToString()}");

        int i = 0;
        while (priorityQueue.Length > 0)
        {
            if (i >= expectedResult.Length)
            {
                Assert.Fail("More items dequeued than expected.");
            }

            var priority = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i], priority);
            i++;

            Debug.WriteLine(priority);
        }
    }

    [TestMethod]
    // Scenario: Same Priority keeps First In First Out order
    //Kathy(3), Bob(2), Sue(3)
    // Expected Result: Kathy, Sue, Bob
    // Defect(s) Found: Dequeue method does not preserve order for same priority items.
    public void Dequeue_ShouldPreserveOrderForSamePriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Kathy", 3);
        priorityQueue.Enqueue("Bob", 2);
        priorityQueue.Enqueue("Sue", 3);

        string[] expectedResult = { "Kathy", "Sue", "Bob" };

        Debug.WriteLine($"Initial Queue: {priorityQueue.ToString()}");

        int i = 0;
        while (priorityQueue.Length > 0)
        {
            if (i >= expectedResult.Length)
            {
                Assert.Fail("More items dequeued than expected.");
            }

            var priority = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i], priority);
            i++;

            Debug.WriteLine(priority);
        }
    }
    [TestMethod]
    //Scenario: Attempt to Dequeue from an empty queue
    //Expected Result: InvalidOperationException is thrown
    public void TestPriorityQueue_EmptyDequeue_ThrowsException()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            //if no exception happens, test fails
            Assert.Fail("Expected  an InvalidOperationException to be thrown, but no exception was thrown.");

        }
        catch (InvalidOperationException ex)
        {
            //Verify that the exception messge is correct
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
        catch (Exception ex)
        {
            //If any other exception happens, test fails
            Assert.Fail($"Expeceted an InvalidOperationAxception to be thrown, but got {ex.GetType().Name} instead.");
        }

    }

}