using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    [SerializeField] TMP_Text screenTitle;
    [SerializeField] TMP_Text screenText;

    [SerializeField] Button button1;
    [SerializeField] Button button2;

    string introTitle = "Intro";
    string introText = @"Wilkommen in Barista VR! Hier erlernst du wie man eine Siebträgermaschine richtig nutzt, um den perfekten Kaffee zu produzieren.
Wir zeigen dir die einzelnen Arbeitsschritte und danach wirst du es ganz allein versuchen. Aber Vorsicht, wenn du einen Fehler machst, wird der Kaffee ungenießbar und du musst von vorn beginnen!
Bist du bereit?";

    string screenTitle1 = "Tutorial - Schritt 1 - Sieb Befüllen";   
    string screenText1 = @"Die Mühle ist bereits mit Bohnen befüllt. Du kannst also direkt loslegen.
Zunächst wählst du den richtigen Mahlgrad. Je niedriger die Stufe, desto gröber wird das Kaffeepulver.
Stelle den Mahlgrad auf Stufe 3!";

    string screenTitle2 = "Tutorial - Schritt 1 - Sieb Befüllen";
    string screenText2 = @"Nimm jetzt den Sieb und stecke ihn in die Kaffemühle.";

    string screenTitle3 = "Tutorial - Schritt 2 - Kaffepulver Tampern";
    string screenText3 = @"Sehr gut. Das Pulver ist fertig, jetzt wird es im Siebträger verteilt.
Lege den Sieb dazu in die Tamper-Station.";

    string screenTitle4 = "Tutorial - Schritt 2 - Kaffepulver Tampern";    
    string screenText4 = @"Jetzt musst du das Pulver noch tampern, damit der Kaffee weder zu wässrig noch zu bitter wird. Drücke dafür den Puck auf das Pulver!
Lege anschließende den Puck zurück in die Haltevorrichtung.";


    string screenTitle5 = "Tutorial - Schritt 3 - Kaffe Brühen";    
    string screenText5 = @"Nun kann es losgehen, stecke den Sieb in die Kaffeemaschine und schalte sie ein!";     

    string screenTitle6 = "Tutorial - Schritt 3 - Kaffe Brühen";    
    string screenText6 = @"Damit der Kaffe nicht in die Leere geht, musst du noch eine Tasse unter den Sieb stellen.";

    string screenTitle7 = "Tutorial - Schritt 3 - Kaffe Brühen";
    string screenText7 = @"Ziehe den Hebel um die Pumpe zu starten und den Kaffe zu brühen.
Bei einer Siebträger musst du dich selbst darum kümmern, wie viel Wasser durch den Sieb fließt.
Der Kaffe Sieb muss etwa 30 Sekunden mit heißem Wasser gebrüht werden um die Tasse zu füllen.";

    string screenTitle8 = "Tutorial - Schritt 4 - Warenausgabe";
    string screenText8 = @"Perfekt! Stelle zum Schluss die Tasse in die Warenausgabe."; 

    string screenTitle9 = "Tutorial - Resultat";
    string screenText9 = @"Hast du dir alles gut gemerkt?
Dann bist du jetzt dran, beweise, dass du bereit bist, einen perfekten Kaffee zu kochen!";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ChangeStage(int stage)
    {
        gameManager.tutorialStage = stage;
        
    }

    public void ShowIntroScreen()
    {
        screenTitle.text = introTitle;
        screenText.text = introText;

        button1.gameObject.SetActive(true);
        button2.gameObject.SetActive(false);

        button1.GetComponentInChildren<TextMeshProUGUI>().text = "JA";

        button1.onClick.AddListener(delegate { ChangeStage(1); });


        
    }
    public void ShowTutorialScreen1()
    {
        screenTitle.text = screenTitle1;
        screenText.text = screenText1;

        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);
    }
    public void ShowTutorialScreen2()
    {
        screenTitle.text = screenTitle2;
        screenText.text = screenText2;

        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);
    }
    public void ShowTutorialScreen3()
    {
        screenTitle.text = screenTitle3;
        screenText.text = screenText3;

        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);
    }
    public void ShowTutorialScreen4()
    {
        screenTitle.text = screenTitle4;
        screenText.text = screenText4;

        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);
    }
    public void ShowTutorialScreen5()
    {
        screenTitle.text = screenTitle5;
        screenText.text = screenText5;

        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);
    }

    public void ShowTutorialScreen6()
    {
        screenTitle.text = screenTitle6;
        screenText.text = screenText6;

        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);
    }

    public void ShowTutorialScreen7()
    {
        screenTitle.text = screenTitle7;
        screenText.text = screenText7;

        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);
    }

    public void ShowTutorialScreen8()
    {
        screenTitle.text = screenTitle8;
        screenText.text = screenText8;
        
        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);
    }

    public void ShowTutorialScreen9()
    {
        screenTitle.text = screenTitle9;
        screenText.text = screenText9;

        button1.gameObject.SetActive(true);
        button2.gameObject.SetActive(true);

        button1.GetComponentInChildren<TextMeshProUGUI>().text = "TUTORIAL WIEDERHOLEN";
        button2.GetComponentInChildren<TextMeshProUGUI>().text = "PRÜFUNG ABLEGEN";
    }
}
