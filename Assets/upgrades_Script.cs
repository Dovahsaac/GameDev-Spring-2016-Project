using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.IO;
using UnityEngine.SceneManagement;

public class upgrades_Script : MonoBehaviour {

    Text upgradeInfo;
    int tankLVL, speedLVL, damageLVL, utilityLVL, ap;
    string[,] wiki = new string[4, 3] { {
            //TANK UPGRADES
            "25% chance to dodge.",
            "35% damage reduction on forward attacks.",
            "1 free life every checkpoint." },
        {
            //SPEED UPGRADES
            "30% faster firing rate",
            "Twice the guns",
            "The lower your health the faster you attack, max 300% attack speed." },
        {
            //DAMAGE UPGRADES
            "20% chance for a 275% attack damage shot.",
            "Shots set enemy units on fire, 1 damage per second.",
            "Every consequitive hit on a target increases its damage taken by 5%." },
        {
            //UTILITY UPGRADES
            "Power-ups appear 50% more often.",
            "Gold is increased by 25%",
            "Power-ups grant twice the bonuses"
        } };

    Button tank1;
    Button tank2;
    Button tank3;
    Button speed1;
    Button speed2;
    Button speed3;
    Button damage1;
    Button damage2;
    Button damage3;
    Button utility1;
    Button utility2;
    Button utility3;

    // Use this for initialization
    void Start () {

        loadSave();

        upgradeInfo = GameObject.Find("upgradeInfo").GetComponent<Text>();

        tank1 = GameObject.Find("Tank1").GetComponent<Button>();
        tank2 = GameObject.Find("Tank2").GetComponent<Button>();
        tank3 = GameObject.Find("Tank3").GetComponent<Button>();
        speed1 = GameObject.Find("Speed1").GetComponent<Button>();
        speed2 = GameObject.Find("Speed2").GetComponent<Button>();
        speed3 = GameObject.Find("Speed3").GetComponent<Button>();
        damage1 = GameObject.Find("Damage1").GetComponent<Button>();
        damage2 = GameObject.Find("Damage2").GetComponent<Button>();
        damage3 = GameObject.Find("Damage3").GetComponent<Button>();
        utility1 = GameObject.Find("Utility1").GetComponent<Button>();
        utility2 = GameObject.Find("Utility2").GetComponent<Button>();
        utility3 = GameObject.Find("Utility3").GetComponent<Button>();

        tank1.onClick.AddListener(Tank1);
        tank2.onClick.AddListener(Tank2);
        tank3.onClick.AddListener(Tank3);
        speed1.onClick.AddListener(Speed1);
        speed2.onClick.AddListener(Speed2);
        speed3.onClick.AddListener(Speed3);
        damage1.onClick.AddListener(Damage1);
        damage2.onClick.AddListener(Damage2);
        damage3.onClick.AddListener(Damage3);
        utility1.onClick.AddListener(Utility1);
        utility2.onClick.AddListener(Utility2);
        utility3.onClick.AddListener(Utility3);

        GameObject.Find("Reset").GetComponent<Button>().onClick.AddListener(Reset);
        GameObject.Find("MainMenu_Button").GetComponent<Button>().onClick.AddListener(Exit);
        GameObject.Find("Continue_Button").GetComponent<Button>().onClick.AddListener(Continue);
        colorButtons();
        GameObject.Find("abilityPoints").GetComponent<Text>().text = ap.ToString();

    }

    private void Continue()
    {
        Save();
        SceneManager.LoadScene("Patricks Workbench");
    }

    private void Save()
    {
        StreamWriter writer = new StreamWriter("save.txt");
        writer.WriteLine(String.Format("{0}\t{1}\t{2}\t{3}\t{4}", ap, tankLVL, speedLVL, damageLVL, utilityLVL));
        writer.Flush();
        writer.Close();
    }

    void Exit()
    {
        Save();
        SceneManager.LoadScene("Main Menu");
    }

