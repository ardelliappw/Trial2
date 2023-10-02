using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

using TodoApi.Models;

[ApiController]
[Route("api/quicksort")]
public class QuickSortController : ControllerBase
{
    [HttpPost("sort")]
    public IActionResult Sort([FromBody] QuickSortModel model)
    {
        int[] data = model.Data;

        if (data == null || data.Length <= 1)
        {
            return Ok("No need to sort. Data is empty or contains only one element.");
        }

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        QuickSort(data, 0, data.Length - 1);

        stopwatch.Stop();
        TimeSpan elapsedTime = stopwatch.Elapsed;

        return Ok(new
        {
            SortedData = data,
            ExecutionTime = elapsedTime.TotalMilliseconds
        });
    }

    private void QuickSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int pivotIndex = Partition(arr, left, right);

            QuickSort(arr, left, pivotIndex - 1);
            QuickSort(arr, pivotIndex + 1, right);
        }
    }

    private int Partition(int[] arr, int left, int right)
    {
        int pivot = arr[right];
        int i = left - 1;

        for (int j = left; j < right; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }

        int temp2 = arr[i + 1];
        arr[i + 1] = arr[right];
        arr[right] = temp2;

        return i + 1;
    }
}
