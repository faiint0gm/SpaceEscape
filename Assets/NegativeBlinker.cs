using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegativeBlinker : MonoBehaviour {

    public static NegativeBlinker instance;

    public GameObject[] negativeQuads;

    void Awake()
    {
        instance = this;
    }

    public void Blink(bool onOff)
    {
        for (int i = 0; i < negativeQuads.Length; i++)
        {
            negativeQuads[i].SetActive(onOff);
        }
    }

    public IEnumerator BlinkTimes(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Blink(true);
                yield return new WaitForSeconds(0.1f*amount-i);
            Blink(false);
            yield return new WaitForSeconds(0.1f * amount - i);

        }
    }
}
