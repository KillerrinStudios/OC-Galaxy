using OCTranspo_Net;
using OCTranspo_Net.Converters;
using OCTranspo_Net.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace OCGalaxy.ViewModels
{
    public class BusArrivalViewModel : OCViewModelBase
    {
        protected OCTranspoService _ocTranspo;

        #region Display Models
        private GetNextTripsForStopResultRoot _apiResult = null;
        public GetNextTripsForStopResultRoot ApiResult
        {
            get { return _apiResult; }
            set
            {
                _apiResult = value;
                RaisePropertyChanged(nameof(ApiResult));
            }
        }

        private RouteDirection _firstRoute = null;
        public RouteDirection FirstRoute
        {
            get { return _firstRoute; }
            set
            {
                _firstRoute = value;
                RaisePropertyChanged(nameof(FirstRoute));
            }
        }

        private Trip _firstTrip = null;
        public Trip FirstTrip
        {
            get { return _firstTrip; }
            set
            {
                _firstTrip = value;
                RaisePropertyChanged(nameof(FirstTrip));
            }
        }

        private DateTime _apiCallLastMade = DateTime.MinValue;
        public DateTime APICallLastMade
        {
            get { return _apiCallLastMade; }
            set
            {
                _apiCallLastMade = value;
                RaisePropertyChanged(nameof(APICallLastMade));
            }
        }

        private int _arrivalMinutes = 0;
        public int ArrivalMinutes
        {
            get { return _arrivalMinutes; }
            set
            {
                _arrivalMinutes = value;
                RaisePropertyChanged(nameof(ArrivalMinutes));
            }
        }

        private bool _isGPSData = false;
        public bool IsGPSData
        {
            get { return _isGPSData; }
            private set
            {
                _isGPSData = value;
                RaisePropertyChanged(nameof(IsGPSData));
            }
        }

        private bool _apiSearching = false;
        public bool APISearching
        {
            get { return _apiSearching; }
            private set
            {
                _apiSearching = value;
                RaisePropertyChanged(nameof(APISearching));
            }
        }
        #endregion

        #region API Models
        private string _stopNumber = "3037";
        public string StopNumber
        {
            get { return _stopNumber; }
            set
            {
                _stopNumber = value;
                RaisePropertyChanged(nameof(StopNumber));
            }
        }

        private string _routeNumber = "97";
        public string RouteNumber
        {
            get { return _routeNumber; }
            set
            {
                _routeNumber = value;
                RaisePropertyChanged(nameof(RouteNumber));
            }
        }
        #endregion

        public BusArrivalViewModel()
        {
            string appID = Secrets.AppID;
            string apiKey = Secrets.ApiKey;
            _ocTranspo = new OCTranspoService(appID, apiKey);

            _apiCallTimer.Elapsed += _apiCallTimer_Elapsed;
        }

        System.Timers.Timer _apiCallTimer = new System.Timers.Timer((OCTranspoService.GPS_UPDATE_EVERY_SECONDS + 1) * 1000);
        public void StartApiCall()
        {
            if (APISearching) { return; }
            _apiCallTimer.Start();
            APISearching = true;
            GetRouteInfo();
        }
        public void StopApiCall() { _apiCallTimer.Stop(); APISearching = false; }
        private void _apiCallTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e) { GetRouteInfo(); }

        public async void GetRouteInfo()
        {
            // If the Stop Number or Route Number hasn't been supplied, Stop the Timer and exit
            if (string.IsNullOrWhiteSpace(StopNumber) || string.IsNullOrWhiteSpace(RouteNumber))
            {
                StopApiCall();
                return;
            }

            // Rate Limit the API Call with the GPS Update Time
            //if (DateTime.Now <= APICallLastMade.AddSeconds(OCTranspoService.GPS_UPDATE_EVERY_SECONDS))
            //{
            //    UpdateArrivalMinutes();
            //    return;
            //}

            // Make the API Call
            var result = await _ocTranspo.GetNextTripsForStop(StopNumber, RouteNumber);
            if (result == null)
            {
                APICallLastMade = DateTime.Now;
                return;
            }

            // Check if there was an error in the API
            if (!string.IsNullOrWhiteSpace(result.GetNextTripsForStopResult.Error))
            {
                Debug.WriteLine(result.GetNextTripsForStopResult.Error);
                StopApiCall();
                return;
            }

            // Cache the API Call
            ApiResult = result;
            APICallLastMade = result.TimeOfResponse;

            // Update the Route & Trip  Information
            var route = result.GetNextTripsForStopResult.Route;
            if (route.RouteDirection.Count > 0) { FirstRoute = route.RouteDirection[0]; }
            if (FirstRoute.Trips.Trip.Count > 0)
            {
                FirstTrip = FirstRoute.Trips.Trip[0];
                switch (FirstTrip.TripSource)
                {
                    case OCTranspo_Net.Models.States.TripDataSource.GPS: IsGPSData = true; break;
                    case OCTranspo_Net.Models.States.TripDataSource.None:
                    case OCTranspo_Net.Models.States.TripDataSource.Schedule:
                    default:
                        IsGPSData = false;
                        break;
                }


                UpdateArrivalMinutes();
            }
        }

        protected void UpdateArrivalMinutes()
        {
            if (FirstTrip == null) return;

            DateTime processingTime = FirstRoute.GetRequestProcessingTime();
            TripTimeConverter converter = new TripTimeConverter(FirstTrip);
            int arrivalMinutes = converter.GetArrivalTimeMinutes(processingTime);
            ArrivalMinutes = arrivalMinutes;
        }
    }
}
