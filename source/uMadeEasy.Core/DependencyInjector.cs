using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;

namespace Lucrasoft.uMadeEasy.Core
{
    /// <summary>
    /// Represents the dependency injector for uMadeEasy
    /// </summary>
    public sealed class DependencyInjector : IDisposable
    {
        private IEnumerable<string> folders;
        private AggregateCatalog catalog;
        private CompositionContainer container;

        public DependencyInjector(IEnumerable<string> folders)
        {
            if (folders == null)
                throw new ArgumentNullException("folders");

            this.folders = folders;
            InitializeDependencyInjection();
        }

        /// <summary>
        /// Build the MEF containers.
        /// </summary>
        private void InitializeDependencyInjection()
        {
            catalog = new AggregateCatalog();

            foreach (var folder in folders.Where(Directory.Exists))
            {
                catalog.Catalogs.Add(new DirectoryCatalog(folder));
            }

            container = new CompositionContainer(catalog);
        }

        /// <summary>
        /// Returns a exported value from the internal MEF container
        /// </summary>
        /// <typeparam name="T">The type to retrieve</typeparam>
        /// <returns>An instance of the Type, or null if not found</returns>
        public T GetExportedValue<T>()
        {
            return container.GetExportedValueOrDefault<T>();
        }

        /// <summary>
        /// Returns a exported value from the internal MEF container
        /// </summary>
        /// <typeparam name="T">The type to retrieve</typeparam>
        /// <param name="contractName">The identifier the part was exported with</param>
        /// <returns>An instance of the Type, or null if not found</returns>
        public T GetExportedValue<T>(string contractName)
        {
            return container.GetExportedValueOrDefault<T>(contractName);
        }

        /// <summary>
        /// Returns a exported value from the internal MEF container
        /// </summary>
        /// <typeparam name="T">The type to retrieve</typeparam>
        /// <returns>An instance of the Type, or null if not found</returns>
        public IEnumerable<T> GetExportedValues<T>()
        {
            return container.GetExportedValues<T>();
        }

        /// <summary>
        /// Returns a exported value from the internal MEF container
        /// </summary>
        /// <typeparam name="T">The type to retrieve</typeparam>
        /// <param name="contractName">The identifier the parts were exported with</param>
        /// <returns>An instance of the Type, or null if not found</returns>
        public IEnumerable<T> GetExportedValues<T>(string contractName)
        {
            return container.GetExportedValues<T>(contractName);
        }

        /// <summary>
        /// Composes the classes and injects the correct imports
        /// </summary>
        /// <param name="composables">An array of classes to compose</param>
        public void Compose(params object[] composables)
        {
            container.ComposeParts(composables);
        }

        public void Dispose()
        {
            if (container != null)
                container.Dispose();

            if (catalog != null)
                catalog.Dispose();
        }
    }
}