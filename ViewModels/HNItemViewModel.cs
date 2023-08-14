using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HNTest.Models;
using Prism.Mvvm;

namespace HNTest.ViewModels
{
    public class HNItemViewModel : BindableBase
    {
        private double _id;
        private string _title;
        private string _postedBy;
        private string _url;
        private int _score;
        private double _time;
        private DateTime _timeDateTime;

        public HNItemViewModel(HNItem item)
        {
            Id = item.Id;
            Title = item.Title;
            PostedBy = item.By;
            Score = item.Score;
            Time = item.Time;
            Url = item.Url;
            TimeDateTime = UnixTimeStampToDateTime(item.Time);
        }

        private DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }

        public double Id
        {
            get => _id;
            set { SetProperty(ref _id, value); }
        }

        public string Title
        {
            get => _title;
            set { SetProperty(ref _title, value); }
        }

        public string PostedBy
        {
            get => _postedBy;
            set { SetProperty(ref _postedBy, value); }
        }

        public string Url
        {
            get => _url;
            set { SetProperty(ref _url, value); }
        }

        public double Time
        {
            get => _time;
            set { SetProperty(ref _time, value); }
        }

        public DateTime TimeDateTime
        {
            get => _timeDateTime;
            set { SetProperty(ref _timeDateTime, value); }
        }

        
        public int Score
        {
            get => _score;
            set { SetProperty(ref _score, value); }
        }
    }
}
