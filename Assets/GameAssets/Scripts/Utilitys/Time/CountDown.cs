using System;
using System.Threading;
using UnityEngine;
using System.Collections;

public class CountDown : MonoBehaviour
{
    public float TimeSpan;

    public EventHandler TimeElapsed = null;

    public static CountDown CreateCountDown(float pTimeSpan)
    {
        var obj = new GameObject("CountDown", new Type[] { typeof(CountDown) });
        var countDown = obj.GetComponent<CountDown>();
        countDown.SetTimer(pTimeSpan);
        return countDown;
    }

    /// <summary>
    /// Ctor 
    /// </summary>
    /// <param name="pTimeSpan">Time in seconds</param>
    private void SetTimer(float pTimeSpan)
    {
        this.TimeSpan = pTimeSpan;
    }

    public void Start()
    {
        StartCoroutine("Elapse");
    }

    public void Stop()
    {
        StopCoroutine("Elapse");
        Destroy(this.gameObject);
    }

    private IEnumerator Elapse()
    {
        yield return new WaitForSeconds(TimeSpan);

        EventHandler ev = TimeElapsed;
        if (ev != null)
            ev(this, new EventArgs());

        Destroy(this.gameObject);
    }
}
