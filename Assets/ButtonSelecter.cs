using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSelecter : MonoBehaviour
{
    public Animator[] anims;
    public int index;
    private bool touched;

    void Start()
    {
        anims[index].Play("ButtonSelected");
    }

    void Update()
    {
        Scroll();
        Select();
    }

    void Select()
    {
        if (Input.GetButtonDown("Jump"))
        {
            switch (index)
            {
                case 0:
                    SceneManager.LoadScene(1);
                    break;
                case 1:
                    Application.Quit();
                    break;
            }
        }
    }

    void Scroll()
    {
        if (Mathf.Abs(Input.GetAxis("Vertical")) > .2f && !touched)
        {
            touched = true;

            if (index >= anims.Length -1)
            {
                anims[index].Play("ButtonUnselected");
                index = 0;
                anims[index].Play("ButtonSelected");
            }
            else
            {
                anims[index].Play("ButtonUnselected");
                index++;
                anims[index].Play("ButtonSelected");
            }
        }

        if (Mathf.Abs(Input.GetAxis("Vertical")) < .2f)
        {
            touched = false;
        }
    }
}


