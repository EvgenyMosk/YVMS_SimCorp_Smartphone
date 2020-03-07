using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Enums;

namespace Core {
	public class MobilePhoneConfigurator {
		public static IMobilePhone CreateMobilePhone(PresetsPhones presetPhone) {
			return new MobilePhone();
		}
	}
}
