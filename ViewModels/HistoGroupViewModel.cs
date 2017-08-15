using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace Histogram_MVVM.ViewModels
{
    public partial class HistoGroupViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        // set these eventually from user checkbox
        private HistogramViewModel _redHistogramVM, _greenHistogramVM, _blueHistogramVM, _lumHistogramVM;


        public HistogramViewModel RedHistogram => _redHistogramVM;
        public HistogramViewModel GreenHistogram => _greenHistogramVM;
        public HistogramViewModel BlueHistogram => _blueHistogramVM;
        public HistogramViewModel LumHistogram => _lumHistogramVM;
        // equivalent to
        // public HistogramViewModel LumHistogram {
        //      get
        //      {
        //          return _lvVM;
        //      }
        // }


        public HistoGroupViewModel()
        {
            _redHistogramVM = new HistogramViewModel("red");
            _greenHistogramVM = new HistogramViewModel("green");
            _blueHistogramVM = new HistogramViewModel("blue");
            _lumHistogramVM = new HistogramViewModel("lum");

        }

        public void CountPixelstoArrays(string ImageName)
        {

            Bitmap bmp = new Bitmap(ImageName);

            int[] red_collection = new int[256];
            int[] green_collection = new int[256];
            int[] blue_collection = new int[256];
            int[] lum_collection = new int[256];

            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    System.Drawing.Color pixel_color = bmp.GetPixel(j, i);

                    red_collection[pixel_color.R]++;
                    green_collection[pixel_color.G]++;
                    blue_collection[pixel_color.B]++;
                    //this may not be the correct formula - double check it
                    lum_collection[(int)Math.Sqrt(.241 * (pixel_color.R * pixel_color.R) + .691 * (pixel_color.G * pixel_color.G) + .068 * (pixel_color.B * pixel_color.B))]++;
                }
            }
            // parameterize this
            RedHistogram.SetHistogram(red_collection);
            GreenHistogram.SetHistogram(green_collection);
            BlueHistogram.SetHistogram(blue_collection);
            LumHistogram.SetHistogram(lum_collection);
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


        // Move me to HistoBoxDictionary?
        public  class SliderValueChangedSample
        {
         

            //private void ColorSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
            //{
            //    Color color = Color.FromRgb((byte)slColorR.Value, (byte)slColorG.Value, (byte)slColorB.Value);
            //    this.Background = new SolidColorBrush(color);
            //}
        }

    }
}

