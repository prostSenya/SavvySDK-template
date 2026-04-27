using System.Runtime.InteropServices;
using UnityEngine;

namespace Code.Infrastructure.Services.CustomVibrationServices.Adapters.Ios
{
	public static class IosHapticsNative
	{
		public static void Init()
		{
#if UNITY_IOS && !UNITY_EDITOR
			NativeInit();
#endif
		}

		public static bool IsSupported()
		{
#if UNITY_IOS && !UNITY_EDITOR
			return NativeIsSupported() == 1;
#else
			return false;
#endif
		}

		public static bool SupportsForceControl()
		{
#if UNITY_IOS && !UNITY_EDITOR
			return NativeSupportsCoreHaptics() == 1;
#else
			return false;
#endif
		}

		public static void Vibrate(float force, float duration)
		{
#if UNITY_IOS && !UNITY_EDITOR
			NativeVibrate(Mathf.Clamp01(force), Mathf.Max(0f, duration));
#endif
		}

		public static void Cancel()
		{
#if UNITY_IOS && !UNITY_EDITOR
			NativeCancel();
#endif
		}

#if UNITY_IOS && !UNITY_EDITOR
		[DllImport("__Internal", EntryPoint = "NativeInit")]
		private static extern void NativeInit();

		[DllImport("__Internal", EntryPoint = "NativeIsSupported")]
		private static extern int NativeIsSupported();

		[DllImport("__Internal", EntryPoint = "NativeSupportsCoreHaptics")]
		private static extern int NativeSupportsCoreHaptics();

		[DllImport("__Internal", EntryPoint = "NativeVibrate")]
		private static extern void NativeVibrate(float force, float duration);

		[DllImport("__Internal", EntryPoint = "NativeCancel")]
		private static extern void NativeCancel();
#endif
	}
}