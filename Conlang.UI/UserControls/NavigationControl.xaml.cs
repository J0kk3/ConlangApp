using Conlang.Infrastructure.Data;
using Conlang.UI.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Conlang.UI.UserControls
{
    /// <summary>
    /// Interaction logic for NavigationControl.xaml
    /// </summary>
    public partial class NavigationControl : UserControl
    {
        readonly ConlangDbContext _context;

        // Parameterless constructor mainly for design-time support
        public NavigationControl()
        {
            InitializeComponent();
        }

        internal NavigationControl(NavigationViewModel viewModel, ConlangDbContext context)
        {
            InitializeComponent();
            DataContext = viewModel;
            _context = context;
        }

        public void SetActiveButton(string pageName)
        {
            ResetButtonColors();
            switch (pageName)
            {
                case "Dictionary":
                    DictionaryButton.Background = Brushes.LightBlue;
                    break;
                case "Sound Changes":
                    SoundChangesButton.Background = Brushes.LightBlue;
                    break;
                case "Family Tree":
                    FamilyTreeButton.Background = Brushes.LightBlue;
                    break;
                case "Dashboard":
                    DashboardButton.Background = Brushes.LightBlue;
                    break;
                case "Logout":
                    LogoutButton.Background = Brushes.LightBlue;
                    break;
            }
        }

        void ResetButtonColors()
        {
            DictionaryButton.Background = Brushes.Transparent;
            SoundChangesButton.Background = Brushes.Transparent;
            FamilyTreeButton.Background = Brushes.Transparent;
            DashboardButton.Background = Brushes.Transparent;
            LogoutButton.Background = Brushes.Transparent;
        }
    }
}