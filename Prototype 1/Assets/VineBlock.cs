using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class VineBlock : Block
{
    public NavMeshSurface[] surface;
    public GameObject[] Vines;
    public GameObject player;
    bool HasClimbed = true;
    // Start is called before the first frame update
    void Start()
    {
        Reset();
        for (int i = 0; i < surface.Length; i++)
        {
            surface[i].BuildNavMesh ();
        }
       
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Reset()
    {
        for (int i = 0; i < Vines.Length; i++)
        {
            Vines[i].SetActive(false);
        }
        HasClimbed = true;
        m_blockType = BlockType.Vine;
        m_isWalkable = false;
    }
    public void ClimbingVines()
    {
        if(HasClimbed)
         {
            for (int i = 0; i < Vines.Length; i++)
            {
                Vines[i].SetActive(true);
            }
        }
        m_isWalkable = true;
            m_blockType = BlockType.Ground;
            
            Vector3 temp = new Vector3(0, transform.position.y/2, 0);
            //play animation
            player.GetComponent<NavMeshAgent>().enabled = false;
            player.transform.position = transform.position + temp;
            player.GetComponent<NavMeshAgent>().enabled = true;
            Debug.Log(player.transform.position);
            HasClimbed = false;
       
    }
    

}
