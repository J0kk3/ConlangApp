using Conlang.Core.Entities.IPA;
using Conlang.Infrastructure.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;

namespace Conlang.UI
{
    /// <summary>
    /// Interaction logic for IPAChart.xaml
    /// </summary>
    public partial class IPAChart : Page
    {
        readonly ConlangDbContext _ctx;
        public ObservableCollection<IPASymbol> IPAConsonants { get; private set; }

        public IPAChart(ConlangDbContext ctx)
        {
            _ctx = ctx;
            InitializeComponent();
            LoadData();
            PopulateIPAGrid();
        }

        void LoadData()
        {
            IPAConsonants = new ObservableCollection<IPASymbol>(_ctx.IPASymbols.ToList());
        }

        Dictionary<string, Dictionary<string, string>> GetIPASymbolsGrouped()
        {
            var symbols = _ctx.IPASymbols.ToList();

            var groupedData = new Dictionary<string, Dictionary<string, string>>();

            foreach (var symbol in symbols)
            {
                if (!groupedData.ContainsKey(symbol.MannerOfArticulation))
                    groupedData[symbol.MannerOfArticulation] = new Dictionary<string, string>();

                var innerDict = groupedData[symbol.MannerOfArticulation];
                innerDict[symbol.PlaceOfArticulation] = symbol.Symbol;
            }

            return groupedData;
        }

        void PopulateIPAGrid()
        {
            var groupedData = GetIPASymbolsGrouped();

            // Create columns based on the unique places of articulation
            var allPlaces = groupedData.SelectMany(g => g.Value.Keys).Distinct().ToList();
            foreach (var place in allPlaces)
            {
                ipaGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            // Iterate over the grouped data and populate the grid
            int rowIndex = 0;
            foreach (var mannerGroup in groupedData)
            {
                var row = new RowDefinition();
                ipaGrid.RowDefinitions.Add(row);

                int columnIndex = 0;
                foreach (var place in allPlaces)
                {
                    var cellValue = mannerGroup.Value.ContainsKey(place) ? mannerGroup.Value[place] : "";
                    var cell = new TextBlock { Text = cellValue };
                    Grid.SetRow(cell, rowIndex);
                    Grid.SetColumn(cell, columnIndex);
                    ipaGrid.Children.Add(cell);
                    columnIndex++;
                }

                rowIndex++;
            }
        }
    }
}