using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;

public partial class Display : System.Web.UI.Page
{
    List<DateTime> dt = new List<DateTime>();
    List<string> name = new List<string>();
    List<float> price1 = new List<float>();
    List<float> price2 = new List<float>();
    List<float> avg5 = new List<float>();
    List<float> avg30 = new List<float>();
    int size = 0;
    int start = 0;
    int end = 0;
    bool IsPageRefresh;
    //public void avg5day();
    //C:\Users\Usama Jamil\Documents\Visual Studio 2013\WebSites\WebSite3\
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["postids"] = System.Guid.NewGuid().ToString();
            Session["postid"] = ViewState["postids"].ToString();
        }
        else
        {
            if (ViewState["postids"].ToString() != Session["postid"].ToString())
            {
                IsPageRefresh = true;
            }
            Session["postid"] = System.Guid.NewGuid().ToString();
            ViewState["postids"] = Session["postid"].ToString();
        }
        var Path = AppDomain.CurrentDomain.BaseDirectory + "data.csv";
        var reader = new StreamReader(File.OpenRead(@Path));
        bool first = true;
        string temp = "";
        DateTime tempDate;
        while (!reader.EndOfStream)
        {
            if (first)
            {
                reader.ReadLine();
                first = false;
            }
            var line = reader.ReadLine();
            var values = line.Split(',');

            temp = values[0];
            tempDate = DateTime.Parse(temp);
            dt.Add(tempDate.Date);
            name.Add(values[1]);
            price1.Add(float.Parse(values[2]));
            price2.Add(float.Parse(values[3]));
            size++;
        }
        reader.Close();
        avg5day();
        avg30day();
        start = 0;
        end = size;
    }
    public List<DateTime> getDate()
    {
        return dt;
    }
    public int getSize()
    {
        return size;
    }
    public List<string> getName()
    {
        return name;
    }
    public List<float> getPrice1()
    {
        return price1;
    }
    public List<float> getPrice2()
    {
        return price2;
    }
    public List<float> getavg5()
    {
        return avg5;
    }
    public List<float> getavg30()
    {
        return avg30;
    }
    public int getstart()
    {
        return start;
    }
    public int getend()
    {
        return end;
    }
    public void set()
    {
        start = 0;
        end = size;
    }
    public void avg5day()
    {
        int curr = 0;
        DateTime temp;
        int t = 0;
        float avg = 0;
        for (int i = 0; i < size; i++)
        {
            temp = dt[i].AddDays(-5);
            t = i - 1;
            curr = 1;
            avg = price2[i];
            if (t >= 0)
            {
                while (dt[t] > temp && t >= 0)
                {
                    curr++;
                    avg = avg + price2[t];
                    t--;
                    if (t < 0)
                        break;
                }
            }
            avg = avg / curr;
            avg5.Add(avg);
        }
    }
    public void avg30day()
    {
        int curr = 0;
        DateTime temp;
        int t = 0;
        float avg = 0;
        for (int i = 0; i < size; i++)
        {
            temp = dt[i].AddDays(-30);
            t = i - 1;
            curr = 1;
            avg = price2[i];
            if (t >= 0)
            {
                while (dt[t] > temp && t >= 0)
                {
                    curr++;
                    avg = avg + price2[t];
                    t--;
                    if (t < 0)
                        break;
                }
            }
            avg = avg / curr;
            avg30.Add(avg);
        }
    }
   
    protected void submit_Click1(object sender, EventArgs e)
    {
        if (!IsPageRefresh)
        {
            int day = day1.SelectedIndex + 1;
            int month = month1.SelectedIndex + 1;
            int year;
            try
            {
                year = int.Parse(year1.Text);
            }
            catch
            {
                year = 1996;
            }
            DateTime dt0 = new DateTime(year, month, day);
            day = day2.SelectedIndex + 1;
            month = month2.SelectedIndex + 1;
            try
            {
                year = int.Parse(year2.Text);
            }
            catch
            {
                year = 1996;
            }
            DateTime dt1 = new DateTime(year, month, day);
            for (int i = 0; i < size; i++)
            {
                if (dt0 == dt[i])
                {
                    start = i;
                    break;
                }
            }
            for (int i = start; i < size; i++)
            {
                if (dt1 == dt[i])
                {
                    end = i + 1;
                    break;
                }
            }
        }
    }
}