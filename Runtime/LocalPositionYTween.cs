using ElRaccoone.Tweens.Core;
using UnityEngine;

namespace ElRaccoone.Tweens {
  public static class LocalPositionYTween {
    public static Tween<float> TweenLocalPositionY (this Component self, float to, float duration) =>
      Tween<float>.Add<Driver> (self).Finalize (to, duration);

    public static Tween<float> TweenLocalPositionY (this GameObject self, float to, float duration) =>
      Tween<float>.Add<Driver> (self).Finalize (to, duration);

    private class Driver : Tween<float, Transform> {
      private Vector3 localPosition;

      public override float OnGetFrom () {
        return this.transform.localPosition.y;
      }

      public override void OnUpdate (float easedTime) {
        this.localPosition = this.transform.localPosition;
        this.valueCurrent = this.InterpolateValue (this.valueFrom, this.valueTo, easedTime);
        this.localPosition.y = this.valueCurrent;
        this.transform.localPosition = this.localPosition;
      }
    }
  }
}