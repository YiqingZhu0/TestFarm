using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Authentication;
using System.Threading.Tasks;
using TestFarm.Models;

namespace TestFarm.Infrastructure.TagHelpers
{
    [HtmlTargetElement("select", Attributes = "model-for")]
    public class SelectOptionTagHelper : TagHelper
    {
        private ILstPlantTypeRepository _repo;

        public SelectOptionTagHelper(ILstPlantTypeRepository repo)
        {
            _repo = repo;
        }

        public ModelExpression ModelFor { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.AppendHtml((await output.GetChildContentAsync(false)).GetContent());

            string selected = ModelFor.Model as string;

            PropertyInfo property = typeof(Plant).GetTypeInfo().GetDeclaredProperty(ModelFor.Name);

            foreach (string type in _repo.GetPlantTypes().Select(t => property.GetValue(t)).Distinct())
            {
                if (selected != null && selected.Equals(type, StringComparison.OrdinalIgnoreCase))
                {
                    output.Content.AppendHtml($"<option selected>{type}</option>");
                }
                else
                {
                    output.Content.AppendHtml($"<option>{type}</option>");
                }
            }
            output.Attributes.SetAttribute("Id", ModelFor.Name);
            output.Attributes.SetAttribute("Name", ModelFor.Name);
        }
    }
}
