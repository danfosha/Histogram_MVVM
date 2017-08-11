using System.ComponentModel;

namespace Histogram_MVVM.ViewModels
{
    public class AppViewModel : INotifyPropertyChanged
    {

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        ImageDisplayViewModel _imageDisplayVM = null;
        HistoGroupViewModel _histoGroupVM = null;

        public ImageDisplayViewModel ImageDisplayVM => _imageDisplayVM;
        public HistoGroupViewModel HistoGroupVM => _histoGroupVM;

        public AppViewModel()
        {
            _imageDisplayVM = new ImageDisplayViewModel();
            _histoGroupVM = new HistoGroupViewModel();
            //_histoGroupVM.ImageName = "C:\\Users\\dani9096\\Pictures\\peak.jpg";
            GetImagePath();

        }

        void GetImagePath() //= "C:\\Users\\dani9096\\Pictures\\peak.jpg"
        {
            string filepath = _imageDisplayVM.SetSourceImage();
            _histoGroupVM.CountPixelstoArrays(filepath);
        }


    /// <summary>
    /// Raises the property changed event.
    /// </summary>
    /// <param name="propertyName">Name of the property.</param>
    private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}