using UnityEngine;

public class DirectionToNearestItemProvider
{
    private float minDistance;
    private float distanseForCheckInCicle;

    private Transform currentTargetItemTransform;

    public Vector2 GetDirectionToNearestItem(Transform startPosTransform, SpriteRenderer spriteRenderer)
    {
        return (GetNearestItemTransform(startPosTransform, spriteRenderer).position - startPosTransform.position).normalized;
    }
   
    private Transform GetNearestItemTransform(Transform startPosTransform, SpriteRenderer spriteRenderer)
    {
        if (StaticGameData.ActiveItemsAtScene.Count == 0) return startPosTransform;

        if (currentTargetItemTransform == null || !currentTargetItemTransform.gameObject.activeSelf) currentTargetItemTransform = StaticGameData.ActiveItemsAtScene[0];


        minDistance = Vector2.Distance(currentTargetItemTransform.position, startPosTransform.position);

        for (int i = 1; i < StaticGameData.ActiveItemsAtScene.Count; i++)
        {
            if (StaticGameData.ActiveItemsAtScene[i].position.x > spriteRenderer.transform.position.x - 0.5f
                && StaticGameData.ActiveItemsAtScene[i].position.x < spriteRenderer.transform.position.x + 0.5f)
            {
                continue;
            }

            distanseForCheckInCicle = Vector2.Distance(StaticGameData.ActiveItemsAtScene[i].position, startPosTransform.position);

            if(minDistance > distanseForCheckInCicle)
            {
                minDistance = distanseForCheckInCicle;
                currentTargetItemTransform = StaticGameData.ActiveItemsAtScene[i];
            }
        }
        
        return currentTargetItemTransform;
    }
}
