using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace GuidGen
{
	public class GuidGeneratorViewModel : BindableBase
	{
		private bool topMost;
		private bool allCaps;
		private string currentGuid;
		private ObservableCollection<string> history;

		public GuidGeneratorViewModel()
		{
			GenerateGuidCommand = new DelegateCommand(GenerateGuid);
			History = new ObservableCollection<string>();
		}

		#region Commands

		public ICommand GenerateGuidCommand { get; set; }

		#endregion

		#region Properties

		public bool TopMost
		{
			get => topMost;
			set => SetProperty(ref topMost, value);
		}

		public bool AllCaps
		{
			get => allCaps;
			set => SetProperty(ref allCaps, value, OnAllCapsChanged);
		}

		public string CurrentGuid
		{
			get => currentGuid;
			set => SetProperty(ref currentGuid, value);
		}

		public ObservableCollection<string> History
		{
			get => history;
			set => SetProperty(ref history, value);
		}

		#endregion

		#region CommandHandlers

		public void GenerateGuid()
		{
			string guid = Guid.NewGuid().ToString().ToLowerInvariant();

			if (AllCaps)
				guid = guid.ToUpperInvariant();

			CurrentGuid = guid;

			History.Insert(0, CurrentGuid);

			SetClipboard();
		}

		#endregion

		private void OnAllCapsChanged()
		{
			string selected = CurrentGuid;
			for (int i = 0; i < History.Count; i++)
			{
				History[i] = allCaps
					? History[i].ToUpperInvariant()
					: History[i].ToLowerInvariant();
			}

			CurrentGuid = selected;

			if (!string.IsNullOrEmpty(CurrentGuid))
			{
				CurrentGuid = allCaps
					? CurrentGuid.ToUpperInvariant()
					: CurrentGuid.ToLowerInvariant();

				SetClipboard();
			}
		}

		private void SetClipboard()
		{
			if (!string.IsNullOrEmpty(CurrentGuid))
				Clipboard.SetText(CurrentGuid);
		}
	}
}