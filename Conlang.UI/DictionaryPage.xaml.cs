using System;
using System.Windows.Controls;

namespace Conlang.UI
{
    /// <summary>
    /// Interaction logic for DictionaryPage.xaml
    /// </summary>
    public partial class DictionaryPage : Page
    {
        readonly IServiceProvider _serviceProvider;
        public DictionaryPage(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }
    }
}