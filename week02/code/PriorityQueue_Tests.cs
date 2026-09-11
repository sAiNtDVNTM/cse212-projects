using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue A(1), B(3), C(2). Dequeue once.
    // Expected Result: B is removed (highest priority).
    // Defect(s) Found: Originally, item was not removed from queue.
    public void TestPriorityQueue_HighestPriorityRemoved()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 3);
        pq.Enqueue("C", 2);

        var result = pq.Dequeue();
        Assert.AreEqual("B", result);
        Assert.AreEqual("[A (Pri:1), C (Pri:2)]", pq.ToString());
    }

    [TestMethod]
    // Scenario: Enqueue A(3), B(3). Dequeue once.
    // Expected Result: A is removed first (FIFO among equals).
    // Defect(s) Found: Original code used >=, so later item B was incorrectly chosen.
    public void TestPriorityQueue_TieBreakingFIFO()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 3);
        pq.Enqueue("B", 3);

        var result = pq.Dequeue();
        Assert.AreEqual("A", result);
        Assert.AreEqual("[B (Pri:3)]", pq.ToString());
    }

    [TestMethod]
    // Scenario: Enqueue A(1), B(5), C(2), D(4). Dequeue repeatedly until empty.
    // Expected Result: B, D, C, A (descending priority order).
    // Defect(s) Found: Last element was skipped in original loop.
    public void TestPriorityQueue_MultipleDequeueOrder()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 5);
        pq.Enqueue("C", 2);
        pq.Enqueue("D", 4);

        Assert.AreEqual("B", pq.Dequeue());
        Assert.AreEqual("D", pq.Dequeue());
        Assert.AreEqual("C", pq.Dequeue());
        Assert.AreEqual("A", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Call Dequeue on empty queue.
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: Exception message was correct, but removal logic errors prevented proper empty state.
    public void TestPriorityQueue_EmptyQueueThrows()
    {
        var pq = new PriorityQueue();

        try
        {
            pq.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}