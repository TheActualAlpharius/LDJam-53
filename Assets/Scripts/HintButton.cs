using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HintButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    [SerializeField] List<string> hintsPerScreen;
    [SerializeField] Text hintText;

    private CameraMover cameraMover;

    private void Start()
    {
        cameraMover = FindObjectOfType<CameraMover>();
    }

    private void OnEnable()
    {
        hintText.text = "";
    }

    public void OnPointerExit(PointerEventData _data)
    {
        hintText.text = "";
    }

    public void OnPointerUp(PointerEventData _data)
    {
        hintText.text = "";
    }

    public void OnPointerDown(PointerEventData _data)
    {
        hintText.text = hintsPerScreen[cameraMover.GetCurrentIndex()];
    }
}
