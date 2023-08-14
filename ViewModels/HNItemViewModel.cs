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

        public HNItemViewModel(HNItem item)
        {
            Id = item.Id;
            Title = item.Title;
            PostedBy = item.By;
            Score = item.Score;
            Time = item.Time;
            Url = item.Url;

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

        public int Score
        {
            get => _score;
            set { SetProperty(ref _score, value); }
        }
    }
}
