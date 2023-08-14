using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;

namespace HNTest.Models
{
    public class HNItem
    {
        public double Id { get; set; } = 1;
        public int Descendants { get; set; }
        public string By { get; set; }

        public List<int> Kids { get; set; }

        public double Time { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public int Score { get; set; }

    }
}
