using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Core;

using PhonePlayerBusinessLogic;

namespace GUI {
	public partial class NotificationsPanel : Form {
		private readonly PhoneControl PhoneControl;
		private readonly Random Random;
		public NotificationsPanel(PhoneControl phoneControl) {
			if (phoneControl == null) {
				throw new ArgumentNullException(nameof(phoneControl));
			}
			InitializeComponent();

			PhoneControl = phoneControl;
			IOutput output = new RichTextBoxWriter(richTxtBxNotificationsLog);
			PhoneControl.EnableNotifications(output);

			Random = new Random();
			timerNotifications.Enabled = true;
		}

		private void timerNotifications_Tick(object sender, EventArgs e) {
			int messageLength = Random.Next(50);
			string message = DescriptionFormatter.GenerateRandomString(messageLength, Random);
			PhoneControl.mobilePhone.NotificationService.ReceiveMessage(message);
		}

		private void NotificationsPanel_FormClosed(object sender, FormClosedEventArgs e) {
			timerNotifications.Enabled = false;
			PhoneControl.DisableNotifications();
		}
	}
}
