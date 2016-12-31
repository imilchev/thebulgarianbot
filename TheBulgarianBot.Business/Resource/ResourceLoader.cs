namespace TheBulgarianBot.Business.Resource
{
    using System.IO;
    using System.Reflection;

    /// <summary>
    /// A class responsible for loading resources.
    /// </summary>
    internal static class ResourceLoader
    {
        /// <summary>
        /// The current assembly's name.
        /// </summary>
        private const string assemblyName = "TheBulgarianBot.Business";

        /// <summary>
        /// Gets the specified resource from the assembly manifest.
        /// </summary>
        /// <param name="resource">The name of the resource to be loaded.</param>
        /// <returns>A stream containing the resource.</returns>
        public static Stream LoadResource(string resource)
        {
            var assembly = Assembly.Load(new AssemblyName(ResourceLoader.assemblyName));
            var resourceName = $"{ResourceLoader.assemblyName}.{resource}";

            return assembly.GetManifestResourceStream(resourceName);
        }
    }
}
