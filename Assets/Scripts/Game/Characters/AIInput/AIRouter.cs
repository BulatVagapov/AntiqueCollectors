using UnityEngine;
using System;

[Serializable]
public class AIRouter
{
    [SerializeField] private Route route;
    [SerializeField] private float distanceForChecking = 0.5f;

    public bool OnRoute;
    public bool EndOfRouteIsReached;
    private bool forward;
    private int routeNodeIndex = 0;
    
    private bool CheckAchievementRouteNode(int routeNodeIndex, Transform characterTrancform)
    {
        if (Vector2.Distance(route.RouteNodes[routeNodeIndex].position, characterTrancform.position) <= distanceForChecking) return true;

        return false;
    }

    public void StartRoute()
    {
        OnRoute = true;
        forward = true;
        EndOfRouteIsReached = false;
        routeNodeIndex = 0;
    }

    public Vector2 GetDirection(Transform characterTrancform)
    {
        if(CheckAchievementRouteNode(routeNodeIndex, characterTrancform))
        {
            if(routeNodeIndex == route.RouteNodes.Length - 1 && forward)
            {
                EndOfRouteIsReached = true;
                forward = false;
                return Vector2.zero;
            }

            if(routeNodeIndex == 0 && !forward)
            {
                OnRoute = false;
                return Vector2.zero;
            }

            if (forward)
            {
                routeNodeIndex++;
            }
            else
            {
                routeNodeIndex--;
            }
        }

        return (route.RouteNodes[routeNodeIndex].position - characterTrancform.position).normalized;
    }
}
