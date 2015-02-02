using UnityEngine;
using System.Collections;

public class ClickTester : MonoBehaviour
{
    private CountDown _CountDown = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        { // if left button pressed...
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var selecatbeObject = hit.collider.gameObject.GetComponent<Selectable>();

                if (hit.collider.gameObject.layer != Layers.SelectField)
                    return;

                if (selecatbeObject != null)
                {
                    selecatbeObject.Select();
                    _CountDown = CountDown.CreateCountDown(0.5f);
                    _CountDown.Start();
                    _CountDown.TimeElapsed += (sender, args) =>
                    {
                        if(selecatbeObject != null)
                            selecatbeObject.HighLight();
                        else 
                        Selector.Instance.Unselect();

                        _CountDown = null;
                    };
                }
                else
                    Selector.Instance.Unselect();
            }
            else
                Selector.Instance.Unselect();
        }

	    if (Input.GetMouseButtonUp(0))
	    {
            if (_CountDown != null)
                _CountDown.Stop();
            _CountDown = null;
	    }
	}
}
