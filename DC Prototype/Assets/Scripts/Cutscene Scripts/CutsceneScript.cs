using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneScript : MonoBehaviour
{
    public static CutsceneScript instance;

    public string[] l;

    void Awake()
    {
        l = new string[18];

        instance = this;

        l[0] = "I WAS RIGHT!!!"; // m
         
        l[1] = "Yeah?"; // b

        l[2] = "HOLLOW EARTH!! OCCAM'S RAZOR!!!"; // m

        l[3] = "How many hours do we have to listen to this?"; // b

        l[4] = "I think I heard the cops looking for a dog in a hot air balloon."; // m

        l[5] = "I might be able to find out where... if I had a raccoon police scanner."; // m

        l[6] = "BK, where can we get a racoon police scanner?"; // m

        l[7] = "The police chief probably has one?"; // b

        l[8] = "But he's at Raccoon Lagoon today. It's his day off."; // b

        l[9] = "Let's wreck it!!"; // m

        l[10] = "MIRA. ARE YOU SERIOUS???"; // b

        l[11] = "Raccoon Lagoon is the happiest raccoon place on raccoon earth."; // b

        l[12] = "It's got great tunes and water balloons."; // b

        l[13] = "Raccoon Lagoon is home of the Fun Flume that's Fun for Raccoons."; // b

        l[14] = "You have no choice, BK."; // m

        l[15] = "The flume is doomed."; // m

        l[16] = "FINE!!"; // b

        l[17] = "But YOU have to answer to the police chief when he's down here."; // b

    }

}
