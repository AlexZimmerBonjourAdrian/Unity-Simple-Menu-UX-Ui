using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using NUnit.Framework;
using TMPro;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using static EEmploye;

public class AllMenuWorkflowTesting
{
    [SetUp]
    public void Setup()
    {

        EditorSceneManager.LoadScene(0);

    }


    [UnityTest, Order(1)]
    public IEnumerator ValueWrite_AddEmployee_WorkflowTestingWithEnumeratorPasses()
    {
        EditorSceneManager.LoadScene(1);
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return new WaitForSeconds(4f);

        //Arrange
        var Button_Send = GameObject.Find("Agregar").GetComponent<UnityEngine.UI.Button>();
        var CIUi = GameObject.Find("Input_CI").GetComponent<TMP_InputField>();
        var NameUi = GameObject.Find("Input_Name").GetComponent<TMP_InputField>();
        var LastNameUi = GameObject.Find("Input_LastName").GetComponent<TMP_InputField>();
        var AdressUi = GameObject.Find("Input_Adress").GetComponent<TMP_InputField>();
        var EmailUi = GameObject.Find("Input_Email").GetComponent<TMP_InputField>();
        var PhoneUi = GameObject.Find("Input_Phone").GetComponent<TMP_InputField>();
        var BirthDateUi = GameObject.Find("BirthdayInput").GetComponentsInChildren<TMP_InputField>();
        var RolUi = GameObject.Find("RolDropdown").GetComponent<TMP_Dropdown>();
        var SeniorityUi = GameObject.Find("SeniorityDropdown").GetComponent<TMP_Dropdown>();
        var JoinDateUi = GameObject.Find("JoinDateInput").GetComponentsInChildren<TMP_InputField>();


        //Act


        //Assert
        Assert.NotNull(Button_Send);
        Assert.NotNull(CIUi);
        Assert.NotNull(NameUi);
        Assert.NotNull(LastNameUi);
        Assert.NotNull(EmailUi);
        Assert.NotNull(PhoneUi);

        Assert.NotNull(BirthDateUi);
        Assert.NotNull(RolUi);
        Assert.NotNull(AdressUi);
        Assert.NotNull(SeniorityUi);
        Assert.NotNull(JoinDateUi);


        Assert.NotNull(JoinDateUi[0]);
        Assert.NotNull(JoinDateUi[1]);
        Assert.NotNull(JoinDateUi[2]);

        Assert.NotNull(BirthDateUi[0]);
        Assert.NotNull(BirthDateUi[1]);
        Assert.NotNull(BirthDateUi[2]);


        CIUi.text = "123456789";
        NameUi.text = "Juan";
        LastNameUi.text = "Torres";
        EmailUi.text = "JuanTorres@yahoo.com";
        AdressUi.text = "Calle Juan Antonio S/N";
        PhoneUi.text = "098523145";
        RolUi.value = 2;
        SeniorityUi.value = 2;
        BirthDateUi[0].text = "01";
        BirthDateUi[1].text = "02";
        BirthDateUi[2].text = "1987";
        JoinDateUi[0].text = "01";
        JoinDateUi[1].text = "02";
        JoinDateUi[2].text = "2017";


        Assert.AreEqual(expected: "123456789", actual: CIUi.text);
        Assert.AreEqual(expected: "Juan", actual: NameUi.text);
        Assert.AreEqual(expected: "Torres", actual: LastNameUi.text);
        Assert.AreEqual(expected: "JuanTorres@yahoo.com", actual: EmailUi.text);
        Assert.AreEqual(expected: "098523145", actual: PhoneUi.text);
        Assert.AreEqual(expected: 2, actual: RolUi.value);
        Assert.AreEqual(expected: 2, actual: SeniorityUi.value);
        Assert.AreEqual(expected: "Calle Juan Antonio S/N", actual: AdressUi.text);
        Assert.AreEqual(expected: "01", actual: BirthDateUi[0].text);
        Assert.AreEqual(expected: "02", actual: BirthDateUi[1].text);
        Assert.AreEqual(expected: "1987", actual: BirthDateUi[2].text);
        Assert.AreEqual(expected: "01", actual: JoinDateUi[0].text);
        Assert.AreEqual(expected: "02", actual: JoinDateUi[1].text);
        Assert.AreEqual(expected: "2017", actual: JoinDateUi[2].text);

        Button_Send.onClick.Invoke();
    }



