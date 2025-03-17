using Codice.CM.Common;
using UnityEngine;
/// <summary>
/// Father Ui Hierarchy
/// This class is the father of all the UI classes
/// </summary>
public abstract class FatherUi : MonoBehaviour
{

   

    protected virtual void NotificationError()
    {
        // Add your error notification logic here
    }
    protected virtual void NotificationSuccess()
    { 
        // Add your success notification logic here
    }

    public virtual void DesactiveMenu()
    {
        // Add your desactive menu logic here
    }
    public virtual void ActiveMenuData()
    {
        // Add your active menu logic here
    }


    public virtual void DesactiveMenuConfirme()
    {
        // Add your desactive menu logic here
    }

   
    public virtual void ActiveMenuConfirme()
    {
        
    }

     public virtual void DesactiveMenuQuit()
    {

    }

   
    public virtual void ActiveMenuQuit()
    {

    }
}
