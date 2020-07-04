using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Fish Template", menuName = "Create New/Fish", order = 1)]
public class Fish_Template : ScriptableObject
{
    enum FishGender { Male = 0, Female = 1 }

    [Header("Fish Information")]
    [SerializeField] private string fishName;
    [SerializeField] private FishGender fishGender;
    [SerializeField] private Sprite fishPortrait;
    [SerializeField] private float fishWeight;
    [SerializeField][Range(-10, 100)] private float fishHunger = 50;

    public string GetFishName()
    {
        return fishName;
    }

    public Sprite GetFishPortrait()
    {
        return fishPortrait;
    }

    public string GetFishGender()
    {
        return fishGender.ToString();
    }

    public float GetFishWeight()
    {
        return fishWeight;
    }

    public float GetFishHunger()
    {
        return fishHunger;
    }

    public void IncrementHunger(float hungerFilled)
    {
        fishHunger += hungerFilled;
    }
}

