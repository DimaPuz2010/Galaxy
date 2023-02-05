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
    private RamGroup currentGroup2;
    private FirstGroup currentGroup1;
    private TypeGroup[] typesGroup = {TypeGroup.shutting, TypeGroup.Ram};

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
        if(currentGroup1 != null && currentGroup1.isAlive == false) {
            if (groupCount == typesGroup.Length) {
                SceneManager.LoadSceneAsync(SceneIDS.winSceneID);
            } else {
                Destroy(currentGroup1.gameObject);
                CreateNewGroup();
                groupCount++;
            }
        }else if(currentGroup2 != null && currentGroup2.isAlive == false) {
            if (groupCount == typesGroup.Length) {
                SceneManager.LoadSceneAsync(SceneIDS.winSceneID);
            } else {
                Destroy(currentGroup2.gameObject);
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
            currentGroup1 = newEnemyGroup.GetComponent<FirstGroup>();

            print("spawn 1");

        }else if (typesGroup[groupCount] == TypeGroup.Ram){

            GameObject newEnemyGroup = Instantiate(enemyGroupRam);
            newEnemyGroup.transform.position = startEnemyGroupPosition;
            currentGroup2 = newEnemyGroup.GetComponent<RamGroup>();
            
            print("spawn 2");
        }
        
    }
    
}
