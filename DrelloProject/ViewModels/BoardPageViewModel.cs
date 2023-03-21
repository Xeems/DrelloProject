using CommunityToolkit.Mvvm.ComponentModel;
using DrelloProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrelloProject.ViewModels
{
    [QueryProperty(nameof(Board), nameof(Board))]
    public partial class BoardPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private Board board;

        [ObservableProperty]
        private ObservableCollection<ATask> aTasks = new ObservableCollection<ATask>();

        public BoardPageViewModel() 
        {
            
        }
    }
}
