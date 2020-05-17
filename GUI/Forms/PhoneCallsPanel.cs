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
		private int _callsGenerationInterval = 3333;
		public PhoneCallsPanelForm(PhoneControl phoneControl) {
			if (phoneControl == null) {
				throw new ArgumentNullException(nameof(phoneControl));
			}
			_phoneControl = phoneControl;


			if (phoneControl.MobilePhone == null) {
				throw new NullReferenceException("Cannot reference a Mobile Phone that is NULL!");
			}
			_phoneCallsGenerator = new PhoneCallsGenerator_Task(_phoneControl.MobilePhone, _callsGenerationInterval);

			InitializeComponent();

			EnableNotifications();

			_phoneCallsGenerator.StartGeneratingNewMessages();
		}

		private void PhoneCallsPanelForm_FormClosing(object sender, FormClosingEventArgs e) {
			DisableNotifications();
			_phoneCallsGenerator.StopGeneratingNewMessages();
		}

		private void EnableNotifications() {
			_phoneControl.MobilePhone.PhoneCallsStorage.NewPhoneCallReceived += RefreshListView;
			_phoneControl.MobilePhone.PhoneCallsStorage.NewPhoneCallReceived += UpdateLastMessage;
		}
		private void DisableNotifications() {
			_phoneControl.MobilePhone.PhoneCallsStorage.NewPhoneCallReceived -= RefreshListView;
			_phoneControl.MobilePhone.PhoneCallsStorage.NewPhoneCallReceived -= UpdateLastMessage;
		}

		private void UpdateLastMessage(object sender, NewPhoneCallEventArgs e) {
			if (InvokeRequired) {
				Invoke(new MethodInvoker(() => UpdateLastMessage(sender, e)));
			} else {

				richTextBoxLastMessage.Text = string.Empty;
				richTextBoxLastMessage.AppendText(e.PhoneCall.Contact.Name + " (" + e.PhoneCall.PhoneNumber + ")" + Environment.NewLine);
				richTextBoxLastMessage.AppendText(e.PhoneCall.CallType.ToString("G") + Environment.NewLine);
				richTextBoxLastMessage.AppendText(e.PhoneCall.CallTime.ToString());
			}
		}
		private void RefreshListView(object sender, NewPhoneCallEventArgs e) {
			if (listViewPhoneCalls == null || e == null) {
				return;
			}

			ClearListView();
			IEnumerable<ICall> calls = _phoneControl.MobilePhone.PhoneCallsStorage.GetCalls();
			PrintCallsToListView(calls);
		}
		private void ClearListView() {
			if (InvokeRequired) {
				Invoke(new MethodInvoker(() => ClearListView()));
			} else {
				listViewPhoneCalls.Items.Clear();
			}
		}
		private void PrintCallsToListView(IEnumerable<ICall> calls) {
			if (calls == null) {
				return;
			}

			foreach (ICall call in calls) {
				PrintCallToListView(call);
			}
		}
		private void PrintCallToListView(ICall call) {
			if (call == null || listViewPhoneCalls == null) {
				return;
			}

			if (InvokeRequired) {
				Invoke(new MethodInvoker(() => PrintCallToListView(call)));
			} else {
				ListViewItem viewItem = new ListViewItem(new[] {
					call.Contact.Name,
					call.CallType.ToString("G"),
					ComposeCallDate(call.CallTime)
				}); ;
				listViewPhoneCalls.Items.Add(viewItem);
			}
		}
		private string ComposeCallDate(DateTime dateTime) {
			return dateTime.ToLongDateString() + " " + dateTime.ToLongTimeString();
		}
	}
}
