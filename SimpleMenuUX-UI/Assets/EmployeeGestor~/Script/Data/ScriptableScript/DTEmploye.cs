using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New DTEmploye", menuName = "Employe/NewEmploye")]
public class DTEmploye : ScriptableObject
{
    public int ID;
    public int Ci;
    public string Name;
    public string Lastname;
    public string Email;
    public int Phone;
    public string Adress;
    public EEmploye.Roles Rol;
    public EEmploye.Seniority Senior;
    public DateTimeCustom JoinDate = new DateTimeCustom("1","1","2014");
    public DateTimeCustom BirthDate = new DateTimeCustom("4", "5", "1989");
    public float Salary;
    public bool ISActive;
    public void setCi(int ci)
    {
        Ci = ci;
    }

    public void setName(string name)
    {
        Name = name;
    }

    public void setLastname(string lastname)
    {
        Lastname = lastname;
    }

    public void setEmail(string email)
    {
        Email = email;
    }

    public void setPhone(int phone)
    {
        Phone = phone;
    }

    public void setAdress(string adress)
    {
        Adress = adress;
    }

    public void setRol(EEmploye.Roles rol)
    {
        Rol = rol;
    }

    public void setSenior(EEmploye.Seniority senior)
    {
        Senior = senior;
    }

    public void setJoinDate(DateTimeCustom joinDate)
    {
        JoinDate = joinDate;
    }

    public void setBirthDate(DateTimeCustom birthDate)
    {
        BirthDate = birthDate;
    }

    public void setSalary(float salary)
    {
        Salary = salary;
    }

    public void setID(int id)
    {
        ID = id;
    }

    public bool setIsActive(bool isActive)
    {
        return ISActive = isActive;
    }

    //Setters
    //Getters
   

    public int getID()
    {
        return ID;
    }
    public int getCi()
    {
        return Ci;
    }


    public DateTimeCustom getBirthDate()
    { 
        return BirthDate; 
    }

    public string getName()
    {
        return Name;
    }

    public string getLastname()
    {
        return Lastname;
    }

    public string getEmail()
    {
        return Email;
    }

    public DateTimeCustom  getJoinDate()
    {
        return JoinDate;
    }

    public int getPhone()
    {
        return Phone;
    }
    public string getAdress()
    {
        return Adress;
    }

    public EEmploye.Roles getRol()
    {
        return Rol;
    }

    public EEmploye.Seniority getSenior()
    {
        return Senior;
    }

    public float getSalary()
    {
        return Salary;
    }

    public bool getISActive()
    {
        return ISActive;
    }

    public string getAllData()
    {
        return ID + " " + Ci + " " + Name + " " + Lastname + " " + Email + " " + Phone + " " + Adress + " " + Rol + " " + Senior + " " + JoinDate.GetDate() + " " + BirthDate.GetDate() + " " + Salary + " " + ISActive;
    }


}
