using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace RPS.UI.ViewModels.Dashboard
{

    public class CategoricalData
    {
        public object Category { get; set; }
        public double Value { get; set; }
    }

    public class TemporalData
    {
        public DateTime Date { get; set; }
        public double Value { get; set; }
    }

    public partial class ChartViewModel : ObservableObject
    {

        public ChartViewModel()
        {
            this.Data = GetCategoricalData();
            //this.TemporalData = new ObservableCollection<TemporalData>();
            //this.OpenItemsData = GetTemporalData();
            this.OpenItemsData = new ObservableCollection<TemporalData>();
            this.ClosedItemsData = new ObservableCollection<TemporalData>();
        }

        public ObservableCollection<CategoricalData> Data { get; set; }

        public ObservableCollection<TemporalData> OpenItemsData { get; set; }
        public ObservableCollection<TemporalData> ClosedItemsData { get; set; }

        private static ObservableCollection<CategoricalData> GetCategoricalData()
        {
            var data = new ObservableCollection<CategoricalData>  {
                new CategoricalData { Category = "A", Value = 0.63 },
                new CategoricalData { Category = "B", Value = 0.85 },
                new CategoricalData { Category = "C", Value = 1.05 },
                new CategoricalData { Category = "D", Value = 0.96 },
                new CategoricalData { Category = "E", Value = 0.78 },
            };

            return data;
        }

        private static ObservableCollection<TemporalData> GetTemporalData()
        {
            var data = new ObservableCollection<TemporalData>  {
                new TemporalData { Date = new DateTime(2023, 1, 1), Value = 0.63 },
                new TemporalData { Date = new DateTime(2023, 2, 1), Value = 0.85 },
                new TemporalData { Date = new DateTime(2023, 3, 1), Value = 1.05 },
                new TemporalData { Date = new DateTime(2023, 4, 1), Value = 0.96 },
                new TemporalData { Date = new DateTime(2023, 5, 1), Value = 0.78 },
            };

            return data;
        }
    }
}
