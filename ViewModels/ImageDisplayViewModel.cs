using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Input;

namespace Histogram_MVVM.ViewModels
{
    public partial class ImageDisplayViewModel : INotifyPropertyChanged
    {

        // From AppViewModel.cs :
        //  _lhsVM = new LHSViewModel(OnSourceImagePathChange);
        //public ImageDisplayViewModel(Action<string> cb)
        //{
        // _cb = cb;
        // _cb?.Invoke("");
        //}


        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Private variables
        private readonly Action action;
        private String _imageName = null;
        #endregion


        #region Public Properties

        public ImageDisplayViewModel(Action action)
        {
            //_action = action;
            this.action = action;
        }

        public String ImageName
        {
            get
            {
                return _imageName;
            }
            set
            {
                if (_imageName != value)
                {
                    _imageName = value;
                    if (this.PropertyChanged != null)
                    {
                        RaisePropertyChanged("ImageName");

                    }
                }
            }
        }
        #endregion

        #region Methods

        public string SetSourceImage(string path = "")
        {
            string checkExtension = Path.GetExtension(path);
            if (string.IsNullOrEmpty(path) || (checkExtension != ".png" && checkExtension != ".jpeg" && checkExtension != ".jpg" && checkExtension != ".tif"))
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image files |*.png;*.jpeg;*.jpg;*.tif |All files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == true)
                {
                    ImageName = openFileDialog.FileName;

                }
            }
            else
            {
                Uri uri = new Uri(path);
                if (uri.IsFile)
                {
                    ImageName = System.IO.Path.GetFileName(uri.LocalPath);
                }

            }
            //return ImageName;
            return Path.GetFullPath(ImageName);

        }

        #endregion

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

        public bool PerformHistogramSmoothing { get; set; }

        public ICommand LoadImageCommand
        {
            get { return new MyICommand(LoadCommand); }
        }

        private void LoadCommand()
        {
            // clears image name, triggering property change back in AppViewmModel
            // change to data trigger?
            action.Invoke();
            //SetSourceImage();
        }


    }
}

