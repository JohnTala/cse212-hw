
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add three items to the queue with different priorities.
    // Expected Result: The item with the highest priority should be removed first.
    // Defect(s) Found: 
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Apple", 1);
        priorityQueue.Enqueue("Banana", 3);
        priorityQueue.Enqueue("Orange", 2);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("Banana", result);
    }

    [TestMethod]
    // Scenario: Add three items to the queue with the same highest priority.
    // Expected Result: The first item added with the highest priority should be removed first.
    // Defect(s) Found: 
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Apple", 5);
        priorityQueue.Enqueue("Banana", 5);
        priorityQueue.Enqueue("Orange", 5);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("Apple", result);
    }

    [TestMethod]
    // Scenario: Add items with different priorities and remove them one at a time.
    // Expected Result: Items should be removed from highest priority to lowest priority.
    // Defect(s) Found: 
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Apple", 1);
        priorityQueue.Enqueue("Banana", 3);
        priorityQueue.Enqueue("Orange", 2);

        Assert.AreEqual("Banana", priorityQueue.Dequeue());
        Assert.AreEqual("Orange", priorityQueue.Dequeue());
        Assert.AreEqual("Apple", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to remove an item from an empty queue.
    // Expected Result: An InvalidOperationException should be thrown with the message "The queue is empty."
    // Defect(s) Found: 
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                string.Format("Unexpected exception of type {0} caught: {1}",
                              e.GetType(), e.Message)
            );
        }
    }
}

