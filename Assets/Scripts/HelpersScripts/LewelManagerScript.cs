using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LewelManagerScript : MonoBehaviour
{
    public GameObject playerShipOriginal;
    Vector3 startPlayerPosition = new Vector3(0, -3.5f, 0);

    public GameObject enemyGroupBullet;
    public GameObject enemyGroupRam;
    Vector3 startEnemyGroupPosition = new Vector3(0, 3.15f, 0);

    private FirstGroup currentGroup;
    private TypeGroup[] typesGroup = {TypeGroup.Ram};

    private int groupCount = 0;

    void Start()
    {
        GameObject newPlayerShip = Instantiate(playerShipOriginal);
        newPlayerShip.transform.position = startPlayerPosition;

        CreateNewGroup();
        groupCount ++;
    }

    void Update()
    {
        if(currentGroup != null && currentGroup.isAlive == false) {
            if (groupCount == typesGroup.Length) {
                SceneManager.LoadSceneAsync(SceneIDS.winSceneID);
            } else {
                Destroy(currentGroup.gameObject);
                CreateNewGroup();
                groupCount++;
            }
        }
    }
    void CreateNewGroup() 
    {
        if (typesGroup[groupCount] == TypeGroup.shutting)
        {

            GameObject newEnemyGroup = Instantiate(enemyGroupBullet);
            newEnemyGroup.transform.position = startEnemyGroupPosition;
            currentGroup = newEnemyGroup.GetComponent<FirstGroup>();

        }else if (typesGroup[groupCount] == TypeGroup.Ram){

            GameObject newEnemyGroup = Instantiate(enemyGroupRam);
            newEnemyGroup.transform.position = startEnemyGroupPosition;
            currentGroup = newEnemyGroup.GetComponent<FirstGroup>();
            
        }
        
    }
    
}
