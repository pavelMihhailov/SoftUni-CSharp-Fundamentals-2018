using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Smartphone : ICallPhones, IBrowseWeb
{
    private List<string> phoneList = new List<string>();

    private List<string> siteList = new List<string>();

    public List<string> PhoneList
    {
        get => this.phoneList;
        private set => this.phoneList = value;
    }

    public List<string> SiteList
    {
        get => this.siteList;
        private set => this.siteList = value;
    }

    public void ReadAndAddPhones(string phones)
    {
        string[] args = phones.Split().ToArray();
        foreach (var number in args)
        {
            if (number.Any(x => !Char.IsDigit(x))) phoneList.Add("false");
            else phoneList.Add(number);
        }
    }

    public void ReadAndAddSites(string sites)
    {
        string[] args = sites.Split().ToArray();
        foreach (var site in args)
        {
            if (site.Any(x => Char.IsDigit(x))) siteList.Add("false");
            else siteList.Add(site);
        }
    }
    public override string ToString()
    {
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < phoneList.Count; i++)
        {
            if (phoneList[i] == "false") result.AppendLine("Invalid number!");
            else result.AppendLine($"Calling... {phoneList[i]}");
        }

        for (int i = 0; i < siteList.Count; i++)
        {
            if (siteList[i] == "false")
            {
                if (i == siteList.Count - 1) result.Append("Invalid URL!");
                else result.AppendLine("Invalid URL!");
            }
            else if (i != siteList.Count - 1) result.AppendLine($"Browsing: {siteList[i]}!");
            else result.Append($"Browsing: {siteList[i]}!");
        }
        return result.ToString();
    }
}