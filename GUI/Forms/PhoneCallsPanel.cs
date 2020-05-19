using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Core.Interfaces;
using Core.SoftwareComponents;

using PhonePlayerBusinessLogic;

namespace GUI.Forms {
	public partial class PhoneCallsPanelForm : Form {
		private PhoneControl _phoneControl;
		private PhoneCallsGenerator_Task _phoneCallsGenerator;
		private int _callsGenerationInterval = 2500;
		public PhoneCallsPanelForm(PhoneControl phoneControl) {
			if (phoneControl == null) {
				throw new ArgumentNullException(nameof(phoneControl));
			}
			_phoneControl = phoneControl;

			if (phoneControl.MobilePhone == null) {
				throw new NullReferenceException("Cannot reference a Mobile Phone that is NULL!");
			}
			_phoneCallsGenerator = new PhoneCallsGenerator_Task(phoneControl.MobilePhone, _callsGenerationInterval);

			InitializeComponent();

			if (phoneControl.MobilePhone.PhoneCallsStorage != null && phoneControl.MobilePhone.PhoneCallsStorage.Count > 0) {
				IList<ICall> phoneCalls = _phoneControl.MobilePhone.PhoneCallsStorage.GetCalls();
				PrintCallsToListView(phoneCalls);
			}

			EnableNotifications();

			if (_phoneControl.MobilePhone.PhoneCallsStorage.Count > 0) {
				PrintLastMessage(_phoneControl.MobilePhone.PhoneCallsStorage[0]);
			}

			_phoneCallsGenerator.StartGeneratingNewMessages();
		}

		private void PhoneCallsPanelForm_FormClosing(object sender, FormClosingEventArgs e) {
			DisableNotifications();

			_phoneCallsGenerator.StopGeneratingNewMessages();
		}

		private void EnableNotifications() {
			_phoneControl.MobilePhone.PhoneCallsStorage.NewPhoneCallReceived += PrintLastMessageToListView;
			_phoneControl.MobilePhone.PhoneCallsStorage.NewPhoneCallReceived += UpdateLastMessage;
		}
		private void DisableNotifications() {
			_phoneControl.MobilePhone.PhoneCallsStorage.NewPhoneCallReceived -= PrintLastMessageToListView;
			_phoneControl.MobilePhone.PhoneCallsStorage.NewPhoneCallReceived -= UpdateLastMessage;
		}

		private void UpdateLastMessage(object sender, NewPhoneCallEventArgs e) {
			PrintLastMessage(e.PhoneCall);
		}
		private void PrintLastMessage(ICall call) {
			if (InvokeRequired) {
				Invoke(new MethodInvoker(() => PrintLastMessage(call)));
			} else {
				richTextBoxLastMessage.Text = string.Empty;
				richTextBoxLastMessage.AppendText(call.Contact.Name + " (" + call.PhoneNumber + ")" + Environment.NewLine);
				richTextBoxLastMessage.AppendText(call.CallType.ToString("G") + Environment.NewLine);
				richTextBoxLastMessage.AppendText(call.CallTime.ToString());
			}
		}
		private void PrintLastMessageToListView(object sender, NewPhoneCallEventArgs e) {
			if (listViewPhoneCalls == null || e == null) {
				return;
			}

			int callsCount = _phoneControl.MobilePhone.PhoneCallsStorage.Count;

			if (callsCount > 1) {
				if (_phoneControl.MobilePhone.PhoneCallsStorage[0].Equals(_phoneControl.MobilePhone.PhoneCallsStorage[1])) {
					string[] listViewItemText = {
							_phoneControl.MobilePhone.PhoneCallsStorage[0].Contact.Name,
							_phoneControl.MobilePhone.PhoneCallsStorage[0].PhoneNumber.ToString(),
							_phoneControl.MobilePhone.PhoneCallsStorage[0].CallType.ToString("G"),
							ComposeCallDate(_phoneControl.MobilePhone.PhoneCallsStorage[0].CallTime),
							"Yes"
						};
					ListViewItem viewItem = CreateListViewItem(listViewItemText);
					PrintItemToListView(viewItem);
				} else {
					PrintCallToListView(_phoneControl.MobilePhone.PhoneCallsStorage.First());
				}
			} else {
				PrintCallToListView(_phoneControl.MobilePhone.PhoneCallsStorage.First());
			}

			//ClearListView();

			//IList<ICall> calls = _phoneControl.MobilePhone.PhoneCallsStorage.GetCalls();

			//PrintCallsToListView(calls);

			//IEnumerable<IGrouping<string, ICall>> calls = _phoneControl.MobilePhone.PhoneCallsStorage.GetCallsGroupByContact();

			//foreach (IGrouping<string, ICall> callsGroup in calls) {
			//	foreach (ICall call in callsGroup) {
			//		PrintCallToListView(call);
			//	}
			//}
		}
		private void ClearListView() {
			if (InvokeRequired) {
				Invoke(new MethodInvoker(() => ClearListView()));
			} else {
				listViewPhoneCalls.Items.Clear();
			}
		}
		private void PrintCallsToListView(IList<ICall> calls) {
			if (calls == null || calls.Count == 0) {
				return;
			}

			if (calls.Count > 1) {
				for (int i = 0; i < calls.Count - 1; i++) {
					if (calls[i].Equals(calls[i + 1])) {
						string[] listViewItemText = CreateTextForListViewItem(calls[i], true);
						ListViewItem viewItem = CreateListViewItem(listViewItemText);
						PrintItemToListView(viewItem);
					} else {
						PrintCallToListView(calls[i]);
					}
				}
				PrintCallToListView(calls[calls.Count - 1]);
			} else {
				PrintCallToListView(calls.First());
			}
		}
		private void PrintCallToListView(ICall call) {
			if (listViewPhoneCalls == null || call == null) {
				return;
			}

			if (InvokeRequired) {
				Invoke(new MethodInvoker(() => PrintCallToListView(call)));
			} else {
				string[] text = CreateTextForListViewItem(call, false);
				ListViewItem viewItem = CreateListViewItem(text);
				PrintItemToListView(viewItem);
			}
		}
		private string[] CreateTextForListViewItem(ICall call, bool isMergedWithPrevious) {
			string mergedWithPrevTxt = "";
			if (isMergedWithPrevious) {
				mergedWithPrevTxt = "Yest";
			}

			string[] listViewItemText = {
							call.Contact.Name,
							call.PhoneNumber.ToString(),
							call.CallType.ToString("G"),
							ComposeCallDate(call.CallTime),
							mergedWithPrevTxt
			};

			return listViewItemText;
		}
		private ListViewItem CreateListViewItem(string[] text) {
			if (text.Length != 5) {
				throw new ArgumentException(nameof(text));
			}
			ListViewItem listViewItem = new ListViewItem(text);
			return listViewItem;
		}
		private void PrintItemToListView(ListViewItem viewItem) {
			if (InvokeRequired) {
				Invoke(new MethodInvoker(() => PrintItemToListView(viewItem)));
			} else {
				listViewPhoneCalls.Items.Insert(0, viewItem);
			}
		}
		private string ComposeCallDate(DateTime dateTime) {
			return dateTime.ToLongDateString() + " " + dateTime.ToLongTimeString();
		}
	}
}
