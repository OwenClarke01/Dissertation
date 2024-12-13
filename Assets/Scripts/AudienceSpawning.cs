using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceSpawning : MonoBehaviour
{
    public GameObject[] audiencePrefabs;
    public Transform chairParent;
    public Transform audienceParent;
    public Transform stage;
    public float forwardOffset = 2f;

    // Start is called before the first frame update
    void Start()
    {
        // final checks
        if (audiencePrefabs.Length == 0)
        {
            Debug.LogError("no audience prefabs assigned");
            return;
        }
        if (chairParent == null)
        {
            Debug.LogError("no chair parent assigned");
            return;
        }
        if (stage == null)
        {
            Debug.LogError("no stage assigned");
            return;
        }
    }

     public void AudienceSpawner()
    {
        // locate all child transforms in chairParent
        List<Transform> chairPositions = new List<Transform>();
        foreach (Transform child in chairParent)
        {
            chairPositions.Add(child);
        }
        if (chairPositions.Count == 0)
        {
            Debug.LogError("no chair positions found as children of chair parent");
            return;
        }

        // instantiate random audience member infront of each chair
        foreach (Transform chair in chairPositions)
        {
            GameObject randomAudienceMember = audiencePrefabs[Random.Range(0, audiencePrefabs.Length)];
            Vector3 directionToStage = new Vector3(stage.position.x - chair.position.x, 0, stage.position.z - chair.position.z).normalized;

            Vector3 spawnPosition = chair.position + directionToStage * forwardOffset;

            GameObject newAudienceMember = Instantiate(randomAudienceMember, spawnPosition, Quaternion.identity);


            Quaternion lookRotation = Quaternion.LookRotation(directionToStage);
            newAudienceMember.transform.rotation = lookRotation;

            if (audienceParent != null)
            {
                newAudienceMember.transform.parent = audienceParent;
            }
        }

        Debug.Log("Hell yeah");
    }
}
