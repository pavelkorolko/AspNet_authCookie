using Classwork_16._02._24_auth_authorization__2.Models;
using Classwork_16._02._24_auth_authorization__2.Repositories;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace Classwork_12._01._24_cookies_sessions_.Helpers
{
    public class ArticleListTagHelper : TagHelper
    {
        private UserRepository userRepository { get; set; }
        public IEnumerable<Article>? Articles { get; set; }

        public ArticleListTagHelper(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "table";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.SetAttribute("class", "table table-hover");
            output.Content.SetHtmlContent(this.BuildUserListHtml());
        }

        private string BuildUserListHtml()
        {
            if(Articles is null)
            {
                return new String("There are no available data!");
            }
            
            
            StringBuilder str = new StringBuilder();

            str.AppendLine("""
                    <thead>
                        <tr>
                            <th scope="col">Title</th>
                            <th scope="col">Heading</th>
                            <th scope="col">Name</th>
                        </tr>
                    </thead>
                """);

            str.AppendLine("<tbody>");
            foreach (var article in Articles)
            {
                str.AppendLine($"""
                            <tr onclick="toggleDropdown(this)">
                                <td>
                                    {article.Title}
                                </td>
                                <td>
                                    {article.GetHeading()}
                                </td>
                                <td>
                                    {userRepository.GetUserById(article.UserId).Name}
                                </td>
                            </tr>
                            <tr class="dropdown-content">
                                <td colspan="3" class="bordered-div">
                                    Content:<br>
                                    {article.Content}
                                </td>
                            </tr>
                    """);

            }

            str.AppendLine("</tbody>");

            return str.ToString();
        }
    }
}
