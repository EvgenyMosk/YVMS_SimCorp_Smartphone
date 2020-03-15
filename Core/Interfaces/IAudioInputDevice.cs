﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core {
	public interface IAudioInputDevice : ICommonDescription {
		void StartRecordingSound();
		void StopRecordingSound();
		void InputVolumeIncrease(int delta);
		void InputVolumeDecrease(int delta);
	}
}