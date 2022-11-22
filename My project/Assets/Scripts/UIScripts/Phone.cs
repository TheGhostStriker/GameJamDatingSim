using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour
{
    public static Phone instance;

    bool phoneToggled = false;
    [SerializeField] GameObject openButton;
    [SerializeField] GameObject closeButton;
    [SerializeField] Transform textMessageParent;
    [SerializeField] TextMessage textMessagePrefab;

    public List<string> textStrings = new List<string>();

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, -800, transform.localPosition.z);

        DisplayTexts();
    }

    public void OpenPhone()
    {
        openButton.SetActive(false);
        closeButton.SetActive(true);

        LeanTween.moveLocalY(gameObject, -115, 1f).setEase(LeanTweenType.easeInOutQuad);
    }

    public void ClosePhone()
    {
        openButton.SetActive(true);
        closeButton.SetActive(false);

        LeanTween.moveLocalY(gameObject, -800, 1f).setEase(LeanTweenType.easeInOutQuad);
    }

    public static void DisplayTexts()
    {
        foreach (Transform child in instance.textMessageParent) Destroy(child);

        foreach (string s in instance.textStrings)
        {
            TextMessage go = Instantiate(instance.textMessagePrefab, instance.textMessageParent);

            go.Initiate(s);
        }
    }
}
