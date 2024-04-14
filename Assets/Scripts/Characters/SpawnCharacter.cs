using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

namespace Character
{
    public class SpawnCharacter : MonoBehaviour
    {

        public Transform[] pointXPosition;

        public Characters[] charactersPrefab;

        public UnityEvent<Characters> characterSpawn;

        public int maxCharacter = 2;
        [Header("Spawn Delay")]
        public float from;
        public float to;
        private void Start()
        {
            StartCoroutine(SpawnTimer());
        }
        IEnumerator SpawnTimer()
        {
            while (true)
            {
                if (transform.childCount < maxCharacter && charactersPrefab.Length > 0 && pointXPosition.Length > 0)
                {
                    
                    var prefab = charactersPrefab[Random.Range(0, charactersPrefab.Length)];
                    Vector3 point = transform.position;
                    point.x = pointXPosition[Random.Range(0, pointXPosition.Length)].position.x;

                    characterSpawn?.Invoke(Instantiate(prefab, point, Quaternion.identity, transform));
                }

                yield return new WaitForSeconds(Random.Range(from, to));
            }
        }

        private void OnDisable()
        {
            characterSpawn.RemoveAllListeners();
        }
    }
}
