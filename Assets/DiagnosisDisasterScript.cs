using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using KModkit;
using Rnd = UnityEngine.Random;

public class DiagnosisDisasterScript : MonoBehaviour
{

    static int _moduleIdCounter = 1;
    int _moduleID = 0;

    public KMBombModule Module;
    public KMAudio Audio;
    public KMSelectable[] Buttons;
    public TextMesh[] Texts;
    public SpriteRenderer Display;
    public Sprite[] Illnesses;
    public MeshRenderer[] StageLights;
    public Material[] StageColors;

    private string[] IllnessNames = {
"8-bitten",
"Aller-Gs",
"Animal Magnetism",
"Anty Matter",
"Banging Headache",
"Barking Mad",
"Beheadedness",
"Blank Look",
"Bone Head",
"Bowhine",
"Brain Farts",
"Budgie Struggler",
"Byteheadedness",
"Camel Toe",
"Cod Piece",
"Cubism",
"Culture Shock",
"Deeply\nIll-Suited",
"Denim Genes",
"Distrawed",
"Fanatick",
"Flat-Packed",
"Futurism",
"Grey Anatomy",
"Harebrained",
"Hazardous Waist",
"Headcrabedness",
"Hero Complex",
"Highly\nIll-Suited",
"Hive Mind",
"Hotheadedness",
"Jest Infection",
"Jester Infection",
"Knightmares",
"Lack of\nHumanity",
"Lightheadedness",
"Metropolism",
"Misdewiener",
"Monopolies",
"Monster Mishmash",
"Motion Sickness",
"Pandemic",
"Pothead",
"Premature\nMummification",
"Private Parts",
"Ramshackled",
"Reptile\nDysfunction",
"Screwball",
"Shadow Boxer",
"Shock Horror",
"Snow Problem",
"Soiled Self",
"Space Caged",
"Square Eyes",
"Turtle Head",
"Under The\nWeather",
"Wet Behind\nThe Ears",
"Woodworms",
"Woolly Man-Mouth",
"Writer's Block"
};
    private Queue<int> Memory = new Queue<int> ();
    private int StagePress;

    void Awake()
    {
        _moduleID = _moduleIdCounter++;
        Texts[0].text = "Illness 1";
        Texts[1].text = "Illness 2";
        Texts[2].text = "Illness 3";
        Texts[3].text = "Illness 4";
    }

    // Use this for initialization
    void Start()
    {
        GeneratePart1();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void GeneratePart1()
    {
        if (Memory.Count < 1)
        {
            Memory = new Queue<int> (new List<int>(Enumerable.Range(0,60)).Shuffle());
        }

        int[] possibleAnswers = { -1, -1, -1, -1 };

        StagePress = Rnd.Range(0, 4);
        Debug.LogFormat("Selected Button {0}",StagePress + 1);

        possibleAnswers[StagePress] = Memory.Dequeue();
        Debug.LogFormat("Selected Answer {0}", IllnessNames[possibleAnswers[StagePress]]);

        while (possibleAnswers.Contains(-1))
        {
            int newJunk = Rnd.Range(0, 60);

            if (possibleAnswers.Contains(newJunk))
            {
                continue;
            }

            possibleAnswers[Array.IndexOf(possibleAnswers, -1)] = newJunk;
            Debug.LogFormat("Junk Answer {0}", IllnessNames[newJunk]);
        }

        for (int i = 0; i < 4; i++)
        {
            Texts[i].text = IllnessNames[possibleAnswers[i]];
        }

        Display.sprite = Illnesses[possibleAnswers[StagePress]];
    }
}
