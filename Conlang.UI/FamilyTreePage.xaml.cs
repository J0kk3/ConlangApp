using System;
using System.Windows.Controls;

namespace Conlang.UI
{
    /// <summary>
    /// Interaction logic for FamilyTreePage.xaml
    /// </summary>
    public partial class FamilyTreePage : Page
    {
        readonly IServiceProvider _serviceProvider;
        public FamilyTreePage(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }
    }
}