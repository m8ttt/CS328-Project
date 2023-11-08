using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public GameObject character;
    public float offset;
    public float smoothing;
    private Vector3 characterPosition;

    void Start()
    {

    }
   
    void Update()
    {
        characterPosition = new Vector3(character.transform.position.x, transform.position.y, transform.position.z);

        if (character.transform.localScale.x > 0f){
            characterPosition = new Vector3(characterPosition.x + offset, characterPosition.y, characterPosition.z);
        } else {
            characterPosition = new Vector3(characterPosition.x - offset, characterPosition.y, characterPosition.z);
        }

        transform.position = Vector3.Lerp(transform.position, characterPosition, smoothing * Time.deltaTime);
    }
}
