using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    private AbstractInput input;
    private CharacterMovement movement;
    private CharacterRotatorRelativeDirection characterRotator;
    private ItemCollector itemCollector;

    public CharacterType CharacterType;

    public ItemCollector ItemCollector => itemCollector;
    public CharacterMovement Movement => movement;

    public void SetInput(AbstractInput input)
    {
        this.input = input;
        input.CollectItemEvent += itemCollector.CollectPossibleItem;
        input.DropItemEvent += itemCollector.DropCollectedItem;
    }

    private void Awake()
    {
        movement = GetComponent<CharacterMovement>();
        characterRotator = GetComponent<CharacterRotatorRelativeDirection>();
        itemCollector = GetComponent<ItemCollector>();
        input = GetComponent<AbstractInput>();
        input.CollectItemEvent += itemCollector.CollectPossibleItem;
        input.DropItemEvent += itemCollector.DropCollectedItem;
    }

    void Update()
    {
        if (input == null) return;
        
        movement.Direction = input.Direction;
        characterRotator.RotateCharacterRelativeDirection(input.Direction);
    }
}
