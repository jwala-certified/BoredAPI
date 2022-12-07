using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace ActivityBoredAPI
{
    public partial class _Default : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                ddlPreference.Items.Add(new ListItem("Education", "education"));
                ddlPreference.Items.Add(new ListItem("Recreational", "recreational"));
                ddlPreference.Items.Add(new ListItem("Social", "social"));
                ddlPreference.Items.Add(new ListItem("DIY", "diy"));
                ddlPreference.Items.Add(new ListItem("Charity", "charity"));
                ddlPreference.Items.Add(new ListItem("Cooking", "cooking"));
                ddlPreference.Items.Add(new ListItem("Relaxation", "relaxation"));
                ddlPreference.Items.Add(new ListItem("Music", "music"));
                ddlPreference.Items.Add(new ListItem("Busywork", "busywork"));


            }
        }

        protected void btnGetActivity_Click(object sender, EventArgs e)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://www.boredapi.com/api/");
            
            var consumeapi = hc.GetAsync("activity?type=" + ddlPreference.SelectedValue.ToString());
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if(readdata.IsSuccessStatusCode)
            {
                var displayresults = readdata.Content.ReadAsStringAsync();
                Activity act = JsonConvert.DeserializeObject<Activity>(displayresults.Result);

                btn.InnerText = act.activity;
                lblType.InnerText = "Type : " + act.type;
                lblNP.InnerText = "Number of Participants : " + act.participants;
                lblRelPrice.InnerText = "Relative Price : " + act.price;
                if (string.IsNullOrEmpty(act.link) == false)
                    lblLink.InnerText = "Link : " + act.link;
                lblAccRating.InnerText = "Accessibility rating : " + act.accessibility;
            }

        }

    }

    public class Activity
    {
        public string activity { get; set; }
        public string type { get; set; }
        public string participants { get; set; }
        public string price { get; set; }
        public string link { get; set; }
        public string key { get; set; }
        public string accessibility { get; set; }
    }
}