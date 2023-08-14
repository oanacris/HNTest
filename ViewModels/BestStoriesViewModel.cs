using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using HNTest.Models;
using Prism.Mvvm;

namespace HNTest.ViewModels
{
    public class BestStoriesViewModel : BindableBase
    {
        private double _id;
        public BestStoriesViewModel(HN item)
        {
            Id = item.Id;

        }
        public double Id
        {
            get => _id;
            set { SetProperty(ref _id, value); }
        }
    }
}