    private void loadSave()
    {
        StreamReader reader = new StreamReader("save.txt");
        string[] data = reader.ReadLine().Split('\t');

        ap = Int32.Parse(data[0]);
        tankLVL = Int32.Parse(data[1]);
        speedLVL = Int32.Parse(data[2]);
        damageLVL = Int32.Parse(data[3]);
        utilityLVL = Int32.Parse(data[4]);

        reader.Close();
    }

    // Update is called once per frame
    void Update () {
	
	}

    void Tank1() { up(Up.TANK, 1); }
    void Tank2() { up(Up.TANK, 2); }
    void Tank3() { up(Up.TANK, 3); }
    void Speed1() { up(Up.SPEED, 1); }
    void Speed2() { up(Up.SPEED, 2); }
    void Speed3() { up(Up.SPEED, 3); }
    void Damage1() { up(Up.DAMAGE, 1); }
    void Damage2() { up(Up.DAMAGE, 2); }
    void Damage3() { up(Up.DAMAGE, 3); }
    void Utility1() { up(Up.UTILITY, 1); }
    void Utility2() { up(Up.UTILITY, 2); }
    void Utility3() { up(Up.UTILITY, 3); }

    void up(Up type,int tier)
    {
        switch (type)
        {
            case Up.TANK: if (tankLVL == tier - 1 && ap > 0) { tankLVL = tier; ap--; } break;
            case Up.SPEED: if (speedLVL == tier - 1 && ap > 0) { speedLVL = tier; ap--; } break;
            case Up.DAMAGE: if (damageLVL == tier - 1 && ap > 0) { damageLVL = tier; ap--; } break;
            case Up.UTILITY: if (utilityLVL == tier - 1 && ap > 0) { utilityLVL = tier; ap--; } break;
        }

        upgradeInfo.text = wiki[(int)type, tier-1];

        colorButtons();

        GameObject.Find("abilityPoints").GetComponent<Text>().text = ap.ToString();
    }

    private void colorButtons()
    {
        if (tankLVL > 0) tank1.GetComponent<Image>().color = Color.red; else tank1.GetComponent<Image>().color = Color.white;
        if (tankLVL > 1) tank2.GetComponent<Image>().color = Color.red; else tank2.GetComponent<Image>().color = Color.white;
        if (tankLVL > 2) tank3.GetComponent<Image>().color = Color.red; else tank3.GetComponent<Image>().color = Color.white;
        if (speedLVL > 0) speed1.GetComponent<Image>().color = Color.red; else speed1.GetComponent<Image>().color = Color.white;
        if (speedLVL > 1) speed2.GetComponent<Image>().color = Color.red; else speed2.GetComponent<Image>().color = Color.white;
        if (speedLVL > 2) speed3.GetComponent<Image>().color = Color.red; else speed3.GetComponent<Image>().color = Color.white;
        if (damageLVL > 0) damage1.GetComponent<Image>().color = Color.red; else damage1.GetComponent<Image>().color = Color.white;
        if (damageLVL > 1) damage2.GetComponent<Image>().color = Color.red; else damage2.GetComponent<Image>().color = Color.white;
        if (damageLVL > 2) damage3.GetComponent<Image>().color = Color.red; else damage3.GetComponent<Image>().color = Color.white;
        if (utilityLVL > 0) utility1.GetComponent<Image>().color = Color.red; else utility1.GetComponent<Image>().color = Color.white;
        if (utilityLVL > 1) utility2.GetComponent<Image>().color = Color.red; else utility2.GetComponent<Image>().color = Color.white;
        if (utilityLVL > 2) utility3.GetComponent<Image>().color = Color.red; else utility3.GetComponent<Image>().color = Color.white;
    }

    private void Reset()
    {

        ap += tankLVL + speedLVL + damageLVL + utilityLVL;
        tankLVL = 0;
        speedLVL = 0;
        damageLVL = 0;
        utilityLVL = 0;

        GameObject.Find("abilityPoints").GetComponent<Text>().text = ap.ToString();

        colorButtons();
    }

}

enum Up
{
    TANK,SPEED,DAMAGE,UTILITY
}
