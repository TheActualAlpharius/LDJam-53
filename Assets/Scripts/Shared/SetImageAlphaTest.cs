using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetImageAlphaTest : MonoBehaviour
{
    [SerializeField] float alphaHitTestMinimumThreshold;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().alphaHitTestMinimumThreshold = alphaHitTestMinimumThreshold;
    }
}
