using Classwork_16._02._24_auth_authorization__2.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace Classwork_16._02._24_auth_authorization__2.Helpers
{
    public class MyArticleListTagHelper:TagHelper
    {
        public List<Article>? Articles { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "table";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.SetAttribute("class", "table table-hover");
            output.Content.SetHtmlContent(this.BuildUserListHtml());
        }

        public string BuildUserListHtml()
        {
            int count = 0;
            StringBuilder tableContent = new StringBuilder();

            tableContent.AppendLine("<thead>");
            tableContent.AppendLine("<tr>");
            tableContent.AppendLine("<th>Id</th>");
            tableContent.AppendLine("<th>Title</th>");
            tableContent.AppendLine("<th>Content</th>");
            tableContent.AppendLine("<th>Action</th>");
            tableContent.AppendLine("</tr>");
            tableContent.AppendLine("</thead>");

            tableContent.AppendLine("<tbody>");

            foreach (var article in Articles)
            {
                tableContent.AppendLine($"<tr onclick='location.href=\"/home/article/{article.Id}\"' style='cursor:pointer;'>");
                tableContent.AppendLine($"<td>{++count}</td>");
                tableContent.AppendLine($"<td>{article.Title}</td>");
                tableContent.AppendLine($"<td>{article.Content}</td>");
                tableContent.AppendLine("<td>");
                tableContent.AppendLine($"<a class='btn btn-primary' onclick='showDeleteConfirmation({article.Id}, event)' role='button'>Delete</a>");
                tableContent.AppendLine("</td>");
                tableContent.AppendLine("</tr>");
            }

            return tableContent.ToString();
        }   
    }
}


