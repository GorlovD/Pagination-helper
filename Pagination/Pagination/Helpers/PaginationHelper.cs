using System;
using System.Web;
using System.Text;
using System.Web.Mvc;
using System.Collections.Generic;


namespace Pagination.Helpers
{


    public class Phone
    {
        public int Id { get; set; }
        public string Fam { get; set; }
        public string Tel { get; set; }
    }


    public class PageInfo
    {

        public int PageNumber { get; set; } // номер текущей страницы  
        public int PageSize { get; set; } //  количество элементов на страницу

        public int Element { get; set; }//   количество элементов на указанной странице

        public int TotalItems { get; set; } //  количество элементов массива данных    
       
        public int TotalPages  //  количество доступных страниц
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / PageSize); }
        }
    }
    public class IndexViewModel
    {
        public IEnumerable<Phone> Phones { get; set; }
        public PageInfo PageInfo { get; set; }
    }


    public static class PaginationHelper
    {
        
        public static MvcHtmlString PageLinks(this HtmlHelper html,
            PageInfo pageInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();


            for (int i = 1; i <= pageInfo.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = (i-1).ToString();
                tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }

    }

}