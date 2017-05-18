using System;
using Angalia.Core.Models;
using Angalia.Core.Services;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Data.SQLite;
using Intersoft.Crosslight.Mobile;
using Intersoft.Crosslight.ViewModels;

namespace Angalia.Core.ViewModels.Forms
{
    public class SliderViewModel : EditorViewModelBase<Setting>
    {
        #region Constructors

        public SliderViewModel()
        {
            this.Title = "Settings";
            dbName = MessageFactory.DatabaseName.Value;
            ILocalStorageService storageService = ServiceProvider.GetService<ILocalStorageService>();
            IActivatorService activatorService = ServiceProvider.GetService<IActivatorService>();
            var factory = activatorService.CreateInstance<Func<string, ISQLiteAsyncConnection>>();
            Db = factory(storageService.GetFilePath(dbName, LocalFolderKind.Data));
        }

        #endregion

        #region Fields
        private string dbName;
        private ISQLiteAsyncConnection _db;
        #endregion

        #region Properties

        public override Type FormMetadataType
        {
            get { return typeof(SettingFormMetadata); }
        }

        protected ISQLiteAsyncConnection Db
        {
            get { return _db; }
            set
            {
                if (_db != value)
                {
                    _db = value;
                    OnPropertyChanged("Db");
                }
            }
        }
        #endregion

        #region Methods

        public override async void Navigated(NavigatedParameter parameter)
        {
            if (IsTableExist("Settings"))
            {
                //var rr = await Db.Table<Settings>().FirstOrDefaultAsync();
                //this.Item = (Settings)rr;

                base.Navigated(parameter);
                var s = new Setting
                {
                    HospitalRadiusValue = 300,
                    PharmacyRadiusValue = 400,
                    HospitalRadius = 800,
                    PharmacyRadius = 700
                };
                this.Item = s;
            }
            else
            {
               
                base.Navigated(parameter);
                this.Item = new Setting();
            }       
        }

        protected override async void ExecuteSave(object parameter)
        {
            Validate();

            if (!HasErrors)
            {
                if (!IsTableExist(nameof(Settings)))
                {
                    await Db.CreateTableAsync<Settings>();
                    ToastPresenter.Show("Table Settings created");
                    await Db.InsertAsync(new Settings { Id = 1, HospitalNearbyRadius = Item.HospitalRadius, PharmacyNearbyRadius = Item.PharmacyRadius });
                    ToastPresenter.Show("Items saved");
                    MessagePresenter.Show("Your settings have been saved successfully");
                }
                else
                {
                    await Db.UpdateAsync(new Settings { Id = 1, HospitalNearbyRadius = Item.HospitalRadius, PharmacyNearbyRadius = Item.PharmacyRadius });
                    ToastPresenter.Show("Items updated");
                    MessagePresenter.Show("Your settings have been updated successfully");
                }
            }
            else
            {
                MessagePresenter.Show(ErrorMessage);
            }

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