    [UnityTest, Order(2)]
    public IEnumerator ValueWrite_ModifyEmployee_WorkflowTestingWithEnumeratorPasses()
    {

        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        EditorSceneManager.LoadScene(2);
        yield return new WaitForSeconds(4f);

        //Arrange


        var SearchUi = GameObject.Find("InputField_Search").GetComponent<TMP_InputField>();
        var Button_Search = GameObject.Find("Search_Button").GetComponent<UnityEngine.UI.Button>();

        SearchUi.text = (Principal.Inst.GetId() - 1).ToString();
        Button_Search.onClick.Invoke();

        var buttonContainer = GameObject.Find("employeersContainer").transform;
        var EmployeeButton = buttonContainer.GetComponentsInChildren<Button>();

        Button Button_EmployeeSelected;

        foreach (var choice in EmployeeButton)
        {
            Button_EmployeeSelected = choice;
            Button_EmployeeSelected.onClick.Invoke();
        }

        var CIUi = GameObject.Find("Input_CI").GetComponent<TMP_InputField>();
        var NameUi = GameObject.Find("Input_Name").GetComponent<TMP_InputField>();
        var LastNameUi = GameObject.Find("Input_LastName").GetComponent<TMP_InputField>();
        var AdressUi = GameObject.Find("Input_Adress").GetComponent<TMP_InputField>();
        var PhoneUi = GameObject.Find("Input_Phone").GetComponent<TMP_InputField>();
        var EmailUi = GameObject.Find("Input_Email").GetComponent<TMP_InputField>();
        var BirthDateUi = GameObject.Find("BirthDateInput").GetComponentsInChildren<TMP_InputField>();
        var RolUi = GameObject.Find("RolDropdown").GetComponent<TMP_Dropdown>();
        var SeniorityUi = GameObject.Find("SeniorityDropdown").GetComponent<TMP_Dropdown>();
        var JoinDateUi = GameObject.Find("JoinDateInput").GetComponentsInChildren<TMP_InputField>();


        // var Button_Cancel = ConfirmPanel.transform.Find("No_Buttom").GetComponent<Button>();


        //Act


        //Assert

        Assert.NotNull(Button_Search);
        Assert.NotNull(SearchUi);


        Assert.NotNull(CIUi);
        Assert.NotNull(NameUi);
        Assert.NotNull(LastNameUi);
        Assert.NotNull(EmailUi);
        Assert.NotNull(PhoneUi);

        Assert.NotNull(BirthDateUi);
        Assert.NotNull(RolUi);
        Assert.NotNull(AdressUi);
        Assert.NotNull(SeniorityUi);
        Assert.NotNull(JoinDateUi);


        Assert.NotNull(JoinDateUi[0]);
        Assert.NotNull(JoinDateUi[1]);
        Assert.NotNull(JoinDateUi[2]);

        Assert.NotNull(BirthDateUi[0]);
        Assert.NotNull(BirthDateUi[1]);
        Assert.NotNull(BirthDateUi[2]);


        CIUi.text = "2435123";
        NameUi.text = "Pepe";
        LastNameUi.text = "Juancho";
        EmailUi.text = "PepeJuancho@yahoo.com";
        AdressUi.text = "DiegoRodriguez S/N";
        PhoneUi.text = "098435667";
        RolUi.value = 2;
        SeniorityUi.value = 2;
        BirthDateUi[0].text = "02";
        BirthDateUi[1].text = "04";
        BirthDateUi[2].text = "1985";
        JoinDateUi[0].text = "06";
        JoinDateUi[1].text = "06";
        JoinDateUi[2].text = "2019";

        var button_Modification = GameObject.Find("Modification_Button").GetComponent<Button>();

        button_Modification.onClick.Invoke();

        var button_Confirm = GameObject.Find("Yes_Buttom").GetComponent<Button>();



        button_Confirm.onClick.Invoke();

        Assert.AreEqual(expected: "2435123", actual: CIUi.text);
        Assert.AreEqual(expected: "Pepe", actual: NameUi.text);
        Assert.AreEqual(expected: "Juancho", actual: LastNameUi.text);
        Assert.AreEqual(expected: "PepeJuancho@yahoo.com", actual: EmailUi.text);
        Assert.AreEqual(expected: "098435667", actual: PhoneUi.text);
        Assert.AreEqual(expected: 2, actual: RolUi.value);
        Assert.AreEqual(expected: 2, actual: SeniorityUi.value);
        Assert.AreEqual(expected: "DiegoRodriguez S/N", actual: AdressUi.text);
        Assert.AreEqual(expected: "02", actual: BirthDateUi[0].text);
        Assert.AreEqual(expected: "04", actual: BirthDateUi[1].text);
        Assert.AreEqual(expected: "1985", actual: BirthDateUi[2].text);
        Assert.AreEqual(expected: "06", actual: JoinDateUi[0].text);
        Assert.AreEqual(expected: "06", actual: JoinDateUi[1].text);
        Assert.AreEqual(expected: "2019", actual: JoinDateUi[2].text);
    }

