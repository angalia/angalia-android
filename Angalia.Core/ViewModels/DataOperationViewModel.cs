using System;
using System.Collections.Generic;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Data.SQLite;
using Intersoft.Crosslight.Input;
using Intersoft.Crosslight.Mobile;
using Intersoft.Crosslight.ViewModels;

namespace Angalia.Core.ViewModels
{
    public class DataOperationViewModel : ViewModelBase
    {
        private string dbName;
        private readonly IActivatorService _activatorService;
        private readonly ILocalStorageService _storageService;
        private readonly dynamic _factory;
        private ISQLiteAsyncConnection _db;
        public DataOperationViewModel()
        {

            dbName = "Angalia.db3";
            ILocalStorageService storageService = ServiceProvider.GetService<ILocalStorageService>();
            IActivatorService activatorService = ServiceProvider.GetService<IActivatorService>();
            var factory = activatorService.CreateInstance<Func<string, ISQLiteAsyncConnection>>();
            Db = factory(storageService.GetFilePath(dbName, LocalFolderKind.Data));
        }

        



        #region Properties        
        public DelegateCommand SavePathCommand { get; set; }

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

        

        public async void SaveItem(object obj)
        {
            await Db.InsertAsync(obj);
            ToastPresenter.Show("Item saved");
        }

        public async void SaveItems(List<object> obj)
        {
            await Db.InsertAllAsync(obj);
            ToastPresenter.Show("Items saved");
        }

        public async void UpdateItem(object obj)
        {
            await Db.UpdateAsync(obj);
            ToastPresenter.Show("Item updated");
        }

        public async void UpdateItems(List<object> obj)
        {
            await Db.UpdateAllAsync(obj);
            ToastPresenter.Show("Items updated");
        }
        #endregion
    }
}