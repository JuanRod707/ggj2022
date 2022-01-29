using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Hero;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] float minimumAxisThreshold;

    HeroCharacter character;
    Vector3 movementVector;

    void FixedUpdate()
    {
        movementVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        
        if (movementVector.magnitude > minimumAxisThreshold)
            character.MoveTowards(movementVector);
    }

    void Update()
    {
        if (Input.GetButtonDown("Attack"))
            character.Attack();

        if (Input.GetButtonDown("Dash"))
            character.Dash(movementVector);
    }

    public void Initialize(HeroCharacter character) => 
        this.character = character;
}
