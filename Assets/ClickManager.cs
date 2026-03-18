using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private int longPressThreshold = 500;
    private int shortClickThreshold = 300;
    private int numClicks = 0;
    private bool waitingLongPress = false;
    private CancellationTokenSource token;
    public async void OnPointerDown(PointerEventData eventData)
    {
        RefreshTimer();
        waitingLongPress = true;
        try
        {
            await Task.Delay(longPressThreshold, token.Token);
            Debug.Log("Long Press");
            ResetToIdle();
        }
        catch(TaskCanceledException) {}
    }
    public async void OnPointerUp(PointerEventData EventData)
    {
        RefreshTimer();
        if (!waitingLongPress) return;
        waitingLongPress = false;
        numClicks++;
        if(numClicks == 1)
        {
            try
            {
                await Task.Delay(shortClickThreshold, token.Token);
                Debug.Log("Short Click");
                ResetToIdle();
            }
            catch (TaskCanceledException) {}
        }

        else if (numClicks == 2)
        {
            Debug.Log("Double Click");
            ResetToIdle();
        }
    }
    private void ResetToIdle()
    {
        numClicks = 0;
        waitingLongPress = false;
    }

    private void RefreshTimer()
    {
        if(token != null)
        {
            token.Cancel();
        }

        token = new CancellationTokenSource();
    }
}
