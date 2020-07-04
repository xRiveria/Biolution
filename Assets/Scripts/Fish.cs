using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Fish : MonoBehaviour
{
    [Header("Systems")]
    [SerializeField] private Fish_Template fishTemplate;
    private NavMeshAgent m_NavigationAgent;
    private Outline outline;

    private void Start()
    {
        outline = GetComponent<Outline>();
        outline.enabled = false;
        m_NavigationAgent = GetComponent<NavMeshAgent>();
        NavigationPoints.RequestPath(this, OnPathFound);
    }

    private void OnMouseOver()
    {
        outline.enabled = true;
        FishQuickViewSystem.QuickViewFishInformation(fishTemplate);
    }

    private void OnMouseExit()
    {
        outline.enabled = false;
        FishQuickViewSystem.CloseQuickViewPanel();
    }

    private void Update()
    {
        if (m_NavigationAgent.pathEndPosition.x == transform.position.x)
        {
            NavigationPoints.RequestPath(this, OnPathFound);
        }      
    }

    IEnumerator PositionReached()
    {
        yield return new WaitForSeconds(1f);
        NavigationPoints.RequestPath(this, OnPathFound);
    }

    public void OnPathFound(Vector3 newPath, bool pathSuccessful)      //Once a path has been found.
    {
        if (pathSuccessful)                      //Check again to make sure that the path is successful.
        {
            m_NavigationAgent.SetDestination(newPath);
        }
    }
}
