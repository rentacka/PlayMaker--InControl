﻿// (c) Copyright HutongGames, LLC 2010-2014. All rights reserved.

using UnityEngine;
using InControl;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("InControl")]
	[Tooltip("Sends an Event when the specified Incontrol control Axis for a given Device is pressed. Optionally store the control state in a bool variable.")]
	public class GetInControlDeviceInputButtonDown : FsmStateAction
	{
		
		[Tooltip("The index of the Device.")]
		public FsmInt deviceIndex;
		
		public InputControlType axis;
		
		public FsmEvent sendEvent;
		[UIHint(UIHint.Variable)]
		public FsmBool storeResult;
		
		
		bool wasPressed;
		//bool isDownFlag;

		InputDevice _inputDevice;

		public override void Reset()
		{
			deviceIndex =null;
			axis = InputControlType.Action1;
			
			sendEvent = null;
			storeResult = null;
		}
		
		public override void OnEnter()
		{
			if (deviceIndex.Value ==-1)
			{
				_inputDevice = InputManager.ActiveDevice;
			}else{
				_inputDevice= InputManager.Devices[deviceIndex.Value];
			}
		}

		public override void OnUpdate()
		{
			wasPressed = _inputDevice.GetControl(axis).WasPressed;
			
			if (wasPressed)
			{
				Fsm.Event(sendEvent);
				
			}
			
			storeResult.Value = wasPressed;
		}
	}
}