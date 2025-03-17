using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;


public class DateTimeCustom 
{
    // Start is called before the first frame update


    public string dd;
    public string mm;
    public string yyyy;
    public string Date;
    public DateTimeCustom(string dD, string mM, string yYYY)
    {
        this.dd = dD;
        this.mm = mM;
        this.yyyy = yYYY;
        Date = dd + "/" + mm + "/" + yyyy;
    }


    public string SetCustomDate(string DD, string MM, string YYYY)
    {
        if (checkDate(DD + "/" + MM + "/" + YYYY))
            if (DD.Length == 1)
                dd = "0" + DD;
            else
                dd = DD;

            if (MM.Length == 1)
                mm = "0" + MM;
            else
                mm = MM;

            yyyy = YYYY;

            if (checkDate())
                return Date = dd + "/" + mm + "/" + yyyy;
            else 
                return Date = "0/0/0";


    }

    public string SetCustomDate(string date)
    {
        string[] temp = date.Split('/');
        if (date != null)
            if (checkDate(date))
                if (temp.Length <= 2)
                    return Date = temp[1] + "/" + temp[0] + "/" + temp[2];

        return Date = "0/0/0";

    }


    public bool checkDate(string date)
    {
        string[] temp = date.Split('/');
        if (temp.Length <= 2)
            return false;
        if (temp[0].Length != 2 || temp[1].Length != 2 || temp[2].Length != 4)
            return false;
        if (int.Parse(temp[0]) > 12 || int.Parse(temp[1]) > 31)
            return false;
        return true;
    }

    public bool checkDate()
    {
        string[] temp = Date.Split('/');
        if (temp.Length <= 2)
            return false;
        if (temp[0].Length != 2 || temp[1].Length != 2 || temp[2].Length != 4)
            return false;
        if (int.Parse(temp[0]) > 12 || int.Parse(temp[1]) > 31)
            return false;
        return true;
    }

    public void SetToday()
    {
        Date = System.DateTime.Now.ToString("dd/MM/yyyy");
    }
    public  string GetDateNowToday()
    {
        return System.DateTime.Now.ToString("dd/MM/yyyy");
    }

    public DateTime GetDateTimeCustomConvertDateTime()
    {
       return new DateTime(int.Parse(dd), int.Parse(mm),int.Parse(yyyy));
    }

    public DateTime GetDateTimeConvertAmericanFormat()
    {
        return new DateTime(int.Parse(yyyy), int.Parse(mm), int.Parse(dd));
    }
    
    public string GetDate()
    {
        return Date;
    }

    public string GetDay()
    {
        return dd;
    }

    public string GetMonth()
    {
        return mm;
    }

    public string GetYear()
    {
        return yyyy;
    }

}
