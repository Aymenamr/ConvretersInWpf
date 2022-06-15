using ConvertersSample.MainApplication.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConvertersSample.MainApplication.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Constructor
        public MainViewModel()
        {
           SelectedSize = TextSize.Small;
           SelectedSafety = Safety.Safe;
        }
        #endregion

        #region Safety  Combo
        public List<Safety> SafetyList
        {
            get
            {
                return Enum.GetValues(typeof(Safety)).Cast<Safety>().ToList();
            }
        }

        private Safety _selectedSafety;
        public Safety SelectedSafety
        {
            get { return _selectedSafety; }
            set
            {
                _selectedSafety = value;
                NotifyPropertyChanged("SelectedSafety");
            }
        }
        #endregion

        #region Text Content
        private string _textContent;
        public string TextContent 
        { 
            get { return _textContent; }
            set 
            {
                _textContent = value; 
                NotifyPropertyChanged("TextContent"); 
            }
        }
        private void UpdateText()
        {
            switch (SelectedSize)
            {
                case TextSize.Small:
                    TextContent = "I'm Small";
                    break;
                case TextSize.Medium:
                    TextContent = "I'm Medium";
                    break;
                case TextSize.Big:
                    TextContent = "I'm Big";
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Text Size
        public List<TextSize> TextSizeList
        {
            get
            {
                return Enum.GetValues(typeof(TextSize)).Cast<TextSize>().ToList();
            }
        }
        private TextSize _selectedTextSize;
        public TextSize SelectedSize {
            get { return _selectedTextSize; }
            set 
            {
                _selectedTextSize = value;
                NotifyPropertyChanged("SelectedSize");
                UpdateText();
            }
        }
        #endregion

        #region Visibility
        private bool _isVisibleChecked;
        public bool IsVisibleChecked 
        { 
            get { return _isVisibleChecked; } 
            set
            {
                _isVisibleChecked = value;
                NotifyPropertyChanged("IsVisibleChecked");
            }        
        }
        #endregion

        #region Property Changed

        public event PropertyChangedEventHandler? PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    #endregion
}

