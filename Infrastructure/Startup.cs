using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nop.Core.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace Nop.Plugin.Misc.PersianCalendar.Infrastructure
{
    internal class Startup : INopStartup
    {
        public int Order => int.MaxValue;

        public void Configure(IApplicationBuilder application)
        {
        }

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMvc().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.Converters.Add(new DateTimeJsonConverter());
            });

            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.ViewLocationExpanders.Add(new ViewLocationExpander());
            });
        }
    }
    public class ViewLocationExpander : IViewLocationExpander
    {
        public void PopulateValues(ViewLocationExpanderContext context)
        {
        }
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            if (context.AreaName == "Admin" &&
                context.ViewName == "EditorTemplates/DateNullable" ||
                context.ViewName == "EditorTemplates/Date" ||
                context.ViewName == "EditorTemplates/DateTime" ||
                context.ViewName == "EditorTemplates/DateTimeNullable")
            {
                viewLocations = new string[] { $"{DefaultPlugin.ViewsPath}{{0}}{RazorViewEngine.ViewExtension} "
                }.Concat(viewLocations);
            }
            return viewLocations;
        }
    }
}
