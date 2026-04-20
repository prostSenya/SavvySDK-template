#import <UIKit/UIKit.h>

extern "C" {
    void MyVibrate(int type) {
        UIImpactFeedbackGenerator *gen = [[UIImpactFeedbackGenerator alloc]
            initWithStyle:UIImpactFeedbackStyleMedium];
        [gen impactOccurred];
    }
}