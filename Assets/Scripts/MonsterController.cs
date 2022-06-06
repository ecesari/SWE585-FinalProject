using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MonsterController : MonoBehaviour
{
    Rigidbody monsterBody;
    private bool isGoingRight = true;

   public float mMovementSpeed = 0.001f;

    // Start is called before the first frame update
    void Start()
    {
        monsterBody = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        // if the ennemy is going right, get the vector pointing to its right
        Vector3 directionTranslation = (isGoingRight) ? transform.right : -transform.right; 
        directionTranslation *= Time.deltaTime * mMovementSpeed;

        monsterBody.transform.Translate(directionTranslation);

    }

    void OnCollisionEnter(Collision collision){
        
        if(collision.gameObject.tag == "Player"){
            Destroy(collision.gameObject);
           ResetGame();
        }else if(collision.gameObject.tag == "LeftTile" || collision.gameObject.tag == "RightTile"){
            isGoingRight = (isGoingRight?false:true);
        }
    }

    public void ResetGame(){
         SceneManager.LoadScene("SampleScene");
        
    }
}
