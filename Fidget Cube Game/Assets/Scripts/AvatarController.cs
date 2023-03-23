using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AvatarController : MonoBehaviour
{    
    public GameObject Avatar1;
    public GameObject Avatar2;
    public GameObject Avatar3;
    public GameObject Avatar4;
    public GameObject Avatar5;
    public GameObject Avatar6;
    public GameObject Avatar7;
    public GameObject Avatar8;
    public GameObject Avatar9;
    public GameObject Avatar10;
    private List<GameObject> Avatars = new List<GameObject>();

    public int currentAvatar = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        Avatars.Add(Avatar1);
        Avatars.Add(Avatar2);
        Avatars.Add(Avatar3);
        Avatars.Add(Avatar4);
        Avatars.Add(Avatar5);
        Avatars.Add(Avatar6);
        Avatars.Add(Avatar7);
        Avatars.Add(Avatar8);
        Avatars.Add(Avatar9);
        Avatars.Add(Avatar10);

        SetAvatarActive(currentAvatar);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            Move();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SelectAvatar();
        }
    }

    private void SetAvatarActive(int currentAvatar)
    {
        for (int i = 0; i < 10; i++)
        {
            if (i == currentAvatar)
            {
                Avatars[i].transform.GetChild(0).gameObject.SetActive(true);
            }
            else
            {
                Avatars[i].transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }

    private void Move()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentAvatar == 9 || currentAvatar == 4)
            {
                
            }
            else
            {
                currentAvatar++;
                SetAvatarActive(currentAvatar);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentAvatar == 0 || currentAvatar == 5)
            {
            
            }
            else
            {
                currentAvatar--;
                SetAvatarActive(currentAvatar);
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentAvatar >= 0 && currentAvatar < 5)
            {
                currentAvatar += 5;
                SetAvatarActive(currentAvatar);
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentAvatar > 4 && currentAvatar < 10)
            {
                currentAvatar -= 5;
                SetAvatarActive(currentAvatar);
            }
        }
    }

    public void SelectAvatar()
    {
        GameManager.instance.avatar = Avatars[currentAvatar].GetComponent<Image>().sprite;
        SceneController.instance.FadeToBlack("Menu");   
    }
}
