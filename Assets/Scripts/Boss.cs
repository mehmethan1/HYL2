using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Boss : MonoBehaviour
{
    //BOSS
    public GameObject LeftHand, RigthHand, Player, Exclamation;
    public Transform LeftPos1, RigthPos1, LeftPos2, RigthPos2;
    Vector3 Playertransform;
    public bool Back, LeftHandisGoing, RigthHandisGoing, LeftisGoing, RigthisGoing = false;
    public bool GetPosition;
    public bool CanChoose = true;
    public Animator anim;

    //Double Punch
    Vector3 LeftPunch,RigthPunch;

    float timer = 0f;
    float interval = 3f;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void RandomSkill()
    {
        LeftHand.transform.position = Vector3.MoveTowards(LeftHand.transform.position, LeftPos1.position, Time.deltaTime * 3);
        RigthHand.transform.position = Vector3.MoveTowards(RigthHand.transform.position, RigthPos1.position, Time.deltaTime * 3);

        // Zaman sayacını arttır
        timer ++;

        // Belirlenen aralığa ulaşıldığında rasgele bir fonksiyonu çağır
        if (timer >= interval && (CanChoose == true))
        {
            int randomState = Random.Range(0, 3);
            if (randomState == 0)
            {
                anim.SetBool("Punch", true);
                CanChoose = false;
                Debug.Log("Fonk 1");
            }
            else if (randomState == 1)
            {
                anim.SetBool("DoublePunch", true);
                CanChoose = false;
                Debug.Log("Fonk 2");
            }
            // Sayacı sıfırla
            timer = 0f;
        }
    }

    public void Punch()
    {
        if (!GetPosition)
        {
            Playertransform = new Vector3(Player.transform.position.x, -4, 0);
            Instantiate(Exclamation, Playertransform, Quaternion.identity);
            GetPosition = true;
        }
        else if(GetPosition)
        {
            if (Playertransform.x < 0)
            {
                if (!LeftHandisGoing)
                {
                    LeftHand.transform.position = Vector3.MoveTowards(LeftHand.transform.position, LeftPos2.position, Time.deltaTime * 4);
                    if (LeftHand.transform.position == LeftPos2.transform.position)
                    {
                        LeftHandisGoing = true;
                    }
                }
                else
                {
                    LeftHand.transform.position = Vector3.MoveTowards(LeftHand.transform.position, Playertransform, 0.3f);
                    if (LeftHand.transform.position == Playertransform)
                    {
                        LeftHandisGoing = false;
                        Back = true;
                    }
                }

                if (Back)
                {
                    LeftHand.transform.position = Vector3.MoveTowards(LeftHand.transform.position, LeftPos1.position, Time.deltaTime * 4);
                    if (Vector2.Distance(LeftHand.transform.position, LeftPos1.position) <= 0.3f)
                    {
                        LeftHand.transform.position = LeftPos1.position;
                        Back = false;
                        anim.SetBool("Punch", false);
                    }
                }
            }
            else if (Playertransform.x > 0)
            {

                if (!RigthHandisGoing)
                {
                    RigthHand.transform.position = Vector3.MoveTowards(RigthHand.transform.position, RigthPos2.position, Time.deltaTime * 4);
                    if (RigthHand.transform.position == RigthPos2.position)
                    {
                        RigthHandisGoing = true;
                    }
                }

                if (RigthHandisGoing)
                {
                    RigthHand.transform.position = Vector3.MoveTowards(RigthHand.transform.position, Playertransform, 0.3f);
                    if (RigthHand.transform.position == Playertransform)
                    {
                        RigthHandisGoing = false;
                        Back = true;
                    }
                }

                if (Back)
                {
                    RigthHand.transform.position = Vector3.MoveTowards(RigthHand.transform.position, RigthPos1.position, Time.deltaTime * 4);
                    if (Vector2.Distance(RigthHand.transform.position, RigthPos1.position) <= 0.3f)
                    {
                        RigthHand.transform.position = RigthPos1.position;
                        Back = false;
                        anim.SetBool("Punch", false);
                    }
                }
            }
        }
    }

    public void DoublePunch()
    {
        if (!GetPosition)
        {
            LeftPunch = new Vector3(Random.Range(-1, -8), -4, 0);
            RigthPunch = new Vector3(Random.Range(8, 0), -4, 0);
            Instantiate(Exclamation, LeftPunch, Quaternion.identity);
            Instantiate(Exclamation, RigthPunch, Quaternion.identity);
            GetPosition = true;
        }
        if (GetPosition)
        {
            //LEFT
            if (!LeftisGoing)
            {
                LeftHand.transform.position = Vector3.MoveTowards(LeftHand.transform.position, LeftPos2.position, Time.deltaTime * 3);
                if (LeftHand.transform.position == LeftPos2.position)
                {
                    LeftisGoing = true;
                }
            }
            if (LeftisGoing)
            {
                LeftHand.transform.position = Vector3.MoveTowards(LeftHand.transform.position, LeftPunch, 0.3f);
                if (LeftHand.transform.position == LeftPunch)
                {
                    LeftisGoing = false;
                    Back = true;
                }
            }

            //RİGTHH
            if (!RigthisGoing)
            {
                RigthHand.transform.position = Vector3.MoveTowards(RigthHand.transform.position, RigthPos2.position, Time.deltaTime * 3);
                if (RigthHand.transform.position == RigthPos2.position)
                {
                    RigthisGoing = true;
                }
            }
            if (RigthisGoing)
            {
                RigthHand.transform.position = Vector3.MoveTowards(RigthHand.transform.position, RigthPunch, 0.3f);
                if (RigthHand.transform.position == RigthPunch)
                {
                    RigthisGoing = false;
                    Back = true;
                }
            }

            //BACK

            if (Back)
            {
                LeftHand.transform.position = Vector3.MoveTowards(LeftHand.transform.position, LeftPos1.position, Time.deltaTime * 4);
                RigthHand.transform.position = Vector3.MoveTowards(RigthHand.transform.position, RigthPos1.position, Time.deltaTime * 4);
                if (Vector2.Distance(LeftHand.transform.position, LeftPos1.position) <= 0.3f && Vector2.Distance(RigthHand.transform.position, RigthPos1.position) <= 0.3f)
                {
                    Back = false;
                    anim.SetBool("DoublePunch", false);
                }
            }
        }
    }

    int i = 0;
    public void TriplePunch()
    {
        for(int i = 0; i < 4; i++)
        {
            if (!GetPosition)
            {
                LeftPunch = new Vector3(Random.Range(-1, -8), -4, 0);
                RigthPunch = new Vector3(Random.Range(8, 0), -4, 0);
                Playertransform = new Vector3(Player.transform.position.x, -4, 0);
                Instantiate(Exclamation, Playertransform, Quaternion.identity);
                GetPosition = true;
            }
            else if (GetPosition)
            {
                if (Playertransform.x < 0)
                {
                    if (!LeftHandisGoing)
                    {
                        LeftHand.transform.position = Vector3.MoveTowards(LeftHand.transform.position, LeftPos2.position, Time.deltaTime * 4);
                        if (LeftHand.transform.position == LeftPos2.transform.position)
                        {
                            LeftHandisGoing = true;
                        }
                    }
                    else
                    {
                        LeftHand.transform.position = Vector3.MoveTowards(LeftHand.transform.position, LeftPunch, 0.3f);
                        if (LeftHand.transform.position == Playertransform)
                        {
                            LeftHandisGoing = false;
                            Back = true;
                        }
                    }

                    if (Back)
                    {
                        LeftHand.transform.position = Vector3.MoveTowards(LeftHand.transform.position, LeftPos1.position, Time.deltaTime * 4);
                        if (Vector2.Distance(LeftHand.transform.position, LeftPos1.position) <= 0.3f)
                        {
                            LeftHand.transform.position = LeftPos1.position;
                            Back = false;
                        }
                    }
                }
                else if (Playertransform.x > 0)
                {

                    if (!RigthHandisGoing)
                    {
                        RigthHand.transform.position = Vector3.MoveTowards(RigthHand.transform.position, RigthPos2.position, Time.deltaTime * 4);
                        if (RigthHand.transform.position == RigthPos2.position)
                        {
                            RigthHandisGoing = true;
                        }
                    }

                    if (RigthHandisGoing)
                    {
                        RigthHand.transform.position = Vector3.MoveTowards(RigthHand.transform.position, RigthPunch, 0.3f);
                        if (RigthHand.transform.position == Playertransform)
                        {
                            RigthHandisGoing = false;
                            Back = true;
                        }
                    }

                    if (Back)
                    {
                        RigthHand.transform.position = Vector3.MoveTowards(RigthHand.transform.position, RigthPos1.position, Time.deltaTime * 4);
                        if (Vector2.Distance(RigthHand.transform.position, RigthPos1.position) <= 0.3f)
                        {
                            RigthHand.transform.position = RigthPos1.position;
                            Back = false;
                        }
                    }
                }
            }

            if( i == 3)
            {
                anim.SetBool("TriplePunch", false);
            }
        }
    }
}
