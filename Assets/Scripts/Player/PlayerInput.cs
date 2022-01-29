using Assets.Scripts.Actors;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    HeroCharacter character;


    void FixedUpdate()
    {
        var movementVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (movementVector.magnitude > 0)
            character.MoveTowards(movementVector);
    }

    public void Initialize(HeroCharacter character) => 
        this.character = character;
}
