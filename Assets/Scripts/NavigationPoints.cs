using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using UnityEngine;
using Unity;
using Random = UnityEngine.Random;

public class NavigationPoints : MonoBehaviour
{
    [Header("Navigation Points")]
    public Queue<NavigationStructure> navigationInstructions = new Queue<NavigationStructure>();
    public List<Transform> navigationLocations = new List<Transform>();
    public List<Transform> foodLocations = new List<Transform>();
    //private Queue<Fish> fishesQueuing = new Queue<Fish>();

    NavigationStructure currentProcess;

    public bool isProcessingPath = false;

    static NavigationPoints instance;

    private void Awake()
    {
        instance = this;
    }

    public static void RequestPath(Fish requester, Action<Vector3, bool> callback)
    {
        Vector3 movementPosition = instance.GetRandomPosition();
        instance.navigationInstructions.Enqueue(new NavigationStructure(movementPosition, callback));
        instance.TryProcessingNext();
    }

    public static void RequestFoodPath(Fish requester, Action<Vector3, bool> callback)
    {
        Vector3 movementPosition = instance.GetRandomFoodPosition();
        instance.navigationInstructions.Enqueue(new NavigationStructure(movementPosition, callback));
        instance.TryProcessingNext();
    }

    private Vector3 GetRandomPosition()
    {
        return navigationLocations[(Random.Range(0, navigationLocations.Count))].transform.position;
    }

    private Vector3 GetRandomFoodPosition()
    {
        return foodLocations[(Random.Range(0, foodLocations.Count))].transform.position;
    }


    public void TryProcessingNext()
    {
        if (navigationInstructions.Count != 0 && isProcessingPath != true)
        {
            for (int i = 0; i < navigationInstructions.Count; i++)
            {
                currentProcess = navigationInstructions.Dequeue();
                isProcessingPath = true;
                DispatchNavigationLocationToFish(currentProcess.m_NavigationPosition);
                continue;            
            }
        }
    }

    public void DispatchNavigationLocationToFish(Vector3 path)
    {
        currentProcess.m_Callback(path, true);
        isProcessingPath = false;  //We set that processing is complete.
        TryProcessingNext(); //We begin to try processing more items in the queue. 
    }
}


public struct NavigationStructure
{
    public Vector3 m_NavigationPosition;
    public Action<Vector3, bool> m_Callback;

    public NavigationStructure(Vector3 navigationPosition, Action<Vector3, bool> callback)
    {
        m_NavigationPosition = navigationPosition;
        m_Callback = callback;
    }
}


