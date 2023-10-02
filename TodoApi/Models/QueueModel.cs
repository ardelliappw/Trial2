namespace TodoApi.Models;

public class QueueModel
{
    private Queue<string> queue = new Queue<string>();

    public void Enqueue(string item)
    {
        queue.Enqueue(item);
    }

    public string Dequeue()
    {
        if (queue.Count > 0)
        {
            return queue.Dequeue();
        }
        else
        {
            throw new InvalidOperationException("The queue is empty.");
        }
    }

    public int Count
    {
        get { return queue.Count; }
    }
}
