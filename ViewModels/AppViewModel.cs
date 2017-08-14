using System.ComponentModel;

namespace Histogram_MVVM.ViewModels
{
    public class AppViewModel : INotifyPropertyChanged
    {

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
        public string filepath = null;
        ImageDisplayViewModel _imageDisplayVM = null;
        HistoGroupViewModel _histoGroupVM = null;

        public ImageDisplayViewModel ImageDisplayVM => _imageDisplayVM;
        public HistoGroupViewModel HistoGroupVM => _histoGroupVM;

        public AppViewModel()
        {
            _imageDisplayVM = new ImageDisplayViewModel(MyAction);
            _histoGroupVM = new HistoGroupViewModel();
            
        }


        private void MyAction()
        {
            if (_histoGroupVM != null)
            {
                filepath = _imageDisplayVM.SetSourceImage();
                _histoGroupVM.CountPixelstoArrays(filepath);
            }
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