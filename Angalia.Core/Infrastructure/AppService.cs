using System;
using Angalia.Core.Models;
using Angalia.Core.ModelServices;
using Angalia.Core.Services;
using Angalia.Core.ViewModels;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Containers;
using Intersoft.Crosslight.Data.SQLite;
using Intersoft.Crosslight.Mobile;

namespace Angalia.Core.Infrastructure
{
    public sealed class CrosslightAppAppService : ApplicationServiceBase
    {
        #region Constructors

        public CrosslightAppAppService(IApplicationContext context)
            : base(context)
        {
            dbName = MessageFactory.DatabaseName.Value;
            
            Container.Current.Register<IMedicalPlaceRepository, MedicalPlaceRepository>().WithLifetimeManager(new ContainerLifetime());
            Container.Current.Register<IMedicalPlaceTypeRepository, MedicalPlaceTypeRepository>().WithLifetimeManager(new ContainerLifetime());
        }

        #endregion

        private string dbName;


        #region Methods

        protected override async void OnStart(StartParameter parameter)
        {
            base.OnStart(parameter);

            var storageService = ServiceProvider.GetService<ILocalStorageService>();
            var activatorService = ServiceProvider.GetService<IActivatorService>();
            var factory = activatorService.CreateInstance<Func<string, ISQLiteConnection>>();
            var db = factory(storageService.GetFilePath(dbName, LocalFolderKind.Data));
            if (!IsTableExist(nameof(Settings)))
            {
                db.CreateTable<Settings>();
                db.Insert(new Settings { Id = 1, HospitalNearbyRadius = 1000, PharmacyNearbyRadius = 1000 });
            }
            if (!IsTableExist(nameof(Hospital)))
            {
                db.CreateTable<Hospital>();
                
            }
            if (!IsTableExist(nameof(Pharmacy)))
            {
                db.CreateTable<Pharmacy>();

            }

            // Set the root ViewModel to be displayed at startup
            this.SetRootViewModel<DrawerViewModel>();
        }

        private bool IsTableExist(string table)
        {
            var storageService = ServiceProvider.GetService<ILocalStorageService>();
            var activatorService = ServiceProvider.GetService<IActivatorService>();
            var factory = activatorService.CreateInstance<Func<string, ISQLiteConnection>>();
            var db = factory(storageService.GetFilePath(dbName, LocalFolderKind.Data));

            if (table.Equals(nameof(Settings)))
            {
                return db.TableExists<Settings>();
            }
            if (table.Equals(nameof(Hospital)))
            {
                return db.TableExists<Hospital>();
            }
            if (table.Equals(nameof(Pharmacy)))
            {
                return db.TableExists<Pharmacy>();
            }
            return false;
        }
        #endregion
    }
}