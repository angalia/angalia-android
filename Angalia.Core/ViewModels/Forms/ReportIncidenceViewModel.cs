using System;
using System.Text;
using Angalia.Core.Models;
using Angalia.Core.Services;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Data.SQLite;
using Intersoft.Crosslight.Input;
using Intersoft.Crosslight.Mobile;
using Intersoft.Crosslight.RestClient;
using Intersoft.Crosslight.ViewModels;
using Newtonsoft.Json;

namespace Angalia.Core.ViewModels.Forms
{
    public class ReportIncidenceViewModel : EditorViewModelBase<ReportIncidence>
    {
        public ReportIncidenceViewModel()
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

        private bool result;
        private bool _isConnectionChangesRegistered;


        #region Properties

        /// <summary>
        /// Gets the type of the form metadata associated to the editor.
        /// </summary>
        /// <value>
        /// The type of the form metadata.
        /// </value>
        public override Type FormMetadataType
        {
            get { return typeof(ReportIncidenceMetaData); }
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

        public override async void Navigated(NavigatedParameter parameter)
        {
            if (true)
            {
                MessagePresenter.Show("By Clicking on I AGREE, you admit to the fact that Angalia will not be held responsible for any wrong or incorrect information", "ACCEPT TERMS?", new[] { "I AGREE", "CANCEL" }, selection =>
                {
                    if (selection != 0) //Yes
                    {
                        NavigationService.Close();
                        MessagePresenter.Show("You cancelled the report");
                    }
                    
                });
            }
            base.Navigated(parameter);
            //TODO: Implement Disclaimer notification
            
        }

        protected override void ExecuteSave(object parameter)
        {
            Validate();

            if (!HasErrors)
            {
                var trx = new StringBuilder();
                trx.Append($"Heading: {Item.Heading}\n".ToUpper());
                trx.Append($"Description: {Item.Description}\n".ToUpper());
                trx.Append($"Name: {Item.Name}\n".ToUpper());
                
                MessagePresenter.Show(trx.ToString(), "CONFIRM DETAILS?", new[] { "YES", "NO" }, async selection =>
                {
                    if (selection == 0) //Yes
                    {
                        this.ActivityPresenter.Show("Saving..", ActivityStyle.SmallIndicatorWithText, true);
                        IRestClient client = new RestClient("http://api.angaliagh.com/hooks/angalia/apps/v1/towncrier/");
                        var request = new RestRequest("report.json", HttpMethod.POST) { RequestFormat = RequestDataFormat.Json };
                        request.AddBody(new ReportIncidenceRequestModel { heading = Item.Heading, message = Item.Description, commenter = Item.Name });
                        var response = await client.ExecuteAsync(request);
                        var r = JsonConvert.DeserializeObject<CommentResponse>(response.Content);

                        if (r.Status)
                        {
                            MessagePresenter.Show(r.Message);
                            this.NavigationService.Navigate<ReportIncidenceViewModel>();
                        }
                        else
                        {
                            MessagePresenter.Show(r.Message);
                        }
                    }
                    else
                    {
                        MessagePresenter.Show("You cancelled the report");
                    }
                });

                
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

    internal class ReportIncidenceRequestModel
    {
        public string commenter { get; set; }
        public string heading { get; set; }
        public string message { get; set; }
        //public string photo { get; set; }
    }
    public class CommentResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; }
    }
}
