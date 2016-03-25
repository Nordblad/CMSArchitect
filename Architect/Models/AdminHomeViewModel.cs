using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Architect.Models
{
    public class AdminHomeViewModel
    {
        public List<Template> Templates { get; set; }
        public List<Page> Pages { get; set; }
        public List<Content> Content { get; set; }
    }

    //public class EditTemplateViewModel
    //{
    //    public string TemplateHtml { get; set; }
    //    public List<CMSStyle> ElementStyles { get; set; }
    //}

    public class DesignTemplateViewModel
    {
        public string TemplateName { get; set; }
        public int TemplateId { get; set; }
        public string TemplateHtml { get; set; }
        public string CssUrl { get; set; }
        public SelectList PageSelectList { get; set; }
    }

    public class SaveTemplateViewModel
    {
        public string TemplateName { get; set; }
        public string TemplateHtml { get; set; }
        public Dictionary<string, Dictionary<string, string>> NewStyles { get; set; }
    }
    //public class CMSStyle
    //{
    //    public string ElementName { get; set; }
    //    public Dictionary<string, string> Styles { get; set; }
    //}

    public class EditPageViewModel
    {
        public Page Page { get; set; }
        public Template Template { get; set; }
        //public List<Content> PageContent { get; set; }
        public Dictionary<string, List<Content>> Content { get; set; }
    }
}