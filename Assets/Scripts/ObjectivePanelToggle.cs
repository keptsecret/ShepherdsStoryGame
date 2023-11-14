using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjectivePanelToggle : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI ObjectiveText;

    [TextArea(15,20)]
    public string Description;

    private CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    void Start()
    {
        ObjectiveText.text = Description;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            if (canvasGroup.interactable)
            {
                canvasGroup.interactable = false;
                canvasGroup.blocksRaycasts = false;
                canvasGroup.alpha = 0f;
            }
            else
            {
                canvasGroup.interactable = true;
                canvasGroup.blocksRaycasts = true;
                canvasGroup.alpha = 1f;
            }
        }
    }
}
