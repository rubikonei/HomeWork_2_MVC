using System.Web.Mvc;

namespace SmartHouseMVC.Helpers
{
    public static class StateHelper
    {
        public static MvcHtmlString CreateState(this HtmlHelper html, bool state)
        {
            TagBuilder span = new TagBuilder("span");
            if (state == true)
            {
                span.InnerHtml = "Включен";
            }
            else
            {
                span.InnerHtml = "Выключен";
            }
            return new MvcHtmlString(span.ToString());
        }
    }
}