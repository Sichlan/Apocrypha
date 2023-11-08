using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media;
using Apocrypha.CommonObject.Models.Simulation.Layers;
using Apocrypha.CommonObject.Services.SimulationServices;
using Apocrypha.ModernUi.Helpers;
using Apocrypha.ModernUi.Services.UserInformationService;
using Apocrypha.ModernUi.ViewModels.Common;
using Mars.Common.Core.Collections;
using Mars.Components.Layers;
using Mars.Core.Executor.Implementation;
using Mars.Interfaces.Layers;

namespace Apocrypha.ModernUi.ViewModels.Tools.MapSimulation;

public class MapMainViewModel : BaseViewModel
{
    private readonly ISimulationContainerService _simulationContainerService;
    private readonly IUserInformationMessageService _userInformationMessageService;

    private ObservableCollection<MapLayerViewModel> _mapLayerViewModels;
    private bool _isLoading;
    private readonly Brush _waterBodyBrush = Brushes.LightSkyBlue;

    /// <summary>
    /// Triggers when the map is updated.
    /// </summary>
    public event Action<MapMainViewModel> OnMapUpdated;

    public ObservableCollection<MapLayerViewModel> MapLayerViewModels
    {
        get => _mapLayerViewModels;
        private set
        {
            if (Equals(value, _mapLayerViewModels))
                return;

            _mapLayerViewModels = value;
            OnPropertyChanged();
        }
    }

    public bool IsLoading
    {
        get => _isLoading;
        set
        {
            if (value == _isLoading)
                return;

            _isLoading = value;
            OnPropertyChanged();
        }
    }

    /// <inheritdoc />
    public MapMainViewModel(ISimulationContainerService simulationContainerService, IUserInformationMessageService userInformationMessageService)
    {
        _simulationContainerService = simulationContainerService;
        _userInformationMessageService = userInformationMessageService;

        MapLayerViewModels = new ObservableCollection<MapLayerViewModel>();
        MapLayerViewModels.CollectionChanged += (sender, args) =>
        {
        };

        _simulationContainerService.OnSimulationInitiated += SimulationContainerServiceOnOnSimulationInitiated;
        _simulationContainerService.OnSimulationStep += SimulationContainerServiceOnOnSimulationStep;
    }

    private void SimulationContainerServiceOnOnSimulationStep(ISimulationContainerService sender)
    {
        IsLoading = true;

        IsLoading = false;
    }

    private void SimulationContainerServiceOnOnSimulationInitiated(ISimulationContainerService sender)
    {
        IsLoading = true;

        Task.Run(() =>
        {
            try
            {
                if (sender.CurrentSimulationWorkflowState?.Model is RuntimeModelImpl runtimeModelImpl)
                {
                    var allFeatures = runtimeModelImpl.AllLayers
                        .SelectMany(x => x is VectorLayer vectorLayer ? vectorLayer.Features : Enumerable.Empty<IVectorFeature>())
                        .ToList();

                    double xMin = allFeatures.Min(x => x.VectorStructured.Geometry.Coordinates.Min(y => y.X)),
                        xMax = allFeatures.Max(x => x.VectorStructured.Geometry.Coordinates.Max(y => y.X)),
                        yMin = allFeatures.Min(x => x.VectorStructured.Geometry.Coordinates.Min(y => y.Y)),
                        yMax = allFeatures.Max(x => x.VectorStructured.Geometry.Coordinates.Max(y => y.Y));

                    var newLayers = new List<MapLayerViewModel>();

                    foreach (var layer in runtimeModelImpl.AllLayers)
                    {
                        switch (layer)
                        {
                            case GisCellsLayer gisCellsLayer:
                                newLayers.Add(new MapLayerViewModel(gisCellsLayer, xMin, xMax, yMin, yMax));

                                break;
                            case GisRiverLayer gisRiverLayer:
                                newLayers.Add(new MapLayerViewModel(gisRiverLayer, xMin, xMax, yMin, yMax));

                                break;

                            case GisRoutesLayer gisRoutesLayer:
                                newLayers.Add(new MapLayerViewModel(gisRoutesLayer, xMin, xMax, yMin, yMax));

                                break;

                            case GisMarkersLayer gisMarkersLayer:
                                newLayers.Add(new MapLayerViewModel(gisMarkersLayer, xMin, xMax, yMin, yMax));

                                break;
                        }
                    }

                    DispatcherHelper.RunOnMainThread(() =>
                    {
                        MapLayerViewModels.Clear();
                        MapLayerViewModels.AddRange(newLayers);
                    });
                }

                UpdateLayout();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                IsLoading = false;
            }
        });
    }

    private void UpdateLayout()
    {
        OnMapUpdated?.Invoke(this);
    }
}