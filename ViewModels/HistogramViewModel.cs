using System.ComponentModel;
using System.Linq;
using System.Windows.Media;

namespace Histogram_MVVM.ViewModels
{
    public class HistogramViewModel : INotifyPropertyChanged
    {
        string _color = string.Empty;
        private int[] _hist = new int[256];

        // Array _hist = null;

        public event PropertyChangedEventHandler PropertyChanged;

        public HistogramViewModel(string clr) { _color = clr; }

        public void SetHistogram(int[] hist) { _hist = hist; RenderedHistogram = Convert(hist); }


        PointCollection _renderedHistogram = null;
        public PointCollection RenderedHistogram
        { //get; set;
            get
            {
                return _renderedHistogram;
            }
            set
            {
                if (_renderedHistogram != value)
                {
                    _renderedHistogram = value;
                    if (this.PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("RenderedHistogram"));
                    }
                }
            }
        }

        // start paste
        #region Private Variables
        //private PointCollection _histogramPoints = null;
        #endregion

        #region Public Properties
        //public PointCollection HistogramPoints
        //{
        //    get
        //    {
        //        return _histogramPoints;
        //    }
        //    set
        //    {
        //        if (this.HistogramPoints != value)
        //        {
        //            this.HistogramPoints = value;
        //            if (this.PropertyChanged != null)
        //            {
        //                PropertyChanged(this, new PropertyChangedEventArgs("HistogramPoints"));
        //            }
        //        }
        //    }
        //}

        #endregion

        #region Private Methods


        // Converts Array to Point Collection
        private PointCollection Convert(int[] values)
        {
            int max = values.Max();

            PointCollection points = new PointCollection();
            // first point (lower-left corner)
            points.Add(new System.Windows.Point(0, max));
            // middle points
            for (int i = 0; i < values.Length; i++)
            {
                points.Add(new System.Windows.Point(i, max - values[i]));
            }
            // last point (lower right corner)
            points.Add(new System.Windows.Point(values.Length - 1, max));

            return points;

        }

        #endregion



    }
}
