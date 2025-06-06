using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario:
    // We add multiple items with different priorities and then dequeue them.
    // Expected Result: Dequeue method should return "HighPriority" first, then "MediumPriority", and finally the "LowPriority".
    // Defect(s) Found: Check if the queue correctly prioritizes the items.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("LowPriority", 1);
        priorityQueue.Enqueue("MediumPriority", 5);
        priorityQueue.Enqueue("HighPriority", 10);

        string firstDequeue = priorityQueue.Dequeue();
        string secondDequeue = priorityQueue.Dequeue();
        string thirdDequeue = priorityQueue.Dequeue();

        Assert.AreEqual("HighPriority", firstDequeue);
        Assert.AreEqual("MediumPriority", secondDequeue);
        Assert.AreEqual("LowPriority", thirdDequeue);
    }

    [TestMethod]
    // Scenario: 
    // Add multiple items with the same priority and dequeue them.
    // Expected Result: The order of dequeue should maintain the FIFO order for items with same priority.
    // Defect(s) Found: Check if the queue correctly dequeues the items in the order they were added.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 5);
        priorityQueue.Enqueue("Item2", 5);
        priorityQueue.Enqueue("Item3", 5);

        string firstDequeue = priorityQueue.Dequeue();
        string secondDequeue = priorityQueue.Dequeue();
        string thirdDequeue = priorityQueue.Dequeue();

        Assert.AreEqual("Item1", firstDequeue);
        Assert.AreEqual("Item2", secondDequeue);
        Assert.AreEqual("Item3", thirdDequeue);
    }

    [TestMethod]
    // Scenario: 
    // Attempt to dequeue from an empty queue.
    // Expected Result: it should throw an InvalidOperationException with the message "The queue is empty."
    // Defect(s) Found: Check if the empty queue correctly throws an exception.
    public void TestPriorityQueue_EmptyQueue()
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
    }

    [TestMethod]
    public void TestPriorityQueue_MixedPriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 5);
        priorityQueue.Enqueue("High", 10);
        priorityQueue.Enqueue("Highest", 15);
        priorityQueue.Enqueue("Medium2", 5); // Same priority as "Medium"

        // Expected order: "Highest", "High", "Medium", "Medium2", "Low"
        string firstDequeue = priorityQueue.Dequeue(); // Should return "Highest"
        string secondDequeue = priorityQueue.Dequeue(); // Should return "High"
        string thirdDequeue = priorityQueue.Dequeue(); // Should return "Medium"
        string fourthDequeue = priorityQueue.Dequeue(); // Should return "Medium2"
        string fifthDequeue = priorityQueue.Dequeue(); // Should return "Low"

        Assert.AreEqual("Highest", firstDequeue);
        Assert.AreEqual("High", secondDequeue);
        Assert.AreEqual("Medium", thirdDequeue);
        Assert.AreEqual("Medium2", fourthDequeue);
        Assert.AreEqual("Low", fifthDequeue);
    }
}