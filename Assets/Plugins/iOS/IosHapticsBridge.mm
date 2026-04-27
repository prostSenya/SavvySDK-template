#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>
#import <AudioToolbox/AudioToolbox.h>

#if __has_include(<CoreHaptics/CoreHaptics.h>)
#import <CoreHaptics/CoreHaptics.h>
#endif

#if __has_include(<CoreHaptics/CoreHaptics.h>)

static CHHapticEngine *s_hapticEngine API_AVAILABLE(ios(13.0)) = nil;
static id<CHHapticPatternPlayer> s_currentPlayer API_AVAILABLE(ios(13.0)) = nil;

#endif

static float Clamp01(float value)
{
	if (value < 0.0f)
		return 0.0f;

	if (value > 1.0f)
		return 1.0f;

	return value;
}

static BOOL SupportsCoreHapticsInternal()
{
#if __has_include(<CoreHaptics/CoreHaptics.h>)
	if (@available(iOS 13.0, *))
	{
		return [CHHapticEngine capabilitiesForHardware].supportsHaptics;
	}
#endif

	return NO;
}

static BOOL IsPhone()
{
	return [[UIDevice currentDevice] userInterfaceIdiom] == UIUserInterfaceIdiomPhone;
}

#if __has_include(<CoreHaptics/CoreHaptics.h>)

static void EnsureHapticEngine()
{
	if (@available(iOS 13.0, *))
	{
		if (!SupportsCoreHapticsInternal())
			return;

		if (s_hapticEngine != nil)
			return;

		NSError *error = nil;
		s_hapticEngine = [[CHHapticEngine alloc] initAndReturnError:&error];

		if (error != nil || s_hapticEngine == nil)
		{
			NSLog(@"Core Haptics engine init failed: %@", error);
			s_hapticEngine = nil;
			return;
		}

		s_hapticEngine.resetHandler = ^
		{
			NSError *startError = nil;
			[s_hapticEngine startAndReturnError:&startError];

			if (startError != nil)
				NSLog(@"Core Haptics engine restart failed: %@", startError);
		};
	}
}

static void StartEngineIfNeeded()
{
	if (@available(iOS 13.0, *))
	{
		EnsureHapticEngine();

		if (s_hapticEngine == nil)
			return;

		NSError *error = nil;
		[s_hapticEngine startAndReturnError:&error];

		if (error != nil)
			NSLog(@"Core Haptics engine start failed: %@", error);
	}
}

static void StopCurrentPlayer()
{
	if (@available(iOS 13.0, *))
	{
		if (s_currentPlayer == nil)
			return;

		NSError *error = nil;
		[s_currentPlayer stopAtTime:0 error:&error];

		if (error != nil)
			NSLog(@"Core Haptics player stop failed: %@", error);

		s_currentPlayer = nil;
	}
}

static void PlayCoreHaptic(float force, float duration)
{
	if (@available(iOS 13.0, *))
	{
		if (!SupportsCoreHapticsInternal())
			return;

		StartEngineIfNeeded();

		if (s_hapticEngine == nil)
			return;

		StopCurrentPlayer();

		float intensity = Clamp01(force);
		float sharpness = 0.5f;
		double hapticDuration = MAX(0.001, duration);

		CHHapticEventParameter *intensityParameter =
			[[CHHapticEventParameter alloc] initWithParameterID:CHHapticEventParameterIDHapticIntensity
														  value:intensity];

		CHHapticEventParameter *sharpnessParameter =
			[[CHHapticEventParameter alloc] initWithParameterID:CHHapticEventParameterIDHapticSharpness
														  value:sharpness];

		CHHapticEvent *event =
			[[CHHapticEvent alloc] initWithEventType:CHHapticEventTypeHapticContinuous
										  parameters:@[intensityParameter, sharpnessParameter]
										relativeTime:0
											duration:hapticDuration];

		NSError *patternError = nil;
		CHHapticPattern *pattern =
			[[CHHapticPattern alloc] initWithEvents:@[event]
										 parameters:@[]
											  error:&patternError];

		if (patternError != nil || pattern == nil)
		{
			NSLog(@"Core Haptics pattern creation failed: %@", patternError);
			return;
		}

		NSError *playerError = nil;
		s_currentPlayer = [s_hapticEngine createPlayerWithPattern:pattern error:&playerError];

		if (playerError != nil || s_currentPlayer == nil)
		{
			NSLog(@"Core Haptics player creation failed: %@", playerError);
			return;
		}

		NSError *startError = nil;
		[s_currentPlayer startAtTime:0 error:&startError];

		if (startError != nil)
			NSLog(@"Core Haptics player start failed: %@", startError);
	}
}

#endif

static void PlayFallback(float force)
{
	float normalizedForce = Clamp01(force);

	if (@available(iOS 13.0, *))
	{
		UIImpactFeedbackGenerator *generator;

		if (normalizedForce < 0.35f)
		{
			generator = [[UIImpactFeedbackGenerator alloc] initWithStyle:UIImpactFeedbackStyleLight];
		}
		else if (normalizedForce < 0.75f)
		{
			generator = [[UIImpactFeedbackGenerator alloc] initWithStyle:UIImpactFeedbackStyleMedium];
		}
		else
		{
			generator = [[UIImpactFeedbackGenerator alloc] initWithStyle:UIImpactFeedbackStyleHeavy];
		}

		[generator prepare];
		[generator impactOccurredWithIntensity:normalizedForce];
		return;
	}

	AudioServicesPlaySystemSound(kSystemSoundID_Vibrate);
}

extern "C"
{
	void NativeInit()
	{
#if __has_include(<CoreHaptics/CoreHaptics.h>)
		if (@available(iOS 13.0, *))
		{
			EnsureHapticEngine();
		}
#endif
	}

	int NativeIsSupported()
	{
		if (SupportsCoreHapticsInternal())
			return 1;

		if (IsPhone())
			return 1;

		return 0;
	}

	int NativeSupportsCoreHaptics()
	{
		return SupportsCoreHapticsInternal() ? 1 : 0;
	}

	void NativeVibrate(float force, float duration)
	{
		float normalizedForce = Clamp01(force);

		if (normalizedForce <= 0.0f || duration <= 0.0f)
		{
			NativeCancel();
			return;
		}

#if __has_include(<CoreHaptics/CoreHaptics.h>)
		if (SupportsCoreHapticsInternal())
		{
			PlayCoreHaptic(normalizedForce, duration);
			return;
		}
#endif

		PlayFallback(normalizedForce);
	}

	void NativeCancel()
	{
#if __has_include(<CoreHaptics/CoreHaptics.h>)
		if (@available(iOS 13.0, *))
		{
			StopCurrentPlayer();
		}
#endif
	}
}