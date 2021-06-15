using System;
using System.Reflection;
using System.Runtime.Loader;

namespace MoresandTech.Api
{
    class PluginHandler : AssemblyLoadContext
    {
      private AssemblyDependencyResolver resolver;

      public PluginHandler(string pluginPath)
      {
        resolver = new AssemblyDependencyResolver(pluginPath);
      }

      protected override Assembly Load(AssemblyName assemblyName)
      {
        string assemblyPath = resolver.ResolveAssemblyToPath(assemblyName);
        if (assemblyPath != null)
        {
          return LoadFromAssemblyPath(assemblyPath);
        }

        return null;
      }

      protected override IntPtr LoadUnmanagedDll(string unmanagedDllName)
      {
        string libraryPath = resolver.ResolveUnmanagedDllToPath(unmanagedDllName);
        if (libraryPath != null)
        {
          return LoadUnmanagedDllFromPath(libraryPath);
        }

        return IntPtr.Zero;
      }
    }
}
