using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5Course.Models
{
    public enum IdeaType
    {
        弱爆了,
        還好,
        歐
    }

    public class IdeaVM
    {
        public int id { get; set; }
        public string Name { get; set; }
        public IdeaType IdeaType { get; set; }
    }
}