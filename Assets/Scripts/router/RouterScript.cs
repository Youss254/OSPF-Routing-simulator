using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class RouterScript : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    GameObject Clonedrouter;
    public Text routerNameText;
    Text ClonedText;
    int nameNumber;
    public Transform canvas;
    public InputField inputF;
    InputField clonedInputField;
    public Toggle m_Toggle;
    public static List<GameObject> routerList = new List<GameObject>();
    void Start()
    {
        //nameNumber = int.Parse(routerNameText.text.Substring(1));
        nameNumber = 0;
        m_Toggle = FindObjectOfType<Toggle>();
    }
   /* void Update()
    {
        if (m_Toggle.isOn)
        {
            enabled = false;
        }
        else
        {
            enabled = true;
        }
    }*/
    void OnMouseDown()
    {
        if (!m_Toggle.isOn)
        {
            if (!gameObject.name.Contains("R"))
            {

                screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
                offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
                Clonedrouter = Instantiate(gameObject, gameObject.transform.position, gameObject.transform.rotation);
                
                ClonedText = Instantiate(routerNameText) as Text;
                ClonedText.text = "R" + (nameNumber).ToString();
                Clonedrouter.name = "R" + (nameNumber).ToString();
                ClonedText.transform.SetParent(canvas, false);
                ClonedText.tag = "NameR";
                Clonedrouter.transform.GetChild(0).GetComponent<StickName>().nameLable = ClonedText;
                nameNumber++;
                routerNameText.text = "R" + (nameNumber).ToString();
                Clonedrouter.AddComponent<CloneMvnt>();
                Clonedrouter.tag = "Crouter";
                clonedInputField = Instantiate(inputF) as InputField;
                clonedInputField.transform.SetParent(canvas.transform, false);
                Clonedrouter.transform.GetChild(1).GetComponent<StickField>().nameField = clonedInputField;
                Clonedrouter.AddComponent<DisplayText>().inputField = clonedInputField.gameObject;
                Clonedrouter.AddComponent<Delete>();
                //Clonedrouter.AddComponent<ChooseRouters>();
                routerList.Add(Clonedrouter);
            }
        }
    }
    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        
        if (!gameObject.name.Contains("R"))
        {
            Clonedrouter.transform.position = curPosition;  
        }
       
    }
    public void ValidateName()
    {
        ClonedText.text = clonedInputField.text;
        clonedInputField.gameObject.SetActive(false);
        //routerNameText = ClonedText;
    }
    /*void OnMouseUp()
    {
       

    }*/


}
