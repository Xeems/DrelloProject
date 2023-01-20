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
    public partial class BoardPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<ATask> aTasks = new ObservableCollection<ATask>();

        public BoardPageViewModel() 
        {
            
        }
    }
}
