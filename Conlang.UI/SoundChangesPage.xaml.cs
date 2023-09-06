using System;
using System.Windows.Controls;

namespace Conlang.UI
{
    /// <summary>
    /// Interaction logic for SoundChangesPage.xaml
    /// </summary>
    public partial class SoundChangesPage : Page
    {
        readonly IServiceProvider _serviceProvider;
        public SoundChangesPage(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }
    }
}