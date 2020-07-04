using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishQuickViewSystem : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject fishQuickViewPanel;
    [SerializeField] private Text fishNameText;
    [SerializeField] private Image fishPortrait;
    [SerializeField] private Image fishMalePortrait;
    [SerializeField] private Image fishFemalePortrait;
    [SerializeField] private Text fishWeightText;

    static FishQuickViewSystem instance;

    private void Awake()
    {
        instance = this;
    }

    public static void QuickViewFishInformation(Fish_Template fishInformation)
    {
        instance.fishNameText.text = fishInformation.GetFishName();
        instance.fishPortrait.sprite = fishInformation.GetFishPortrait();
        
        if (fishInformation.GetFishGender() == "Male")
        {
            instance.fishFemalePortrait.gameObject.SetActive(false);
        }
        else
        {
            instance.fishMalePortrait.gameObject.SetActive(false);
        }

        instance.fishWeightText.text = fishInformation.GetFishWeight().ToString() + " Pounds";

        instance.fishQuickViewPanel.SetActive(true);
    }

    public static void CloseQuickViewPanel()
    {
        instance.fishQuickViewPanel.SetActive(false);
        instance.fishNameText.text = "";
        instance.fishPortrait.sprite = null;
        instance.fishFemalePortrait.gameObject.SetActive(true);
        instance.fishMalePortrait.gameObject.SetActive(true);
        instance.fishWeightText.text = "";

    }
}
