using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities and then dequeue.
    // Expected Result: The item with the highest priority is returned.
    // Defect(s) Found: None.
    public void Test_DequeueReturnsHighestPriority()
    {
        // Arrange
        var queue = new PriorityQueue();
        queue.Enqueue("A", 1);  // Lowest priority
        queue.Enqueue("B", 3);  // Highest priority among these items
        queue.Enqueue("C", 2);  // Middle priority

        // Act
        string result = queue.Dequeue();

        // Assert – The highest priority item should be returned.
        Assert.AreEqual("B", result, "Dequeue should return the item with the highest priority.");
    }

    [TestMethod]
    // Scenario: Enqueue two items with the same highest priority along with another lower-priority item.
    // Expected Result: The first enqueued item among those with the highest priority is returned.
    // Defect(s) Found: The test returned "Second" instead of "First," meaning the implementation does not maintain FIFO ordering for tied priorities.
    public void Test_TieBreakerFIFO()
    {
        // Arrange
        var queue = new PriorityQueue();
        queue.Enqueue("First", 5);   // First item with highest priority
        queue.Enqueue("Second", 5);  // Another item with identical highest priority
        queue.Enqueue("Third", 3);   // Lower priority

        // Act
        string result = queue.Dequeue();

        // Assert – "First" should be returned because it was enqueued first among the highest priority items.
        Assert.AreEqual("First", result, "When there is a tie in priority, the first enqueued item should be dequeued.");
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty queue.
    // Expected Result: An InvalidOperationException is thrown.
    // Defect(s) Found: None.
    public void Test_EmptyQueueThrowsException()
    {
        // Arrange
        var queue = new PriorityQueue();

        // Act and Assert – Empty queue should cause an exception.
        Assert.ThrowsException<InvalidOperationException>(() => queue.Dequeue(), "Dequeue should throw an exception if the queue is empty.");
    }
    
    [TestMethod]
    // Scenario: Enqueue items where the last inserted element has the highest priority.
    // Expected Result: The last enqueued element, having the highest priority, is selected and returned.
    // Defect(s) Found: The test returned "A" instead of "C," meaning the implementation is skipping the last element during priority evaluation due to incorrect loop conditions.
    public void Test_LastElementConsideration()
    {
        // Arrange
        var queue = new PriorityQueue();
        queue.Enqueue("A", 2); // Moderate priority
        queue.Enqueue("B", 1); // Lower priority
        queue.Enqueue("C", 5); // Last element with highest priority
        
        // Act
        string result = queue.Dequeue();
        
        // Assert – "C" should be returned because it has the highest priority.
        Assert.AreEqual("C", result, "The last element with the highest priority should be considered in the Dequeue.");
    }

    [TestMethod]
    // Scenario: Enqueue multiple items and perform consecutive dequeues.
    // Expected Result: Each dequeue removes the highest priority element, so subsequent dequeue operations return different items.
    // Defect(s) Found: The test returned "B" instead of "C" on the second dequeue, meaning the removal of items is not being handled correctly.
    public void Test_DequeueRemovesItem()
    {
        // Arrange
        var queue = new PriorityQueue();
        queue.Enqueue("A", 1);
        queue.Enqueue("B", 3);
        queue.Enqueue("C", 2);

        // Act
        string first = queue.Dequeue();  // Highest: "B"
        // After removal, among the remaining items ("A" and "C"), "C" has a higher priority.
        string second = queue.Dequeue();
        // Final item remaining should be "A".
        string third = queue.Dequeue();

        // Assert – Verify the order of elements returned after each dequeue.
        Assert.AreEqual("B", first, "First dequeued element should be 'B'.");
        Assert.AreEqual("C", second, "Second dequeued element should be 'C'.");
        Assert.AreEqual("A", third, "Third dequeued element should be 'A'.");
    }
}
