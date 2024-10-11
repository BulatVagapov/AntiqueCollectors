using UnityEngine;

public class AIInput : AbstractInput
{
    [SerializeField] private AIRouter router;
    private DirectionToNearestItemProvider directionProvider = new();
    private SpriteRenderer spriteRenderer;
    private CharacterManager characterManager;
    
    void Start()
    {
        characterManager = GetComponent<CharacterManager>();
        spriteRenderer = transform.GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        if(characterManager.ItemCollector.PossibleToCollectItem != null)
        {
            OnCollectItem();
        }
        
        if(characterManager.ItemCollector.CollectedItem != null)
        {
            if (!router.OnRoute)
            {
                router.StartRoute();
            }
            else
            {
                if (router.EndOfRouteIsReached)
                {
                    OnDropItem();
                }
            }

            direction = router.GetDirection(transform);
            return;
        }

        if (characterManager.ItemCollector.CollectedItem == null && router.OnRoute)
        {
            direction = router.GetDirection(transform);
            return;
        }

        if (characterManager.ItemCollector.CollectedItem == null && !router.OnRoute)
        {
            direction = directionProvider.GetDirectionToNearestItem(characterManager.ItemCollector.HandTransform, spriteRenderer);
            return;
        }
    }
}
