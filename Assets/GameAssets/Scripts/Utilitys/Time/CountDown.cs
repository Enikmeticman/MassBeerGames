using System;
using System.Threading;
using UnityEngine;
using System.Collections;

public class CountDown : MonoBehaviour
{
    public int TimeSpan;

    public EventHandler TimeElapsed = null;

    public static CountDown CreateCountDown(int pTimeSpan)
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
    private void SetTimer(int pTimeSpan)
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

        Debug.Log("lol");

        EventHandler ev = TimeElapsed;
        if (ev != null)
            ev(this, new EventArgs());

        Destroy(this.gameObject);
    }
}
