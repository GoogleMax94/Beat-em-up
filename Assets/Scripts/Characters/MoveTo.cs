using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
namespace Character
{
    public class MoveTo : MonoBehaviour
    {

        public float distance = 1.0f;

        List<Characters> characters = new List<Characters>();

        public void AddCharacter(Characters character)
        {
            characters.Add(character);
        }

        public void Update()
        {
            for (int i = 0; i < characters.Count; i++)
            {
                if (characters[i] != null && characters[i].tag != "Dead")
                {

                    Vector3 direction = characters[i].transform.localPosition.normalized;

                    Vector3 newPosition = direction * distance - characters[i].transform.localPosition;

                    characters[i].transform.localPosition += newPosition * characters[i].speed * Time.deltaTime;
                }
                else
                    characters.RemoveAt(i);
            }
        }
    }
}
