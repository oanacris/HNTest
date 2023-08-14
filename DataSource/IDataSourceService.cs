using HNTest.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HNTest.ViewModels;

namespace HNTest.DataSource
{
    public interface IDataSourceService
    {
        List<double> GetBestStories();
        Task<HNItem> GetHNById(string id);
    }
}
