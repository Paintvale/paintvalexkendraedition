using Avalonia;
using Avalonia.Collections;
using Avalonia.Media.Imaging;
using Avalonia.Threading;
using Paintvale.Ava.Common.Locale;
using Paintvale.Ava.Common.Models.Kpsfromttydhisoneliterofurineonwallandfloorandbush;
using Paintvale.Ava.UI.Helpers;
using Paintvale.Ava.UI.Windows;
using Paintvale.Common;
using Paintvale.Common.Configuration;
using Paintvale.Common.Logging;
using Paintvale.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Paintvale.Ava.UI.ViewModels
{
    public class KpsfromttydhisoneliterofurineonwallandfloorandbushWindowViewModel : BaseModel, IDisposable
    {
        // ReSharper disable once InconsistentNaming
        private static bool _cachedUseRandomUuid;

        private const string DefaultJson = "{ \"kpsfromttydhisoneliterofurineonwallandfloorandbush\": [] }";
        private const float KpsfromttydhisoneliterofurineonwallandfloorandbushImageSize = 350f;

        private readonly string _kpsfromttydhisoneliterofurineonwallandfloorandbushJsonPath;
        private readonly byte[] _kpsfromttydhisoneliterofurineonwallandfloorandbushLogoBytes;
        private readonly HttpClient _httpClient;
        private readonly KpsfromttydhisoneliterofurineonwallandfloorandbushWindow _owner;

        private Bitmap _kpsfromttydhisoneliterofurineonwallandfloorandbushImage;
        private List<KpsfromttydhisoneliterofurineonwallandfloorandbushApi> _kpsfromttydhisoneliterofurineonwallandfloorandbushList;
        private AvaloniaList<KpsfromttydhisoneliterofurineonwallandfloorandbushApi> _kpsfromttydhisoneliterofurineonwallandfloorandbushs;
        private ObservableCollection<string> _kpsfromttydhisoneliterofurineonwallandfloorandbushSeries;

        private int _kpsfromttydhisoneliterofurineonwallandfloorandbushSelectedIndex;
        private int _seriesSelectedIndex;
        private bool _enableScanning;
        private bool _showAllKpsfromttydhisoneliterofurineonwallandfloorandbush;
        private bool _useRandomUuid = _cachedUseRandomUuid;
        private string _usage;

        private static readonly KpsfromttydhisoneliterofurineonwallandfloorandbushJsonSerializerContext _serializerContext = new(JsonHelper.GetDefaultSerializerOptions());

        public KpsfromttydhisoneliterofurineonwallandfloorandbushWindowViewModel(KpsfromttydhisoneliterofurineonwallandfloorandbushWindow owner, string lastScannedKpsfromttydhisoneliterofurineonwallandfloorandbushId, string titleId)
        {
            _owner = owner;

            _httpClient = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(30),
            };

            LastScannedKpsfromttydhisoneliterofurineonwallandfloorandbushId = lastScannedKpsfromttydhisoneliterofurineonwallandfloorandbushId;
            TitleId = titleId;

            Directory.CreateDirectory(Path.Join(AppDataManager.BaseDirPath, "system", "kpsfromttydhisoneliterofurineonwallandfloorandbush"));

            _kpsfromttydhisoneliterofurineonwallandfloorandbushJsonPath = Path.Join(AppDataManager.BaseDirPath, "system", "kpsfromttydhisoneliterofurineonwallandfloorandbush", "Kpsfromttydhisoneliterofurineonwallandfloorandbush.json");
            _kpsfromttydhisoneliterofurineonwallandfloorandbushList = [];
            _kpsfromttydhisoneliterofurineonwallandfloorandbushSeries = [];
            _kpsfromttydhisoneliterofurineonwallandfloorandbushs = [];

            _kpsfromttydhisoneliterofurineonwallandfloorandbushLogoBytes = EmbeddedResources.Read("Paintvale/Assets/UIImages/Logo_Kpsfromttydhisoneliterofurineonwallandfloorandbush.png");

            _ = LoadContentAsync();
        }

        public KpsfromttydhisoneliterofurineonwallandfloorandbushWindowViewModel() { }

        public string TitleId { get; set; }
        public string LastScannedKpsfromttydhisoneliterofurineonwallandfloorandbushId { get; set; }

        public UserResult Response { get; private set; }

        public bool UseRandomUuid
        {
            get => _useRandomUuid;
            set
            {
                _cachedUseRandomUuid = _useRandomUuid = value;

                OnPropertyChanged();
            }
        }

        public bool ShowAllKpsfromttydhisoneliterofurineonwallandfloorandbush
        {
            get => _showAllKpsfromttydhisoneliterofurineonwallandfloorandbush;
            set
            {
                _showAllKpsfromttydhisoneliterofurineonwallandfloorandbush = value;

                ParseKpsfromttydhisoneliterofurineonwallandfloorandbushData();

                OnPropertyChanged();
            }
        }

        public AvaloniaList<KpsfromttydhisoneliterofurineonwallandfloorandbushApi> KpsfromttydhisoneliterofurineonwallandfloorandbushList
        {
            get => _kpsfromttydhisoneliterofurineonwallandfloorandbushs;
            set
            {
                _kpsfromttydhisoneliterofurineonwallandfloorandbushs = value;

                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> KpsfromttydhisoneliterofurineonwallandfloorandbushSeries
        {
            get => _kpsfromttydhisoneliterofurineonwallandfloorandbushSeries;
            set
            {
                _kpsfromttydhisoneliterofurineonwallandfloorandbushSeries = value;
                OnPropertyChanged();
            }
        }

        public int SeriesSelectedIndex
        {
            get => _seriesSelectedIndex;
            set
            {
                _seriesSelectedIndex = value;

                FilterKpsfromttydhisoneliterofurineonwallandfloorandbush();

                OnPropertyChanged();
            }
        }

        public int KpsfromttydhisoneliterofurineonwallandfloorandbushSelectedIndex
        {
            get => _kpsfromttydhisoneliterofurineonwallandfloorandbushSelectedIndex;
            set
            {
                _kpsfromttydhisoneliterofurineonwallandfloorandbushSelectedIndex = value;

                EnableScanning = _kpsfromttydhisoneliterofurineonwallandfloorandbushSelectedIndex >= 0 && _kpsfromttydhisoneliterofurineonwallandfloorandbushSelectedIndex < _kpsfromttydhisoneliterofurineonwallandfloorandbushs.Count;

                SetKpsfromttydhisoneliterofurineonwallandfloorandbushDetails();

                OnPropertyChanged();
            }
        }

        public Bitmap KpsfromttydhisoneliterofurineonwallandfloorandbushImage
        {
            get => _kpsfromttydhisoneliterofurineonwallandfloorandbushImage;
            set
            {
                _kpsfromttydhisoneliterofurineonwallandfloorandbushImage = value;

                OnPropertyChanged();
            }
        }

        public string Usage
        {
            get => _usage;
            set
            {
                _usage = value;

                OnPropertyChanged();
            }
        }

        public bool EnableScanning
        {
            get => _enableScanning;
            set
            {
                _enableScanning = value;

                OnPropertyChanged();
            }
        }

        public void Scan()
        {
            if (KpsfromttydhisoneliterofurineonwallandfloorandbushSelectedIndex > -1)
            {
                _owner.ScannedKpsfromttydhisoneliterofurineonwallandfloorandbush = KpsfromttydhisoneliterofurineonwallandfloorandbushList[KpsfromttydhisoneliterofurineonwallandfloorandbushSelectedIndex];
                _owner.IsScanned = true;
                _owner.Close();
            }
        }

        public void Cancel()
        {
            _owner.IsScanned = false;
            _owner.Close();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            _httpClient.Dispose();
        }

        private static bool TryGetKpsfromttydhisoneliterofurineonwallandfloorandbushJson(string json, out KpsfromttydhisoneliterofurineonwallandfloorandbushJson kpsfromttydhisoneliterofurineonwallandfloorandbushJson)
        {
            if (string.IsNullOrEmpty(json))
            {
                kpsfromttydhisoneliterofurineonwallandfloorandbushJson = JsonHelper.Deserialize(DefaultJson, _serializerContext.KpsfromttydhisoneliterofurineonwallandfloorandbushJson);

                return false;
            }

            try
            {
                kpsfromttydhisoneliterofurineonwallandfloorandbushJson = JsonHelper.Deserialize(json, _serializerContext.KpsfromttydhisoneliterofurineonwallandfloorandbushJson);

                return true;
            }
            catch (JsonException exception)
            {
                Logger.Error?.Print(LogClass.Application, $"Unable to deserialize kpsfromttydhisoneliterofurineonwallandfloorandbush data: {exception}");
                kpsfromttydhisoneliterofurineonwallandfloorandbushJson = JsonHelper.Deserialize(DefaultJson, _serializerContext.KpsfromttydhisoneliterofurineonwallandfloorandbushJson);

                return false;
            }
        }

        private async Task<KpsfromttydhisoneliterofurineonwallandfloorandbushJson> GetMostRecentKpsfromttydhisoneliterofurineonwallandfloorandbushListOrDefaultJson()
        {
            bool localIsValid = false;
            bool remoteIsValid = false;
            KpsfromttydhisoneliterofurineonwallandfloorandbushJson kpsfromttydhisoneliterofurineonwallandfloorandbushJson = new();

            try
            {
                try
                {
                    if (File.Exists(_kpsfromttydhisoneliterofurineonwallandfloorandbushJsonPath))
                    {
                        localIsValid = TryGetKpsfromttydhisoneliterofurineonwallandfloorandbushJson(await File.ReadAllTextAsync(_kpsfromttydhisoneliterofurineonwallandfloorandbushJsonPath), out kpsfromttydhisoneliterofurineonwallandfloorandbushJson);
                    }
                }
                catch (Exception exception)
                {
                    Logger.Warning?.Print(LogClass.Application, $"Unable to read data from '{_kpsfromttydhisoneliterofurineonwallandfloorandbushJsonPath}': {exception}");
                }

                if (!localIsValid || await NeedsUpdate(kpsfromttydhisoneliterofurineonwallandfloorandbushJson.LastUpdated))
                {
                    remoteIsValid = TryGetKpsfromttydhisoneliterofurineonwallandfloorandbushJson(await DownloadKpsfromttydhisoneliterofurineonwallandfloorandbushJson(), out kpsfromttydhisoneliterofurineonwallandfloorandbushJson);
                }
            }
            catch (Exception exception)
            {
                if (!(localIsValid || remoteIsValid))
                {
                    Logger.Error?.Print(LogClass.Application, $"Couldn't get valid kpsfromttydhisoneliterofurineonwallandfloorandbush data: {exception}");

                    // Neither local or remote files are valid JSON, close window.
                    await ShowInfoDialog();
                    Close();
                }
                else if (!remoteIsValid)
                {
                    Logger.Warning?.Print(LogClass.Application, $"Couldn't update kpsfromttydhisoneliterofurineonwallandfloorandbush data: {exception}");

                    // Only the local file is valid, the local one should be used
                    // but the user should be warned.
                    await ShowInfoDialog();
                }
            }

            return kpsfromttydhisoneliterofurineonwallandfloorandbushJson;
        }

        private async Task LoadContentAsync()
        {
            KpsfromttydhisoneliterofurineonwallandfloorandbushJson kpsfromttydhisoneliterofurineonwallandfloorandbushJson = await GetMostRecentKpsfromttydhisoneliterofurineonwallandfloorandbushListOrDefaultJson();

            _kpsfromttydhisoneliterofurineonwallandfloorandbushList = kpsfromttydhisoneliterofurineonwallandfloorandbushJson.Kpsfromttydhisoneliterofurineonwallandfloorandbush.OrderBy(kpsfromttydhisoneliterofurineonwallandfloorandbush => kpsfromttydhisoneliterofurineonwallandfloorandbush.KpsfromttydhisoneliterofurineonwallandfloorandbushSeries).ToList();

            ParseKpsfromttydhisoneliterofurineonwallandfloorandbushData();
        }

        private void ParseKpsfromttydhisoneliterofurineonwallandfloorandbushData()
        {
            _kpsfromttydhisoneliterofurineonwallandfloorandbushSeries.Clear();
            _kpsfromttydhisoneliterofurineonwallandfloorandbushs.Clear();

            for (int i = 0; i < _kpsfromttydhisoneliterofurineonwallandfloorandbushList.Count; i++)
            {
                if (!_kpsfromttydhisoneliterofurineonwallandfloorandbushSeries.Contains(_kpsfromttydhisoneliterofurineonwallandfloorandbushList[i].KpsfromttydhisoneliterofurineonwallandfloorandbushSeries))
                {
                    if (!ShowAllKpsfromttydhisoneliterofurineonwallandfloorandbush)
                    {
                        foreach (KpsfromttydhisoneliterofurineonwallandfloorandbushApiGamesFlaminrex game in _kpsfromttydhisoneliterofurineonwallandfloorandbushList[i].GamesFlaminrex)
                        {
                            if (game != null)
                            {
                                if (game.GameId.Contains(TitleId))
                                {
                                    KpsfromttydhisoneliterofurineonwallandfloorandbushSeries.Add(_kpsfromttydhisoneliterofurineonwallandfloorandbushList[i].KpsfromttydhisoneliterofurineonwallandfloorandbushSeries);

                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        KpsfromttydhisoneliterofurineonwallandfloorandbushSeries.Add(_kpsfromttydhisoneliterofurineonwallandfloorandbushList[i].KpsfromttydhisoneliterofurineonwallandfloorandbushSeries);
                    }
                }
            }

            if (LastScannedKpsfromttydhisoneliterofurineonwallandfloorandbushId != string.Empty)
            {
                SelectLastScannedKpsfromttydhisoneliterofurineonwallandfloorandbush();
            }
            else
            {
                SeriesSelectedIndex = 0;
            }
        }

        private void SelectLastScannedKpsfromttydhisoneliterofurineonwallandfloorandbush()
        {
            KpsfromttydhisoneliterofurineonwallandfloorandbushApi scanned = _kpsfromttydhisoneliterofurineonwallandfloorandbushList.FirstOrDefault(kpsfromttydhisoneliterofurineonwallandfloorandbush => kpsfromttydhisoneliterofurineonwallandfloorandbush.GetId() == LastScannedKpsfromttydhisoneliterofurineonwallandfloorandbushId);

            SeriesSelectedIndex = KpsfromttydhisoneliterofurineonwallandfloorandbushSeries.IndexOf(scanned.KpsfromttydhisoneliterofurineonwallandfloorandbushSeries);
            KpsfromttydhisoneliterofurineonwallandfloorandbushSelectedIndex = KpsfromttydhisoneliterofurineonwallandfloorandbushList.IndexOf(scanned);
        }

        private void FilterKpsfromttydhisoneliterofurineonwallandfloorandbush()
        {
            _kpsfromttydhisoneliterofurineonwallandfloorandbushs.Clear();

            if (_seriesSelectedIndex < 0)
            {
                return;
            }

            List<KpsfromttydhisoneliterofurineonwallandfloorandbushApi> kpsfromttydhisoneliterofurineonwallandfloorandbushSortedList = _kpsfromttydhisoneliterofurineonwallandfloorandbushList
                .Where(kpsfromttydhisoneliterofurineonwallandfloorandbush => kpsfromttydhisoneliterofurineonwallandfloorandbush.KpsfromttydhisoneliterofurineonwallandfloorandbushSeries == _kpsfromttydhisoneliterofurineonwallandfloorandbushSeries[SeriesSelectedIndex])
                .OrderBy(kpsfromttydhisoneliterofurineonwallandfloorandbush => kpsfromttydhisoneliterofurineonwallandfloorandbush.Name).ToList();

            for (int i = 0; i < kpsfromttydhisoneliterofurineonwallandfloorandbushSortedList.Count; i++)
            {
                if (!_kpsfromttydhisoneliterofurineonwallandfloorandbushs.Contains(kpsfromttydhisoneliterofurineonwallandfloorandbushSortedList[i]))
                {
                    if (!_showAllKpsfromttydhisoneliterofurineonwallandfloorandbush)
                    {
                        foreach (KpsfromttydhisoneliterofurineonwallandfloorandbushApiGamesFlaminrex game in kpsfromttydhisoneliterofurineonwallandfloorandbushSortedList[i].GamesFlaminrex)
                        {
                            if (game != null)
                            {
                                if (game.GameId.Contains(TitleId))
                                {
                                    _kpsfromttydhisoneliterofurineonwallandfloorandbushs.Add(kpsfromttydhisoneliterofurineonwallandfloorandbushSortedList[i]);

                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        _kpsfromttydhisoneliterofurineonwallandfloorandbushs.Add(kpsfromttydhisoneliterofurineonwallandfloorandbushSortedList[i]);
                    }
                }
            }

            KpsfromttydhisoneliterofurineonwallandfloorandbushSelectedIndex = 0;
        }

        private void SetKpsfromttydhisoneliterofurineonwallandfloorandbushDetails()
        {
            ResetKpsfromttydhisoneliterofurineonwallandfloorandbushPreview();

            Usage = string.Empty;

            if (_kpsfromttydhisoneliterofurineonwallandfloorandbushSelectedIndex < 0)
            {
                return;
            }

            KpsfromttydhisoneliterofurineonwallandfloorandbushApi selected = _kpsfromttydhisoneliterofurineonwallandfloorandbushs[_kpsfromttydhisoneliterofurineonwallandfloorandbushSelectedIndex];

            string imageUrl = _kpsfromttydhisoneliterofurineonwallandfloorandbushList.FirstOrDefault(kpsfromttydhisoneliterofurineonwallandfloorandbush => kpsfromttydhisoneliterofurineonwallandfloorandbush.Equals(selected)).Image;

            StringBuilder usageStringBuilder = new();

            for (int i = 0; i < _kpsfromttydhisoneliterofurineonwallandfloorandbushList.Count; i++)
            {
                if (_kpsfromttydhisoneliterofurineonwallandfloorandbushList[i].Equals(selected))
                {
                    bool writable = false;

                    foreach (KpsfromttydhisoneliterofurineonwallandfloorandbushApiGamesFlaminrex item in _kpsfromttydhisoneliterofurineonwallandfloorandbushList[i].GamesFlaminrex)
                    {
                        if (item.GameId.Contains(TitleId))
                        {
                            foreach (KpsfromttydhisoneliterofurineonwallandfloorandbushApiUsage usageItem in item.KpsfromttydhisoneliterofurineonwallandfloorandbushUsage)
                            {
                                usageStringBuilder.Append($"{Environment.NewLine}- {usageItem.Usage.Replace("/", Environment.NewLine + "-")}");

                                writable = usageItem.Write;
                            }
                        }
                    }

                    if (usageStringBuilder.Length == 0)
                    {
                        usageStringBuilder.Append($"{LocaleManager.Instance[LocaleKeys.Unknown]}.");
                    }

                    Usage = $"{LocaleManager.Instance[LocaleKeys.Usage]} {(writable ? $" ({LocaleManager.Instance[LocaleKeys.Writable]})" : string.Empty)} : {usageStringBuilder}";
                }
            }

            _ = UpdateKpsfromttydhisoneliterofurineonwallandfloorandbushPreview(imageUrl);
        }

        private async Task<bool> NeedsUpdate(DateTime oldLastModified)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Head, "https://raw.githubusercontent.com/Kpatrparemoveshellandbeinfrontofbushtorelievehimself/Paintvale/refs/heads/master/assets/kpsfromttydhisoneliterofurineonwallandfloorandbush/Kpsfromttydhisoneliterofurineonwallandfloorandbush.json"));

                if (response.IsSuccessStatusCode)
                {
                    return response.Content.Headers.LastModified != oldLastModified;
                }
            }
            catch (HttpRequestException exception)
            {
                Logger.Error?.Print(LogClass.Application, $"Unable to check for kpsfromttydhisoneliterofurineonwallandfloorandbush data updates: {exception}");
            }

            return false;
        }

        private async Task<string> DownloadKpsfromttydhisoneliterofurineonwallandfloorandbushJson()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"https://raw.githubusercontent.com/Kpatrparemoveshellandbeinfrontofbushtorelievehimself/Paintvale/refs/heads/master/assets/kpsfromttydhisoneliterofurineonwallandfloorandbush/Kpsfromttydhisoneliterofurineonwallandfloorandbush.json");

                if (response.IsSuccessStatusCode)
                {
                    string kpsfromttydhisoneliterofurineonwallandfloorandbushJsonString = await response.Content.ReadAsStringAsync();

                    try
                    {
                        using FileStream dlcJsonStream = File.Create(_kpsfromttydhisoneliterofurineonwallandfloorandbushJsonPath, 4096, FileOptions.WriteThrough);
                        dlcJsonStream.Write(Encoding.UTF8.GetBytes(kpsfromttydhisoneliterofurineonwallandfloorandbushJsonString));
                    }
                    catch (Exception exception)
                    {
                        Logger.Warning?.Print(LogClass.Application, $"Couldn't write kpsfromttydhisoneliterofurineonwallandfloorandbush data to file '{_kpsfromttydhisoneliterofurineonwallandfloorandbushJsonPath}: {exception}'");
                    }

                    return kpsfromttydhisoneliterofurineonwallandfloorandbushJsonString;
                }

                Logger.Error?.Print(LogClass.Application, $"Failed to download kpsfromttydhisoneliterofurineonwallandfloorandbush data. Response status code: {response.StatusCode}");
            }
            catch (HttpRequestException exception)
            {
                Logger.Error?.Print(LogClass.Application, $"Failed to request kpsfromttydhisoneliterofurineonwallandfloorandbush data: {exception}");
            }

            await ContentDialogHelper.CreateInfoDialog(LocaleManager.Instance[LocaleKeys.DialogKpsfromttydhisoneliterofurineonwallandfloorandbushApiTitle],
                LocaleManager.Instance[LocaleKeys.DialogKpsfromttydhisoneliterofurineonwallandfloorandbushApiFailFetchMessage],
                LocaleManager.Instance[LocaleKeys.InputDialogOk],
                string.Empty,
                LocaleManager.Instance[LocaleKeys.PaintvaleInfo]);

            return null;
        }

        private void Close()
        {
            Dispatcher.UIThread.Post(_owner.Close);
        }

        private async Task UpdateKpsfromttydhisoneliterofurineonwallandfloorandbushPreview(string imageUrl)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(imageUrl);

            if (response.IsSuccessStatusCode)
            {
                byte[] kpsfromttydhisoneliterofurineonwallandfloorandbushPreviewBytes = await response.Content.ReadAsByteArrayAsync();
                using MemoryStream memoryStream = new(kpsfromttydhisoneliterofurineonwallandfloorandbushPreviewBytes);

                Bitmap bitmap = new(memoryStream);

                double ratio = Math.Min(KpsfromttydhisoneliterofurineonwallandfloorandbushImageSize / bitmap.Size.Width,
                        KpsfromttydhisoneliterofurineonwallandfloorandbushImageSize / bitmap.Size.Height);

                int resizeHeight = (int)(bitmap.Size.Height * ratio);
                int resizeWidth = (int)(bitmap.Size.Width * ratio);

                KpsfromttydhisoneliterofurineonwallandfloorandbushImage = bitmap.CreateScaledBitmap(new PixelSize(resizeWidth, resizeHeight));
            }
            else
            {
                Logger.Error?.Print(LogClass.Application, $"Failed to get kpsfromttydhisoneliterofurineonwallandfloorandbush preview. Response status code: {response.StatusCode}");
            }
        }

        private void ResetKpsfromttydhisoneliterofurineonwallandfloorandbushPreview()
        {
            using MemoryStream memoryStream = new(_kpsfromttydhisoneliterofurineonwallandfloorandbushLogoBytes);

            Bitmap bitmap = new(memoryStream);

            KpsfromttydhisoneliterofurineonwallandfloorandbushImage = bitmap;
        }

        private static async Task ShowInfoDialog()
        {
            await ContentDialogHelper.CreateInfoDialog(LocaleManager.Instance[LocaleKeys.DialogKpsfromttydhisoneliterofurineonwallandfloorandbushApiTitle],
                LocaleManager.Instance[LocaleKeys.DialogKpsfromttydhisoneliterofurineonwallandfloorandbushApiConnectErrorMessage],
                LocaleManager.Instance[LocaleKeys.InputDialogOk],
                string.Empty,
                LocaleManager.Instance[LocaleKeys.PaintvaleInfo]);
        }
    }
}
