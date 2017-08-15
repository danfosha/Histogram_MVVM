namespace Histogram_MVVM.ViewModels
{
    public class AppViewModel 
    {
                
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
                
    }
}