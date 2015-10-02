using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class InvokeAfter : MonoBehaviour {

    private UnityAction<GameObject> action;

	public void Initialize(UnityAction<GameObject> action, float timeDelay)
    {
        this.action = action;
        Invoke("doIt", timeDelay);
    }

    private void doIt()
    {
        action(gameObject);
    }
}
