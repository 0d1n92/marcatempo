using api.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace api.DTOs
{
    public class UserActions
    {
        public int Index { get; set; }
        public DateTime Date { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public List<Model.Entity.Action> Actions { get; set; }
        public string Total { get; set; } 

        public UserActions (DateTime Date, string FirstName, string LastName, List<Model.Entity.Action> Actions, string UserName)
        {
            this.Date = Date;
            this.LastName = LastName;
            this.FirstName = FirstName;
            this.Actions = Actions;
            this.UserName = UserName;
            this.Total = (Actions != null || Actions.Count() > 0)? this.TotalCalcolate(Actions) : "0:00";
        }

        private string TotalCalcolate(List<Model.Entity.Action> act)
        {
            var sumsHoursAct = act.Where(x => x.Exit != null).Select(x => $"{(x.Exit.Value - x.Entry.Value).Hours}:{(x.Exit.Value - x.Entry.Value).Minutes}");
            var sumsHoursActParse = sumsHoursAct.Select(ta => TimeSpan.Parse(ta));
            var tot = new TimeSpan();
            foreach(var s in sumsHoursActParse)
            {
                tot += s;
            }
            return $"{tot.Hours}:{tot.Minutes.ToString("00")}";
        }
    }
}