    [UnityTest, Order(3)]
    public IEnumerator ValueWrite_incrementEmployee_WorkflowTestingWithEnumeratorPasses()
    {
        EditorSceneManager.LoadScene(3);

        yield return new WaitForSeconds(4f);

        var IncrementUi = GameObject.Find("Input_Increment").GetComponent<TMP_InputField>();

        var RolUi = GameObject.Find("RolDropdown").GetComponent<TMP_Dropdown>();
        var SeniorityUi = GameObject.Find("SeniorityDropdown").GetComponent<TMP_Dropdown>();



        IncrementUi.text = "20";
        RolUi.value = 2;
       SeniorityUi.value = 2;

        var Button_Agregar = GameObject.Find("Agregar_Button").GetComponent<UnityEngine.UI.Button>();
        Button_Agregar.onClick.Invoke();


        var button_Confirm = GameObject.Find("Yes_Buttom").GetComponent<UnityEngine.UI.Button>();
        button_Confirm.onClick.Invoke();

    }
    [UnityTest, Order(4)]
    public IEnumerator ValueWrite_RemoveEmployee_WorkflowTestingWithEnumeratorPasses()
    {

        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        EditorSceneManager.LoadScene(4);
        yield return new WaitForSeconds(4f);

        //Arrange


        var SearchUi = GameObject.Find("InputField_Search").GetComponent<TMP_InputField>();
        var Button_Search = GameObject.Find("Search_Button").GetComponent<UnityEngine.UI.Button>();

        SearchUi.text = (Principal.Inst.GetId() - 1).ToString();
        Button_Search.onClick.Invoke();

        var buttonContainer = GameObject.Find("employeersContainer").transform;
        var EmployeeButton = buttonContainer.GetComponentsInChildren<UnityEngine.UI.Button>();

        Button Button_EmployeeSelected;

        foreach (var choice in EmployeeButton)
        {
            Button_EmployeeSelected = choice;
            Button_EmployeeSelected.onClick.Invoke();
        }


        var button_Confirm = GameObject.Find("Yes_Buttom").GetComponent<UnityEngine.UI.Button>();
        button_Confirm.onClick.Invoke();

     
    }
}




