using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_Client.ReadListServiceNS;

namespace WPF_Client.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        private string _statusString;
        public string StatusString
        {
            get
            {
                return _statusString;
            }
            set
            {
                _statusString = value;
                OnPropertyChanged("StatusString");
            }
        }

        private ReadListContractClient _client;

        private ObservableCollection<ReadList> _readLists;
        public ObservableCollection<ReadList> ReadLists
        {
            get
            {
                if (_readLists == null)
                {
                    if (_client != null)
                        try
                        {
                            _readLists = new ObservableCollection<ReadList>(_client.GetAllReadLists());
                        }
                        catch { }
                    else
                    {
                        try
                        {
                            _client = new ReadListContractClient();
                            _readLists = new ObservableCollection<ReadList>(_client.GetAllReadLists());
                        }
                        catch { }
                    }
                }

                return _readLists;
            }
            set
            {
                _readLists = value;
                OnPropertyChanged("ReadLists");
            }
        }

        private ReadList _selectedReadList;
        public ReadList SelectedReadList
        {
            get { return _selectedReadList; }
            set
            {
                _selectedReadList = value;
                OnPropertyChanged("SelectedReadList");
            }

        }

        #region UpdateCommand

        RelayCommand _updateReadListCommand;
        public ICommand UpdateReadList
        {
            get
            {
                if (_updateReadListCommand == null)
                    _updateReadListCommand = new RelayCommand(ExecuteUpdateReadListCommand, CanExecuteUpdateReadListCommand);
                return _updateReadListCommand;
            }
        }

        public void ExecuteUpdateReadListCommand(object parameter)
        {
            ReadList selectedItem = parameter as ReadList;
            if (selectedItem != null)
            {
                try
                {
                    StatusString = _client.UpdateReadList(selectedItem);
                }
                catch (Exception e)
                {
                    StatusString = "Оновлення не вдалося!";
                }
                ReadLists = null;
            }
        }

        public bool CanExecuteUpdateReadListCommand(object parameter)
        {
            ReadList selectedItem = parameter as ReadList;
            if (selectedItem != null)
            {
                if (string.IsNullOrWhiteSpace(selectedItem.AuthorName) ||
                    string.IsNullOrWhiteSpace(selectedItem.BookTitle) ||
                    selectedItem.ReadingDate > DateTime.Now ||
                    selectedItem.Page <= 0 ||
                    selectedItem.Rating <= 0 || selectedItem.Rating > 5)
                {
                    return false;
                }

                return true;
            }

            return false;
        }

        #endregion

        #region DeleteCommand

        RelayCommand _deleteReadListCommand;
        public ICommand DeleteReadList
        {
            get
            {
                if (_deleteReadListCommand == null)
                    _deleteReadListCommand = new RelayCommand(ExecuteDeleteReadListCommand, CanExecuteDeleteReadListCommand);
                return _deleteReadListCommand;
            }
        }

        public void ExecuteDeleteReadListCommand(object parameter)
        {
            ReadList selectedItem = parameter as ReadList;
            if (selectedItem != null)
            {
                try
                {
                    StatusString = _client.DeleteById(selectedItem.Id);
                    selectedItem = _readLists.FirstOrDefault(find => find.Id == selectedItem.Id);
                    if(selectedItem != null)
                        _readLists.Remove(selectedItem);
                }
                catch (Exception e)
                {
                    ReadLists = null;
                    StatusString = "Видалення не вдалося!";
                }
            }
        }

        public bool CanExecuteDeleteReadListCommand(object parameter)
        {
            ReadList selectedItem = parameter as ReadList;
            if (selectedItem != null)
            {
                return true;
            }

            return false;
        }

        #endregion

        private ReadList _newReadList;

        public ReadList NewReadList
        {
            get
            {
                if(_newReadList == null)
                    _newReadList = new ReadList(){AuthorName = "", BookTitle = "", ReadingDate = DateTime.Now, Page = 0, Rating = 0};
                return _newReadList;
            }
            set
            {
                _newReadList = value;
                OnPropertyChanged("NewReadList");
            }
        }

        #region AddCommand

        RelayCommand _addReadListCommand;
        public ICommand AddReadList
        {
            get
            {
                if (_addReadListCommand == null)
                    _addReadListCommand = new RelayCommand(ExecuteAddReadListCommand, CanExecuteAddReadListCommand);
                return _addReadListCommand;
            }
        }

        public void ExecuteAddReadListCommand(object parameter)
        {
            ReadList selectedItem = parameter as ReadList;
            if (selectedItem != null)
            {
                try
                {
                    StatusString = _client.InsertReadList(selectedItem.AuthorName, selectedItem.BookTitle, selectedItem.ReadingDate,
                        selectedItem.Page, selectedItem.Rating);
                }
                catch (Exception e)
                {
                    StatusString = "Додавання нового значення не вдалося!";
                }
                
                ReadLists = null;
                NewReadList = null;
            }
        }

        public bool CanExecuteAddReadListCommand(object parameter)
        {
            ReadList selectedItem = parameter as ReadList;
            if (selectedItem != null)
            {
                if (string.IsNullOrWhiteSpace(selectedItem.AuthorName) ||
                    string.IsNullOrWhiteSpace(selectedItem.BookTitle) ||
                    selectedItem.ReadingDate > DateTime.Now ||
                    selectedItem.Page <= 0 ||
                    selectedItem.Rating <= 0 || selectedItem.Rating > 5)
                {
                    return false;
                }

                return true;
            }

            return false;
        }

        #endregion

        #region SearchCommand

        private string _searchString;

        public string SearchString
        {
            get
            {
                if (_searchString == null)
                    _searchString = "";
                return _searchString;
            }
            set
            {
                _searchString = value;
                OnPropertyChanged("SearchString");
            }
        }

        RelayCommand _searchCommand;
        public ICommand SearchCommand
        {
            get
            {
                if (_searchCommand == null)
                    _searchCommand = new RelayCommand(ExecuteSearchCommand, CanExecuteSearchCommand);
                return _searchCommand;
            }
        }

        public void ExecuteSearchCommand(object parameter)
        {
            string str = parameter as string;
            IEnumerable<ReadList> search;
            if (str != null)
            {
                if (!string.IsNullOrWhiteSpace(str))
                {
                    try
                    {
                        ReadLists = new ObservableCollection<ReadList>(_client.FindByAuthorOrTitle(str));
                    if (ReadLists.Count == 0)
                        {
                            StatusString = "За даними критеріями пошуку нічого не знайдено!";
                            ReadLists = null;
                        }
                        else
                        {
                            StatusString = "";
                        }
                    }
                    catch (Exception e)
                    {
                    }

                }
                else
                {
                    ReadLists = null;
                    StatusString = "";
                }
            }
        }

        public bool CanExecuteSearchCommand(object parameter)
        {
            return true;
        }


        #endregion
        public MainWindowViewModel()
        {
        }
    }
}
