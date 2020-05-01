using RazorLight;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Email.Core.Parser
{
    public class RazorParserService : IDisposable
    {
        public void Dispose()
        {
        }

        public string Parse<T>(string template, T model)
        {
            return ParseAsync(template, model).GetAwaiter().GetResult();
        }

        private async Task<string> ParseAsync<T>(string template, T model)
        {
            // Get the current assembly and create the embedded Razor Engine
            
            Assembly assembly = Assembly.GetExecutingAssembly();
            RazorLightEngine engine = new RazorLightEngineBuilder()
                .UseEmbeddedResourcesProject(assembly, "Email.Core.Parser")
                .UseMemoryCachingProvider()
                .SetOperatingAssembly(assembly)
                .Build();

            // Could also use the complete path to generate the engine
            //RazorLightEngine engine = new RazorLightEngineBuilder()
            //    .UseFileSystemProject(@"C:\<<Exact path here>>\EmailSenderUsingRazorParser\Email.Core.Parser\Email.Core.Parser.csproj")
            //    .UseMemoryCachingProvider()
            //    .SetOperatingAssembly(assembly)
            //    .Build();

            
            //  Another way if we use the RazorLight 1.0.0 stable version
            //  Need to add this to csproj file and templates folder to the startup project as well
            //  <None Update="Templates\*.*">
            //  <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
            //  </None>
            //   RazorLightEngine engine = new RazorLightEngineBuilder()
            //    .UseFileSystemProject
            //    (Directory.GetCurrentDirectory()+@"\Templates\")
            //                 .UseMemoryCachingProvider()
            //    .SetOperatingAssembly(Assembly.GetExecutingAssembly())
            //     .Build();

           //return await engine.CompileRenderAsync(template+".cshtml", model);


            // Render the html using the model
            return await engine.CompileRenderAsync($"Templates.{template}.cshtml", model);
        }
    }
}

