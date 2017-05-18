using System;
using Angalia.Core.Models;
using Angalia.Core.Services;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Data.SQLite;
using Intersoft.Crosslight.Input;
using Intersoft.Crosslight.Mobile;
using Intersoft.Crosslight.ViewModels;

namespace Angalia.Core.ViewModels
{
    public class DiseaseSurveillanceViewModel : EditorViewModelBase<DiseaseSurveillance>
    {
        public DiseaseSurveillanceViewModel()
        {
            this.SubmitCollectionCommand = new DelegateCommand(ExecuteSave);

            dbName = MessageFactory.DatabaseName.Value;

            ILocalStorageService storageService = ServiceProvider.GetService<ILocalStorageService>();
            IActivatorService activatorService = ServiceProvider.GetService<IActivatorService>();
            var factory = activatorService.CreateInstance<Func<string, ISQLiteAsyncConnection>>();

            this.Db = factory(storageService.GetFilePath(dbName, LocalFolderKind.Data));
        }

        private string dbName;
        private readonly IActivatorService _activatorService;
        private readonly ILocalStorageService _storageService;
        private readonly dynamic _factory;
        private ISQLiteAsyncConnection _db;

        private bool result = false;
        private bool _isConnectionChangesRegistered = false;


        #region Properties

        /// <summary>
        /// Gets the type of the form metadata associated to the editor.
        /// </summary>
        /// <value>
        /// The type of the form metadata.
        /// </value>
        public override Type FormMetadataType
        {
            get { return typeof(DiseaseSsurveillanceFormMetadata); }
        }

        public DelegateCommand SubmitCollectionCommand { get; set; }

        protected ISQLiteAsyncConnection Db
        {
            get { return _db; }
            set
            {
                if (_db != value)
                {
                    _db = value;
                    this.OnPropertyChanged("Db");
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Executes the save command.
        /// </summary>
        /// <param name="parameter">Parameter.</param>
        protected override async void ExecuteSave(object parameter)
        {
            Validate();

            if (!HasErrors)
            {

            }
            else
            {
                MessagePresenter.Show(ErrorMessage);
            }

        }


        /// <summary>
        /// Called when this instance is navigated.
        /// </summary>
        /// <param name="parameter">Parameter.</param>
        public override void Navigated(NavigatedParameter parameter)
        {
            base.Navigated(parameter);

            Item = new DiseaseSurveillance();
        }        

        private void ExecuteInvokeService(object parameter)
        {
            string serviceParameter = parameter.ToString();

            if (serviceParameter == "GetCurrentConnection")
            {
                result = this.MobileService.Reachability.IsSupported();

                if (result)
                {
                    NetworkConnectionStatus status = this.MobileService.Reachability.GetConnectionStatus();

                    if (status == NetworkConnectionStatus.NoConnection)
                        this.ToastPresenter.Show("Status: No network connection");
                    else if (status == NetworkConnectionStatus.WiFi)
                        this.ToastPresenter.Show("Status: Connected to WiFi");
                    else if (status == NetworkConnectionStatus.WWAN)
                        this.ToastPresenter.Show("Status: Connected to WWAN");
                    else if (status == NetworkConnectionStatus.WiFiAndWWAN)
                        this.ToastPresenter.Show("Status: Connected to both WiFi and WWAN");
                }
            }
            else if (serviceParameter == "GetReachability")
            {
                result = this.MobileService.Reachability.IsSupported();

                if (result)
                {
                    this.ActivityPresenter.Show("Checking...");
                    this.MobileService.Reachability.ShowNetworkActivityIndicator();

                    this.MobileService.Reachability.GetHostReachability("www.google.com", (reachabilityResult) =>
                    {
                        this.ActivityPresenter.Hide();
                        this.MobileService.Reachability.HideNetworkActivityIndicator();

                        this.ToastPresenter.Show("Reachable: " + reachabilityResult.IsReachable.ToString() + ", Via WWAN: " + reachabilityResult.IsReachableViaWWAN.ToString() + ", Via WiFI: " + reachabilityResult.IsReachableViaWiFi.ToString());
                    });
                }
            }
            else if (serviceParameter == "MonitorConnection")
            {
                result = this.MobileService.Reachability.IsSupported();

                if (result)
                {
                    if (!_isConnectionChangesRegistered)
                    {
                        this.MobileService.Reachability.StartMonitoringReachabilityChanges(this.OnReachabilityChanged);
                        _isConnectionChangesRegistered = true;
                    }

                    this.ToastPresenter.Show("Try to turn on/off the 3G (or the WiFi on your Mac if running on Simulator) to see this feature in action.");
                }
            }
            else if (serviceParameter == "ScheduleNotification")
            {
                result = this.MobileService.Notification.IsSupported();

                if (result)
                {
                    this.ToastPresenter.Show("A local notification is scheduled in the next 5 seconds.");

                    this.MobileService.Notification.ScheduleLocalNotification(new LocalNotification("Intersoft Crosslight", "Congratulations! You've successfully scheduled a local notification in your application", DateTime.Now.AddSeconds(5)));
                }
            }

            if (!result)
                this.ToastPresenter.Show("Location service is not supported in this device/simulator, or not enabled in the Settings.");
        }

        private void OnReachabilityChanged(object sender, ReachabilityEventArgs e)
        {
            if (!e.IsReachable)
                this.ToastPresenter.Show("No Internet connection");
            else if (e.IsReachableViaWiFi)
                this.ToastPresenter.Show("Connected to Internet through WiFi");
            else if (e.IsReachableViaWWAN)
                this.ToastPresenter.Show("Connected to Internet through WWAN");
        }

        #endregion
    }
}