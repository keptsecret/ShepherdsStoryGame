using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SignPanelScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI PuzzleText;

    [TextArea(15, 20)]
    public string Description;

    private CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    void Start()
    {
        PuzzleText.text = Description;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Z))
        {
            if (canvasGroup.interactable)
            {
                canvasGroup.interactable = false;
                canvasGroup.blocksRaycasts = false;
                canvasGroup.alpha = 0f;
            }
        }
    }
}